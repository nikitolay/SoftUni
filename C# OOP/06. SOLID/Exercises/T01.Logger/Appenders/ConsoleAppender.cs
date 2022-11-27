using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T01.Logger.Appenders.Interfaces;
using T01.Logger.Enumerations;
using T01.Logger.Layouts.Interfaces;

namespace T01.Logger.Appenders
{
    public class ConsoleAppender : Appender
    {

        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string date, ReportLevel level, string message)
        {
            if (ReportLevel <= level)
            {
                MessagesCount++;
                Console.WriteLine(string.Format(Layout.Format, date, level, message));
            }
        }

    }
}
