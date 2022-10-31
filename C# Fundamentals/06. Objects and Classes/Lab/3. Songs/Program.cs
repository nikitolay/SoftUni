using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            for (int i = 0; i < n; i++)
            {

                List<string> list = Console.ReadLine().Split("_").ToList();
                Song song = new Song(list[0], list[1], list[2]);
                songs.Add(song);
            }
            string typeOfList = Console.ReadLine();
            if (typeOfList == "all")
            {
                foreach (var item in songs)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                foreach (var item in songs.Where(x => x.TypeList == typeOfList))
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
    public class Song
    {
        public Song(string typeList, string name, string time)
        {
            TypeList = typeList;
            Name = name;
            Time = time;
        }

        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }

}
