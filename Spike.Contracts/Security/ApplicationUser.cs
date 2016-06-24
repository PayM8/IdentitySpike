
namespace Spike.Contracts.Security
{
    using System;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;
    using Users;

    public class ApplicationUser : IUser<string>
    {
        public DateTime CreateDate { get; set; }
        public ApplicationUser()
        {
            CreateDate = DateTime.Now;           
        }

        public string Id { get; set; }
        public IdentityType IdentityType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public IEnumerable<UserRole> Roles { get; set; }
    }
}