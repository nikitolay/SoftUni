using System;
using System.Collections.Generic;
using System.Text;

namespace T01.Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public void Drive(double distance);
        public void ReFuel(double fuel);
    }
}
