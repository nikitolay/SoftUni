using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new FootballBettingContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}