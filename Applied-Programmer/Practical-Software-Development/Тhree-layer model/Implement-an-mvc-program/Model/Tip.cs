using System;
using System.Collections.Generic;
using System.Text;

namespace Implement_an_mvc_program.Model
{
    public class Tip
    {
        private double amount;
        private double percent;

        public Tip(double amount, double percent)
        {
            Amount = amount;
            Percent = percent;
        }
        public Tip() : this(0, 0) { }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public double Percent
        {
            get { return percent; }
            set
            {
                if (value > 1)
                {
                    percent = value / 100.0;

                }
                else
                {

                    percent = value;
                }
            }
        }
        public double CalculateTip()
        {
            return Amount * Percent;
        }
        public double CalculateTotal()
        {
            return CalculateTip() + Amount;
        }

    }
}
