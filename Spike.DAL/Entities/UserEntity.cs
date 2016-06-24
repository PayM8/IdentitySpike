
namespace Spike.Adapters.Entities
{
    using System.Collections.Generic;
    using Contracts.Security;
    using Contracts.Users;

    public class UserEntity
    {
        public UserEntity()
        {
            this.Roles = new List<UserRole>();
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public IdentityType IdentityType { get; set; }

        public List<UserRole> Roles { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}
