﻿using System;
using System.Collections.Generic;
using System.Text;

namespace T03.Template_Pattern
{
    internal class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdough Bread. (20 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for Sourdough Bread.");
        }
    }
}
