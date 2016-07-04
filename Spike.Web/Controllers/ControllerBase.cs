
namespace Spike.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;
    using Contracts.Security;
    using Security;
    using Security.Models;
    using Microsoft.Owin.Security.Cookies;
    using Providers.WCF.Proxy;

    public class ControllerBase : Controller
    {
        public readonly IUserStore<ApplicationUser> UserStore;
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

        // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
        public class ApplicationUserManager : UserManager<ApplicationUser>
        {
            public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
            {
            }

            public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
            {
                var securityProvider = ProviderFactory.CreateSecurityProvider();
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(securityProvider));

                // Configure validation logic for usernames
                manager.UserValidator = new UserValidator<ApplicationUser>(manager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };

                // Configure validation logic for passwords
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = true,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = true,
                };

                // Configure user lockout defaults
                manager.UserLockoutEnabledByDefault = true;
                manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                manager.MaxFailedAccessAttemptsBeforeLockout = 5;

                // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
                // You can write your own provider and plug it in here.
                manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
                {
                    MessageFormat = "Your security code is {0}"
                });
                manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
                {
                    Subject = "Security Code",
                    BodyFormat = "Your security code is {0}"
                });
                manager.EmailService = new EmailService();
                manager.SmsService = new SmsService();
                var dataProtectionProvider = options.DataProtectionProvider;
                if (dataProtectionProvider != null)
                {
                    manager.UserTokenProvider =
                        new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
                }
                return manager;
            }
        }

        public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
        {
            public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
                : base(userManager, authenticationManager)
            {
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


        public class ApplicationAuthenticationManager : IAuthenticationManager
        {
            public IEnumerable<AuthenticationDescription> GetAuthenticationTypes()
            {
                throw new NotImplementedException();
            }

            public IEnumerable<AuthenticationDescription> GetAuthenticationTypes(Func<AuthenticationDescription, bool> predicate)
            {
                throw new NotImplementedException();
            }

            public Task<AuthenticateResult> AuthenticateAsync(string authenticationType)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<AuthenticateResult>> AuthenticateAsync(string[] authenticationTypes)
            {
                throw new NotImplementedException();
            }

            public void Challenge(AuthenticationProperties properties, params string[] authenticationTypes)
            {
                throw new NotImplementedException();
            }

            public void Challenge(params string[] authenticationTypes)
            {
                throw new NotImplementedException();
            }

            public void SignIn(AuthenticationProperties properties, params ClaimsIdentity[] identities)
            {
                throw new NotImplementedException();
            }

            public void SignIn(params ClaimsIdentity[] identities)
            {
                throw new NotImplementedException();
            }

            public void SignOut(params string[] authenticationTypes)
            {
                throw new NotImplementedException();
            }

            public ClaimsPrincipal User { get; set; }
            public AuthenticationResponseChallenge AuthenticationResponseChallenge { get; set; }
            public AuthenticationResponseGrant AuthenticationResponseGrant { get; set; }
            public AuthenticationResponseRevoke AuthenticationResponseRevoke { get; set; }
        }
    }
}