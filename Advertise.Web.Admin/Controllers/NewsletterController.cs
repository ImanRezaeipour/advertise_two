using Advertise.Core.Constants;
using Advertise.Core.Models.Newsletter;
using Advertise.Service.Factories.Newsletters;
using Advertise.Service.Services.Newsletters;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Validators.Newsletters;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class NewsletterController : Controller
    {
        #region Private Fields

        private readonly INewsletterFactory _newsletterFactory;
        private readonly INewsletterService _newsletterService;

        #endregion Private Fields

        #region Public Constructors

       
        public NewsletterController(INewsletterService newsletterService,  INewsletterFactory newsletterFactory)
        {
            _newsletterService = newsletterService;
            _newsletterFactory = newsletterFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcSiteMapNode(ParentKey = "Panel_Newsletter_List", Title = "ایجاد خبرنامه", Key = "Panel_Newsletter_New")]
        [ImportModelData(typeof(NewsletterCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _newsletterFactory.PrepareCreateViewModelAsync();
            return View(MVC.Newsletter.Views.Create, viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(NewsletterCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _newsletterService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Newsletter.List());
        }


        [MvcAuthorize(PermissionConst.CanNewsletterDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _newsletterService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "خبرنامه ها", Key = "Panel_Newsletter_List")]
        [MvcAuthorize(PermissionConst.CanNewsletterList)]
        public virtual async Task<ActionResult> List(NewsletterSearchRequest request)
        {
            var viewModel = await _newsletterFactory.PrepareListViewModelAsync(request);
            return View(MVC.Newsletter.Views.List,viewModel);
        }


        public virtual async Task<JsonResult> SubscribeAjax(NewsletterCreateViewModel viewModel)
        {
            if (viewModel == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);


            await _newsletterService.SubscribeByViewModelAsync(viewModel);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}