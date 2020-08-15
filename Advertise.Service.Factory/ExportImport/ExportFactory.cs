using System.Threading.Tasks;
using Advertise.Core.Models.ExportImport;
using Advertise.Service.Services.Categories;

namespace Advertise.Service.Factories.ExportImport
{

    public class ExportFactory : IExportFactory
    {
        #region Private Fields

        private readonly ICategoryService _categoryService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryService"></param>
        public ExportFactory(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<ExportIndexViewModel> PrepareIndexViewModelAsync()
        {
            var viewModel = new ExportIndexViewModel
            {
                CategoryList = await _categoryService.GetAllAsSelectListAsync()
            };

            return viewModel;
        }

        #endregion Public Methods
    }
}