using Advertise.Core.Exceptions;
using Advertise.Core.Models.Category;
using Advertise.Core.Models.CategoryOption;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Product;
using Advertise.Core.Models.ProductComment;
using Advertise.Core.Models.ProductFeature;
using Advertise.Core.Models.ProductImage;
using Advertise.Core.Models.ProductReview;
using Advertise.Core.Models.ProductSpecification;
using Advertise.Core.Models.ProductTag;
using Advertise.Core.Models.Tag;
using Advertise.Core.Types;
using Advertise.Core.Utilities;
using Advertise.Service.Services.Catalogs;
using Advertise.Service.Services.Categories;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.Guarantees;
using Advertise.Service.Services.Keywords;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Locations;
using Advertise.Service.Services.Products;
using Advertise.Service.Services.Receipts;
using Advertise.Service.Services.Tags;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Core.Domains.Specifications;
using Advertise.Core.Extensions;
using Advertise.Core.Helpers;
using Advertise.Core.Models.CatalogFeature;
using Advertise.Core.Models.CatalogImage;
using Advertise.Service.Services.Specifications;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Advertise.Service.Factories.Products
{
    public class ProductFactory : IProductFactory
    {
        #region Private Fields

        private readonly IAddressService _addressService;
        private readonly IBagService _bagService;
        private readonly ICatalogImageService _catalogImageService;
        private readonly ICatalogService _catalogService;
        private readonly ICategoryService _categoryService;
        private readonly ICommonService _commonService;
        private readonly ICompanyService _companyService;
        private readonly IGuaranteeService _guaranteeService;
        private readonly IKeywordService _keywordService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IProductCommentService _productCommentService;
        private readonly IProductFeatureService _productFeatureService;
        private readonly IProductImageService _productImageService;
        private readonly IProductKeywordService _productKeywordService;
        private readonly IProductLikeService _productLikeService;
        private readonly IProductRateService _productRateService;
        private readonly IProductReviewService _productReviewService;
        private readonly IProductService _productService;
        private readonly IProductSpecificationService _productSpecificationService;
        private readonly IProductTagService _productTagService;
        private readonly IProductVisitService _productVisitService;
        private readonly ITagService _tagService;
        private readonly IWebContextManager _webContextManager;
        private readonly ICatalogSpecificationService _catalogSpecificationService;
        private readonly ICatalogFeatureService _catalogFeatureService;
        private readonly IProductNotifyService _productNotifyService;
        private readonly ISpecificationService _specificationService;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="listManager"></param>
        ///  <param name="commonService"></param>
        ///  <param name="addressService"></param>
        ///  <param name="tagService"></param>
        ///  <param name="productService"></param>
        ///  <param name="mapper"></param>
        ///  <param name="productLikeService"></param>
        ///  <param name="webContextManager"></param>
        ///  <param name="productVisitService"></param>
        ///  <param name="productReviewService"></param>
        ///  <param name="productImageService"></param>
        ///  <param name="productTagService"></param>
        ///  <param name="bagService"></param>
        ///  <param name="productFeatureService"></param>
        ///  <param name="productCommentService"></param>
        ///  <param name="productSpecificationService"></param>
        /// <param name="categoryService"></param>
        /// <param name="companyService"></param>
        /// <param name="productRateService"></param>
        public ProductFactory(IListManager listManager, ICommonService commonService, IAddressService addressService, ITagService tagService, IProductService productService, IMapper mapper, IProductLikeService productLikeService, IWebContextManager webContextManager, IProductVisitService productVisitService, IProductReviewService productReviewService, IProductImageService productImageService, IProductTagService productTagService, IBagService bagService, IProductFeatureService productFeatureService, IProductCommentService productCommentService, IProductSpecificationService productSpecificationService, ICategoryService categoryService, ICompanyService companyService, IProductRateService productRateService, IKeywordService keywordService, IProductKeywordService productKeywordService, ICatalogService catalogService, IGuaranteeService guaranteeService, ICatalogImageService catalogImageService, ICatalogSpecificationService catalogSpecificationService, ICatalogFeatureService catalogFeatureService, IProductNotifyService productNotifyService, ISpecificationService specificationService)
        {
            _listManager = listManager;
            _commonService = commonService;
            _addressService = addressService;
            _tagService = tagService;
            _productService = productService;
            _mapper = mapper;
            _productLikeService = productLikeService;
            _webContextManager = webContextManager;
            _productVisitService = productVisitService;
            _productReviewService = productReviewService;
            _productImageService = productImageService;
            _productTagService = productTagService;
            _bagService = bagService;
            _productFeatureService = productFeatureService;
            _productCommentService = productCommentService;
            _productSpecificationService = productSpecificationService;
            _categoryService = categoryService;
            _companyService = companyService;
            _productRateService = productRateService;
            _keywordService = keywordService;
            _productKeywordService = productKeywordService;
            _catalogService = catalogService;
            _guaranteeService = guaranteeService;
            _catalogImageService = catalogImageService;
            _catalogSpecificationService = catalogSpecificationService;
            _catalogFeatureService = catalogFeatureService;
            _productNotifyService = productNotifyService;
            _specificationService = specificationService;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<ProductBulkCreateViewModel> PrepareBulkCreateViewModelAsync(ProductBulkCreateViewModel viewModelPrepare = null)
        {
            var viewModel = viewModelPrepare ?? new ProductBulkCreateViewModel();

            viewModel.CategoryListJson = JsonConvert.SerializeObject(await _categoryService.GetAllowedAsSelect2ObjectAsync());
            viewModel.CatalogListJson = JsonConvert.SerializeObject(await _catalogService.GetAsSelect2ObjectAsync());
            viewModel.GuaranteeList = await _guaranteeService.GetAsSelectListAsync();
            viewModel.ColorList = EnumHelper.CastToSelectListItems<ColorType>();

            return viewModel;
        }


        public async Task<ProductBulkEditViewModel> PrepareBulkEditViewModelAsync()
        {
            var request = new ProductSearchRequest
            {
                CreatedById = _webContextManager.CurrentUserId,
                PageSize = PageSize.All
            };
            var products = await _productService.GetByRequestAsync(request);
            var productBulks = _mapper.Map<IList<ProductBulkViewModel>>(products);

            var viewModel = new ProductBulkEditViewModel
            {
                CategoryListJson = JsonConvert.SerializeObject(await _categoryService.GetAllowedAsSelect2ObjectAsync()),
                CatalogListJson = JsonConvert.SerializeObject(await _catalogService.GetAsSelect2ObjectAsync()),
                GuaranteeList = await _guaranteeService.GetAsSelectListAsync(),
                ColorList = EnumHelper.CastToSelectListItems<ColorType>(),
                ProductBulks = productBulks
            };

            return viewModel;
        }


        public async Task<ProductCreateViewModel> PrepareCreateViewModelAsync(ProductCreateViewModel viewModelPrepare = null)
        {
            var viewModel = viewModelPrepare ?? new ProductCreateViewModel();

            var tags = await _tagService.GetActiveAsync();
            viewModel.Tags = _mapper.Map<List<TagViewModel>>(tags);
            var company = await _companyService.FindByUserIdAsync(_webContextManager.CurrentUserId);
            viewModel.CategoryId = company.CategoryId.GetValueOrDefault();
            viewModel.SellTypeList = EnumHelper.CastToSelectListItems<SellType>(); 
            viewModel.KeywordList = await _keywordService.GetAllActiveAsSelectListAsync();

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public async Task<ProductDetailViewModel> PrepareDetailViewModelAsync(string productCode)
        {
            var result = await _productService.IsApprovedAsync(productCode);
            if (!result)
                throw new FactoryException("عدم تائید محصول");

            var product = await _productService.FindByCodeAsync(productCode);
            if (product == null)
                throw new FactoryException();
            var viewModel = _mapper.Map<ProductDetailViewModel>(product);

            //  VISIT LOG
            await _productVisitService.CreateByProductIdAsync(viewModel.Id);

            //  CATALOG DETAIL
            if (product.IsCatalog == true)
            {
                var catalogProductRequest = new ProductSearchRequest
                {
                    Code = product.Code
                };
                var catalogProducts = await _productService.GetByRequestAsync(catalogProductRequest);
                viewModel.CatalogProducts = _mapper.Map<IList<CatalogDetailViewModel>>(catalogProducts);

                foreach (var catalogProduct in viewModel.CatalogProducts)
                {
                    catalogProduct.ProductIsExist = await _bagService.IsExistByProductIdAsync(catalogProduct.ProductId, _webContextManager.CurrentUserId);
                }

                viewModel.HighestPrice = await _productService.MaxByRequestAsync(new ProductSearchRequest { CatalogId = product.CatalogId, Sell = SellType.Available, AvailableCountGreater = 0 }, p => p.Price);
                viewModel.LowestPrice = await _productService.MinByRequestAsync(new ProductSearchRequest { CatalogId = product.CatalogId, Sell = SellType.Available, AvailableCountGreater = 0 }, p => p.Price);
                viewModel.CatalogCompanyCount = await _productService.CountByRequestAsync(new ProductSearchRequest { DistinctByCompanyId =  true,CatalogId = product.CatalogId, Sell = SellType.Available, AvailableCountGreater = 0 });
               }

            //  OTHER
            viewModel.LikeCount = await _productLikeService.CountAllLikedByProductIdAsync(viewModel.Id);
            viewModel.ImageCount = await _productImageService.CountAllByProductIdAsync(viewModel.Id);
            viewModel.TagCount = await _productTagService.CountAllByProductIdAsync(viewModel.Id);
            viewModel.InitLike = await _productLikeService.IsLikeCurrentUserByProductIdAsync(viewModel.Id);
            viewModel.InitNotify = await _productNotifyService.IsExistByProductIdAsync(viewModel.Id, true);
            viewModel.VisitCount = await _productVisitService.CountByProductIdAsync(viewModel.Id);
            viewModel.IsExist = await _bagService.IsExistByProductIdAsync( viewModel.Id,_webContextManager.CurrentUserId);
            viewModel.RateUsers = await _productRateService.GetUserCountByProductIdAsync(viewModel.Id);
            viewModel.RateNumber = await _productRateService.GetRateByProductIdAsync(viewModel.Id);
            viewModel.CurrentUserRate = await _productRateService.GetRateByCurrentUserAsync(viewModel.Id);

            //  CATEGORY OPTION
            if (product.CategoryId != null)
            {
                var categoryOption = await _categoryService.GetCategoryOptionByIdAsync(product.CategoryId.Value);
                viewModel.CategoryOption = _mapper.Map<CategoryOptionViewModel>(categoryOption);
            }

            //  PRODUCT IMAGES
            if (viewModel.IsCatalog == true)
            {
                var catalogImages = await _catalogImageService.GetByCatalogIdAsync(viewModel.CatalogId.Value);
                viewModel.Images = _mapper.Map<List<ProductImageViewModel>>(catalogImages);
            }
            else
            {
                var productImages = await _productImageService.GetByProductIdAsync(viewModel.Id);
                viewModel.Images = _mapper.Map<List<ProductImageViewModel>>(productImages);
            }

            //  PRODUCT FEATURES
            if (viewModel.IsCatalog == true)
            {
                var catalogFeatureRequest = new CatalogFeatureSearchRequest
                {
                    CatalogId = viewModel.CatalogId,
                    PageSize = PageSize.Count100
                };
                var catalogFeatures = await _catalogFeatureService.GetByRequestAsync(catalogFeatureRequest);
                viewModel.Features = _mapper.Map<List<ProductFeatureViewModel>>(catalogFeatures);
            }
            else
            {
                var requestFeature = new ProductFeatureSearchRequest
                {
                    ProductId = viewModel.Id,
                    PageSize = PageSize.Count100
                };
                var features = await _productFeatureService.GetByRequestAsync(requestFeature);
                viewModel.Features = _mapper.Map<List<ProductFeatureViewModel>>(features);
            }

            //  PRODUCT TAGS
            var tags = await _productTagService.GetByProductIdAsync(viewModel.Id);
            viewModel.Tags = tags.Select(model => new ProductTagViewModel
            {
                TagTitle = model.Tag.Title,
                TagColor = model.Tag.Color
            }).ToList();

            //  PRODUCT COMMENTS
            var request = new ProductCommentSearchRequest
            {
                PageSize = PageSize.Count100,
                ProductId = viewModel.Id,
                State = StateType.Approved
            };
            var productCommentList = await _productCommentService.ListByRequestAsync(request);
            viewModel.ProductCommentList = productCommentList;

            //  PRODUCT SPECIFICATIONS
            if (viewModel.IsCatalog == true)
            {
                var catalogSpecification = await _catalogSpecificationService.GetByCatalogIdAsync(viewModel.CatalogId.Value);
                var orderProductSpecificationViewModels = catalogSpecification.Select(model =>
                        new ProductSpecificationViewModel
                        {
                            ProductId = model.CatalogId.GetValueOrDefault(),
                            Id = model.Id,
                            SpecificationId = model.SpecificationId.GetValueOrDefault(),
                            SpecificationOptionTitle = model.SpecificationOption?.Title ?? model.Value,
                            SpecificationTitle = model.Specification?.Title,
                            SpecificationOrder = model.Specification?.Order
                        })
                    .OrderBy(model => model.SpecificationOrder)
                    .ThenBy(model => model.SpecificationTitle)
                    .ThenBy(model => model.SpecificationOptionTitle)
                    .ToList();

                viewModel.ProductSpecifications = orderProductSpecificationViewModels
                    .GroupBy(model => model.SpecificationTitle, model => model.SpecificationOptionTitle,
                        (key, value) => new ProductSpecificationViewModel
                        {
                            SpecificationTitle = key,
                            SpecificationValues = value.ToList()
                        })
                    .ToList();
            }
            else
            {
                var productSpecification = await _productSpecificationService.GetByProductIdAsync(viewModel.Id);
                var orderProductSpecificationViewModels = productSpecification.Select(model =>
                        new ProductSpecificationViewModel
                        {
                            ProductId = model.ProductId.GetValueOrDefault(),
                            Id = model.Id,
                            SpecificationId = model.SpecificationId.GetValueOrDefault(),
                            SpecificationOptionTitle = model.SpecificationOption?.Title ?? model.Value,
                            SpecificationTitle = model.Specification?.Title,
                            SpecificationOrder = model.Specification?.Order
                        })
                    .OrderBy(model => model.SpecificationOrder)
                    .ThenBy(model => model.SpecificationTitle)
                    .ThenBy(model => model.SpecificationOptionTitle)
                    .ToList();

                viewModel.ProductSpecifications = orderProductSpecificationViewModels
                    .GroupBy(model => model.SpecificationTitle, model => model.SpecificationOptionTitle,
                        (key, value) => new ProductSpecificationViewModel
                        {
                            SpecificationTitle = key,
                            SpecificationValues = value.ToList()
                        })
                    .ToList();
            }
            

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="isMine"></param>
        /// <returns></returns>
        public async Task<ProductEditViewModel> PrepareEditViewModelAsync(string productCode, bool isMine = false, ProductEditViewModel viewModelPrepare = null)
        {
            var result = await _productService.IsMineByCodeAsync(productCode);
            if (!result)
                throw new FactoryException("عدم دسترسی به این محصول");

            var product = await _productService.FindByCodeAsync(productCode);
            var viewModel = viewModelPrepare ?? _mapper.Map<ProductEditViewModel>(product);

            var tags = await _tagService.GetActiveAsync();
            viewModel.Tags = _mapper.Map<List<TagViewModel>>(tags);

            var productTags = await _productTagService.GetByProductIdAsync(product.Id);
            viewModel.ProductTags = _mapper.Map<List<ProductTagCreateViewModel>>(productTags);

            viewModel.SellTypeList = EnumHelper.CastToSelectListItems<SellType>();
            viewModel.KeywordList = await _keywordService.GetAllActiveAsSelectListAsync();
            viewModel.ProductKeywords = await _productKeywordService.GetTitlesByProductIdAsync(product.Id);
            viewModel.ProductKeywordList = await _productKeywordService.GetIdsByProductIdAsync(product.Id);

            if (isMine)
                viewModel.IsMine = true;

            return viewModel;
        }


        public async Task<ProductListViewModel> PrepareListViewModelAsync(ProductSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _productService.CountByRequestAsync(request);
            var products = await _productService.GetByRequestAsync(request);
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            productsViewModel = productsViewModel.GroupBy(model => model.Code).Select(model => model.First()).ToList();
            foreach (var productViewModel in productsViewModel)
            {
                if (productViewModel.IsCatalog == true)
                {
                    productViewModel.HighestPrice = await _productService.MaxByRequestAsync(new ProductSearchRequest {CatalogId = productViewModel.CatalogId, Sell = SellType.Available, AvailableCountGreater = 0 }, product => product.Price);
                    productViewModel.LowestPrice = await _productService.MinByRequestAsync(new ProductSearchRequest {CatalogId = productViewModel.CatalogId, Sell = SellType.Available, AvailableCountGreater = 0 }, product => product.Price);
                    productViewModel.CatalogCompanyCount = await _productService.CountByRequestAsync(new ProductSearchRequest { DistinctByCompanyId = true, CatalogId = productViewModel.CatalogId, Sell = SellType.Available, AvailableCountGreater = 0 });
                }
            }

            for (var i = 0; i < productsViewModel.Count; i++)
            {
                productsViewModel[i].IsExist = await _bagService.IsExistByProductIdAsync(productsViewModel[i].Id,_webContextManager.CurrentUserId);
            }

            var viewModel = new ProductListViewModel
            {
                Products = productsViewModel,
                SearchRequest = request,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                SortMemberList = await _listManager.GetSortMemberFilterListAsync(),
                StateTypeList = EnumHelper.CastToSelectListItems<StateType>(),
                ProductApproved = await _productService.CountByUserIdAsync(_webContextManager.CurrentUserId, StateType.Approved),
                ProductPendeing = await _productService.CountByUserIdAsync(_webContextManager.CurrentUserId, StateType.Pending),
                ProductReject = await _productService.CountByUserIdAsync(_webContextManager.CurrentUserId, StateType.Rejected),
                ProductAll = await _productService.CountByUserIdAsync(_webContextManager.CurrentUserId, StateType.All)
            };

            if (isCurrentUser)
            {
                viewModel.IsMine = true;
                viewModel.Products.ForEach(p => p.IsMine = true);
            }

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<ProductReviewListViewModel> PrepareReviewListViewModelAsync(Guid productId)
        {
            var productReviews = await _productReviewService.GetByProductIdAsync(productId);
            var productReviewsViewModel = _mapper.Map<IList<ProductReviewViewModel>>(productReviews);
            var listViewModel = new ProductReviewListViewModel
            {
                ProductReviews = productReviewsViewModel
            };

            return listViewModel;
        }


        public async Task<ProductSearchViewModel> PrepareSearchViewModelAsync(ProductSearchRequest request)

        {
            var viewModel = new ProductSearchViewModel();

            //  PRODUCT LIST
           request.CategoryWithMany = true;
            request.State = StateType.Approved;
            request.Sell = SellType.Available;
            viewModel.MinPrice = await _productService.MinByRequestAsync(request, product => product.Price);
            viewModel.MaxPrice = await _productService.MaxByRequestAsync(request, product => product.Price);

            var category = await _categoryService.FindByAliasAsync(request.CategoryAlias);
            if (category != null) request.CategoryId = category.Id;
            request.SpecificationsDictionary = request.QueryString.ToQueryStringDictionary();
           
          
            if (request.Price.HasValue())
            {
                var priceOrigin = request.Price.Split('-');
                if (priceOrigin.Length == 2)
                {
                    decimal result;
                    if (decimal.TryParse(priceOrigin[0], out result))
                        request.MinPrice = result;
                    if (decimal.TryParse(priceOrigin[1], out result))
                        request.MaxPrice = result;
                }
            }
            if (request.SpecificationsDictionary != null && request.SpecificationsDictionary.ContainsKey("color"))
                request.Colors = request.SpecificationsDictionary["color"].Select(s => s.ToInt32()).ToList();

                var productList = await _productService.GetByRequestAsync(request);
            viewModel.Products = _mapper.Map<List<ProductViewModel>>(productList);
           
           //viewModel.Products = viewModel.Products.GroupBy(model => model.Code).Select(model => model.First()).ToList();
            foreach (var productViewModel in viewModel.Products)
            {
                if (productViewModel.IsCatalog == true)
                {
                    productViewModel.HighestPrice = await _productService.MaxByRequestAsync(new ProductSearchRequest { CatalogId = productViewModel.CatalogId, Sell = SellType.Available, AvailableCountGreater = 0 }, product => product.Price);
                    productViewModel.LowestPrice = await _productService.MinByRequestAsync(new ProductSearchRequest { CatalogId = productViewModel.CatalogId, Sell = SellType.Available, AvailableCountGreater = 0 }, product => product.Price);
                    productViewModel.CatalogCompanyCount = await _productService.CountByRequestAsync(new ProductSearchRequest { DistinctByCompanyId = true, CatalogId = productViewModel.CatalogId, Sell = SellType.Available, AvailableCountGreater = 0 });
                }
            }

            //  FILL SEARCH
            viewModel.SearchRequest = request;
            viewModel.SearchRequest.TotalCount = await _productService.CountByRequestAsync(request);
           
            //  FILL LIST
            viewModel.CityList = await _addressService.GetProvinceAsSelectListItemAsync();
            viewModel.PageSizeFilterList = EnumHelper.CastToSelectListItems<PageSizeFilterType>();
            viewModel.SortDirectionFilterList = await _listManager.GetSortDirectionFilterListAsync();
            viewModel.SortMemberFilterList = await _listManager.GetSortMemberFilterListAsync();
            viewModel.CategoryList = await _categoryService.GetRaletedCategoriesByAliasAsync(request.CategoryAlias);

            var rootId = (await _categoryService.GetRootAsync()).Id;
            var categories = await _categoryService.GetChildsByIdAsync(rootId);
            viewModel.Categories = _mapper.Map<List<CategoryViewModel>>(categories);
            viewModel.Specifications = await _specificationService.GetViewModelByCategoryAliasAsync(request.CategoryAlias);
            viewModel.Colors = EnumHelper.CastToSelectListItems<ColorType>();
            foreach (var color in viewModel.Colors)
            {
                if (request.Colors != null){
                    if (request.Colors.Contains(color.Value.ToInt32()))
                        color.Selected = true;
                }
            }

            foreach (var specification in viewModel.Specifications)
            {
                foreach (var specificationOption in specification.Options)
                {
                    if (request.SpecificationsDictionary != null && (request.SpecificationsDictionary.ContainsKey(specification.Title) && request.SpecificationsDictionary[specification.Title].Any(m => m == specificationOption.Title)))
                        specificationOption.IsSelected = true;
                }
            }
            viewModel.RequestValues =
                await _productService.CastQueryDictionaryToRequestValues(viewModel.SearchRequest
                    .SpecificationsDictionary);
            return viewModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="isMine"></param>
        /// <param name="viewModelPrepare"></param>
        /// <returns></returns>
        public async Task<ProductBulkEditViewModel> PrepareEditCatalogViewModelAsync(string productCode, bool isMine = false, ProductBulkEditViewModel viewModelPrepare = null)
        {
            var products = await _productService.GetByCodeWithCurrentUser(productCode);
            var productBulks = _mapper.Map<IList<ProductBulkViewModel>>(products);

            var viewModel = new ProductBulkEditViewModel
            {
                CategoryListJson = JsonConvert.SerializeObject(await _categoryService.GetAllowedAsSelect2ObjectAsync()),
                CatalogListJson = JsonConvert.SerializeObject(await _catalogService.GetAsSelect2ObjectAsync()),
                GuaranteeList = await _guaranteeService.GetAsSelectListAsync(),
                ColorList = EnumHelper.CastToSelectListItems<ColorType>(),
                ProductBulks = productBulks
            };
            //var viewModel = viewModelPrepare ?? _mapper.Map<ProductBulkEditViewModel>(product);

            //viewModel.CategoryListJson = JsonConvert.SerializeObject(await _categoryService.GetAllowedAsSelect2ObjectAsync());
            //viewModel.CatalogListJson = JsonConvert.SerializeObject(await _catalogService.GetAsSelect2ObjectAsync());
            //viewModel.GuaranteeList = await _guaranteeService.GetAsSelectListAsync();
            //viewModel.ColorList = SelectListHelper.CastToSelectListItems<ColorType>();

            if (isMine)
                viewModel.IsMine = true;

            return viewModel;
        }

        #endregion Public Methods
    }
}