namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
            // string input = Console.ReadLine();
            Console.WriteLine(RemoveBooks(db));

        }
        //ex. 2
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context.Books
                .AsEnumerable()
                .Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();


            return string.Join(Environment.NewLine, books);

        }


        //ex. 3
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.EditionType == EditionType.Gold)
                .Where(x => x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();


            return string.Join(Environment.NewLine, books);
        }

        //ex. 4
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} - ${book.Price}");
            }


            return result.ToString().Trim();
        }

        //ex. 5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();


            return string.Join(Environment.NewLine, books);
        }

        //ex. 6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var books = context.Books
                .Where(x => x.BookCategories.Any(x => categories.Contains(x.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //ex. 7

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder result = new StringBuilder();

            DateTime releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate < releaseDate)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price
                })
                .ToList();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price}");
            }

            return result.ToString().TrimEnd();
        }

        //ex. 8

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder result = new StringBuilder();

            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                })
                .ToList();

            foreach (var author in authors)
            {
                result.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return result.ToString().TrimEnd();
        }

        //ex. 9

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //ex. 10

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder result = new StringBuilder();

            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => new
                {
                    x.Title,
                    AuthorFirstName = x.Author.FirstName,
                    AuthorLastName = x.Author.LastName
                })
                .ToList();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} ({book.AuthorFirstName} {book.AuthorLastName})");
            }

            return result.ToString().TrimEnd();
        }

        //ex. 11

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return booksCount;
        }

        //ex. 12

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var authors = context.Authors
                .Select(x => new
                {
                    FullName = $"{x.FirstName} {x.LastName}",
                    TotalCopies = x.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.TotalCopies)
                .ToList();

            foreach (var author in authors)
            {
                result.AppendLine($"{author.FullName} - {author.TotalCopies}");
            }


            return result.ToString().TrimEnd();
        }

        //ex. 13

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var categoryProfits = context.Categories
                .Select(x => new
                {
                    x.Name,
                    TotalProfit = x.CategoryBooks.Select(x => new
                    {
                        BookProfit = x.Book.Copies * x.Book.Price
                    }).Sum(x => x.BookProfit)
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.Name)
                .ToList();

            foreach (var cp in categoryProfits)
            {
                result.AppendLine($"{cp.Name} ${cp.TotalProfit:f2}");
            }

            return result.ToString().TrimEnd();
        }

        //ex. 14

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks.Select(x => new
                    {
                        x.Book.Title,
                        x.Book.ReleaseDate
                    }).OrderByDescending(x => x.ReleaseDate).Take(3)
                })
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var category in categories)
            {
                result.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    result.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return result.ToString().TrimEnd();
        }

        //ex. 15

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();

        }

        //ex. 16

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context.Books
                .Where(x => x.Copies < 4200);

            int count = booksToDelete.Count();

            context.Books.RemoveRange(booksToDelete);

            context.SaveChanges();

            return count;
        }
    }
}
