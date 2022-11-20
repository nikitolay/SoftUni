using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {

        private ICollection<Car> Cars;
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Cars = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => Cars.Count;
        public void Add(Car car)
        {
            if (Cars.Count < Capacity)
            {
                Cars.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = Cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (carToRemove == null)
            {
                return false;
            }
            Cars.Remove(carToRemove);
            return true;
        }
        public Car GetLatestCar()
        {
            Car car = Cars.OrderByDescending(x => x.Year).FirstOrDefault();
            return car;
        }
        public Car GetCar(string manufacturer, string model)
        {
            Car car = Cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return car;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in Cars)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString();
        }
    }
}
