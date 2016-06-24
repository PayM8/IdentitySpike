
namespace Spike.Contracts.Providers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using Security;

    public interface ISecurityProvider
    {
        ApplicationUser RegisterUser(ApplicationUser user);

        ApplicationUser DeleteUser(int id);

        ApplicationUser GetUser(int id);

        IEnumerable<Claim> GetUserClaims(int userId);
    }
}
