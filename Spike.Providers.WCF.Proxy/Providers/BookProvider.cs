
namespace Spike.Providers.WCF.Proxy.Providers
{
    using System.Collections.Generic;
    using Contracts.Providers;
    using Book = Contracts.Books.Book;

    public class BookProvider : IBookProvider
    {
        public Book AddBook(Book book)
        {
            var consumer = new ServiceClientWrapper<BookProviderService.BookProviderServiceClient, BookProviderService.BookProviderService>();

            return consumer.Excecute(service => service.AddBook(book));
        }

        public Book GetBook(int id)
        {
            var consumer = new ServiceClientWrapper<BookProviderService.BookProviderServiceClient, BookProviderService.BookProviderService>();

            return consumer.Excecute(service => service.GetBook(id));
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var consumer = new ServiceClientWrapper<BookProviderService.BookProviderServiceClient, BookProviderService.BookProviderService>();

            return consumer.Excecute(service => service.GetAllBooks());
        }
    }
}
