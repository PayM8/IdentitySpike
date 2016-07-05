
namespace Spike.Contracts.Providers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using Security;

    public interface IIdentityResolver
    {
        CommonIdentity RegisterUser(CommonIdentity user);

        CommonIdentity DeleteUser(string userName);

        CommonIdentity GetUser(string userName);

        IEnumerable<Claim> GetUserClaims(string userName);
    }
}
