
namespace Spike.Adapters
{
    using System;
    using Entities;
    using Contracts.Security;
    using StubData;
    
    public static class SecurityAdapter
    {
        public static UserEntity RegisterUser(UserEntity user)
        {
            return DatabaseStub.Instance.GetUser(user.UserName) != null ?
                new UserEntity() : DatabaseStub.Instance.AddUser(user);
        }

        public static UserEntity DeleteUser(string userName)
        {
            return DatabaseStub.Instance.DeleteUser(userName);
        }

        public static UserEntity GetUser(string userName)
        {
            return DatabaseStub.Instance.GetUser(userName);
        }

        public static void AddUserRole(string userName, IdentityRole role)
        {
            var user = DatabaseStub.Instance.GetUser(userName);
            if (user == null)
            {
                throw new ArgumentException("User does not exist");
            }

            if (user.Roles.Exists(r => r == role)) return;
            user.Roles.Add(role);
            DatabaseStub.Instance.UpdateUser(user);
        }
    }
}
