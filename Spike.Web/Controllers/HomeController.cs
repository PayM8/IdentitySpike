
namespace Spike.Web.Controllers
{
    using System.Web.Mvc;
    using Models;
    using System.Linq;
    using Providers.WCF.Proxy;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           var provider = ProviderFactory.CreateSecurityProvider();
           var user = provider.GetUser("marius");

            var homeModel = new Home()
            {
                UserName = user.UserName
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
