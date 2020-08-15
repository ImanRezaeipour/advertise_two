using System;
using Microsoft.Owin.Security;

namespace Advertise.Service.Services.WebContext
{
    public interface IWebContextManager
    {
        Guid CurrentUserId { get; }

        /// <summary>
        ///
        /// </summary>
        string CurrentRequestIp { get; }

        /// <summary>
        ///
        /// </summary>
        string CurrentRequestBrowser { get; }

        /// <summary>
        ///
        /// </summary>
        Uri CurrentRequestUrl { get; }

        /// <summary>
        ///
        /// </summary>
        Guid CurrentRoleId { get; }

        /// <summary>
        ///
        /// </summary>
        Guid CurrentCompanyId { get; }

        /// <summary>
        /// 
        /// </summary>
        IAuthenticationManager CurrentUserAuthenticate { get; }

        /// <summary>
        /// 
        /// </summary>
        Guid CurrentCategoryId { get; }
    }
}