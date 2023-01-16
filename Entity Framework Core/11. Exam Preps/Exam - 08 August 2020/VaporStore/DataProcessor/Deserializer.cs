namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var gamesDto = JsonConvert.DeserializeObject<GameImportModel[]>(jsonString);

            foreach (var gameDto in gamesDto)
            {
                var tagsDtoCount = gameDto.Tags.Count();
                if (!IsValid(gameDto) || tagsDtoCount == 0)
                {
                    sb.AppendLine("Invalid Data");  
                    continue;
                }

                var genre = context.Genres.FirstOrDefault(x => x.Name == gameDto.Genre)
                    ?? new Genre { Name = gameDto.Genre };
                var developer = context.Developers.FirstOrDefault(x => x.Name == gameDto.Developer)
                    ?? new Developer { Name = gameDto.Developer };

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate.Value,
                    Developer = developer,
                    Genre = genre,
                };

                foreach (var tagDto in gameDto.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(x => x.Name == tagDto)
                        ?? new Tag { Name = tagDto };
                    game.GameTags.Add(new GameTag { Tag = tag });
                }

                sb.AppendLine($"Added {game.Name} ({gameDto.Genre}) with {game.GameTags.Count()} tags");
                context.Add(game);
                context.SaveChanges();
            }


            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var usersDto = JsonConvert.DeserializeObject<UserImportModel[]>(jsonString);

            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                if (!IsValid(userDto) || !IsValid(userDto.Cards))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    Cards = userDto.Cards.Select(x => new Card
                    {
                        Number = x.Number,
                        Cvc = x.Cvc,
                        Type = x.Type.Value
                    })
                    .ToArray()
                };
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count()} cards");
                users.Add(user);
            }
            context.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PurchaseImportModel[]), new XmlRootAttribute("Purchases"));
            var purchasesDto = (PurchaseImportModel[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var purchases = new List<Purchase>();
            foreach (var purchaseDto in purchasesDto)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = purchaseDto.Type.Value,
                    ProductKey = purchaseDto.Key,
                    Card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card),
                    Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Title)
                };
                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}"!);
                purchases.Add(purchase);
            }

            context.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}