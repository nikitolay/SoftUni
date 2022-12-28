namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            int input = int.Parse(Console.ReadLine());

            Console.WriteLine(ExportSongsAboveDuration(context, input));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {

            StringBuilder result = new StringBuilder();

            var albums = context.Producers
                .FirstOrDefault(x => x.Id == producerId)
                .Albums
                .Select(x => new
                {
                    x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs.Select(x => new
                    {
                        SongName = x.Name,
                        Price = x.Price,
                        SongWriterName = x.Writer.Name
                    }).OrderByDescending(x => x.SongName)
                    .ThenBy(x => x.SongWriterName),
                    AlbumPrice = x.Price
                }).OrderByDescending(x => x.AlbumPrice);

            foreach (var album in albums)
            {
                result.AppendLine($"-AlbumName: {album.Name}");
                result.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                result.AppendLine($"-ProducerName: {album.ProducerName}");

                int count = 1;
                foreach (var song in album.Songs)
                {
                    result.AppendLine("-Songs:");
                    result.AppendLine($"---#{count++}");
                    result.AppendLine($"---SongName: {song.SongName}");
                    result.AppendLine($"---Price: {song.Price:f2}");
                    result.AppendLine($"---Writer: {song.SongWriterName}");

                }
                result.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }


            return result.ToString();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder result = new StringBuilder();

            var songs = context.Songs
                .ToList()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new
                {
                    x.Name,
                    PerformerFullName = x.SongPerformers
                    .Select(x => $"{x.Performer.FirstName} {x.Performer.LastName}").FirstOrDefault(),
                    WriterName = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    x.Duration
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.WriterName)
                .ThenBy(x => x.PerformerFullName)
                .ToList();

            int count = 1;
            foreach (var song in songs)
            {
                result.AppendLine($"-Song #{count++}");
                result.AppendLine($"---SongName: {song.Name}");
                result.AppendLine($"---Writer: {song.WriterName}");
                result.AppendLine($"---Performer: {song.PerformerFullName}");
                result.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                result.AppendLine($"---Duration: {song.Duration}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
