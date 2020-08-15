using Advertise.Core.Models.Category;
using Advertise.Core.Models.CompanyCatalog;
using Advertise.Core.Models.Specification;
using Advertise.Service.Services.Categories;
using Advertise.Service.Services.ExportImport.Help;
using Advertise.Service.Services.Keywords;
using Advertise.Service.Services.Manufacturers;
using Advertise.Service.Services.Products;
using Advertise.Service.Services.Specifications;
using AutoMapper;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Configuration;
using Advertise.Core.Models.Catalog;

namespace Advertise.Service.Services.ExportImport
{
    /// <summary>
    /// Export manager
    /// </summary>
    public class ExportManager : IExportManager
    {
        #region Private Fields

        private readonly ICategoryService _categoryService;
        private readonly IConfigurationManager _configurationManager;
        private readonly IKeywordService _keywordService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly ISpecificationOptionService _specificationOptionService;
        private readonly ISpecificationService _specificationService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryService"></param>
        /// <param name="configurationManager"></param>
        /// <param name="productService"></param>
        /// <param name="mapper"></param>
        /// <param name="specificationService"></param>
        /// <param name="specificationOptionService"></param>
        public ExportManager(ICategoryService categoryService, IConfigurationManager configurationManager, IProductService productService, IMapper mapper, ISpecificationService specificationService, ISpecificationOptionService specificationOptionService, IKeywordService keywordService, IManufacturerService manufacturerService)
        {
            _categoryService = categoryService;
            _configurationManager = configurationManager;
            _productService = productService;
            _mapper = mapper;
            _specificationService = specificationService;
            _specificationOptionService = specificationOptionService;
            _keywordService = keywordService;
            _manufacturerService = manufacturerService;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<byte[]> GetCatalogTemplateAsExcelAsync(Guid categoryId)
        {
            var defaultCatalog = new List<CatalogExportViewModel>
            {
                new CatalogExportViewModel
                {
                    Code = "100",
                }
            };

            return await ExportCatalogsToXlsxAsync(defaultCatalog, categoryId);
        }


        public async Task<byte[]> GetCategoryAsExcelAsync()
        {
            var request = new CategorySearchRequest();
            var categories = await _categoryService.GetByRequestAsync(request);
            var vm = _mapper.Map<IList<CategoryViewModel>>(categories);

            return await ExportCategoriesToXlsxAsync(vm);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Export objects to XLSX
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="properties">Class access to the object through its properties</param>
        /// <param name="itemsToExport">The objects to export</param>
        /// <returns></returns>
        protected virtual byte[] ExportToXlsx<T>(PropertyByName<T>[] properties, IEnumerable<T> itemsToExport)
        {
            using (var stream = new MemoryStream())
            {
                // ok, we can run the real code of the sample now
                using (var xlPackage = new ExcelPackage(stream))
                {
                    // uncomment this line if you want the XML written out to the outputDir
                    //xlPackage.DebugMode = true;

                    // get handles to the worksheets
                    var worksheet = xlPackage.Workbook.Worksheets.Add(typeof(T).Name);
                    var fWorksheet = xlPackage.Workbook.Worksheets.Add("DataForFilters");
                    fWorksheet.Hidden = eWorkSheetHidden.VeryHidden;

                    //worksheet.Cells.AutoFitColumns(50, 500);

                    //create Headers and format them
                    var manager = new PropertyManager<T>(properties.Where(p => !p.Ignore));
                    manager.WriteCaption(worksheet, SetCaptionStyle);

                    var row = 2;
                    foreach (var items in itemsToExport)
                    {
                        manager.CurrentObject = items;
                        manager.WriteToXlsx(worksheet, row++, _configurationManager.ExportImportUseDropdownlistsForAssociatedEntities, fWorksheet: fWorksheet);
                    }

                    xlPackage.Save();
                }
                return stream.ToArray();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="style"></param>
        protected virtual void SetCaptionStyle(ExcelStyle style)
        {
            style.Fill.PatternType = ExcelFillStyle.Solid;
            style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
            style.Font.Bold = true;
            //style.Locked = true;
            //style.ShrinkToFit = true;
        }

        #endregion Protected Methods

        #region Private Methods

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="catalogs"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        private async Task<byte[]> ExportCatalogsToXlsxAsync(IEnumerable<CatalogExportViewModel> catalogs, Guid categoryId)
        {
            var properties = new[]
            {
                new PropertyByName<CatalogExportViewModel>("Id", p => p.Id),
                new PropertyByName<CatalogExportViewModel>("Body", p => p.Body),
                new PropertyByName<CatalogExportViewModel>("Code", p => p.Code),
                new PropertyByName<CatalogExportViewModel>("Description", p => p.Description),
                new PropertyByName<CatalogExportViewModel>("FeatureTitle1", p => p.FeatureTitle1),
                new PropertyByName<CatalogExportViewModel>("FeatureTitle2", p => p.FeatureTitle2),
                new PropertyByName<CatalogExportViewModel>("FeatureTitle3", p => p.FeatureTitle3),
                new PropertyByName<CatalogExportViewModel>("FeatureTitle4", p => p.FeatureTitle4),
                new PropertyByName<CatalogExportViewModel>("FeatureTitle5", p => p.FeatureTitle5),
                new PropertyByName<CatalogExportViewModel>("ImageFileName1", p => p.ImageFileName1),
                new PropertyByName<CatalogExportViewModel>("ImageFileName2", p => p.ImageFileName2),
                new PropertyByName<CatalogExportViewModel>("ImageFileName3", p => p.ImageFileName3),
                new PropertyByName<CatalogExportViewModel>("ImageFileName4", p => p.ImageFileName4),
                new PropertyByName<CatalogExportViewModel>("ImageFileName5", p => p.ImageFileName5),
                new PropertyByName<CatalogExportViewModel>("KeywordId", p => "34BC5D0C-A987-EB33-EDFC-39E3761B5722")
                {
                    DropDownElements = await _keywordService.GetAllActiveAsSelectListAsync(),
                    AllowBlank = true
                },
                new PropertyByName<CatalogExportViewModel>("ManufacturerId", p => "34BC5D0C-A987-EB33-EDFC-39E3761B5722")
                {
                    DropDownElements = await _manufacturerService.GetAllAsSelectListAsync(),
                },
                new PropertyByName<CatalogExportViewModel>("MetaDescription", p => p.MetaDescription),
                new PropertyByName<CatalogExportViewModel>("MetaKeywords", p => p.MetaKeywords),
                new PropertyByName<CatalogExportViewModel>("MetaTitle", p => p.MetaTitle),
                new PropertyByName<CatalogExportViewModel>("ReviewBody", p => p.ReviewBody),
                new PropertyByName<CatalogExportViewModel>("Title", p => p.Title)
            };

            var extraProperties = new List<PropertyByName<CatalogExportViewModel>>();
            foreach (var specification in await _specificationService.GetByCategoryIdAsync(categoryId))
            {
                extraProperties.Add(new PropertyByName<CatalogExportViewModel>(specification.Title, p => "")
                {
                    DropDownElements = await _specificationOptionService.GetAsSelectListBySpecificationIdAsync(specification.Id),
                    AllowBlank = true
                });
            }

            return ExportToXlsx(properties.Concat(extraProperties).ToArray(), catalogs);
        }

        /// <summary>
        /// Export categories to XLSX
        /// </summary>
        /// <param name="categories">Categories</param>
        private async Task<byte[]> ExportCategoriesToXlsxAsync(IEnumerable<CategoryViewModel> categories)
        {
            var properties = new[]
            {
                new PropertyByName<CategoryViewModel>("Id", p => p.Id),
                new PropertyByName<CategoryViewModel>("Description", p => p.Description),
                new PropertyByName<CategoryViewModel>("Alias", p => p.Alias),
                new PropertyByName<CategoryViewModel>("IsActive", p => p.IsActive),
                new PropertyByName<CategoryViewModel>("Title", p => p.Title),
                new PropertyByName<CategoryViewModel>("Order", p => p.Order),
                new PropertyByName<CategoryViewModel>("MetaTitle", p => p.MetaTitle)
            };

            return ExportToXlsx(properties, categories);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyCatalogs"></param>
        /// <returns></returns>
        private async Task<byte[]> ExportCompanyCatalogsToXlsxAsync(IEnumerable<CompanyCatalogViewModel> companyCatalogs)
        {
            var properties = new[]
            {
                new PropertyByName<CompanyCatalogViewModel>("price", p => p.Price)
            };

            return ExportToXlsx(properties, companyCatalogs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="specifications"></param>
        /// <returns></returns>
        private async Task<byte[]> ExportSpecificationsToXlsxAsync(IEnumerable<SpecificationViewModel> specifications)
        {
            var properties = new[]
            {
                new PropertyByName<SpecificationViewModel>("Title", p => p.Title)
            };

            return ExportToXlsx(properties, specifications);
        }

        #endregion Private Methods
    }
}