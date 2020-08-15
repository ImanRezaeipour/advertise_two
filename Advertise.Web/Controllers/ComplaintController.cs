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





        #endregion Public Methods
    }
}