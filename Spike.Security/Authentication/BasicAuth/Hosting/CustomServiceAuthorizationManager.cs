
namespace Spike.Security.Authentication.BasicAuth.Hosting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ServiceModel;

    class CustomServiceAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            return base.CheckAccessCore(operationContext);
        }
    }
}
