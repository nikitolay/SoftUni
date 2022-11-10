using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMVC.Views;
using Implement_an_mvc_program.Model;

namespace ConsoleMVC.Controllers
{
    internal class TipCalculatorController
    {
        private Tip tip;
        private Display display;
        public TipCalculatorController()
        {
            display = new Display();
            tip = new Tip(display.Amount, display.Percent);
            display.TipAmount = tip.CalculateTip();
            display.Total = tip.CalculateTotal();
            display.ShowTipAndTotal();
        }
    }
}
