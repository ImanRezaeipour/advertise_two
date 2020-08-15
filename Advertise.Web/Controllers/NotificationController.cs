using Advertise.Core.Constants;
using Advertise.Core.Models.Notification;
using Advertise.Service.Factories.Notifications;
using Advertise.Service.Services.Notifications;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class NotificationController : BaseController
    {
        #region Private Fields

        private readonly INotificationFactory _notificationFactory;
        private readonly INotificationService _notificationService;

        #endregion Private Fields

        #region Public Constructors


        public NotificationController(INotificationService notificationService, INotificationFactory notificationFactory)
        {
            _notificationService = notificationService;
            _notificationFactory = notificationFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanNotificationDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _notificationService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

  
        [MvcAuthorize(PermissionConst.CanNotificationMyList)]
        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "اعلانات", Key = "Profile_Notification_ListMe")]
        public virtual async Task<ActionResult> MyList(NotificationSearchRequest request)
        {
            var viewModel = await _notificationFactory.PrepareListViewModelAsync(request, true);
            return View(MVC.Notification.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}