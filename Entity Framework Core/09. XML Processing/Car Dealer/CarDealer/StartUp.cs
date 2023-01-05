
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
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
    }
}