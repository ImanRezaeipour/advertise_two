using Advertise.Core.Constants;
using Advertise.Core.Models.CompanyConversation;
using Advertise.Service.Factories.Companies;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Core.Models.ProductComment;
using Advertise.Web.Framework.Extensions;

namespace Advertise.Web.Controllers
{

    public partial class CompanyConversationController : BaseController
    {
        #region Private Fields

        private readonly ICompanyConversationFactory _companyConversationFactory;
        private readonly ICompanyConversationService _companyConversationService;

        #endregion Private Fields

        #region Public Constructors

   
        public CompanyConversationController(ICompanyConversationService companyConversationService, ICompanyConversationFactory companyConversationFactory)
        {
            _companyConversationService = companyConversationService;
            _companyConversationFactory = companyConversationFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanCompanyConversationCreate)]
        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "ایجاد", Key = "Profile_Conversation_Create")]
        public virtual async Task<ActionResult> Create()
        {
            return View(MVC.CompanyConversation.Views._Create);
        }


        [MvcAuthorize(PermissionConst.CanCompanyConversationCreateAjax)]
        public virtual async Task<JsonResult> CreateAjax(CompanyConversationCreateViewModel viewModel)
        {
            if (viewModel.Body == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyConversationService.CreateByViewModelAsync(viewModel);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

      

        [MvcAuthorize(PermissionConst.CanCompanyConversationDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));

            await _companyConversationService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<JsonResult> DetailAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var viewModel = await _companyConversationService.GetListByUserIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(RenderRazorViewToString(MVC.CompanyConversation.Views._List, viewModel)), JsonRequestBehavior.AllowGet);
        }

     
        [MvcAuthorize(PermissionConst.CanCompanyConversationList)]
        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "ویرایش", Key = "Panel_Conversation_List")]
        public virtual async Task<ActionResult> List(CompanyConversationSearchRequest request)
        {
            var viewModel = await _companyConversationFactory.PrepareListViewModelAsync(request);
            return View(MVC.CompanyConversation.Views.List, viewModel);
        }

     
        [MvcAuthorize(PermissionConst.CanCompanyConversationMyList)]
        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "ویرایش", Key = "Profile_Conversation_List")]
        public virtual async Task<ActionResult> MyList(CompanyConversationSearchRequest request)
        {
            var viewModel = await _companyConversationFactory.PrepareListViewModelAsync(request ,true);
            return View(MVC.CompanyConversation.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}