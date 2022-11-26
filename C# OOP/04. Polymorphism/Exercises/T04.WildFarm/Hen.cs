using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {
            weightGain = 0.35;

        }

        public override string AskForFood() => "Cluck";

        public override void Eat(Food food)
        {
            FoodEaten += food.Quantity;
            Weight += weightGain * food.Quantity;
        }
    }
}
