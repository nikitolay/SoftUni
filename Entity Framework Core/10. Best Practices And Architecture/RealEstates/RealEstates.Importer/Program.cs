using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RealEstates.Importer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ImportJsonFile("imot.bg-houses-Sofia-raw-data-2021-03-18.json");
            Console.WriteLine();
            ImportJsonFile("imot.bg-raw-data-2021-03-18.json");
            //propertiesService.Add();
        }
        public static void ImportJsonFile(string fileName)
        {
            var dbContext = new ApplicationDbContext();
            dbContext.Database.Migrate();
            IPropertiesService propertiesService = new PropertiesService(dbContext);

            var properties = JsonSerializer.Deserialize<IEnumerable<PropertyAsJson>>(File.ReadAllText(fileName));//vrushta kolekciq ot obekti

            foreach (var jsonProp in properties)
            {
                propertiesService.Add(jsonProp.District, jsonProp.Floor, jsonProp.TotalFloors, jsonProp.Size, jsonProp.YardSize, jsonProp.Year, jsonProp.Type, jsonProp.BuildingType, jsonProp.Price??0);
                 Console.Write(".");
            }
        }
    }
}