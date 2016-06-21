

namespace Spike.Public.Services.Books
{
    using Contracts.Books;
    using System.Collections.Generic;
    using System.Linq;

    public static class Mapper
    {
        public static Providers.WCF.Proxy.BookProviderService.Book Map(this Book original)
        {
            if (original == null)
            {
                return null;
            }

            return new Providers.WCF.Proxy.BookProviderService.Book
            {
                Id = original.Id,
                Author = original.Author,
                Title = original.Title,
                Year = original.Year
            };
        }

        public static IEnumerable<Providers.WCF.Proxy.BookProviderService.Book> Map(this IEnumerable<Book> original)
        {
            return original.Select(book => book.Map());
        }

        public static Book Map(this Providers.WCF.Proxy.BookProviderService.Book original)
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

        public static IEnumerable<Book> Map(this IEnumerable<Providers.WCF.Proxy.BookProviderService.Book> original)
        {
            return original.Select(book => book.Map());
        }
    }
}
