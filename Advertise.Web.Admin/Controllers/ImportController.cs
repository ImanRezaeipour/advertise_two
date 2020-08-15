using System;
using Advertise.Core.Models.ExportImport;
using Advertise.Service.Factories.ExportImport;
using Advertise.Service.Services.ExportImport;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class ImportController : Controller
    {
        #region Private Fields

        private readonly IImportFactory _importFactory;
        private readonly IImportManager _importManager;

        #endregion Private Fields

        #region Public Constructors

 
        public ImportController(IImportManager importManager, IImportFactory importFactory)
        {
            _importManager = importManager;
            _importFactory = importFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [HttpPost]
        public virtual async Task<ActionResult> CatalogExcel(ImportCatalogViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            await _importManager.ImportCatalogsFromXlsxAsync(viewModel.CatalogFile.InputStream, viewModel.CategoryId);
            return RedirectToAction(MVC.Import.Index());
        }

       
        [HttpPost]
        public virtual async Task<ActionResult> CategoryExcel(HttpPostedFileBase file)
        {
            await _importManager.ImportCategoriesFromXlsxAsync(file.InputStream);
            return View(MVC.Import.Views.Index);
        }


        public virtual async Task<ActionResult> Index()
        {
            var viewModel = await _importFactory.PrepareIndexViewModelAsync();
            return View(MVC.Import.Views.Index, viewModel);
        }

        #endregion Public Methods
    }
}