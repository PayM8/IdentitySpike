
namespace Spike.Contracts.Providers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using Security;

    public interface ISecurityProvider
    {
        ApplicationUser RegisterUser(ApplicationUser user);

        ApplicationUser DeleteUser(string userName);

        ApplicationUser GetUser(string userName);

        IEnumerable<Claim> GetUserClaims(string userName);
    }
}
