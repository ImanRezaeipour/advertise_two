using Advertise.Core.Constants;
using Advertise.Core.Models.UserViolation;
using Advertise.Service.Factories.Users;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Users;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{
    public partial class UserViolationController : BaseController
    {
        #region Private Fields

        private readonly IUserViolationFactory _userViolationFactory;
        private readonly IUserViolationService _userViolationService;

        #endregion Private Fields

        #region Public Constructors


        public UserViolationController(IUserViolationService userViolationService, IUserViolationFactory userViolationFactory)
        {
            _userViolationService = userViolationService;
            _userViolationFactory = userViolationFactory;
        }

        #endregion Public Constructors

        #region Public Methods



        [MvcAuthorize(PermissionConst.CanUserViolationDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _userViolationService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }





        #endregion Public Methods
    }
}