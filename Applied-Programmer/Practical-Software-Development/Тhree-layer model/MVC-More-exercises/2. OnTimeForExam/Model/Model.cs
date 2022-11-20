using System;
using System.Collections.Generic;
using System.Text;

namespace _2._OnTimeForExam.Model
{
    public class Model
    {
        private DateTime startTime;
        private DateTime arrivalTime;

        public Model(int startHour, int startMinutes, int arrivalHour, int arrivalMinutes)
        {
            StartHour = startHour;
            StartMinutes = startMinutes;
            ArrivalHour = arrivalHour;
            ArrivalMinutes = arrivalMinutes;

            startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startHour, startMinutes, 0);
            arrivalTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, arrivalHour, arrivalMinutes, 0);
        }
        private int startHour;

        public int StartHour
        {
            get
            {
                return startHour;
            }
            set
            {
                if (value >= 0 && value <= 23)
                {
                    startHour = value;

                }
                else
                {
                    throw new Exception("Incorrect Start Hour Input");
                }
            }
        }

        private int startMinutes;

        public int StartMinutes
        {
            get
            {
                return startMinutes;
            }
            set
            {
                if (value >= 0 && value <= 59)
                {
                    startHour = value;

                }
                else
                {
                    throw new Exception("Incorrect Start Minutes Input");
                }
            }
        }

        private int arrivalHour;

        public int ArrivalHour
        {
            get
            {
                return arrivalHour;
            }
            set
            {
                if (value >= 0 && value <= 23)
                {
                    startHour = value;

                }
                else
                {
                    throw new Exception("Incorrect Arrival Hour Input");
                }
            }
        }

        private int arrivalMinutes;

        public int ArrivalMinutes
        {
            get
            {
                return arrivalMinutes;
            }
            set
            {
                if (value >= 0 && value <= 59)
                {
                    startHour = value;

                }
                else
                {
                    throw new Exception("Incorrect Arrival Minutes Input");
                }
            }
        }

        public string Calculate()
        {
            string result = string.Empty;
            int diffHours = (startTime - arrivalTime).Hours;
            int diffMinutes = (startTime - arrivalTime).Minutes;
            string append = string.Empty;
            if (DateTime.Compare(arrivalTime, startTime) <= 0)
            {
                if (diffMinutes <= 30 && diffHours == 0)
                {
                    result += "On time\n";
                }
                else
                {
                    result += "Early\n";
                }

                if (diffMinutes < 10)
                {
                    append = "0";
                }
                if (diffMinutes > 0 && diffHours == 0)
                {
                    result += $"{append}{diffMinutes} minutes before the start";

                }
                else if (diffHours > 0)
                    result += $"{diffHours}:{append}{diffMinutes} hours before the start";
            }
            else
            {
                result += "Late\n";
                if (diffMinutes < 10) append = "0";
                if (diffMinutes > 0 && diffHours == 0)
                {
                    result += $"{append}{diffMinutes} minutes after  the start";
                }
                else result += $"{diffHours}:{append}{diffMinutes} hours after  the start";
            }
            return result;
        }
    }
}
