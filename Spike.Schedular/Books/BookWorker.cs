
using Spike.Providers;

namespace Spike.Schedular.Books
{
    using System.Threading.Tasks;

    public static class BookWorker
    {
        public static bool IsBusy = false;

        public static void AddBullsEye()
        {
            var provider = ProviderFactory.CreateBookProvider();
            var book = new BookBuilder().BullsEye().Build();
            
            provider.AddBook(book);
        }

        public static Task<Contracts.Books.Book> GetBookAsync(int id)
        {
           return GetBookAsyncInternal(id);
        }

        private static async Task<Contracts.Books.Book> GetBookAsyncInternal(int id)
        {
            var provider = ProviderFactory.CreateBookProvider();

            return provider.GetBook(id);
        }
    }
}
