
namespace Spike.Web
{
    using Contracts.Books;
    using Providers.WCF.Proxy;
    using Providers.WCF.Proxy.Builders;

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
            var provider = ProviderFactory.CreateBookProvider();

            return provider.GetBook(new BookBuilder().BullsEye().Build().Id);
        }

        public static IEnumerable<Book> GetAllBooks()
        {
            var provider = ProviderFactory.CreateBookProvider();

            return provider.GetAllBooks();
        }

        private static Book AddBook(Book book)
        {
            var provider = ProviderFactory.CreateBookProvider();
 
            return provider.AddBook(book);
        }

        public static string Display(this Book book)
        {
            return book == null ? "No book." :
                string.Format("Id: {0} Title: {1} Author: {2} Year: {3}",
                book.Id, book.Title, book.Author, book.Year);
        }
    }
}