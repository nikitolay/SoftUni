using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T01.Logger.Appenders.Interfaces;
using T01.Logger.Enumerations;
using T01.Logger.Loggers.Interfaces;

namespace T01.Logger.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = appenders.ToList();
        }

        public ICollection<IAppender> Appenders { get; }

        public void Critical(string date, string message)
        {
            Log(date, ReportLevel.Critical, message);

        }


        public void Error(string date, string message)
        {
            Log(date, ReportLevel.Error, message);

        }

        public void Fatal(string date, string message)
        {
            Log(date, ReportLevel.Fatal, message);

        }

        public void Info(string date, string message)
        {
            Log(date, ReportLevel.Info, message);

        }

        public void Warning(string date, string message)
        {
            Log(date, ReportLevel.Warning, message);
        }
        private void Log(string date, ReportLevel reportLevel, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(date, reportLevel, message);
            }
        }
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Logger info");

            foreach (var appender in this.Appenders)
            {
                builder.AppendLine(appender.GetAppenderInfo());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
