using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.IO.Compression;

namespace Streams__Files_and_Directories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // EvenLines();
            // LineNumbers();
            //WordCount();
            //CopyBinaryFile();
            // DirectoryTraversal();
            //ZipAndExtract();
        }

        private static void ZipAndExtract()
        {
            string sourceDirtectory = @"C:\Users\nikor\OneDrive\Работен плот\folderInDekstop";
            string targetDirtectory = @"C:\Users\nikor\OneDrive\Работен плот\result.zip";
            string destinationDirtectory = @"C:\Users\nikor\OneDrive\Работен плот\result";
            ZipFile.CreateFromDirectory(sourceDirtectory, targetDirtectory);
            ZipFile.ExtractToDirectory(targetDirtectory, destinationDirtectory);
        }

        private static void DirectoryTraversal()
        {
            string[] allFiles = Directory.GetFiles("../../../", ".");

            //extension-name-size
            Dictionary<string, Dictionary<string, double>> groupedFiles = new Dictionary<string, Dictionary<string, double>>();
            foreach (var file in allFiles)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (!groupedFiles.ContainsKey(fileInfo.Extension))
                {
                    groupedFiles.Add(fileInfo.Extension, new Dictionary<string, double>());
                }
                double size = (double)file.Length / 1024;
                groupedFiles[fileInfo.Extension].Add(fileInfo.Name, size);

            }
            var sortedFiles = groupedFiles
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key);
            List<string> lines = new List<string>();
            foreach (var file in sortedFiles)
            {
                lines.Add(file.Key);
                foreach (var item in file.Value)
                {
                    lines.Add($"--{item.Key} - {item.Value:f3}kb");
                }
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";
            File.WriteAllLines(path, lines);
        }

        private static void CopyBinaryFile()
        {
            using FileStream fileReader = new FileStream("copyMe.png", FileMode.Open);
            using FileStream fileWriter = new FileStream("copyMeCopy.png", FileMode.Create);

            byte[] buffer = new byte[256];
            while (true)
            {
                int currentBytes = fileReader.Read(buffer, 0, 256);//vrushta kolko baita sa procheteni
                if (currentBytes == 0)
                {
                    // fileWriter.Flush();
                    break;
                }
                fileWriter.Write(buffer, 0, 256);
            }
        }

        private static void WordCount()
        {
            string[] words = File.ReadAllLines("words.txt");
            string[] lines = File.ReadAllLines("text.txt");

            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string pattern = @$"\b{word}";

                result.Add(word, 0);

                for (int i = 0; i < lines.Length; i++)
                {
                    foreach (Match m in Regex.Matches(lines[i].ToLower(), pattern))
                    {
                        result[word]++;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in result.OrderByDescending(x => x.Value))
            {
                sb.AppendLine($"{item.Key} - {item.Value}");
            }

            File.WriteAllText("actualResult.txt", sb.ToString());
        }

        private static void LineNumbers()
        {
            string[] text = File.ReadAllLines("text.txt");
            for (int i = 0; i < text.Length; i++)
            {
                int words = 0;
                int punctuation = 0;
                for (int j = 0; j < text[i].Length; j++)
                {
                    if (char.IsLetter(text[i][j]))
                    {
                        words++;
                    }
                    else if (char.IsPunctuation(text[i][j]))
                    {
                        punctuation++;
                    }
                }
                string result = $"Line {i + 1}: {text[i]} ({words})({punctuation}){Environment.NewLine}";
                File.AppendAllText("output2.txt", result);
            }
        }

        private static void EvenLines()
        {
            StreamReader sr = new StreamReader("text.txt");
            string[] symbols = { "-", ",", ".", "!", "?" };
            string line = sr.ReadLine();
            int index = 0;
            while (line != null)
            {
                if (index % 2 == 0)
                {

                    foreach (var item in symbols)
                    {
                        line = line.Replace(item, "@");
                    }
                    File.AppendAllText("output1.txt", $"{string.Join(" ", line.Split().Reverse())}{Environment.NewLine}");
                }
                line = sr.ReadLine();
                index++;
            }
        }
    }
}
