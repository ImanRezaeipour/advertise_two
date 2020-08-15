using Advertise.Service.Services.ExportImport;
using Advertise.Web.Framework.Filters;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Core.Constants;
using Advertise.Core.Models.ExportImport;
using Advertise.Service.Factories.ExportImport;

namespace Advertise.Web.Controllers
{

    public partial class ExportController : Controller
    {
        #region Private Fields

        private readonly IExportManager _exportService;
        private readonly IExportFactory _exportFactory;

        #endregion Private Fields

        #region Public Constructors

   
        public ExportController(IExportManager exportService, IExportFactory exportFactory)
        {
            _exportService = exportService;
            _exportFactory = exportFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [SkipRemoveWhiteSpaces]
        public virtual async Task<ActionResult> CatalogTemplateExcel(ExportIndexViewModel viewModel)
        {
            var catalogTemplate = await _exportService.GetCatalogTemplateAsExcelAsync(viewModel.CategoryId);
            return File(catalogTemplate, MimeTypes.TextXlsx);
        }


        [SkipRemoveWhiteSpaces]
        public virtual async Task<ActionResult> CategoryExcel()
        {
            var categories = await _exportService.GetCategoryAsExcelAsync();
            return File(categories, MimeTypes.TextXlsx);
        }


        public virtual async Task<ActionResult> Index()
        {
            var viewModel = await _exportFactory.PrepareIndexViewModelAsync();
            return View(MVC.Export.Views.Index, viewModel);
        }

        #endregion Public Methods
    }
}