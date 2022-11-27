using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T01.Logger.Loggers.Interfaces
{
    public interface ILogFile
    {
        void Write(string content);
        int Size { get; }
    }
}
