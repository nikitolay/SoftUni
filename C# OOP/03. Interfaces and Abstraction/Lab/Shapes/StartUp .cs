using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            var radius = int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(radius);

            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            IDrawable recta = new Rectangle(width, height);

            circle.Draw();
            recta.Draw(); ;

        }
    }
}
