using System;
using System.IO;

namespace _4._Merge_Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstLines = File.ReadAllLines("FileOne.txt");
            string[] secondLines = File.ReadAllLines("FileTwo.txt");
            foreach (var line in firstLines)
            {
                File.AppendAllText("output.txt", $"{line}{Environment.NewLine}");
            }
            foreach (var line in secondLines)
            {
                File.AppendAllText("output.txt", $"{line}{Environment.NewLine}");
            }
        }
    }
}
