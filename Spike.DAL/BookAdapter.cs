
namespace Spike.Adapters
{
    using System.Collections.Generic;
    using Contracts.Books;

    public static class BookAdapter
    {
        public static Book AddBook(Book book)
        {
            return DatabaseStub.Instance.GetBook(book.Id) != null ? new Book() : DatabaseStub.Instance.AddBook(book);
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
