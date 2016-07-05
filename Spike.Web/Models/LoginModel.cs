
namespace Spike.Web.Models
{
    public class LoginModel
    {
        public LoginModel()
        {
            Result = string.Empty;
            UserName = string.Empty;
        }

        public bool IsLoggedIn { get; set; }

        public string UserName { get; set; }

        public string Result { get; set; }
    }
}