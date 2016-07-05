
namespace Spike.Web.Security
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Cookies;
    using Contracts.Security;
    using Providers.WCF.Proxy;

    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public virtual async Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            var provider = ProviderFactory.CreateSecurityProvider();

            var user = provider.GetUser(userName);

            //TODO: Expand

            // Verify Password
            const bool verifyPassword = true;

            if (user != null && verifyPassword)
            {
                return SignInStatus.Success;
            }

            return SignInStatus.Failure;
        }

        public Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUserManager userManager, ApplicationUser user)
        {
            var provider = ProviderFactory.CreateSecurityProvider();

            return user.GenerateUserIdentityAsync(userManager, provider, new CookieAuthenticationOptions().AuthenticationType);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}