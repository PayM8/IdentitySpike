
namespace Spike.Web.Controllers
{
    using System;
    using Microsoft.AspNet.Identity.Owin;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Contracts.Security;
    using Providers.WCF.Proxy;
    using Models;
    using Security;
    
    public class AccountController : ControllerBase
    {
        private readonly IUserStore<CommonIdentity> _store = new UserStore<CommonIdentity>(ProviderFactory.CreateSecurityProvider());
        
        public ActionResult UserLogin(string userName, string password)
        {
            var task = this.UserManager.PasswordSignIn(userName, password, false, false);

            var model = new LoginModel
            {
                UserName = userName
            };

            switch (task.Result)
            {
                case SignInStatus.Success:
                    model.IsLoggedIn = true;
                    break;
                case SignInStatus.LockedOut:
                    model.Result = "Locked out";
                    break;
                case SignInStatus.RequiresVerification:
                    //  RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                    break;
                case SignInStatus.Failure:
                    break;
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }

            return View(model);
        }

        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new CommonIdentity { UserName = model.Email, Email = model.Email };
            var result = new UserManager<CommonIdentity>(_store).CreateAsync(user, model.Password);

            if (result.Result.Succeeded)
            {
                //  await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                return RedirectToAction("Index", "Home");
            }

            throw new Exception("Unable to register user.");
        }
    }
}