using Advertise.Core.Models.Report;
using Advertise.Service.Services.Reports;
using Advertise.Web.Framework.Filters;
using Newtonsoft.Json;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Core.Constants;
using Advertise.Service.Factories.Reports;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Results;

namespace Advertise.Web.Controllers
{

    public partial class ReportController : BaseController
    {
        #region Private Fields

        private readonly IReportService _reportService;
        private readonly IReportFactory _reportFactory;

        #endregion Private Fields

        #region Public Constructors

        public ReportController(IReportService reportService, IReportFactory reportFactory)
        {
            _reportService = reportService;
            _reportFactory = reportFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        public virtual async Task<ActionResult> Create()
        {

            return View(MVC.Report.Views.Create);
        }


        [HttpPost]
        public virtual async Task<ActionResult> Create(ReportCreateViewModel viewModel)
        {

            await _reportService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Report.List());
        }


        [AjaxOnly]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _reportService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<ActionResult> Detail(Guid? id, ReportParameterViewModel viewModel = null)
        {
            TempData[id.ToString()] = viewModel;
            var options = new StiMvcViewerOptions();
            return View(MVC.Report.Views.Detail, viewModel);
        }


        public virtual async Task<ActionResult> DetailExportReport(Guid? id)
        {
            StiReport report = StiMvcViewer.GetReportObject();
            //StiRequestParams parameters = StiMvcViewer.GetRequestParams();

            //if (parameters.ExportFormat == StiExportFormat.Pdf)
            //{
            //    // Some actions with report when exporting to PDF
            //}

            return StiMvcViewer.ExportReportResult(report);
        }


        public virtual async Task<ActionResult> DetailInteraction(Guid? id)
        {
            //StiRequestParams requestParams = StiMvcViewer.GetRequestParams();
            //if (requestParams.Action == StiAction.Variables)
            //{
            //    DataSet data = new DataSet();
            //    data.ReadXml(Server.MapPath("~/Content/Data/Demo.xml"));

            //    StiReport report = StiMvcViewer.GetReportObject();
            //    report.RegData("Demo", data);

            //    return StiMvcViewer.InteractionResult(report);
            //}

            return StiMvcViewer.InteractionResult();
        }


        public virtual async Task<ActionResult> DetailPrintReport(Guid? id)
        {
            StiReport report = StiMvcViewer.GetReportObject();

            // Some actions with report when printing

            return StiMvcViewer.PrintReportResult(report);
        }


        public virtual async Task<ActionResult> DetailReport(Guid? id, ReportParameterViewModel viewModel)
        {
            if (id == null || viewModel == null)
                throw new ArgumentNullException(nameof(id));
            viewModel = (ReportParameterViewModel)TempData[id.ToString()];
            var report = await _reportService.GetReportAsStiReportAsync(id.Value ,viewModel);
            return StiMvcViewer.GetReportSnapshotResult(report);
        }


        [SkipRemoveWhiteSpaces]
        public virtual async Task<ActionResult> DetailViewerEvent(Guid? id)
        {
            return StiMvcViewer.ViewerEventResult();
        }


        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if(id == null)
                throw new ArgumentNullException(nameof(id));

            var viewModel = await _reportFactory.PrepareEditViewModelAsync(id.Value);
            return View(MVC.Report.Views.Edit, viewModel);
        }


        [HttpPost]
        public virtual async Task<ActionResult> Edit(ReportEditViewModel viewModel)
        {
            await _reportService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Report.List());
        }


        [MvcAuthorize]
        public virtual async Task<JsonResult> GetListAjax()
        {
            // Result
           // var request = JsonConvert.DeserializeObject<Service.Managers.Kendo.DynamicLinq.DataSourceRequest>(Request.Url.ParseQueryString().GetKey(0));
            var list = await _reportService.GeAllAsync();
            return Json(AjaxResult.Succeeded(list), JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<ActionResult> List(ReportSearchRequest request)
        {

            var viewModel = await _reportFactory.PrepareListViewModelAsync(request);
            return View(MVC.Report.Views.List, viewModel);
        }

        public virtual async Task<JsonResult> FromDateToDateAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));
            
                var viewModel = await _reportFactory.PrepareReportParameter(id.Value);
                return Json(AjaxResult.Succeeded(RenderRazorViewToString(MVC.Report.Views._FromDateToDate, viewModel)),JsonRequestBehavior.AllowGet);
            
        }

        #endregion Public Methods
    }
}