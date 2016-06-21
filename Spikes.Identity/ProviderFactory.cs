
namespace Spike.Providers
{
    using Books;

    public class ProviderFactory
    {
        public static BookProvider CreateBookProvider()
        {
            return new BookProvider(); 
        }
    }
}
