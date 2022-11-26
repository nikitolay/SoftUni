using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten)
        {
            WingSize = wingSize;
        }
        public double WingSize { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
