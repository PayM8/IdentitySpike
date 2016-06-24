﻿
namespace Spike.Providers
{
    using Books;
    using Security;

    public class ProviderFactory
    {
        public static BookProvider CreateBookProvider()
        {
            return new BookProvider(); 
        }

        public static SecurityProvider CreateSecurityProvider()
        {
            return new SecurityProvider();
        }
    }
}
