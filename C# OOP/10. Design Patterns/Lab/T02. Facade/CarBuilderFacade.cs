using System;
using System.Collections.Generic;
using System.Text;

namespace T02._Facade
{
    public class CarBuilderFacade
    {
        protected Car Car { get; set; }
        public CarBuilderFacade()
        {
            Car = new Car();
        }
        public Car Build() => Car;
    }
}
