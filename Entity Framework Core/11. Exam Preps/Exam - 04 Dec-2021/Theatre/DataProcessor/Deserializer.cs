namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(PlayImportModel[]),
                new XmlRootAttribute("Plays"));

            var playsDto = (PlayImportModel[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var plays = new List<Play>();

            foreach (var playDto in playsDto)
            {
                var duration = TimeSpan.ParseExact(playDto.Duration, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);

                var isEnumValid = Enum.TryParse(playDto.Genre, out Genre playGenre);

                if (!IsValid(playDto) || !isEnumValid || duration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = playGenre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter,
                };
                plays.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CastImportModel[]), new XmlRootAttribute("Casts"));
            var castsDto = (CastImportModel[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var casts = new List<Cast>();

            foreach (var castDto in castsDto)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var cast = new Cast
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId,
                };
                casts.Add(cast);
                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter ? "main" : "lesser"));
            }
            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var theatersDto = JsonConvert.DeserializeObject<IEnumerable<ProjectionImportModel>>(jsonString);

            var theatres = new List<Theatre>();

            foreach (var theaterDto in theatersDto)
            {
                if (!IsValid(theaterDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theatre = new Theatre
                {
                    Name = theaterDto.Name,
                    NumberOfHalls = theaterDto.NumberOfHalls,
                    Director = theaterDto.Director,
                };

                foreach (var ticketDto in theaterDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var ticket = new Ticket
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId,
                    };

                    theatre.Tickets.Add(ticket);
                }
                theatres.Add(theatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count()));
            }
            context.Theatres.AddRange(theatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
