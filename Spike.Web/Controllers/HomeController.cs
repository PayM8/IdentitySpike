
using Spike.Web.Models;

namespace Spike.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOption(string option)
        {
            var model = new MultiChoiceResult()
            {
                Result = string.Format("Test results for [{0}]", option) 
            };

            return View("GetOption", model);
        }
    }
}
