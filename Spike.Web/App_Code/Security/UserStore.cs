using Microsoft.AspNet.Identity;

namespace Spike.Web.Security
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity.Owin;
    using Contracts.Providers;
    using Contracts.Security;
    using Providers.WCF.Proxy;

    public class UserStore<TUser> :
          IUserStore<TUser>, IUserPasswordStore<TUser>
          where TUser : ApplicationUser
    {
        public ISecurityProvider Provider { get; private set; }

        public UserStore(ISecurityProvider provider)
        {
            this.Provider = provider;
        }

        public Task CreateAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException();

            var newUser = Provider.RegisterUser(user);

            return Task.FromResult<object>(newUser);
        }

        public Task<TUser> FindByIdAsync(string id)
        {
            throw new NotSupportedException("Method Find User By Id is not supported.");
        }

        public Task<TUser> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException("Missing user name");

            var user = Provider.GetUser(userName);

            return Task.FromResult(user as TUser);
        }

        public Task UpdateAsync(TUser user)
        {
            throw new NotSupportedException("Method Find By Id is not supported.");
        }

        public Task DeleteAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentException("Missing user");

            var deletedUser = Provider.DeleteUser(user.UserName);

            return Task.FromResult(deletedUser as TUser);
        }

        public Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult<object>(null);
        }

        public Task<string> GetPasswordHashAsync(TUser user)
        {
            var passwordHash = user.Password;
            return Task.FromResult(passwordHash);
        }

        public Task<bool> HasPasswordAsync(TUser user)
        {
            var hasPassword = string.IsNullOrEmpty(user.Password);
            return Task.FromResult(hasPassword);
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

        public void Dispose() { }
    }

}