using Advertise.Core.Constants;
using Advertise.Core.Models.Product;
using Advertise.Core.Types;
using Advertise.Service.Factories.Products;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Products;
using Advertise.Service.Validators.Product;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.Mvc;
using Advertise.Core.Models.Common;

namespace Advertise.Web.Controllers
{

    public partial class ProductController : BaseController
    {
        #region Private Fields

        private readonly IProductFactory _productFactory;
        private readonly IProductService _productService;

        #endregion Private Fields

        #region Public Constructors

        public ProductController(IProductService productService, IProductFactory productFactory)
        {
            _productService = productService;
            _productFactory = productFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [MvcAuthorize(PermissionConst.CanProductCreate)]
        [ClearModelData(typeof(ProductCreateViewModel))]
        public virtual async Task<ActionResult> Create(ProductCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _productService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Product.Create());
        }


        [MvcAuthorize(PermissionConst.CanProductCreate)]
        [MvcSiteMapNode(ParentKey = "Profile_Product_ListMe", Title = "ایجاد", Key = "Profile_Product_New")]
        [ImportModelData(typeof(ProductCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _productFactory.PrepareCreateViewModelAsync();
            return View(MVC.Product.Views.Create, viewModel);
        }


        [ImportModelData(typeof(ProductBulkCreateViewModel))]
        public virtual async Task<ActionResult> BulkCreate()
        {
            var viewModel = await _productFactory.PrepareBulkCreateViewModelAsync();
            return View(MVC.Product.Views.BulkCreate, viewModel);
        }


        [HttpPost]
        public virtual async Task<ActionResult> BulkCreate(ProductBulkCreateViewModel viewModel)
        {
            if(viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            await _productService.CreateBulkByViewModelAsync(viewModel);
            return RedirectToAction(MVC.Product.MyList());
        }


        [ImportModelData(typeof(ProductBulkEditViewModel))]
        public virtual async Task<ActionResult> BulkEdit()
        {
            var viewModel = await _productFactory.PrepareBulkEditViewModelAsync();
            return View(MVC.Product.Views.BulkEdit, viewModel);
        }


        [HttpPost]
        [ClearModelData(typeof(ProductBulkEditViewModel))]
        public virtual async Task<ActionResult> BulkEdit(ProductBulkEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            await _productService.EditBulkByViewModelAsync(viewModel);
            return RedirectToAction(MVC.Product.MyList());
        }


        [HttpPost]
        [MvcAuthorize(PermissionConst.CanProductDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(string id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _productService.DeleteByCodeAsync(id);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }



        [MvcSiteMapNode(ParentKey = "Panel_Product_List", Title = "ویرایش", Key = "Panel_Product_Edit", PreservedRouteParameters = "code")]
        [MvcAuthorize(PermissionConst.CanProductEdit)]
        [ImportModelData(typeof(ProductEditViewModel))]
        public virtual async Task<ActionResult> Edit(string code)
        {
            if (code == null)
                return View(MVC.Error.Views.NotFound);

            var viewModel = await _productFactory.PrepareEditViewModelAsync(code);
            return viewModel != null ? View(MVC.Product.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        public virtual async Task<ActionResult> EditCatalog(string code)
        {
            if (code == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _productFactory.PrepareEditCatalogViewModelAsync(code);
            ViewBag.IsEditCatalog = true;
            return View(MVC.Product.Views.BulkEdit, viewModel);
        }


        [HttpPost]
        public virtual async Task<ActionResult> EditCatalog(ProductEditCatalogViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _productService.EditCatalogByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Product.MyList());
        }


        [MvcAuthorize(PermissionConst.CanProductEditApprove)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> EditApprove(ProductEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

           
            await _productService.EditApproveByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Product.List());
        }


        [MvcAuthorize(PermissionConst.CanProductEditReject)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [ImportModelData(typeof(ProductEditViewModel))]
        public virtual async Task<ActionResult> EditReject(ProductEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

           await _productService.EditRejectByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Product.List());
        }


        public virtual async Task<JsonResult> GetCountAjax(ProductSearchRequest request)
        {
            request.State = StateType.Approved;
            var count = await _productService.CountByRequestAsync(request);
            return Json(AjaxResult.Succeeded(count), JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<JsonResult> GetCountByCategoryIdAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var result = await _productService.CountByCategoryIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(result), JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<JsonResult> GetCountByCompanyIdAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var count = await _productService.CountByCompanyIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(count), JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<JsonResult> GetFileAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));

            var file = await _productService.GetFileAsFineUploaderModelByIdAsync(id.Value);
            return Json(file, JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<JsonResult> GetFilesAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));

            var files = await _productService.GetFilesAsFineUploaderModelByIdAsync(id.Value);
            return Json(files, JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanProductList)]
        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "محصولات", Key = "Panel_Product_List")]
        public virtual async Task<ActionResult> List(ProductSearchRequest request)
        {
            var viewModel = await _productFactory.PrepareListViewModelAsync(request);
            return View(MVC.Product.Views.List, viewModel);
        }


        public virtual async Task<JsonResult> ListMoreAjax(ProductSearchRequest request)
        {
            request.State = StateType.Approved;
            var viewModel = await _productFactory.PrepareListViewModelAsync(request);
            return Json(viewModel != null ? AjaxResult.Succeeded(RenderRazorViewToString(MVC.Product.Views._ListMore, viewModel)) : AjaxResult.Failed(AjaxErrorStatus.InternalServerError), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [MvcAuthorize(PermissionConst.CanProductMyDeleteAjax)]
        public virtual async Task<JsonResult> MyDeleteAjax(string id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _productService.DeleteByCodeAsync(id, true);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcSiteMapNode(ParentKey = "Profile_Product_ListMe", Title = "ویرایش", Key = "Profile_Product_MyEdit", PreservedRouteParameters = "code")]
        [MvcAuthorize(PermissionConst.CanProductMyEdit)]
        [ImportModelData(typeof(ProductEditViewModel))]
        public virtual async Task<ActionResult> MyEdit(string code)
        {
            if (code == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _productFactory.PrepareEditViewModelAsync(code, true);
            return viewModel != null ? View(MVC.Product.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanProductMyEdit)]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> MyEdit(ProductEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

           await _productService.EditByViewModelAsync(viewModel, true);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Product.MyList());
        }


        [MvcAuthorize(PermissionConst.CanProductMyList)]
        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = " محصولات من", Key = "Profile_Product_ListMe")]
        public virtual async Task<ActionResult> MyList(ProductSearchRequest request)
        {
            var viewModel = await _productFactory.PrepareListViewModelAsync(request, true);
            return View(MVC.Product.Views.List, viewModel);
        }


        public virtual async Task<JsonResult> ProductReviewListAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var viewModel = await _productFactory.PrepareReviewListViewModelAsync(id.Value);
            return Json(viewModel != null ? AjaxResult.Succeeded(PartialView(MVC.Product.Views._ProductReviewList, viewModel)) : AjaxResult.Failed(AjaxErrorStatus.InternalServerError), JsonRequestBehavior.AllowGet);
        }



        [MvcSiteMapNode(ParentKey = "Public_Home_Index", Title = "جزئیات", Key = "Public_Product_Detail", PreservedRouteParameters = "code")]
        public virtual async Task<ActionResult> Detail(string code, string slug = "")
        {
            if (code == null)
                return View(MVC.Error.Views.BadRequest);


            var viewModel = await _productFactory.PrepareDetailViewModelAsync(code);
            return viewModel == null ? View(MVC.Error.Views.InternalServerError) : View(MVC.Product.Views.Detail, viewModel);
        }


        public virtual async Task<ActionResult> Search(string id, ProductSearchRequest request = null)
        {
            var requestSafe = request ?? new ProductSearchRequest();
            requestSafe.QueryString = Request.Url?.Query.UrlDecode();
            requestSafe.CategoryAlias = id ?? "Category-All";
            requestSafe.GroupBy = product => product.Code;
            requestSafe.PageSize = PageSize.Count60;
            var viewModel = await _productFactory.PrepareSearchViewModelAsync(requestSafe);
            return viewModel != null ? View(MVC.Product.Views.Search, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        public virtual async Task<JsonResult> ApproveAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _productService.SetStateByIdAsync(id.Value, StateType.Approved);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        public virtual async Task<JsonResult> RejectAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _productService.SetStateByIdAsync(id.Value, StateType.Rejected);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}