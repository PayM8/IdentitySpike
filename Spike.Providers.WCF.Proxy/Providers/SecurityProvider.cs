
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

        public ApplicationUser DeleteUser(int id)
        {
            var consumer = new ServiceClientWrapper<SecurityProviderService.SecurityProviderServiceClient, SecurityProviderService.SecurityProviderService>();

            return consumer.Excecute(service => service.DeleteUser(id));
        }

        public ApplicationUser GetUser(int id)
        {
            var consumer = new ServiceClientWrapper<SecurityProviderService.SecurityProviderServiceClient, SecurityProviderService.SecurityProviderService>();

            return consumer.Excecute(service => service.GetUser(id));
        }

        public IEnumerable<Claim> GetUserClaims(int userId)
        {
            var consumer = new ServiceClientWrapper<SecurityProviderService.SecurityProviderServiceClient, SecurityProviderService.SecurityProviderService>();

            return consumer.Excecute(service => service.GetUserClaims(userId));
        }
    }
}
