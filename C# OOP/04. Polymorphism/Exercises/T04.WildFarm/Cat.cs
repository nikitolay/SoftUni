using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion, breed)
        {
            weightGain = 0.30;
        }

        public override string AskForFood() => "Meow";

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * weightGain;
                return;
            }
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
