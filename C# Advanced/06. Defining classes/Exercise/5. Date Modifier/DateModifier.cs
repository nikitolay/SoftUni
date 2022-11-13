using System;
using System.Collections.Generic;
using System.Text;

namespace _5._Date_Modifier
{
    public class DateModifier
    {
        public DateModifier(DateTime firstDate, DateTime secondtDate)
        {
            FirstDate = firstDate;
            SecondtDate = secondtDate;
        }

        public DateTime FirstDate { get; set; }
        public DateTime SecondtDate { get; set; }
        public int DifferenceInDay()
        {

            int difference = Math.Abs((FirstDate - SecondtDate).Days);
            return difference;
        }
    }
}
