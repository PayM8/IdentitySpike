
namespace Spike.Public.Services.Books
{
    using System.Collections.Generic;
    using Providers.WCF.Proxy;
    using Providers.WCF.Proxy.BookProviderService;
    using Book = Contracts.Books.Book;

    public class BookService : IBookService
    {
        public Book AddBook(Book book)
        {
            var consumer = new ServiceClientWrapper<BookProviderServiceClient, BookProviderService>();

            return consumer.Excecute(service => service.AddBook(book.Map())).Map();
        }

        public Book GetBook(int id)
        {
            var consumer = new ServiceClientWrapper<BookProviderServiceClient, BookProviderService>();

            return consumer.Excecute(service => service.GetBook(id)).Map();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var consumer = new ServiceClientWrapper<BookProviderServiceClient, BookProviderService>();

            return consumer.Excecute(service => service.GetAllBooks()).Map();
        }
    }
}
