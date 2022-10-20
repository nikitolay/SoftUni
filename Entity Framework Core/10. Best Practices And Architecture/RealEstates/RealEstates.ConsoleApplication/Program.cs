using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services;

namespace RealEstates.ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            // db.Database.Migrate();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Property Search");
                Console.WriteLine("2. Most expensive districts");
                Console.WriteLine("0. Exit");
                bool parsed = int.TryParse(Console.ReadLine(), out int option);

                if (parsed&&option==0) break;

                if (parsed && option >= 1 && option <= 2)
                {
                    switch (option)
                    {
                        case 1:
                            PropertySearch(db);
                            break;
                        case 2:
                            MostExpensiveDistricts(db);
                            break;
                    }
                    Console.WriteLine("Press any key to continue....");
                    Console.ReadKey();//ako napisha glupost me vrushta direktno da go pisha nanovo
                }
            }
        }

        private static void MostExpensiveDistricts(ApplicationDbContext db)
        {
            IDistrictsService districtService=new DistrictService(db);
           var districts= districtService.GetMostExpensiveDistricts(20);
            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name} => {district.AveragePricePerSquareMeter}EURO/m2{district.PropertiesCount} ");
            }
        }

        private static void PropertySearch(ApplicationDbContext db)
        {
            Console.WriteLine("Min price ");
            int minPrice=int.Parse(Console.ReadLine());

            Console.WriteLine("Max price ");
            int maxPrice = int.Parse(Console.ReadLine());

            Console.WriteLine("Min size ");
            int minSize = int.Parse(Console.ReadLine());

            Console.WriteLine("Max size ");
            int maxSize = int.Parse(Console.ReadLine());

            IPropertiesService service=new PropertiesService(db);
           var properties= service.Search(minPrice,maxPrice,minSize,maxSize);
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.DistrictName}; {property.BuildingType}; {property.PropertyType};   {property.Price} EURO;  => {property.Size}/m2");
            }
        }
    }
}