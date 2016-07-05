
namespace Spike.Providers.WCF
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using Contracts.Providers;
    using System.Security.Claims;
    using Contracts.Security;

    [ServiceContract(Namespace = "Spike.Providers")]
    public class IdentityResolverService : IIdentityResolver
    {
        [OperationContract]
        public CommonIdentity RegisterUser(CommonIdentity user)
        {
            var provider = ProviderFactory.CreateSecurityProvider();

            return provider.RegisterUser(user);
        }

        [OperationContract]
        public CommonIdentity DeleteUser(string userName)
        {
            var provider = ProviderFactory.CreateSecurityProvider();

            return provider.DeleteUser(userName);
        }

        [OperationContract]
        public CommonIdentity GetUser(string userName)
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
