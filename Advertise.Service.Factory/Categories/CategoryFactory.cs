using Advertise.Core.Exceptions;
using Advertise.Core.Models.Category;
using Advertise.Core.Models.CategoryOption;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Company;
using Advertise.Core.Models.Home;
using Advertise.Core.Models.Product;
using Advertise.Core.Types;
using Advertise.Core.Utilities;
using Advertise.Service.Services.Categories;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Products;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Advertise.Core.Helpers;
using Advertise.Service.Services.Seo;

namespace Advertise.Service.Factories.Categories
{

    public class CategoryFactory : ICategoryFactory
    {

        #region Private Fields

        private readonly ICategoryFollowService _categoryFollowService;
        private readonly ICategoryService _categoryService;
        private readonly ICommonService _commonService;
        private readonly ICompanyService _companyService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly ISeoService _seoService;
        private readonly IProductService _productService;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="companyService"></param>
        ///  <param name="mapper"></param>
        /// <param name="listManager"></param>
        /// <param name="categoryFollowService"></param>
        /// <param name="categoryService"></param>
        /// <param name="productService"></param>
        /// <param name="commonService"></param>
        public CategoryFactory(ICompanyService companyService, IMapper mapper, IListManager listManager, ICategoryFollowService categoryFollowService, ICategoryService categoryService, IProductService productService, ICommonService commonService, ISeoService seoService)
        {
            _companyService = companyService;
            _mapper = mapper;
            _listManager = listManager;
            _categoryFollowService = categoryFollowService;
            _categoryService = categoryService;
            _productService = productService;
            _commonService = commonService;
            _seoService = seoService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="currentTitle"></param>
        /// <param name="isAllSearch"></param>
        /// <returns></returns>
        public async Task<CategoryBreadCrumbViewModel> PrepareBreadCrumbViewModelAsync(Guid categoryId, string currentTitle, bool? isAllSearch)
        {
            var allParents = await _categoryService.GetParentsByIdAsync(categoryId);
            var nodes = _mapper.Map<List<CategoryViewModel>>(allParents);
            var viewModel = new CategoryBreadCrumbViewModel
            {
                Nodes = nodes,
                CurrentTitle = currentTitle,
                IsAllSearch = isAllSearch
            };

            return viewModel;
        }

        ///  <summary>
        ///  </summary>
        ///  <param name="categoryId"></param>
        ///  <returns></returns>
        public async Task<CompanyListViewModel> PrepareCompanyListViewModelAsync(Guid categoryId)
        {
            var request = new CompanySearchRequest
            {
                CategoryId = categoryId,
                PageIndex = 1
            };
            var categoryCompanies = await _companyService.GetByRequestAsync(request);

            var categoryCompanyViewModel = _mapper.Map<List<CompanyViewModel>>(categoryCompanies);

            var listViewModel = new CompanyListViewModel
            {
                SearchRequest = request,
                Companies = categoryCompanyViewModel
            };

            return listViewModel;
        }

        ///  <summary>
        ///  </summary>
        ///  <returns></returns>
        public async Task<CategoryCreateViewModel> PrepareCreateViewModelAsync()
        {
            var viewModel = new CategoryCreateViewModel();
            return viewModel;
        }

        /// <summary>
        ///نمایش جزئیات دسته
        /// </summary>
        /// <param name="categoryAlias"></param>
        /// <returns></returns>
        public async Task<CategoryDetailViewModel> PrepareDetailViewModelAsync(string categoryAlias, string slug)
        {
            var seoExist = await _seoService.IsExistCategoryByIdAsync(categoryAlias);
            if (seoExist)
                throw new ValidationException("Category is modified.");

            var slugResult = await _categoryService.IsCompareNameAndSlugAsync(categoryAlias, slug);
            if (!slugResult)
                throw new ValidationException("عدم تطابق اسلاگ");
            var category = await _categoryService.FindByAliasAsync(categoryAlias);
            if (category == null)
                throw new FactoryException();
            var viewModel = _mapper.Map<CategoryDetailViewModel>(category);

            var categoryOption = await _categoryService.GetCategoryOptionByIdAsync(category.Id);
            viewModel.CategoryOption = categoryOption != null ? _mapper.Map<CategoryOptionViewModel>(categoryOption) : null;

            var categories = await _categoryService.GetCategoriesByParentId(viewModel.Id);
            viewModel.Categories = categories != null ? _mapper.Map<List<CategoryViewModel>>(categories) : null;

            viewModel.CompanyCount = await _companyService.CountByCategoryIdAsync(viewModel.Id);
            viewModel.FollowerCount = await _categoryFollowService.CountAllFollowByCategoryIdAsync(viewModel.Id);
            viewModel.ProductCount = await _productService.CountByCategoryIdAsync(viewModel.Id);
            viewModel.InitFollow = await _categoryFollowService.IsFollowCurrentUserByCategoryIdAsync(viewModel.Id);

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="categoryAlias"></param>
        /// <returns></returns>
        public async Task<CategoryEditViewModel> PrepareEditViewModelAsync(string categoryAlias)
        {
            var category = await _categoryService.FindByAliasAsync(categoryAlias);
            if (category == null)
                throw new FactoryException();
            var viewModel = _mapper.Map<CategoryEditViewModel>(category);

            var categoryOption = await _categoryService.GetCategoryOptionByIdAsync(category.Id);
            viewModel.CategoryOptionList = new[]
            {
                new SelectListItem
                {
                    Text = categoryOption.Title,
                    Value = categoryOption.Id.ToString()
                }
            };

            return viewModel;
        }


        public async Task<CategoryListViewModel> PrepareListViewModelAsync(CategorySearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            var categories = await _categoryService.GetByRequestAsync(request);
            var categoriesMap = _mapper.Map<List<CategoryViewModel>>(categories);
            request.TotalCount = await _categoryService.CountByRequestAsync(request);

            var categoriesList = new CategoryListViewModel
            {
                SearchRequest = request,
                Categories = categoriesMap,
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                ActiveList = EnumHelper.CastToSelectListItems<ActiveType>(),//await _listManager.GetActiveListAsync(),
            PageSizeList = await _listManager.GetPageSizeListAsync()
            };

            return categoriesList;
        }


        public async Task<MainMenuViewModel> PrepareMainMenuViewModelAsync()
        {
            var viewModel = new MainMenuViewModel();

            var request = new CategorySearchRequest
            {
                PageSize = PageSize.All
            };
            var categories = _categoryService.QueryByRequest(request);
            viewModel.Categories = await categories.ProjectTo<CategoryViewModel>().ToListAsync();

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<ProductListViewModel> PrepareProductListViewModelAsync(Guid categoryId)
        {
            var request = new ProductSearchRequest
            {
                CategoryId = categoryId
            };
            var categoryProducts = await _productService.GetByRequestAsync(request);
            var categoryProductViewModel = _mapper.Map<List<ProductViewModel>>(categoryProducts);

            var listViewModel = new ProductListViewModel
            {
                SearchRequest = request,
                Products = categoryProductViewModel
            };

            return listViewModel;
        }

        #endregion Public Methods

    }
}