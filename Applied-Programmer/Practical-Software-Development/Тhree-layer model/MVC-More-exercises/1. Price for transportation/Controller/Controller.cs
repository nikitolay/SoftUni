
using _1._Price_for_transportation.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Price_for_transportation.Controller
{
    public class Controller
    {
        private Display display;
        private Model.Model model;

        public Controller()
        {
            display = new Display();
            model = new Model.Model(display.kilometers, display.time);
            display.totalPrice = model.CalculatePrice();
            display.ShowCheapestWayToTravel();
        }

    }
}

