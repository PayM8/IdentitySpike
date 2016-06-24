
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
            return DatabaseStub.Instance.GetUser(user.Id) != null ?
                new UserEntity() : DatabaseStub.Instance.AddUser(user);
        }

        public static  UserEntity DeleteUser(int id)
        {
           return DatabaseStub.Instance.DeleteUser(id);
        }

        public static UserEntity GetUser(int id)
        {
            return DatabaseStub.Instance.GetUser(id);
        }

        public static void AddUserRole(int userId, UserRole role)
        {
            var user = DatabaseStub.Instance.GetUser(userId);
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
