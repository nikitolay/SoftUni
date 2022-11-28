using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T01.Logger.Appenders.Interfaces;

namespace T01.Logger.Loggers.Interfaces
{
    public interface ILogger
    {
        ICollection<IAppender> Appenders { get; }

        void Error(string date, string message);

        void Warning(string date, string message);

        void Info(string date, string message);

        void Critical(string date, string message);

        void Fatal(string date, string message);
    }
}
