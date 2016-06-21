
namespace Spike.Providers.WCF
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using Contracts.Books;
    using Contracts.Providers;

    [ServiceContract(Namespace = "Spike.Providers")]
    public class BookProviderService : IBookProvider
    {
        [OperationContract]
        public Book AddBook(Book book)
        {
            var provider = ProviderFactory.CreateBookProvider();

            return provider.AddBook(book);
        }

        [OperationContract]
        public Book GetBook(int id)
        {
            var provider = ProviderFactory.CreateBookProvider();

            return provider.GetBook(id);
        }

        [OperationContract]
        public IEnumerable<Book> GetAllBooks()
        {
            var provider = ProviderFactory.CreateBookProvider();

            return provider.GetAllBooks();
        }
    }
}
