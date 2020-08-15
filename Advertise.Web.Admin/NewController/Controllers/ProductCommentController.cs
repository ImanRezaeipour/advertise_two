using Advertise.Core.Constants;
using Advertise.Core.Models.ProductComment;
using Advertise.Service.Factories.Products;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Products;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Core.Types;

namespace Advertise.Web.Controllers
{

    public partial class ProductCommentController : BaseController
    {
        #region Private Fields

        private readonly IProductCommentFactory _productCommentFactory;
        private readonly IProductCommentService _productCommentService;

        #endregion Private Fields

        #region Public Constructors

        public ProductCommentController(IProductCommentService productCommentService, IProductCommentFactory productCommentFactory)
        {
            _productCommentService = productCommentService;
            _productCommentFactory = productCommentFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanProductCommentCreate)]
        [MvcSiteMapNode(ParentKey = "Profile_ProductComment_List", Title = "ایجاد", Key = "Profile_ProductComment_Create")]
        [ImportModelData(typeof(ProductCommentCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            return PartialView(MVC.ProductComment.Views._Create);
        }


        [MvcAuthorize(PermissionConst.CanProductCommentCreateAjax)]
        public virtual async Task<JsonResult> CreateAjax(ProductCommentCreateViewModel viewModel)
        {
            if (viewModel.Body == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _productCommentService.CreateByViewModelAsync(viewModel);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanProductCommentDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _productCommentService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcSiteMapNode(ParentKey = "Panel_ProductComment_List", Title = "ویرایش", Key = "Panel_ProductComment_Edit", PreservedRouteParameters = "id")]
        [ImportModelData(typeof(ProductCommentEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _productCommentFactory.PrepareEditViewModelAsync(id.Value);
            return View(MVC.ProductComment.Views.Edit, viewModel);
        }


        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanProductCommentEditApprove)]
        public virtual async Task<ActionResult> EditApprove(ProductCommentEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _productCommentService.EditApproveByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.ProductComment.List());
        }


        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanProductCommentEditReject)]
        public virtual async Task<ActionResult> EditReject(ProductCommentEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

          
            await _productCommentService.EditRejectByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.ProductComment.List());
        }


        [MvcAuthorize(PermissionConst.CanProductCommentList)]
        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "کامنت ها", Key = "Panel_ProductComment_List")]
        public virtual async Task<ActionResult> List(ProductCommentSearchRequest request)
        {
            var viewModel = await _productCommentFactory.PrepareListViewModelAsync(request);
            return View(MVC.ProductComment.Views.List, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanProductCommentMyDeleteAjax)]
        public virtual async Task<JsonResult> MyDeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _productCommentService.DeleteByIdAsync(id.Value, true);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanProductCommentMyEdit)]
        [MvcSiteMapNode(ParentKey = "Profile_ProductComment_List", Title = "ویرایش", Key = "Profile_ProductComment_Edit", PreservedRouteParameters = "id")]
        public virtual async Task<ActionResult> MyEdit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _productCommentFactory.PrepareEditViewModelAsync(id.Value, true);
            return View(MVC.ProductComment.Views.Edit, viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanProductCommentMyEdit)]
        public virtual async Task<ActionResult> MyEdit(ProductCommentEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

           await _productCommentService.EditByViewModelAsync(viewModel, true);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.ProductComment.MyList());
        }


        [MvcAuthorize(PermissionConst.CanProductCommentMyList)]
        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "کامنت ها", Key = "Profile_ProductComment_List")]
        public virtual async Task<ActionResult> MyList(ProductCommentSearchRequest request)
        {
            var viewModel = await _productCommentFactory.PrepareListViewModelAsync(request, true);
            return View(MVC.ProductComment.Views.List, viewModel);
        }

        public virtual async Task<JsonResult> ApproveAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _productCommentService.SetStateByIdAsync(id.Value, StateType.Approved);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        public virtual async Task<JsonResult> RejectAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _productCommentService.SetStateByIdAsync(id.Value, StateType.Rejected);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}