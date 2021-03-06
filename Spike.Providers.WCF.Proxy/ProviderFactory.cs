﻿
namespace Spike.Providers.WCF.Proxy
{
    using Providers;

    public class ProviderFactory
    {
        public static BookProvider CreateBookProvider()
        {
            return new BookProvider(); 
        }

        public static IdentityResolver CreateSecurityProvider()
        {
            return new IdentityResolver();
        }
    }
}
