using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    class Parking
    {
        public Parking(int capacity)
        {
            Cars = new List<Car>();
            Capacity = capacity;
        }
        public List<Car> Cars { get; set; }
        public int Count  => Cars.Count();
        public int Capacity { get; set; }

        public string AddCar(Car car)
        {
            if (Cars.Contains(car))
            {
                return "Car with that registration number, already exists!";
            }
            else if (Cars.Count > Capacity)
            {
                return "Parking is full!";
            }
            else
            {
                Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            if (!Cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car currentCar = Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
                Cars.Remove(currentCar);
                return $"Successfully removed {registrationNumber}";
            }
        }
        public Car GetCar(string registrationNumber)
        {

            return Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {

        }
    }
}
