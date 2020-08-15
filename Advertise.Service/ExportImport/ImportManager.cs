using Advertise.Core.Constants;
using Advertise.Core.Models.Category;
using Advertise.Service.Services.Categories;
using Advertise.Service.Services.ExportImport.Help;
using AutoMapper;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Models.Catalog;
using Advertise.Core.Models.CatalogSpecification;
using Advertise.Core.Types;
using Advertise.Service.Services.Catalogs;
using Advertise.Service.Services.Specifications;

namespace Advertise.Service.Services.ExportImport
{
    /// <summary>
    /// Import manager
    /// </summary>
    public class ImportManager : IImportManager
    {
        #region Private Fields

        private readonly ICategoryService _categoryService;
        private readonly ICatalogService _catalogService;
        private readonly ISpecificationService _specificationService;
        private readonly ISpecificationOptionService _specificationOptionService;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        /// 
        ///  </summary>
        ///  <param name="categoryService"></param>
        ///  <param name="mapper"></param>
        /// <param name="catalogService"></param>
        /// <param name="specificationService"></param>
        public ImportManager(ICategoryService categoryService, IMapper mapper, ICatalogService catalogService, ISpecificationService specificationService, ISpecificationOptionService specificationOptionService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _catalogService = catalogService;
            _specificationService = specificationService;
            _specificationOptionService = specificationOptionService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Import categories from XLSX file
        /// </summary>
        /// <param name="stream">Stream</param>
        public async Task ImportCategoriesFromXlsxAsync(Stream stream)
        {
            using (var xlPackage = new ExcelPackage(stream))
            {
                // get the first worksheet in the workbook
                var worksheet = xlPackage.Workbook.Worksheets.FirstOrDefault();
                if (worksheet == null)
                    throw new Exception("No worksheet found");

                //the columns
                var properties = GetPropertiesByExcelCells<CategoryViewModel>(worksheet);

                var manager = new PropertyManager<CategoryViewModel>(properties);

                var iRow = 2;
                while (true)
                {
                    var allColumnsAreEmpty = manager.GetProperties
                        .Select(property => worksheet.Cells[iRow, property.PropertyOrderPosition])
                        .All(cell => string.IsNullOrEmpty(cell?.Value?.ToString()));

                    if (allColumnsAreEmpty)
                        break;

                    // read current row data
                    manager.ReadFromXlsx(worksheet, iRow);

                    bool isNew;
                    var categoryViewModel = new CategoryViewModel();
                    if (string.IsNullOrEmpty(manager.GetProperty("Id").StringValue))
                    {
                        isNew = true;
                    }
                    else
                    {
                        var category = await _categoryService.FindByIdAsync(Guid.Parse(manager.GetProperty("Id").StringValue));
                        if (category == null)
                        {
                            isNew = true;
                        }
                        else
                        {
                            isNew = false;
                            categoryViewModel = _mapper.Map<CategoryViewModel>(category);
                        }
                    }

                    foreach (var property in manager.GetProperties)
                    {
                        switch (property.PropertyName)
                        {
                            case "Title":
                                categoryViewModel.Title = property.StringValue;
                                break;

                            case "Order":
                                categoryViewModel.Order = property.IntValue;
                                break;

                            case "Alias":
                                categoryViewModel.Alias = property.StringValue;
                                break;
                        }
                    }

                    if (isNew)
                    {
                        var createViewModel = _mapper.Map<CategoryCreateViewModel>(categoryViewModel);
                        await _categoryService.CreateByViewModelAsync(createViewModel);
                    }
                    else
                    {
                        var editViewModel = _mapper.Map<CategoryEditViewModel>(categoryViewModel);
                        await _categoryService.EditByViewModelAsync(editViewModel);
                    }

                    iRow++;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task ImportCatalogsFromXlsxAsync(Stream stream, Guid categoryId)
        {
            using (var xlPackage = new ExcelPackage(stream))
            {
                // get the first worksheet in the workbook
                var worksheet = xlPackage.Workbook.Worksheets.FirstOrDefault();
                if (worksheet == null)
                    throw new Exception("No worksheet found");

                //the columns
                var properties = GetPropertiesByExcelCells<CatalogExportViewModel>(worksheet);

                var manager = new PropertyManager<CatalogExportViewModel>(properties);

                var iRow = 2;
                while (true)
                {
                    var allColumnsAreEmpty = manager.GetProperties
                        .Select(property => worksheet.Cells[iRow, property.PropertyOrderPosition])
                        .All(cell => string.IsNullOrEmpty(cell?.Value?.ToString()));

                    if (allColumnsAreEmpty)
                        break;

                    // read current row data
                    manager.ReadFromXlsx(worksheet, iRow);

                    bool isNew;
                    var catalogViewModel = new CatalogExportViewModel();
                    if (string.IsNullOrEmpty(manager.GetProperty("Id").StringValue))
                    {
                        isNew = true;
                    }
                    else
                    {
                        var catalog = await _catalogService.FindByIdAsync(Guid.Parse(manager.GetProperty("Id").StringValue));
                        if (catalog == null)
                        {
                            isNew = true;
                        }
                        else
                        {
                            isNew = false;
                            catalogViewModel = _mapper.Map<CatalogExportViewModel>(catalog);
                        }
                    }

                    foreach (var property in manager.GetProperties)
                    {
                        switch (property.PropertyName)
                        {
                            case "Title":
                                catalogViewModel.Title = property.StringValue;
                                break;

                            case "Body":
                                catalogViewModel.Body = property.StringValue;
                                break;

                            case "Code":
                                catalogViewModel.Code = property.StringValue;
                                break;

                            case "Description":
                                catalogViewModel.Description = property.StringValue;
                                break;

                            case "FeatureTitle1":
                                catalogViewModel.FeatureTitle1 = property.StringValue;
                                break;

                            case "FeatureTitle2":
                                catalogViewModel.FeatureTitle2 = property.StringValue;
                                break;

                            case "FeatureTitle3":
                                catalogViewModel.FeatureTitle3 = property.StringValue;
                                break;

                            case "FeatureTitle4":
                                catalogViewModel.FeatureTitle4 = property.StringValue;
                                break;

                            case "FeatureTitle5":
                                catalogViewModel.FeatureTitle5 = property.StringValue;
                                break;

                            case "ImageFileName1":
                                catalogViewModel.ImageFileName1 = property.StringValue;
                                break;

                            case "ImageFileName2":
                                catalogViewModel.ImageFileName2 = property.StringValue;
                                break;

                            case "ImageFileName3":
                                catalogViewModel.ImageFileName3 = property.StringValue;
                                break;

                            case "ImageFileName4":
                                catalogViewModel.ImageFileName4 = property.StringValue;
                                break;

                            case "ImageFileName5":
                                catalogViewModel.ImageFileName5 = property.StringValue;
                                break;

                            case "KeywordId":
                                catalogViewModel.KeywordId = property.StringValue;
                                break;

                            case "ManufacturerId":
                                catalogViewModel.ManufacturerId = property.GuidValue.Value;
                                break;

                            case "MetaDescription":
                                catalogViewModel.MetaDescription = property.StringValue;
                                break;

                            case "MetaKeywords":
                                catalogViewModel.MetaKeywords = property.StringValue;
                                break;

                            case "MetaTitle":
                                catalogViewModel.MetaTitle = property.StringValue;
                                break;

                            case "ReviewBody":
                                catalogViewModel.ReviewBody = property.StringValue;
                                break;
                        }
                    }

                    var catalogSpecification = new List<CatalogSpecification>();
                    foreach (var specification in await _specificationService.GetByCategoryIdAsync(categoryId))
                    {
                        if(string.IsNullOrEmpty(manager.GetProperty(specification.Title).StringValue))
                            continue;
                        catalogSpecification.Add(new CatalogSpecification
                        {
                            SpecificationId = specification.Id,
                            SpecificationOptionId = specification.Type == SpecificationType.String ? null : await _specificationOptionService.GetIdByTitleAsync(manager.GetProperty(specification.Title).StringValue, specification.Id),
                            Value = specification.Type == SpecificationType.String ? manager.GetProperty(specification.Title).StringValue : null
                        });
                    }

                    if (isNew)
                    {
                        //var createViewModel = _mapper.Map<CatalogCreateViewModel>(catalogViewModel);
                        catalogViewModel.Specifications = _mapper.Map<IList<CatalogSpecificationViewModel>>(catalogSpecification);
                        catalogViewModel.CategoryId = categoryId;
                        await _catalogService.CreateByViewModelAsync(catalogViewModel);
                    }
                    else
                    {
                        var editViewModel = _mapper.Map<CatalogEditViewModel>(catalogViewModel);
                        editViewModel.Specifications = _mapper.Map<IList<CatalogSpecificationViewModel>>(catalogSpecification);
                        editViewModel.CategoryId = categoryId;
                        await _catalogService.EditByViewModelAsync(editViewModel);
                    }

                    iRow++;
                }
            }
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="columnValue"></param>
        /// <returns></returns>
        protected virtual string ConvertColumnToString(object columnValue)
        {
            if (columnValue == null)
                return null;

            return Convert.ToString(columnValue);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        protected virtual int GetColumnIndex(string[] properties, string columnName)
        {
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));

            if (columnName == null)
                throw new ArgumentNullException(nameof(columnName));

            for (int i = 0; i < properties.Length; i++)
                if (properties[i].Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return i + 1; //excel indexes start from 1
            return 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        protected virtual string GetMimeTypeFromFilePath(string filePath)
        {
            var mimeType = MimeMapping.GetMimeMapping(filePath);

            //little hack here because MimeMapping does not contain all mappings (e.g. PNG)
            if (mimeType == MimeTypes.ApplicationOctetStream)
                mimeType = MimeTypes.ImageJpeg;

            return mimeType;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="worksheet"></param>
        /// <returns></returns>
        protected virtual IList<PropertyByName<T>> GetPropertiesByExcelCells<T>(ExcelWorksheet worksheet)
        {
            var properties = new List<PropertyByName<T>>();
            var poz = 1;
            while (true)
            {
                try
                {
                    var cell = worksheet.Cells[1, poz];

                    if (cell == null || cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString()))
                        break;

                    poz += 1;
                    properties.Add(new PropertyByName<T>(cell.Value.ToString()));
                }
                catch
                {
                    break;
                }
            }

            return properties;
        }

        #endregion Protected Methods
    }
}