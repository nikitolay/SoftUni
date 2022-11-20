using System;
using System.Collections.Generic;
using System.Text;

namespace _2._OnTimeForExam.View
{
    public class Display
    {
        public int StartHour { get; set; }
        public int StartMinutes { get; set; }
        public int ArrivalHour { get; set; }
        public int ArrivalMinutes { get; set; }
        public string Response { get; set; }

        public Display()
        {
            StartHour = 0;
            StartMinutes = 0;
            ArrivalHour = 0;
            ArrivalMinutes = 0;
        }

        public void Input()
        {
            Console.Write("Enter the exam hour start: ");
            StartHour = int.Parse(Console.ReadLine());

            Console.Write("Enter the exam minutes start: ");
            StartMinutes = int.Parse(Console.ReadLine());

            Console.Write("Enter arrival hour: ");
            ArrivalHour = int.Parse(Console.ReadLine());

            Console.Write("Enter arrival minutes: ");
            ArrivalMinutes = int.Parse(Console.ReadLine());
        }
        public void Output()
        {
            Console.WriteLine(Response);
        }
    }
}
