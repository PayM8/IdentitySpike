
namespace Spike.Adapters.StubData
{
    using System.Collections.Generic;
    using System.Linq;
    using Entities;
    using Contracts.Books;

    public class DatabaseStub
    {
        private IList<Book> _books;
        private IList<UserEntity> _users;

        private static DatabaseStub _instance;
        
        public static DatabaseStub Instance
        {
            get
            {
                return _instance ?? (
                    _instance = new DatabaseStub
                    {
                        _books = new List<Book>(),
                        _users = UserWaldo.InitUsers().ToList()
                    }); 
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

        public UserEntity AddUser(UserEntity user)
        {
            this._users.Add(user);
            return user;
        }

        public UserEntity GetUser(string userName)
        {
            return this._users.FirstOrDefault(user => user.UserName.Equals(userName) && !user.IsDeleted);
        }

        public UserEntity DeleteUser(string userName)
        {
            var found = this._users.FirstOrDefault(user => user.UserName.Equals(userName));

            if (found == null)
            {
                return null;
            }

            found.IsDeleted = true;
            return found;
        }

        public UserEntity UpdateUser(UserEntity user)
        {
            var existingUser = _users.First(usr => usr.UserName.Equals(user.UserName));

            existingUser.IdentityType = user.IdentityType;
            existingUser.Roles = user.Roles;

            return existingUser;
        }
    }
}
