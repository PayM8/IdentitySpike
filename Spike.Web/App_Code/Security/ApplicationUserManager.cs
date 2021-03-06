﻿
namespace Spike.Web.Security
{
    using System;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Contracts.Security;
    using Providers.WCF.Proxy;
    using System.Threading.Tasks;

    public class CommonIdentityManager : UserManager<CommonIdentity>
    {
        public CommonIdentityManager(IUserStore<CommonIdentity> store)
            : base(store)
        {
        }

        public static CommonIdentityManager Create(IdentityFactoryOptions<CommonIdentityManager> options, IOwinContext context)
        {
            var securityProvider = ProviderFactory.CreateSecurityProvider();
            var manager = new CommonIdentityManager(new UserStore<CommonIdentity>(securityProvider));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<CommonIdentity>(manager)
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
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<CommonIdentity>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<CommonIdentity>
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
                    new DataProtectorTokenProvider<CommonIdentity>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        public CommonIdentity Find(string userName, string password)
        {
            var provider = ProviderFactory.CreateSecurityProvider();

            var user = provider.GetUser(userName);

            return user;
        }

        public Task<SignInStatus> PasswordSignIn(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            var provider = ProviderFactory.CreateSecurityProvider();

            var user = provider.GetUser(userName);

            //TODO: Expand

            // Verify Password
            const bool verifyPassword = true;

            if (user != null && verifyPassword)
            {
                return Task.FromResult(SignInStatus.Success);
            }

            return Task.FromResult(SignInStatus.Failure);
        }
    }
}