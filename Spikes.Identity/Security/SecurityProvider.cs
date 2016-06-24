
namespace Spike.Providers.Security
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using Contracts.Providers;
    using Contracts.Security;
    using Adapters;

    public class SecurityProvider : ISecurityProvider
    {
        public ApplicationUser RegisterUser(ApplicationUser user)
        {
            return SecurityAdapter.RegisterUser(user.Map()).Map();
        }

        public ApplicationUser DeleteUser(string userName)
        {
            return SecurityAdapter.DeleteUser(userName).Map();
        }

        public ApplicationUser GetUser(string userName)
        {
            return SecurityAdapter.GetUser(userName).Map();
        }

        public IEnumerable<Claim> GetUserClaims(string userName)
        {
            var user = SecurityAdapter.GetUser(userName);
            
            if (user == null)
            {
                return new List<Claim>();
            }

            var claims = GetClaimsForRoles(user.Roles);
            claims.AddRange(GetUserCustomClaims(userName));

            return claims;
        }

        private static List<Claim> GetClaimsForRoles(IEnumerable<UserRole> roles)
        {
            return new ClaimRoleMapper(roles).UserClaims;
        }

        private static IEnumerable<Claim> GetUserCustomClaims(string userName)
        {
            // Add non Role based claim logic here

            return new List<Claim>();
        }
    }
}
