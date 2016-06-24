
namespace Spike.Security.Models
{
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Contracts.Security;

    public class CustomUserManager : UserManager<ApplicationUser>
    {
        public CustomUserManager()
            : base(new UserStore<ApplicationUser>())
        {            
            //We can retrieve Old System Hash Password and can encypt or decrypt old password using custom approach.
	        //When we want to reuse old system password as it would be difficult for all users to initiate pwd change as per Idnetity Core hashing.
            this.PasswordHasher = new OldSystemPasswordHasher();           
        }
       
        public override Task<ApplicationUser> FindAsync(string userName, string password)
        {
            var taskInvoke = Task<ApplicationUser>.Factory.StartNew(() =>
                {
                    //First Verify Password...
                    var result = this.PasswordHasher.VerifyHashedPassword(userName, password);
                    if (result != PasswordVerificationResult.SuccessRehashNeeded) return null;

                    //Return User Profile Object...
                    //So this data object will come from Database we can write custom ADO.net to retrieve details/
                    var applicationUser = new ApplicationUser
                    {
                        UserName = "san"
                    
                    };

                    return applicationUser;
                });

            return taskInvoke;
        }      
    }

    /// <summary>
    /// Use Custom approach to verify password
    /// </summary>
    public class OldSystemPasswordHasher : PasswordHasher
    {
        public override string HashPassword(string password)
        {
            return base.HashPassword(password);
        }

        public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {

            //Here we will place the code of password hashing that is there in our current solucion.This will take cleartext anad hash
	        //Just for demonstration purpose I always return true.	
            if (true)
            {
                return PasswordVerificationResult.SuccessRehashNeeded;
            }
            else
            {
                return PasswordVerificationResult.Failed;
            }
        }
    }
}