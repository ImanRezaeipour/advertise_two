using System;
using Advertise.Core.Domains.Users;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Advertise.Service.Services.Users
{

    public class SignInService : SignInManager<User, Guid>, ISignInService
    {
        #region Private Fields

        private readonly IAuthenticationManager _authenticationManager;
        private readonly IUserService _userService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="authenticationManager"></param>
        public SignInService(UserService userService, IAuthenticationManager authenticationManager)
            : base(userService, authenticationManager)
        {
            _userService = userService;
            _authenticationManager = authenticationManager;
        }

        #endregion Public Constructors
    }
}