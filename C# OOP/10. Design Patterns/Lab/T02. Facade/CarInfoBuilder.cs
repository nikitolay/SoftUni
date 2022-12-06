using System;
using System.Collections.Generic;
using System.Text;

namespace T02._Facade
{
    public class CarInfoBuilder : CarBuilderFacade
    {
        public CarInfoBuilder(Car car)
        {
            Car = car;
        }
        public CarInfoBuilder WithType(string type)
        {
            Car.Type = type;
            return this;
        }
    }
}
