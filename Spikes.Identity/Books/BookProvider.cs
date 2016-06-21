
namespace Spike.Providers.Books
{
    using System;
    using System.Collections.Generic;
    using Adapters;
    using Contracts.Books;
    using Contracts.Providers;

    public class BookProvider : IBookProvider
    {
        public Book AddBook(Book book)
        {
            return BookAdapter.AddBook(book);
        }

        public Book GetBook(int id)
        {
            return BookAdapter.GetBook(id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return BookAdapter.GetAllBooks();
        }
    }
}
