using System.Web.Http;
using System.Web.Mvc;

namespace Spike.Web.Areas.V01
{
    public class V01AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "V01";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {        
        }
    }
}