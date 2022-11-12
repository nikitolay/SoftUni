using System;
using System.IO;

namespace _6._Folder_Size
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] allFiles = Directory.GetFiles("TestFolder");
            double result = 0;
            foreach (var file in allFiles)
            {
                FileInfo fileInfo = new FileInfo(file);
                result += (double)(fileInfo.Length / 1024) / 1024;
            }
            File.WriteAllText("output.txt", $"{result}");
        }
    }
}
