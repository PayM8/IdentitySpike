
namespace Spike.Providers.Security
{
    using System.Security.Claims;
    using System.Collections.Generic;
    using Contracts.Security;
    using System.Linq;
    
    public class ClaimRoleMapper
    {
        public ClaimRoleMapper(IEnumerable<IdentityRole> userRoles)
        {
            this.UserRoles = userRoles;
            this.UserClaims = new List<Claim>();

            foreach (var role in userRoles)
            {
                switch (role)
                {
                    case IdentityRole.Basic:
                        this.AddClaims(_basicRoleClaims);
                        break;
                    case IdentityRole.Admin:
                        this.AddClaims(_adminClaims);
                        break;
                    case IdentityRole.Super:
                        this.AddClaims(_superUserClaims);
                        break;
                }
            }
        }

        private IEnumerable<IdentityRole> UserRoles { get; set; }
        public List<Claim> UserClaims { get; private set; }

        private static readonly Claim BasicUser = new Claim("Access", "BasicUser");
        private static readonly Claim AddUser = new Claim("Access", "AddUser");
        private static readonly Claim EditUser = new Claim("Access", "EditUser");
        private static readonly Claim BackOffice = new Claim("Access", "BackOffice");
        private static readonly Claim SuperUser = new Claim("Access", "SuperUser");

        private readonly Claim[] _basicRoleClaims = new[]
        {
            BasicUser
        };

        private readonly Claim[] _adminClaims = new[]
        {
            AddUser,
            EditUser,
            BackOffice,
        };

        private readonly Claim[] _superUserClaims = new[]
        {
            SuperUser
        };

        private void AddClaims(IEnumerable<Claim> claims)
        {
            foreach (var claim in claims)
            {
                if (!this.UserClaims.Any(c => c.Value.Equals(claim.Value)))
                {
                    this.UserClaims.Add(claim);
                }
            }
        }
    }
}
