
namespace Spike.Providers.WCF
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using Contracts.Providers;
    using System.Security.Claims;
    using Contracts.Security;

    [ServiceContract(Namespace = "Spike.Providers")]
    public class SecurityProviderService : ISecurityProvider
    {
        [OperationContract]
        public ApplicationUser RegisterUser(ApplicationUser user)
        {
            var provider = ProviderFactory.CreateSecurityProvider();

            return provider.RegisterUser(user);
        }

        [OperationContract]
        public ApplicationUser DeleteUser(string userName)
        {
            var provider = ProviderFactory.CreateSecurityProvider();

            return provider.DeleteUser(userName);
        }

        [OperationContract]
        public ApplicationUser GetUser(string userName)
        {
            var provider = ProviderFactory.CreateSecurityProvider();

            return provider.GetUser(userName);
        }

        [OperationContract]
        public IEnumerable<Claim> GetUserClaims(string userName)
        {
            var provider = ProviderFactory.CreateSecurityProvider();

            return provider.GetUserClaims(userName);
        }
    }
}
