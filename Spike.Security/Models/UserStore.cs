
namespace Spike.Security.Models
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Contracts.Security;

    public class UserStore<TUser> :
        IUserStore<TUser>, IUserPasswordStore<TUser>
        where TUser : ApplicationUser
    {

        public Task CreateAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException();

            // Create user from provider
            return null;
        }

        public Task<TUser> FindByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException();

            // Get User from provider
            return null;
        }

        public Task<TUser> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException("Missing user name");

            // Find user by username
            return null;
        }

        public Task UpdateAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentException("Missing user");

            // Update user object
            return null;
        }

        public Task DeleteAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentException("Missing user");

            // Soft Delete user from provider
            return null;
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

        public void Dispose() {}
    }
}