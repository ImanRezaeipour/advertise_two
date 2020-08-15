using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Advertise.Service.Services.WebContext;
using Microsoft.Owin.Security;

namespace Advertise.Service.Services.Users
{
    /// <summary>
    /// Based from  HttpContext.Current.GetOwinContext().Authentication
    /// </summary>
    public class AuthenticationManager : IAuthenticationManager
    {
        #region Private Fields

        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="webContextManager"></param>
        public AuthenticationManager(IWebContextManager webContextManager)
        {
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public AuthenticationResponseChallenge AuthenticationResponseChallenge
        {
            get { return _webContextManager.CurrentUserAuthenticate.AuthenticationResponseChallenge; }
            set { _webContextManager.CurrentUserAuthenticate.AuthenticationResponseChallenge = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public AuthenticationResponseGrant AuthenticationResponseGrant
        {
            get { return _webContextManager.CurrentUserAuthenticate.AuthenticationResponseGrant; }
            set { _webContextManager.CurrentUserAuthenticate.AuthenticationResponseGrant = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public AuthenticationResponseRevoke AuthenticationResponseRevoke
        {
            get { return _webContextManager.CurrentUserAuthenticate.AuthenticationResponseRevoke; }
            set { _webContextManager.CurrentUserAuthenticate.AuthenticationResponseRevoke = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public ClaimsPrincipal User
        {
            get { return _webContextManager.CurrentUserAuthenticate.User; }
            set { _webContextManager.CurrentUserAuthenticate.User = value; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="authenticationType"></param>
        /// <returns></returns>
        public Task<AuthenticateResult> AuthenticateAsync(string authenticationType)
        {
            return _webContextManager.CurrentUserAuthenticate.AuthenticateAsync(authenticationType);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="authenticationTypes"></param>
        /// <returns></returns>
        public Task<IEnumerable<AuthenticateResult>> AuthenticateAsync(string[] authenticationTypes)
        {
            return _webContextManager.CurrentUserAuthenticate.AuthenticateAsync(authenticationTypes);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="authenticationTypes"></param>
        public void Challenge(AuthenticationProperties properties, params string[] authenticationTypes)
        {
            _webContextManager.CurrentUserAuthenticate.Challenge(properties, authenticationTypes);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="authenticationTypes"></param>
        public void Challenge(params string[] authenticationTypes)
        {
            _webContextManager.CurrentUserAuthenticate.Challenge(authenticationTypes);
        }


        public IEnumerable<AuthenticationDescription> GetAuthenticationTypes()
        {
            return _webContextManager.CurrentUserAuthenticate.GetAuthenticationTypes();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<AuthenticationDescription> GetAuthenticationTypes(Func<AuthenticationDescription, bool> predicate)
        {
            return _webContextManager.CurrentUserAuthenticate.GetAuthenticationTypes(predicate);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="identities"></param>
        public void SignIn(AuthenticationProperties properties, params ClaimsIdentity[] identities)
        {
            _webContextManager.CurrentUserAuthenticate.SignIn(properties, identities);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="identities"></param>
        public void SignIn(params ClaimsIdentity[] identities)
        {
            _webContextManager.CurrentUserAuthenticate.SignIn(identities);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="authenticationTypes"></param>
        public void SignOut(AuthenticationProperties properties, params string[] authenticationTypes)
        {
            _webContextManager.CurrentUserAuthenticate.SignOut(properties, authenticationTypes);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="authenticationTypes"></param>
        public void SignOut(params string[] authenticationTypes)
        {
            _webContextManager.CurrentUserAuthenticate.SignOut(authenticationTypes);
        }

        #endregion Public Methods
    }
}