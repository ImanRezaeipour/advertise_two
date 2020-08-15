using Advertise.Core.Models.CompanyOfficial;
using Advertise.Service.Factories.Companies;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Core.Constants;
using Advertise.Web.Framework.Results;

namespace Advertise.Web.Controllers
{
    public partial class CompanyOfficialController : Controller
    {
        #region Private Fields

        private readonly ICompanyOfficialFactory _companyOfficialFactory;
        private readonly ICompanyOfficialService _companyOfficialService;

        #endregion Private Fields

        #region Public Constructors

        public CompanyOfficialController(ICompanyOfficialService companyOfficialService, ICompanyOfficialFactory companyOfficialFactory)
        {
            _companyOfficialService = companyOfficialService;
            _companyOfficialFactory = companyOfficialFactory;
        }

        #endregion Public Constructors

        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [MvcAuthorize(PermissionConst.CanCompanyOfficialApprove)]
        public virtual async Task<ActionResult> EditApprove(CompanyOfficialEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            if (ModelState.IsValid == false)
            {
                this.MessageError("خطایی رخ داده مجدد امتحان کنید");
                return View(MVC.CompanyOfficial.Views.Edit, viewModel);
            }

            await _companyOfficialService.ApproveByViewModelAsync(viewModel);
            this.MessageError("عملیات با موفقیت ثبت شد");
            return View(MVC.Profile.Views.Dashboard);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MvcAuthorize(PermissionConst.CanCompanyOfficialCreate)]
        public virtual async Task<ActionResult> Create()
        {
            return View(MVC.CompanyOfficial.Views.Create);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [MvcAuthorize(PermissionConst.CanCompanyOfficialCreate)]
        public virtual async Task<ActionResult> Create(CompanyOfficialCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            if (ModelState.IsValid == false)
            {
                this.MessageError("خطایی رخ داده مجدد امتحان کنید");
                return View(MVC.CompanyOfficial.Views.Create, viewModel);
            }

            await _companyOfficialService.CreateByViewModelAsync(viewModel);
            this.MessageError("عملیات با موفقیت ثبت شد");
            return RedirectToAction(MVC.Home.LandingPage());
        }
        public virtual async Task<JsonResult> GetFileOfficialNewspaperAddressAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var fileCover = await _companyOfficialService.GetFileOfficialNewspaperAddressAsFineUploaderModelByIdAsync(id.Value);
            return Json(fileCover, JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<JsonResult> GetFileBusinessLicenseFileNameAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var fileCover = await _companyOfficialService.GetFileBusinessLicenseAsFineUploaderModelByIdAsync(id.Value);
            return Json(fileCover, JsonRequestBehavior.AllowGet);
        }

        public virtual async Task<JsonResult> GetFileNationalCardFileNameAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var fileCover = await _companyOfficialService.GetFileNationalCardAsFineUploaderModelByIdAsync(id.Value);
            return Json(fileCover, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [MvcAuthorize(PermissionConst.CanCompanyOfficialMyEdit)]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _companyOfficialFactory.PrepareEditViewModelAsync(id.Value, true);
            return View(MVC.CompanyOfficial.Views.Edit, viewModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [MvcAuthorize(PermissionConst.CanCompanyOfficialMyEdit)]
        public virtual async Task<ActionResult> MyEdit(CompanyOfficialEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            if (ModelState.IsValid == false)
            {
                this.MessageError("خطایی رخ داده مجدد امتحان کنید");
                return View(MVC.CompanyOfficial.Views.Edit, viewModel);
            }

            await _companyOfficialService.EditByViewModelAsync(viewModel);
            this.MessageError("عملیات با موفقیت ثبت شد");
            return RedirectToAction(MVC.Home.LandingPage());

        }


        public virtual async Task<ActionResult> List(CompanyOfficialSearchRequest request)
        {
            var viewModel = await _companyOfficialFactory.PrepareListViewModRelAsync(request);
            return View(MVC.CompanyOfficial.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}