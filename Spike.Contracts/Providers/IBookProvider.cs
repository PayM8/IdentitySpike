
namespace Spike.Contracts.Providers
{
    using System.Collections.Generic;
    using Books;
    
    public interface IBookProvider
    {
        Book AddBook(Book book);

        Book GetBook(int id);

        IEnumerable<Book> GetAllBooks();
    }
}
