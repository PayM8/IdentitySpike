
namespace Spike.Web.Controllers
{
    using System.Web.Mvc;
    using Models;
    using System.Linq;
 
    public class HomeController : ControllerBase
    {

        public ActionResult Index()
        {
            //var user = new ApplicationUser() { UserName = "Marius"};
           // var result =  UserManager.CreateAsync(user, user.Password);

            var homeModel = new Home()
            {
                LoginModel = new LoginModel { UserName = "marius" }
            };

            return View(homeModel);
        }

        
        public ActionResult GetOption(string option)
        {
            var output = string.Empty;

            switch (option)
            {
                case "a" :
                    output = BookWorker.AddBullsEye().ToString();
                    break;
                case "b" :
                    output = BookWorker.AddFiveDysfunctions().ToString();
                    break;
                case "c" :
                    output = BookWorker.GetBullsEyeBook().ToString();
                    break;
                case "d" :
                    output = BookWorker.GetAllBooks()
                        .Aggregate(output, (current, book) => string.Format("{0}{1}; ", current, book));
                    break;
            }
            
            var model = new MultiChoiceResult()
            {
                Result = output
            };

            return View("GetOption", model);
        }
    }
}
