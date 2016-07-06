// <copyright file="BasicAuthenticationAttribute.cs" company="PayM8">
// Copyright (c) 2016 PayM8. All rights reserved.
// </copyright>
// <summary>Implements the basic authentication attribute class</summary>
namespace Spike.Security.BasicAuth.MVC
{
    using Spike.Providers;
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Attribute for basic authentication.
    /// </summary>
    public class BasicAuthenticationAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        /// <summary>
        /// Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var currentRequest = actionContext.Request;
            if (currentRequest.Headers.Contains("Authorization"))
            {
                var auth = actionContext.Request.Headers.GetValues("Authorization").FirstOrDefault();
                if (!string.IsNullOrEmpty(auth))
                {
                    var cred = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(auth.Substring(6))).Split(':');
                    var provider = ProviderFactory.CreateSecurityProvider();
                    return;
                }
            }

            actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", @"Basic realm=SpikeRealm");
        }
    }

}
