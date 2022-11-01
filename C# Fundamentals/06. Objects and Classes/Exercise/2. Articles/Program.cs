using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace _2._Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> article = Console.ReadLine().Split(", ").ToList();
            Article article1 = new Article(article[0], article[1], article[2]);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();

                switch (arr[0])
                {
                    case "Edit:":
                        article1.Edit(arr);
                        break;
                    case "ChangeAuthor:":
                        article1.ChangeAuthor(arr);
                        break;
                    case "Rename:":
                        article1.Rename(arr);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(article1);
        }
    }
    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }


        public void Edit(string[] content)
        {
            Content = "";
            for (int i = 1; i < content.Length; i++)
            {
                if (i == content.Length - 1)
                {
                    Content += content[i];


                }
                else
                {
                    Content += content[i] + " ";


                }

            }
        }
        public void ChangeAuthor(string[] author)
        {
            Author = "";
            for (int i = 1; i < author.Length; i++)
            {
                if (i == author.Length - 1)
                {
                    Author += author[i];

                }
                else
                {
                    Author += author[i] + " ";

                }

            }
        }
        public void Rename(string[] title)
        {
            Title = "";
            for (int i = 1; i < title.Length; i++)
            {

                if (i == title.Length - 1)
                {
                    Title += title[i];


                }
                else
                {
                    Title += title[i] + " ";

                }

            }
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
