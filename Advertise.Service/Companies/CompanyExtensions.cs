using Advertise.Service.Services.WebContext;
using System;
using System.Web;
using Advertise.Core.Infrastructure.DependencyManagement;
using Advertise.Service.Services.Permissions;

namespace Advertise.Service.Services.Companies
{

    public static class CompanyExtensions
    {
        #region Public Properties

        public static ICompanyAttachmentService CompanyAttachmentService { get; set; } = ContainerManager.Container.GetInstance<ICompanyAttachmentService>();
        public static ICompanyImageService CompanyImageService { get; set; } = ContainerManager.Container.GetInstance<ICompanyImageService>();
        public static IWebContextManager ContextManager { get; set; } = ContainerManager.Container.GetInstance<IWebContextManager>();

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyAttachmentId"></param>
        /// <returns></returns>
        public static bool CanEditThisCompanyAttachment(this Guid companyAttachmentId)
        {
            if (HttpContext.Current.User.IsInRole(PermissionConst.CanCompanyImageEdit))
                return true;

            var companyImage = CompanyAttachmentService.
                GetById(companyAttachmentId);
            if (HttpContext.Current.User.IsInRole(PermissionConst.CanCompanyImageMyEdit) &&
                companyImage.CreatedById == ContextManager.CurrentUserId)
                return true;

            return false;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyImageId"></param>
        /// <returns></returns>
        public static bool CanEditThisCompanyImage(this Guid companyImageId)
        {
            if (HttpContext.Current.User.IsInRole(PermissionConst.CanCompanyImageEdit))
                return true;

            var companyImage = CompanyImageService.GetById(companyImageId);
            if (HttpContext.Current.User.IsInRole(PermissionConst.CanCompanyImageMyEdit) &&
                companyImage.CreatedById == ContextManager.CurrentUserId)
                return true;

            return false;
        }

        #endregion Public Methods
    }
}