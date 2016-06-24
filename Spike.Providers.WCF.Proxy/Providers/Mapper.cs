
namespace Spike.Providers.WCF.Proxy.Providers
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts.Books;

    public static class Mapper
    {
        public static BookProviderService.Book Map(this Book original)
        {
            if (original == null)
            {
                return null;
            }

            return new BookProviderService.Book
            {
                Id = original.Id,
                Author = original.Author,
                Title = original.Title,
                Year = original.Year
            };
        }

        public static IEnumerable<BookProviderService.Book> Map(this IEnumerable<Book> original)
        {
            return original.Select(book => book.Map());
        }

        public static Book Map(this BookProviderService.Book original)
        {
            if (original == null)
            {
                return null;
            }

            return new Book
            {
                Id = original.Id,
                Author = original.Author,
                Title = original.Title,
                Year = original.Year
            };
        }

        public static IEnumerable<Book> Map(this IEnumerable<BookProviderService.Book> original)
        {
            return original.Select(book => book.Map());
        }
    }
}
