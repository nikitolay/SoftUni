using _2._OnTimeForExam.View;
using _2._OnTimeForExam.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2._OnTimeForExam.Controllers
{
    public class Controller
    {
        private Display display;
        private Model.Model model;
        public Controller()
        {
            display = new Display();
            while (model is null)
            {
                try
                {
                    display.Input();
                    model = new Model.Model
                   (
                        display.StartHour,
                        display.StartMinutes,
                        display.ArrivalHour,
                        display.ArrivalMinutes
                   );
                }
                catch (Exception e)
                {
                    display.Response = e.Message;
                    display.Output();
                }
            }
            display.Response = model.Calculate();
            display.Output();
        }
    }
}
