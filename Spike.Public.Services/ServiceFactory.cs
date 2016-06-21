
namespace Spike.Public.Services
{
    using Books;

    public class ServiceFactory
    {
        public static BookService CreateBookService()
        {
            return new BookService();
        }
    }
}
