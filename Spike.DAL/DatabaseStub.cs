
namespace Spike.Adapters
{
    using System.Collections.Generic;
    using Contracts.Books;
    using System.Linq;
    
    public class DatabaseStub
    {
        private IList<Book> _books;
        private static DatabaseStub _instance;
        
        public static DatabaseStub Instance
        {
            get
            {
                return _instance ?? (_instance = new DatabaseStub {_books = new List<Book>()}); 
            }
        }

        public Book AddBook(Book book)
        {
            this._books.Add(book);
            return book;
        }

        public Book GetBook(int id)
        {
            return this._books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return this._books;
        }
    }
}
