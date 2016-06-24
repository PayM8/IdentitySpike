
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
        public ApplicationUser DeleteUser(int id)
        {
            var provider = ProviderFactory.CreateSecurityProvider();

            return provider.DeleteUser(id);
        }

        [OperationContract]
        public ApplicationUser GetUser(int id)
        {
            var provider = ProviderFactory.CreateSecurityProvider();

            return provider.GetUser(id);
        }

        [OperationContract]
        public IEnumerable<Claim> GetUserClaims(int userId)
        {
            var provider = ProviderFactory.CreateSecurityProvider();

            return provider.GetUserClaims(userId);
        }
    }
}
