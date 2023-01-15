namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .AsEnumerable()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count() >= 20)
                .Select(x => new TheatreExportModel
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets
                        .Where(p => p.RowNumber >= 1 && p.RowNumber <= 5)
                        .Select(y => y.Price)
                        .Sum(),
                    Tickets = x.Tickets
                    .Where(p => p.RowNumber >= 1 && p.RowNumber <= 5)
                    .Select(c => new TicketExportModel
                    {
                        Price = decimal.Parse(c.Price.ToString("f2")),
                        RowNumber = c.RowNumber,
                    })
                    .OrderByDescending(x => x.Price)
                    .ToArray()

                })
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name);

            var json = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return json;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .AsEnumerable()
                 .Where(x => x.Rating <= rating)
                 .Select(x => new PlayExportModel
                 {
                     Title = x.Title,
                     Duration = x.Duration.ToString("c"),
                     Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                     Genre = x.Genre.ToString(),
                     Actors = x.Casts.Where(v => v.IsMainCharacter)
                       .Select(y => new ActorExportModel
                       {
                           FullName = y.FullName,
                           MainCharacter = $"Plays main character in '{y.Play.Title}'."
                       })
                       .OrderByDescending(x => x.FullName)
                       .ToArray()
                 })
                 .OrderBy(x => x.Title)
                 .ThenByDescending(x => x.Genre)
                 .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayExportModel[]), new XmlRootAttribute("Plays"));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            using var sw = new StringWriter();
            xmlSerializer.Serialize(sw, plays, ns);

            return sw.ToString();
        }
    }
}
