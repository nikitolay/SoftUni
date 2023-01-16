namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var games = context.Genres
                .ToList()
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    x.Id,
                    Genre = x.Name,
                    Games = x.Games
                    .Select(y => new
                    {
                        y.Id,
                        Title = y.Name,
                        Developer = y.Developer.Name,
                        Tags = string.Join(", ", y.GameTags.Select(p => p.Tag.Name)),
                        Players = y.Purchases.Count()
                    })
                    .Where(d => d.Players > 0)
                    .OrderByDescending(d => d.Players)
                    .ThenBy(d => d.Id),
                    TotalPlayers = x.Games.Sum(v => v.Purchases.Count())
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id);

            var json = JsonConvert.SerializeObject(games, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var users = context.Users
                .AsEnumerable()
                .Where(x => x.Cards.Any(x => x.Purchases.Count() > 0))
                .Where(x => x.Cards.Any(y => y.Purchases.Any(k => k.Type.ToString() == storeType)))
                .Select(x => new UserExportModel
                {
                    Username = x.Username,
                    Purchases = x.Cards
                             .SelectMany(c => c.Purchases)
                             //.Where(c => c.Type.ToString() == storeType)
                             .Select(c => new PurchaseExportModel
                             {
                                 Card = c.Card.Number,
                                 Cvc = c.Card.Cvc,
                                 Date = c.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                                 Game = new GameExportModel
                                 {
                                     Title = c.Game.Name,
                                     Genre = c.Game.Genre.Name,
                                     Price = c.Game.Price,
                                 }
                             })
                             .OrderBy(c => c.Date)
                             .ToArray(),
                    TotalSpent =x.Cards.SelectMany(c=>c.Purchases).Select(g=>g.Game.Price).Sum()
                })
                .OrderByDescending(x=>x.TotalSpent)
                .ThenBy(x=>x.Username)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserExportModel[]), new XmlRootAttribute("Users"));
            var sw = new StringWriter();
            var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(sw, users, ns);

            return sw.ToString();
        }
    }
}