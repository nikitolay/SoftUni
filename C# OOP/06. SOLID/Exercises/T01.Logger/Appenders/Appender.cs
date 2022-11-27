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
    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout)
        {
            Layout = layout;
        }
        public ILayout Layout { get; }

        public int MessagesCount { get; protected set; }

        public abstract void Append(string date, ReportLevel level, string message);

        public ReportLevel ReportLevel { get; set; }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesCount}";
        }
    }
}
