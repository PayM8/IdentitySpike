
namespace Spike.Contracts.Books
{
    using System;

    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime Year { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0} Title: {1} Author: {2} Year: {3}", Id, Title, Author, Year);
        }
    }
}
