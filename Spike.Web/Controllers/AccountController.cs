
using System.Linq;

namespace Spike.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Contracts.Security;
    using Providers.WCF.Proxy;
    using Security.Models;
    using Models;
    
    public class AccountController : ControllerBase
    {
        private readonly IUserStore<ApplicationUser> _store = new UserStore<ApplicationUser>(ProviderFactory.CreateSecurityProvider());

 
        public ActionResult Login(string userName, string password)
        {
            var identity = new ApplicationUser { UserName = userName };
            var loginResult = UserManager.CreateAsync(identity, password);

            var model = new LoginModel
            {
                UserName = userName,
                Result = string.Format("Is Succes: [{0}] Has Errors [{1}]", (loginResult.Result.Succeeded) ? 
                "Yes" : "No", (loginResult.Result.Errors.Any()) ? "Yes" : "No")
            };

            return View(model);
        }

        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = new UserManager<ApplicationUser>(_store).CreateAsync(user, model.Password);

            if (result.Result.Succeeded)
            {
                //  await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                return RedirectToAction("Index", "Home");
            }

            throw new Exception("Unable to register user.");
        }
    }
}