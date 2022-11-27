using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T01.Logger.Enumerations;
using T01.Logger.Layouts.Interfaces;

namespace T01.Logger.Appenders.Interfaces
{
    public interface IAppender
    {
        void Append(string date, ReportLevel level, string message);
        ReportLevel ReportLevel { get; set; }
    }
}
