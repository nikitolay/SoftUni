using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library:IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        private List<Book> books;

        public IEnumerator<Book> GetEnumerator()
        {
           return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            public Book Current => books[index];
            private int index;
            object IEnumerator.Current =>Current;
            public LibraryIterator(IEnumerable<Book> books)
            {
                this.books =new List<Book>(books);
                Reset();
               // this.books.Sort(new BookComparator());
            }

            public bool MoveNext()
            {
                index++; 
                return index < books.Count;
            }

            public void Reset()
            {
                index= -1;
            }
            public void Dispose()
            {
            }
        }

    }
}
