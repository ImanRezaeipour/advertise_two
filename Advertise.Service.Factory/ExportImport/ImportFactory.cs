using System.Threading.Tasks;
using Advertise.Core.Models.ExportImport;
using Advertise.Service.Services.Categories;

namespace Advertise.Service.Factories.ExportImport
{

    public class ImportFactory : IImportFactory
    {
        #region Private Fields

        private readonly ICategoryService _categoryService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryService"></param>
        public ImportFactory(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<ImportIndexViewModel> PrepareIndexViewModelAsync()
        {
            var viewModel = new ImportIndexViewModel
            {
                CategoryList = await _categoryService.GetAllAsSelectListAsync()
            };

            return viewModel;
        }

        #endregion Public Methods
    }
}