
namespace WcfCosumer
{
    using System;
    using System.Linq;
    using System.Threading;
    using BookService;
    using System.Collections.Generic;

    public static class BookWorker
    {
        public static Book AddBullsEye()
        {
            return AddBook(new BookBuilder().BullsEye().Build());
        }

        public static Book AddFiveDysfunctions()
        {
            return AddBook(new BookBuilder().FiveDysfunctions().Build());
        }

        public static Book GetBullsEyeBook()
        {
            Book newBook;

            using (var client = new BookServiceClient())
            {
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

        public static IEnumerable<Book> GetAllBooks()
        {
           IEnumerable<Book> books;

            using (var client = new BookServiceClient())
            {
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

            Thread.Sleep(2000);
            return books;
        }

        private static Book AddBook(Book book)
        {
            Book newBook;
            Console.WriteLine("Start - Adding [{0}] book", book.Display());

            using (var client = new BookServiceClient())
            {
                newBook = client.AddBook(book);
            }

            Console.WriteLine("End - Adding [{0}] book", newBook.Display());
            Thread.Sleep(2000);
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
