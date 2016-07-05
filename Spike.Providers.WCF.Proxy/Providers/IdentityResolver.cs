
namespace Spike.Providers.WCF.Proxy.Providers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using Contracts.Providers;
    using Contracts.Security;

    public class IdentityResolver : IIdentityResolver
    {
        public CommonIdentity RegisterUser(CommonIdentity user)
        {
            var consumer = new ServiceClientWrapper<IdentityResolverService.IdentityResolverServiceClient, IdentityResolverService.IdentityResolverService>();

            return consumer.Excecute(service => service.RegisterUser(user));
        }

        public CommonIdentity DeleteUser(string userName)
        {
            var consumer = new ServiceClientWrapper<IdentityResolverService.IdentityResolverServiceClient, IdentityResolverService.IdentityResolverService>();

            return consumer.Excecute(service => service.DeleteUser(userName));
        }

        public CommonIdentity GetUser(string userName)
        {
            var consumer = new ServiceClientWrapper<IdentityResolverService.IdentityResolverServiceClient, IdentityResolverService.IdentityResolverService>();

            return consumer.Excecute(service => service.GetUser(userName));
        }

        public IEnumerable<Claim> GetUserClaims(string userName)
        {
            var consumer = new ServiceClientWrapper<IdentityResolverService.IdentityResolverServiceClient, IdentityResolverService.IdentityResolverService>();

            return consumer.Excecute(service => service.GetUserClaims(userName));
        }
    }
}
