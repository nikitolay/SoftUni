
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.XMLHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<CarDealerProfile>();
            });


            CarDealerContext db = new CarDealerContext();
            // db.Database.EnsureDeleted();
            // db.Database.EnsureCreated();

            //ex. 9
            // var xml = File.ReadAllText("../../../Datasets/suppliers.xml");
            // Console.WriteLine(ImportSuppliers(db, xml));
            //ex. 10
            //var xml = File.ReadAllText("../../../Datasets/parts.xml");
            //Console.WriteLine(ImportParts(db, xml));
            //ex. 11
            //var xml = File.ReadAllText("../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(db, xml));
            //ex. 12
            //var xml = File.ReadAllText("../../../Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(db, xml));
            //ex. 13
            //var xml = File.ReadAllText("../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(db, xml));

            Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }

        //ex. 9
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {


            var xmlSerializer =
                new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));

            var suppliersDto = (SupplierInputModel[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();
            foreach (var supplierDto in suppliersDto)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }
            context.Suppliers.AddRange(suppliers);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        //ex. 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute("Parts"));
            var partsDto = (PartInputModel[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Part> parts = new List<Part>();

            foreach (var partDto in partsDto)
            {
                var supplier = context.Suppliers.Find(partDto.SupplierId);

                if (supplier != null)
                {
                    var part = Mapper.Map<Part>(partDto);
                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }
        //ex. 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CarInputModel[]), new XmlRootAttribute("Cars"));
            var carsDto = (CarInputModel[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var cars = new List<Car>();

            foreach (var carDto in carsDto.Distinct())
            {
                var car = Mapper.Map<Car>(carDto);
                context.Cars.Add(car);

                foreach (var part in carDto.Parts.PartsId)
                {
                    if (car.PartCars.All(p => p.PartId != part.PartId
                    && context.Parts.Find(part.PartId) != null))
                    {

                        var partCar = new PartCar
                        {
                            CarId = car.Id,
                            PartId = part.PartId,
                        };

                        car.PartCars.Add(partCar);

                    }
                }
                cars.Add(car);
            }

            int count = context.SaveChanges();
            return $"Successfully imported {count}";

        }

        //ex. 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Customers";

            var customersDto = XMLConverter.Deserializer<CustomerInputModel>(inputXml, rootElement);

            var customers = Mapper.Map<IEnumerable<Customer>>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }
        //ex. 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Sales";

            var allSales = context.Sales.Select(x => x.Id).ToList();

            var salesDto = XMLConverter.Deserializer<SaleInputModel>(inputXml, rootElement)
                .Where(x => context.Cars.Any(y => y.Id == x.CarId));


            var sales = Mapper.Map<IEnumerable<Sale>>(salesDto);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }
        //ex. 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            const string rootElement = "cars";

            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .Select(x => new CarsWithDistanceDto
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToList();

            string xml = XMLConverter.Serialize(cars, rootElement);

            return xml;
        }
        //ex. 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            const string rootElement = "cars";

            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new ExportCarsBMWDto
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            string xml = XMLConverter.Serialize(cars, rootElement);

            return xml;
        }
        //ex. 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            const string rootElement = "suppliers";

            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new LocalSuppliersDto
                {

                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToList();

            var xml = XMLConverter.Serialize(suppliers, rootElement);

            return xml;
        }
        //ex. 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            const string rootElement = "cars";
            var cars = context.Cars
                .Select(x => new ExportCarsWithPartsDto
                {

                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(y => new ExportCarPartsDto
                    {
                        Name = y.Part.Name,
                        Price = y.Part.Price,
                    })
                    .OrderByDescending(p => p.Price)
                    .ToList()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToList();

            var xml = XMLConverter.Serialize(cars, rootElement);

            return xml;
        }
        //ex. 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            const string rootElement = "customers";

            var customers = context.Customers
                .Where(x => x.Sales.Any(x => x.Car != null))
                .Select(x => new TotalSalesByCustomerDto
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count(),
                    SpentMoney = x.Sales.SelectMany(p => p.Car.PartCars)
                                        .Sum(c => c.Part.Price)

                })
                .OrderByDescending(x => x.SpentMoney)
                .ToList();

            var xml = XMLConverter.Serialize(customers, rootElement);

            return xml;
        }
        //ex. 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            const string rootElement = "sales";

            var sales = context.Sales
                .Select(x => new SalesWithAppliedDiscountDto
                {
                    Car = new SaleCarsInfoDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance,
                    },
                    CustomerName = x.Customer.Name,
                    Discount = x.Discount,
                    Price = x.Car.PartCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = x.Car.PartCars.Sum(p => p.Part.Price)
                    - x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100
                })
                .ToList();

            var xml = XMLConverter.Serialize(sales, rootElement);

            return xml;
        }
    }
}