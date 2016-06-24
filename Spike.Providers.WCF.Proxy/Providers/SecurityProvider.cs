
namespace Spike.Providers.WCF.Proxy.Providers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using Contracts.Providers;
    using Contracts.Security;

    public class SecurityProvider : ISecurityProvider
    {
        public ApplicationUser RegisterUser(ApplicationUser user)
        {
            var consumer = new ServiceClientWrapper<SecurityProviderService.SecurityProviderServiceClient, SecurityProviderService.SecurityProviderService>();

            return consumer.Excecute(service => service.RegisterUser(user));
        }

        public ApplicationUser DeleteUser(string userName)
        {
            var consumer = new ServiceClientWrapper<SecurityProviderService.SecurityProviderServiceClient, SecurityProviderService.SecurityProviderService>();

            return consumer.Excecute(service => service.DeleteUser(userName));
        }

        public ApplicationUser GetUser(string userName)
        {
            var consumer = new ServiceClientWrapper<SecurityProviderService.SecurityProviderServiceClient, SecurityProviderService.SecurityProviderService>();

            return consumer.Excecute(service => service.GetUser(userName));
        }

        public IEnumerable<Claim> GetUserClaims(string userName)
        {
            var consumer = new ServiceClientWrapper<SecurityProviderService.SecurityProviderServiceClient, SecurityProviderService.SecurityProviderService>();

            return consumer.Excecute(service => service.GetUserClaims(userName));
        }
    }
}
