// <copyright file="BasicAuthentication.cs" company="PayM8">
// Copyright (c) 2016 PayM8. All rights reserved.
// </copyright>
// <summary>Implements the basic authentication class</summary>
namespace Spike.Security.Authentication.BasicAuth.MVC
{
    using System;
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;
    using System.ServiceModel;

    /// <summary>
    /// A basic authentication.
    /// </summary>
    public class BasicAuthentication : UserNamePasswordValidator
    {
        /// <summary>
        /// When overridden in a derived class, validates the specified username and password.
        /// </summary>
        /// <param name="userName">The username to validate.</param>
        /// <param name="password">The password to validate.</param>
        public override void Validate(string userName, string password)
        {
            if (userName != "user" || password != "banana")
            {
                throw new FaultException("Authentication Failed");
            }
            return;
        }
    }
}
