

namespace RestConsumer
{
    using System;
    using System.Threading;
    using Spike.Contracts.Books;

    public static class BookWorker
    {
        public static void AddBullsEye()
        {
            AddBook(new BookBuilder().BullsEye().Build());
        }

        public static void AddFiveDysfunctions()
        {
            AddBook(new BookBuilder().FiveDysfunctions().Build());
        }

        public static void GetBullsEyeBook()
        {
            var client = new BookClient();
            client.GetSingleBook("api/book/1");
        }

        public static void GetAllBooks()
        {
            var client = new BookClient();
            client.GetListBook("api/book");
        }

        private static void AddBook(Book book)
        {
            Console.WriteLine("Start - Adding [{0}] book", book.Display());

            var client = new BookClient();
            client.PostSingleBook("api/book", book);

            Thread.Sleep(2000);
        }

        public static string Display(this Book book)
        {
            return book == null ? "No book." :
                string.Format("Id: {0} Title: {1} Author: {2} Year: {3}",
                book.Id, book.Title, book.Author, book.Year);
        }
    }
}
