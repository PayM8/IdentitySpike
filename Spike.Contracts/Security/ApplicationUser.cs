
namespace Spike.Contracts.Security
{
    using System;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Providers;
    using Users;

    public class ApplicationUser : IUser<string>
    {
        public ApplicationUser()
        {
            CreateDate = DateTime.Now;
            
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, ISecurityProvider provider, string authTypes)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authTypes);

            var claims = provider.GetUserClaims(this.UserName);

            foreach (var claim in claims)
            {
                userIdentity.AddClaim(claim);
            }

            return userIdentity;
        }

        public DateTime CreateDate { get; set; }
      
        public string Id { get; set; }
        public IdentityType IdentityType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public IEnumerable<UserRole> Roles { get; set; }
    }
}