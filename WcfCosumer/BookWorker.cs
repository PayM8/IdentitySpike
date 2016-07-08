
namespace WcfCosumer
{
    using System;
    using System.Linq;
    using System.Threading;
    using BookService;
    using System.Collections.Generic;
    using System.ServiceModel.Security;
    using System.ServiceModel;

    public static class BookWorker
    {
        public static Book AddBullsEye(string username, string password)
        {
            return AddBook(new BookBuilder().BullsEye().Build(), username, password);
        }

        public static Book AddFiveDysfunctions(string username, string password)
        {
            return AddBook(new BookBuilder().FiveDysfunctions().Build(), username, password);
        }

        public static Book GetBullsEyeBook(string username, string password)
        {
            Book newBook;

            using (var client = new BookServiceClient())
            {
                client.ClientCredentials.UserName.UserName = username;
                client.ClientCredentials.UserName.Password = password;
                newBook = client.GetBook(new BookBuilder().BullsEye().Id);
            }

            if (newBook == null)
            {
                Console.WriteLine("BullsEye Book was not found");
            }
            else
            {
                Console.WriteLine("Retrieved [{0}] book", newBook.Display());
            }

            Thread.Sleep(2000);
            return newBook;
        }

        public static IEnumerable<Book> GetAllBooks(string username, string password)
        {
            IEnumerable<Book> books;
            try
            {
                using (var client = new BookServiceClient())
                {
                    client.ClientCredentials.UserName.UserName = username;
                    client.ClientCredentials.UserName.Password = password;

                    books = client.GetAllBooks();

                }

                if (!books.Any())
                {
                    Console.WriteLine("No books where found");
                }
                else
                {
                    foreach (var book in books)
                    {
                        Console.WriteLine("Retrieved [{0}] book", book.Display());
                    }
                }

            }
            catch (Exception me)
            {
                Console.WriteLine(me.Message);
                books = new List<Book>();
            }
            Thread.Sleep(2000);
            return books;
        }

        private static Book AddBook(Book book, string username, string password)
        {
            Book newBook;
            try
            {
                Console.WriteLine("Start - Adding [{0}] book", book.Display());

                using (var client = new BookServiceClient())
                {
                    client.ClientCredentials.UserName.UserName = username;
                    client.ClientCredentials.UserName.Password = password;

                    newBook = client.AddBook(book);

                }

                Console.WriteLine("End - Adding [{0}] book", newBook.Display());
                Thread.Sleep(2000);

            }
            catch (Exception me)
            {
                newBook = new Book();
                newBook.Title = me.Message;
                Console.WriteLine(me.Message);
            }
            return newBook;
        }

        public static string Display(this Book book)
        {
            return book == null ? "No book." :
                string.Format("Id: {0} Title: {1} Author: {2} Year: {3}",
                book.Id, book.Title, book.Author, book.Year);
        }
    }
}
