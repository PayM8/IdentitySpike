
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Spike.Contracts.Security;
using Spike.Providers.WCF.Proxy;
using Spike.Web.Security;

namespace Spike.Web.Controllers
{
    public class ControllerBase : Controller
    {
        public readonly UserStore<ApplicationUser> UserStore;
        public readonly ApplicationSignInManager SignInManager;
        public readonly ApplicationUserManager UserManager;
        public readonly ApplicationAuthenticationManager AuthenticationManager;
        public const bool RememberMe = false;

        public ControllerBase()
        {
            this.UserStore = new UserStore<ApplicationUser>(ProviderFactory.CreateSecurityProvider());
            this.UserManager = new ApplicationUserManager(this.UserStore);
            this.AuthenticationManager = new ApplicationAuthenticationManager();
            this.SignInManager = new ApplicationSignInManager(UserManager, AuthenticationManager);
        }

        public SignInStatus LogIn(string returnUrl, string userName, string passwordHash)
        {
            var result = new ApplicationSignInManager(UserManager, AuthenticationManager)
                .PasswordSignInAsync(userName, passwordHash, RememberMe, shouldLockout: false);

            return result.Result;
        }
    }
}