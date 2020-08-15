using Advertise.Core.Domains.Companies;
using Advertise.Core.Domains.Roles;
using Advertise.Core.Domains.Users;
using Advertise.Data.DbContexts;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Advertise.Core.Extensions;

namespace Advertise.Service.Services.WebContext
{

    public class WebContextManager : IWebContextManager
    {
        #region Private Fields

        private readonly IDbSet<Company> _companies;
        private readonly IDbSet<Role> _roles;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<User> _user;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="unitOfWork"></param>
        public WebContextManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _user = unitOfWork.Set<User>();
            _companies = unitOfWork.Set<Company>();
            _roles = unitOfWork.Set<Role>();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public Guid CurrentCategoryId => _companies.AsNoTracking().Where(m => m.CreatedById == CurrentUserId).Select(m => m.CategoryId).SingleOrDefault() ?? Guid.Empty;

        /// <summary>
        ///
        /// </summary>
        public Guid CurrentCompanyId => _companies.AsNoTracking().Where(m => m.CreatedById == CurrentUserId).Select(m => m.Id).SingleOrDefault();

        /// <summary>
        ///
        /// </summary>
        public HttpContext CurrentContext => HttpContext.Current;

        /// <summary>
        ///
        /// </summary>
        public string CurrentRequestBrowser => HttpContext.Current.Request.GetBrowser();

        /// <summary>
        ///
        /// </summary>
        public string CurrentRequestIp => HttpContext.Current.Request.GetIp();

        /// <summary>
        ///
        /// </summary>
        public Uri CurrentRequestUrl => HttpContext.Current.Request.Url;

        /// <summary>
        ///
        /// </summary>
        public Guid CurrentRoleId => _user.AsNoTracking().Where(m => m.Id == CurrentUserId).Select(m => m.Roles.Select(r => r.RoleId).FirstOrDefault()).SingleOrDefault();

        /// <summary>
        ///
        /// </summary>
        public IAuthenticationManager CurrentUserAuthenticate => HttpContext.Current.GetOwinContext().Authentication;

        /// <summary>
        ///
        /// </summary>
        public Guid CurrentUserId => HttpContext.Current.User.Identity.IsAuthenticated ? Guid.Parse(HttpContext.Current.User.Identity.GetUserId()) : Guid.Empty;

        #endregion Public Properties
    }
}