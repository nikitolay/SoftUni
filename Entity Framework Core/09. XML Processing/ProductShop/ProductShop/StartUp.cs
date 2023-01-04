using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ProductShopProfile>();
            });


            ProductShopContext db = new ProductShopContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //ex. 1
            // var xml = File.ReadAllText("../../../Datasets/users.xml");
            // Console.WriteLine(ImportUsers(db, xml));
            //ex. 2
            // var xml = File.ReadAllText("../../../Datasets/products.xml");
            // Console.WriteLine(ImportProducts(db, xml));
            //ex. 3
            // var xml = File.ReadAllText("../../../Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(db, xml));
            //ex. 4
            // var xml = File.ReadAllText("../../../Datasets/categories-products.xml");
            // Console.WriteLine(ImportCategoryProducts(db, xml));

            Console.WriteLine(GetUsersWithProducts(db));
        }
        //ex. 1
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(UserInputModel[]), new XmlRootAttribute("Users"));

            var usersDto = (UserInputModel[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var users = usersDto.Select(Mapper.Map<User>).ToList();

            context.Users.AddRange(users);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }
        //ex. 2
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ProductInputModel[]), new XmlRootAttribute("Products"));

            var productsDto = (ProductInputModel[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = productsDto.Select(Mapper.Map<Product>).ToList();

            context.Products.AddRange(products);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }
        //ex. 3
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryInputModel[]), new XmlRootAttribute("Categories"));

            var categoresDto = (CategoryInputModel[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = categoresDto.Select(Mapper.Map<Category>).ToList();

            context.Categories.AddRange(categories);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }
        //ex. 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer =
               new XmlSerializer(typeof(CategoryProductInputModel[]),
                   new XmlRootAttribute("CategoryProducts"));
            var categoryProductsDto =
                ((CategoryProductInputModel[])xmlSerializer.Deserialize(new StringReader(inputXml)))
                .ToList();

            var categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoryProductsDto)
            {
                var targetProduct = context.Products.Find(categoryProductDto.ProductId);
                var targetCategory = context.Categories.Find(categoryProductDto.CategoryId);

                if (targetProduct != null && targetCategory != null)
                {
                    var category = Mapper.Map<CategoryProduct>(categoryProductDto);
                    categoryProducts.Add(category);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";

        }
        //ex. 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .Select(x => new ProductInRangeDto
                {
                    Name = $"{x.Buyer.FirstName} {x.Buyer.LastName}",
                    Price = x.Price
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ProductInRangeDto[]), new XmlRootAttribute("Products"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }
        //ex. 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new GetSoldProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Products = u.ProductsSold.Select(p => new SoldProductDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                        .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(GetSoldProductsDto[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
        //ex. 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new GetCategoriesByProductsCountDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(GetCategoriesByProductsCountDto[]), new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }
        //ex. 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count() >= 1)
                .OrderByDescending(x => x.ProductsSold.Count())
                .Select(x => new GetUsersWithProductsDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new SoldProductsCountDto
                    {
                        Count = x.ProductsSold.Count(),
                        Products = x.ProductsSold
                        .Select(p => new SoldProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            var result = new UserAndProductsDto
            {
                Count = users.Count(),
                Users = users
            };


            var xmlSerializer = new XmlSerializer(typeof(UserAndProductsDto), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), result, namespaces);

            return sb.ToString().TrimEnd();

        }
    }
}