using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Price_for_transportation.Model
{
    internal class Fee
    {
        public Fee(double initiationFee, double dailyRate, double nightRate)
        {
            InitiationFee = initiationFee;
            DailyRate = dailyRate;
            NightRate = nightRate;
        }

        public double InitiationFee { get; set; }
        public double DailyRate { get; set; }
        public double NightRate { get; set; }
    }
}
