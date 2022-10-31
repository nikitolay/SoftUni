using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Store_Boxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            while (true)
            {
                string[] arr = Console.ReadLine().Split();
                if (arr[0] == "end")
                {
                    break;
                }
                int serialNumber = int.Parse(arr[0]);
                string itemName = arr[1];
                int itemQuantity = int.Parse(arr[2]);
                decimal itemPrice = decimal.Parse(arr[3]);
                decimal boxPrice = itemQuantity * itemPrice;
                Item item = new Item(itemName, itemPrice);
                Box box = new Box(serialNumber, item, itemQuantity, boxPrice);
                boxes.Add(box);
            }
            foreach (var box in boxes.OrderByDescending(x => x.Price))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.Price:f2}");
            }
        }
    }
    public class Item
    {
        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class Box
    {
        public Box(int serialNumber, Item item, int itemQuantity, decimal price)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = itemQuantity;
            Price = price;
        }

        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal Price { get; set; }
    }


}
