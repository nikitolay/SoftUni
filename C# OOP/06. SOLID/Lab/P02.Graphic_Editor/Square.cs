using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Square : IShape
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("I'm Square");

        }
    }
}
