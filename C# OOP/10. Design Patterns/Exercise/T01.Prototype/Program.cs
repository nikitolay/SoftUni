using System;

namespace T01.Prototype
{
    public class Program
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();
            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["PB&J"] = new Sandwich("White", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["Turkey"] = new Sandwich("Rye", "Bacon", "", "Lettuce, Tomato");


            sandwichMenu["Loaded"] = new Sandwich("Rye", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["ThereMeat"] = new Sandwich("Rye", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["Vegetaries"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");

            Sandwich sandwich1 = sandwichMenu["BLT"].Clone() as Sandwich;
            Sandwich sandwich2 = sandwichMenu["ThereMeat"].Clone() as Sandwich;
            Sandwich sandwich3 = sandwichMenu["Vegetaries"].Clone() as Sandwich;
        }
    }
}
