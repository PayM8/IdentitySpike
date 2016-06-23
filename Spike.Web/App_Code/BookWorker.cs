namespace Spike.Web
{
    using Providers.WCF.Proxy;
    using Providers.WCF.Proxy.BookProviderService;
    using Public.Services.Books;
    using System.Collections.Generic;
    using Book = Contracts.Books.Book;
    
    public static class BookWorker
    {
        public static Book AddBullsEye()
        {
            return AddBook(new BookBuilder().BullsEye().Build().Map());
        }

        public static Book AddFiveDysfunctions()
        {
            return AddBook(new BookBuilder().FiveDysfunctions().Build().Map());
        }

        public static Book GetBullsEyeBook()
        {
            var consumer = new ServiceClientWrapper<BookProviderServiceClient, BookProviderService>();

            return consumer.Excecute(service => service.GetBook((new BookBuilder().BullsEye().Build()).Id)).Map();
        }

        public static IEnumerable<Book> GetAllBooks()
        {
            var consumer = new ServiceClientWrapper<BookProviderServiceClient, BookProviderService>();

            return consumer.Excecute(service => service.GetAllBooks()).Map();
        }

        private static Book AddBook(Book book)
        {
            var consumer = new ServiceClientWrapper<BookProviderServiceClient, BookProviderService>();

            return consumer.Excecute(service => service.AddBook(book.Map())).Map();
        }

        public static string Display(this Book book)
        {
            return book == null ? "No book." :
                string.Format("Id: {0} Title: {1} Author: {2} Year: {3}",
                book.Id, book.Title, book.Author, book.Year);
        }
    }
}