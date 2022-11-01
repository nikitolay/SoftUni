using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Articles_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split(", ");
                Article article1 = new Article(arr[0], arr[1], arr[2]);
                articles.Add(article1);

            }
            string criteria = Console.ReadLine();
            if (criteria=="title")
            {
               articles= articles.OrderBy(x => x.Title).ToList();
            }
            else if (criteria == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();

            }
            else
            {
                articles = articles.OrderBy(x => x.Author).ToList();

            }
            foreach (var item in articles)
            {
                Console.WriteLine(item);
            }
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



        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
