
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

        public ApplicationUser DeleteUser(int id)
        {
            return SecurityAdapter.DeleteUser(id).Map();
        }

        public ApplicationUser GetUser(int id)
        {
            return SecurityAdapter.GetUser(id).Map();
        }

        public IEnumerable<Claim> GetUserClaims(int userId)
        {
            var user = SecurityAdapter.GetUser(userId);
            
            if (user == null)
            {
                return new List<Claim>();
            }

            var claims = GetClaimsForRoles(user.Roles);
            claims.AddRange(GetUserCustomClaims(userId));

            return claims;
        }

        private static List<Claim> GetClaimsForRoles(IEnumerable<UserRole> roles)
        {
            return new ClaimRoleMapper(roles).UserClaims;
        }

        private static IEnumerable<Claim> GetUserCustomClaims(int userId)
        {
            // Add non Role based claim logic here

            return new List<Claim>();
        }
    }
}
