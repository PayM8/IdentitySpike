// <copyright file="BasicAuthentication.cs" company="PayM8">
// Copyright (c) 2016 PayM8. All rights reserved.
// </copyright>
// <summary>Implements the basic authentication class</summary>
namespace Spike.Security.BasicAuth.WCF
{
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;

    /// <summary>
    /// A basic authentication.
    /// </summary>
    public class BasicAuthentication : UserNamePasswordValidator
    {
        /// <summary>
        /// When overridden in a derived class, validates the specified username and password.
        /// </summary>
        /// <exception cref="SecurityTokenValidationException">Thrown when a Security Token Validation error condition occurs.</exception>
        /// <param name="userName">The username to validate.</param>
        /// <param name="password">The password to validate.</param>
        public override void Validate(string userName, string password)
        {
            if (userName == null && password == null)
                throw new SecurityTokenValidationException("Authentication Failed");
        }
    }
}
