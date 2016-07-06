// <copyright file="BasicAuthentication.cs" company="PayM8">
// Copyright (c) 2016 PayM8. All rights reserved.
// </copyright>
// <summary>Implements the basic authentication class</summary>
namespace Spike.Security.Authentication.BasicAuth.Rest
{
    using System;
    using System.Linq;
    using System.Web.Http.Filters;

    /// <summary>
    /// A basic authentication.
    /// </summary>
    public class BasicAuthentication : ActionFilterAttribute
    {
        /// <summary>
        /// Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Contains("Authorization"))
            {
                var auth = actionContext.Request.Headers.GetValues("Authorization").ToList()[0];
                var cred = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(auth.Substring(6))).Split(':');
                var username = cred[0];
                var password = cred[1];
                return;
            }
            actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=SpikeReal");
        }
    }
}
