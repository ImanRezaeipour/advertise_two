using Advertise.Core.Constants;
using Advertise.Core.Models.CompanyFollow;
using Advertise.Service.Factories.Companies;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class CompanyFollowController : BaseController
    {

        #region Private Fields

        private readonly ICompanyFollowFactory _companyFollowFactory;
        private readonly ICompanyFollowService _companyFollowService;

        #endregion Private Fields

        #region Public Constructors

   
        public CompanyFollowController(ICompanyFollowService companyFollowService, ICompanyFollowFactory companyFollowFactory)
        {
            _companyFollowService = companyFollowService;
            _companyFollowFactory = companyFollowFactory;
        }

        #endregion Public Constructors

        #region Public Methods

        public virtual async Task<JsonResult> CountAjax(Guid? companyId)
        {
            if (companyId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var count = await _companyFollowService.CountAsync(companyId.Value);
            return Json(AjaxResult.Succeeded(count), JsonRequestBehavior.AllowGet);
        }


        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "لیست فالورهای من", Key = "Profile_CompanyFollow_MyFollowerList")]
        public virtual async Task<ActionResult> MyFollowerList()
        {
            var viewModel = await _companyFollowFactory.PrepareListViewModelAsync(true, true);
            return View(MVC.CompanyFollow.Views.MyFollowerList, viewModel);
        }


        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "لیست فالوهای من", Key = "Profile_CompanyFollow_MyFollowList")]
        [MvcAuthorize(PermissionConst.CanCompanyFollowMyFollowList)]
        public virtual async Task<ActionResult> MyFollowList()
        {
            var viewModel = await _companyFollowFactory.PrepareListViewModelAsync(true);
            return View(MVC.CompanyFollow.Views.MyFollowList, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanCompanyFollowMyFollowList)]
        public virtual async Task<JsonResult> MyFollowListMoreAjax(CompanyFollowSearchRequest request)
        {
            if (request == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var viewModel = await _companyFollowService.ListByRequestAsync(request);
            return Json(viewModel.CompanyFollows?.Any() == true ? AjaxResult.Succeeded(PartialView(MVC.CompanyFollow.Views._FollowListMore, viewModel)) : AjaxResult.Failed(AjaxErrorStatus.NoMoreInfo), JsonRequestBehavior.AllowGet);
        }

      
        [MvcAuthorize(PermissionConst.CanCompanyFollowMyIsFollowAjax)]
        public virtual async Task<JsonResult> MyIsFollowAjax(Guid? companyId)
        {
            if (companyId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var isFollow = await _companyFollowService.IsFollowByCurrentUserAsync(companyId.Value);
            return Json(AjaxResult.Succeeded(isFollow), JsonRequestBehavior.AllowGet);
        }

      
        [MvcAuthorize(PermissionConst.CanCompanyFollowMyToggleFollowAjax)]
        public virtual async Task<JsonResult> MyToggleAjax(Guid? companyId)
        {
            if (companyId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyFollowService.ToggleFollowCurrentUserByCompanyIdAsync(companyId.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}