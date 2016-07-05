
namespace Spike.Providers.Security
{
    using Adapters.Entities;
    using Contracts.Security;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class Mapper
    {
        public static UserEntity Map(this CommonIdentity original)
        {
            if (original == null)
            {
                return new UserEntity();
            }

            var id = string.IsNullOrEmpty(original.Id) ? 0 : int.Parse(original.Id);
            var convertedRoles = (original.Roles ?? new List<IdentityRole>()).ToList();
            
            return new UserEntity
            {
                Id = id,
                UserName = original.UserName,
                Password = original.Password,
                IdentityType = original.IdentityType,
                Roles = convertedRoles
            };
        }

        public static CommonIdentity Map(this UserEntity original)
        {
            if (original == null)
            {
                return new CommonIdentity();
            }

            var id = original.Id.ToString();
            var convertedRoles = (original.Roles ?? new List<IdentityRole>()).ToList();

            return new CommonIdentity
            {
                Id = id,
                UserName = original.UserName,
                Password = original.Password,
                IdentityType = original.IdentityType,
                Roles = convertedRoles
            };
        }
    }
}
