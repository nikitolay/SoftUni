using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T01.Logger.Enumerations;
using T01.Logger.Layouts.Interfaces;
using T01.Logger.Loggers.Interfaces;

namespace T01.Logger.Appenders
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout)
            : base(layout)
        {
        }
        public ILogFile File { get; set; }
        public override void Append(string date, ReportLevel level, string message)
        {
            if (ReportLevel <= level)
            {
                MessagesCount++;
                File.Write(string.Format(Layout.Format, date, message));
            }
        }
        public override string ToString()
        {
            return base.ToString() + $", File size: {this.File.Size}";
        }
    }
}
