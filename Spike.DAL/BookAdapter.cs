
namespace Spike.Adapters
{
    using System;
    using System.Collections.Generic;
    using Contracts.Books;

    public static class BookAdapter
    {
        public static Book AddBook(Book book)
        {
            return DatabaseStub.Instance.AddBook(book);
        }

        public static Book GetBook(int id)
        {
            return DatabaseStub.Instance.GetBook(id);
        }

        public static IEnumerable<Book> GetAllBooks()
        {
            return DatabaseStub.Instance.GetAllBooks();
        }
    }
}
