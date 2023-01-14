namespace Footballers.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context.Coaches.AsEnumerable()
                .Where(x => x.Footballers.Any())
                .Select(x => new CoachExportModel
                {
                    CoachName = x.Name,
                    FootballersCount = x.Footballers.Count(),
                    Footballers = x.Footballers.Select(y => new FootballerExportModel
                    {
                        Name = y.Name,
                        Position = y.PositionType.ToString(),
                    })
                    .OrderBy(x => x.Name)
                    .ToArray()
                })
                .OrderByDescending(x => x.FootballersCount)
                .ThenBy(x => x.CoachName)
                .ToArray();

            using (StringWriter stringwriter = new StringWriter())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(CoachExportModel[]), new XmlRootAttribute("Coaches"));
                var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                xmlSerializer.Serialize(stringwriter, coaches, ns);
                return stringwriter.ToString();
            }

        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {

            var teams = context.Teams.AsEnumerable()
                  .Where(x => x.TeamsFootballers.Any(x => x.Footballer.ContractStartDate >= date))
                  .Select(x => new
                  {
                      Name = x.Name,
                      Footballers = x.TeamsFootballers.Where(c => c.Footballer.ContractStartDate >= date)
                      .OrderByDescending(c => c.Footballer.ContractEndDate)
                      .ThenBy(c => c.Footballer.Name)
                      .Select(y => new
                      {
                          FootballerName = y.Footballer.Name,
                          ContractStartDate = y.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                          ContractEndDate = y.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                          BestSkillType = y.Footballer.BestSkillType.ToString(),
                          PositionType = y.Footballer.PositionType.ToString()
                      })
                  })
                  .OrderByDescending(x => x.Footballers.Count())
                  .ThenBy(x => x.Name)
                  .Take(5)
                  .ToList();

            var json = JsonConvert.SerializeObject(teams, Formatting.Indented);

            return json;

        }
    }
}
