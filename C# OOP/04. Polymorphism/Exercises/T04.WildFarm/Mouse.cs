using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten, livingRegion)
        {
            weightGain = 0.10;
        }

        public override string AskForFood() => "Squeak";

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                FoodEaten += food.Quantity;
                Weight += weightGain * food.Quantity;
                return;
            }
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
