using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T01.Logger.Appenders;
using T01.Logger.Appenders.Interfaces;
using T01.Logger.Layouts.Interfaces;
using T01.Logger.Loggers;

namespace T01.Logger.Factory
{
    public class AppenderFactory
    {
        public IAppender Create(string type, ILayout layout)
        {
            IAppender appender = null;
            if (type == nameof(FileAppender))
            {
                appender = new FileAppender(layout, new LogFile());
            }
            else if (type == nameof(ConsoleAppender))
            {
                appender = new ConsoleAppender(layout);
            }
            else
            {
                throw new ArgumentException("Invalid type");
            }
            return appender;
        }
    }
}
