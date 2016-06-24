
namespace Spike.Adapters.StubData
{
    using System.Collections.Generic;
    using Entities;
    using Contracts.Security;
    using Contracts.Users;

    public class UserWaldo
    {
        public static IEnumerable<UserEntity> InitUsers()
        {
            var users = new List<UserEntity> {Marius, Rob, Fred};

            return users;
        }

        private static readonly UserEntity Marius = new UserEntity
        {
            Id = 1,
            IdentityType = IdentityType.InternalUser,
            UserName = "marius",
            Password = "password",
            Roles = new List<UserRole>
            {
                UserRole.Basic,
                UserRole.Admin,
                UserRole.SuperUser
            }
        };

        private static readonly UserEntity Rob = new UserEntity
        {
            Id = 1,
            IdentityType = IdentityType.InternalUser,
            UserName = "rob",
            Password = "password",
            Roles = new List<UserRole>
            {
                UserRole.Basic
            }
        };

        private static readonly UserEntity Fred = new UserEntity
        {
            Id = 1,
            IdentityType = IdentityType.InternalUser,
            UserName = "fred",
            Password = "password",
            Roles = new List<UserRole>
            {
                UserRole.Basic,
                UserRole.Admin
            }
        };
    }
}
