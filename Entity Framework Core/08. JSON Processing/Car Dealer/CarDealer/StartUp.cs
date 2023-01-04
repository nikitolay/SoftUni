using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Input;
using CarDealer.DTO.Output;
using CarDealer.Models;
using Castle.Core.Resource;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();

            // db.Database.EnsureDeleted();
            // db.Database.EnsureCreated();
            //ex. 9
            //var json = File.ReadAllText("../../../Datasets/suppliers.json");
            //ex. 10
            //var json = File.ReadAllText("../../../Datasets/parts.json");
            //ex. 11
            //var json = File.ReadAllText("../../../Datasets/cars.json");
            //ex. 12
            //var json = File.ReadAllText("../../../Datasets/customers.json");
            //ex. 13
            //var json = File.ReadAllText("../../../Datasets/sales.json");

            Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }
        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
            mapper = config.CreateMapper();
        }
        //ex. 9
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var dtoSuppliers = JsonConvert
                .DeserializeObject<IEnumerable<SupplierInputModel>>(inputJson);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(dtoSuppliers);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }
        //ex. 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var dtoParts = JsonConvert
                .DeserializeObject<IEnumerable<PartInputModel>>(inputJson)
                .Where(x => context.Suppliers.Any(y => y.Id == x.SupplierId));

            var parts = mapper.Map<IEnumerable<Part>>(dtoParts);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }
        //ex. 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {

            var dtoCars = JsonConvert.DeserializeObject<IEnumerable<CarInputModel>>(inputJson);

            var listOfCars = new List<Car>();

            foreach (var car in dtoCars)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance,
                };

                foreach (var part in car?.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = part
                    });
                }
                listOfCars.Add(currentCar);
            }

            context.Cars.AddRange(listOfCars);
            context.SaveChanges();


            return $"Successfully imported {listOfCars.Count()}.";
        }
        //ex. 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var dtoCustomers = JsonConvert.DeserializeObject<IEnumerable<CustomerInputModel>>(inputJson);

            var customers = mapper.Map<IEnumerable<Customer>>(dtoCustomers);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }
        //ex. 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var dtoSales = JsonConvert.DeserializeObject<IEnumerable<SaleInputModel>>(inputJson);

            var sales = mapper.Map<IEnumerable<Sale>>(dtoSales);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }
        //ex. 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    x.IsYoungDriver
                })
                .ToList();

            var resultJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return resultJson;
        }
        //ex. 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance,
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var resultJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return resultJson;
        }
        //ex. 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToList();

            var resultJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return resultJson;

        }
        //ex. 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new CarPartDto
                {
                    Car = new ExportCarDto
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance,
                    },
                    Parts = x.PartCars
                    .Select(p => new ExportPartDto
                    {
                        Name = p.Part.Name,
                        Price = $"{p.Part.Price:f2}",
                    }).ToList()
                }).ToList();

            var resultJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return resultJson;
        }
        //ex. 18

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Any())
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count(),
                    spentMoney = x.Sales
                               .SelectMany(s => s.Car.PartCars)
                               .Sum(p => p.Part.Price)

                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
            };

            var resultJson = JsonConvert.SerializeObject(customers, settings);

            return resultJson;

        }
        //ex 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new ExportSaleDiscountDto
                {
                    Car = new ExportCarDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance,
                    },
                    CustomerName = x.Customer.Name,
                    Discount = $"{x.Discount:F2}",
                    Price = x.Car.PartCars.Sum(y => y.Part.Price).ToString("f2"),
                    PriceWithDiscount = (x.Car.PartCars.Sum(y => y.Part.Price)
                    - x.Car.PartCars.Sum(y => y.Part.Price) * x.Discount / 100).ToString("f2"),

                })
                .ToList();

            var resultJson = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return resultJson;
        }
    }
}