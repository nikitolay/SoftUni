using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Price_for_transportation.Model
{
    internal class Model
    {
        private int kilometers;
        private string time;
        private double startPrice;

        public Model(int kilometers, string time)
        {
            this.Kilometers = kilometers;
            this.Time = time;
        }
        public Model() : this(0, "")
        {

        }

        public int Kilometers
        {
            get { return kilometers; }
            set { kilometers = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public double StartPrice
        {
            get { return startPrice; }
            set { startPrice = value; }
        }
        public double CalculateCheapest()
        {
            double pricePerKm = 0;
            if (Kilometers < 20)
            {
                StartPrice = 0.70;
                if (Time == "day")
                {
                    pricePerKm = 0.79;
                }
                else
                {
                    pricePerKm = 0.90;
                }
            }
            else if (Kilometers >= 20 && Kilometers <= 100)
            {
                startPrice = 0;
                pricePerKm = 0.09;
            }
            else
            {
                startPrice = 0;
                pricePerKm = 0.06;
            }
            return pricePerKm;
        }
        public double CalculatePrice()
        {
            return CalculateCheapest() * Kilometers + startPrice;
        }
    }
}
