using _1._Price_for_transportation.Model;
using _1._Price_for_transportation.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Price_for_transportation.Controller
{
    internal class FeeDisplayController
    {
        private const double TAXI_INITIATION_FEE = 0.70;
        private const double BUS_INITIATION_FEE = 0.09;
        private const double TRAIN_INITIATION_FEE = 0.06;
        private Fee fee;
        private Display display;

        public FeeDisplayController()
        {

            display = new Display();
            // fee = new Fee();
        }

    }
}

