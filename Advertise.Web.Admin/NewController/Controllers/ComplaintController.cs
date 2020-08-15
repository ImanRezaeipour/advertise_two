using Advertise.Core.Constants;
using Advertise.Core.Models.Complaint;
using Advertise.Service.Factories.Complaints;
using Advertise.Service.Services.Complaints;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Web.Framework.Extensions;

namespace Advertise.Web.Controllers
{

    public partial class ComplaintController : BaseController
    {

        #region Private Fields

        private readonly IComplaintFactory _complaintFactory;
        private readonly IComplaintService _complaintService;

        #endregion Private Fields

        #region Public Constructors

     
        public ComplaintController(IComplaintService complaintService, IComplaintFactory complaintFactory)
        {
            _complaintService = complaintService;
            _complaintFactory = complaintFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(ComplaintCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _complaintService.CreateByViewModel(viewModel);
            this.MessageSuccess("پیام شما یا موفقیت ثبت شد.");
            return RedirectToAction(MVC.Home.LandingPage());
        }


        [MvcSiteMapNode(ParentKey = "Panel_Complaint_List", Title = "ایجاد ", Key = "Panel_Complaint_New")]
        [ImportModelData(typeof(ComplaintCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            return View(MVC.Complaint.Views.Create);
        }


        [MvcAuthorize(PermissionConst.CanComplaintDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _complaintService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcSiteMapNode(ParentKey = "Panel_Complaint_List", Title = "جزئیات", Key = "Panel_Complaint_Detail", PreservedRouteParameters = "id")]
        public virtual async Task<ActionResult> Detail(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _complaintFactory.PrepareDetailViewModelAsync(id.Value);
            return viewModel == null ? View(MVC.Error.Views.InternalServerError) : View(MVC.Complaint.Views.Detail, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanComplaintList)]
        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "گزارش شکایات", Key = "Panel_Complaint_List")]
        public virtual async Task<ActionResult> List(ComplaintSearchRequest request)
        {
            var viewModel = await _complaintFactory.PrepareListViewModelAsync(request);
            return View(MVC.Complaint.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}