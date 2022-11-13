using System;
using System.Collections.Generic;
using System.Text;

namespace _8._Car_Salesman
{
    internal class Car
    {
        public Car(string model, Engine engine, int weight = 0, string color = "")
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }//
        public string Color { get; set; }//
        string defaultString = "n/a";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.Power}");
            if (Engine.Displacement != 0)
            {
                sb.AppendLine($"    Displacement: {Engine.Displacement}");
            }
            else
            {
                sb.AppendLine($"    Displacement: {defaultString}");

            }
            if (Engine.Efficiency != "")
            {
                sb.AppendLine($"    Efficiency: {Engine.Efficiency}");
            }
            else
            {
                sb.AppendLine($"    Efficiency: {defaultString}");

            }
            if (Weight != 0)
            {
                sb.AppendLine($"  Weight: {Weight}");

            }
            else
            {
                sb.AppendLine($"  Weight: {defaultString}");

            }
            if (Color != "")
            {
                sb.AppendLine($"  Color: {Color}");
            }
            else
            {
                sb.AppendLine($"  Color: {defaultString}");
            }
            return sb.ToString();
        }
    }
}
