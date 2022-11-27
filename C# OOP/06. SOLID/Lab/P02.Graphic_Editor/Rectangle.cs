using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Rectangle : IShape
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("I'm Recangle");

        }
    }
}
