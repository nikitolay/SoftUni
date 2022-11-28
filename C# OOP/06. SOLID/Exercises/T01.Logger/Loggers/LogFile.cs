using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T01.Logger.Loggers.Interfaces;

namespace T01.Logger.Loggers
{
    public class LogFile : ILogFile
    {

        private string path = "../../../log.txt";

        public LogFile()
        {
           using FileStream fs = new FileStream(path, FileMode.Create);
        }

        public int Size
        {
            get
            {
                using (var stream = new StreamReader(path))
                {
                    return stream.ReadToEnd().ToCharArray()
                        .Where(Char.IsLetter)
                        .Sum(c => c);
                }
            }
        }
        public void Write(string content)
        {
            using (var stream = new StreamWriter(path, true))
            {
                stream.WriteLine(content);
            }
        }
    }
}
