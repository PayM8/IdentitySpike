
namespace Spike.Public.Services.Books
{
    using System.Collections.Generic;
    using Providers.WCF.Proxy;
    using Contracts.Books;


    public class BookService : IBookService
    {
        public Book AddBook(Book book)
        {
            var provider = ProviderFactory.CreateBookProvider();

            return provider.AddBook(book);
        }

        public Book GetBook(int id)
        {
            var provider = ProviderFactory.CreateBookProvider();

            return provider.GetBook(id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var provider = ProviderFactory.CreateBookProvider();

            return provider.GetAllBooks();
        }
    }
}
