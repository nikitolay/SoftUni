using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Price_for_transportation.View
{
    public class Display
    {
        public int Km { get; set; }
        public string Day { get; set; }
        public double TheLowestPrice { get; set; }
        private void GetValues()
        {
            this.Km = int.Parse(Console.ReadLine());
            this.Day = Console.ReadLine();
        }
        public void ShowTheLowestPrice()
        {
            Console.WriteLine(TheLowestPrice);
        }
    }
}
