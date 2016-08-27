using System;

namespace Library_Card_Catalog
{
    [Serializable()]
    public class Book
    {

        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int NumPages { get; set; }
        public int YearPublished { get; set; }

        public Book() { }

        public Book(string t, string a, string g, int n, int y)
        {
            this.Title = t;
            this.Author = a;
            this.Genre = g;
            this.NumPages = n;
            this.YearPublished = y;
        }

    }
}
