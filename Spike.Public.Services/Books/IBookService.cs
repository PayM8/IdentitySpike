
namespace Spike.Public.Services.Books
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using Contracts.Books;
    
    [ServiceContract(Namespace = "Spike.Public")]
    public interface IBookService
    {
        [OperationContract]
        Book AddBook(Book book);

        [OperationContract]
        Book GetBook(int id);

        [OperationContract]
        IEnumerable<Book> GetAllBooks();
    }
}
