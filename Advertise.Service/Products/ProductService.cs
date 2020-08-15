using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Domains.Categories;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Domains.Locations;
using Advertise.Core.Domains.Products;
using Advertise.Core.Domains.Users;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Product;
using Advertise.Core.Models.ProductLike;
using Advertise.Core.Objects;
using Advertise.Core.Types;
using Advertise.Core.Utilities;
using Advertise.Data.DbContexts;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Services.Keywords;
using Advertise.Service.Services.Locations;
using Advertise.Service.Services.Notifications;
using Advertise.Service.Services.Receipts;
using Advertise.Service.Services.Specifications;
using Advertise.Service.Services.WebContext;
using Advertise.Service.Validators.Product;
using AutoMapper;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using Advertise.Core.Exceptions;
using Advertise.Core.Helpers;
using Advertise.Service.Managers.Events;
using Advertise.Service.Managers.File;
using Advertise.Service.Managers.Html;
using Advertise.Service.Services.Categories;
using Org.BouncyCastle.Crypto.Tls;
using Z.EntityFramework.Plus;

namespace Advertise.Service.Services.Products
{
    /// <summary>
    /// </summary>
    public class ProductService : IProductService
    {
        #region Private Fields

        private readonly IBagService _bagService;
        private readonly IDbSet<Category> _categoryRepository;
        private readonly IDbSet<Company> _companyRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IKeywordService _keywordService;
        private readonly ICityService _cityService;
        private readonly ISpecificationOptionService _specificationOptionService;
        private readonly ISpecificationService _specificationService;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;
        private readonly IProductCommentService _productCommentService;
        private readonly IDbSet<ProductFeature> _productFeatureRepository;
        private readonly IProductFeatureService _productFeatureService;
        private readonly IDbSet<ProductImage> _productImageRepository;
        private readonly IProductImageService _productImageService;
        private readonly IDbSet<ProductKeyword> _productKeywordRepository;
        private readonly IProductLikeService _productLikeService;
        private readonly IDbSet<Product> _productRepository;
        private readonly IProductReviewService _productReviewService;
        private readonly IDbSet<ProductSpecification> _productSpecificationRepository;
        private readonly IProductSpecificationService _productSpecificationService;
        private readonly IDbSet<ProductTag> _productTagRepository;
        private readonly IProductTagService _productTagService;
        private readonly IProductVisitService _productVisitService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<User> _userRepository;
        private readonly IWebContextManager _webContextManager;
        private readonly IDbSet<Catalog> _catalogRepository;

        #endregion Private Fields

        #region Public Constructors

        ///   <summary>
        ///
        ///   </summary>
        ///   <param name="mapper"></param>
        ///   <param name="productReviewService"></param>
        ///   <param name="productImageService"></param>
        ///   <param name="productTagService"></param>
        ///   <param name="productFeatureService"></param>
        ///   <param name="productVisitService"></param>
        ///   <param name="productSpecificationService"></param>
        ///   <param name="bagService"></param>
        ///   <param name="productCommentService"></param>
        ///   <param name="unitOfWork"></param>
        ///   <param name="webContextManager"></param>
        ///   <param name="eventPublisher"></param>
        ///  <param name="keywordService"></param>
        /// <param name="productLikeService"></param>
        public ProductService(IMapper mapper, IProductReviewService productReviewService, IProductImageService productImageService, IProductTagService productTagService, IProductFeatureService productFeatureService, IProductVisitService productVisitService, IProductSpecificationService productSpecificationService, IBagService bagService, IProductCommentService productCommentService, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher, INotificationService notificationService, IKeywordService keywordService, IProductLikeService productLikeService, ISpecificationOptionService specificationOptionService, ISpecificationService specificationService, ICityService cityService)
        {
            _mapper = mapper;
            _productImageRepository = unitOfWork.Set<ProductImage>();
            _productImageService = productImageService;
            _productTagService = productTagService;
            _productFeatureService = productFeatureService;
            _productCommentService = productCommentService;
            _productVisitService = productVisitService;
            _productSpecificationService = productSpecificationService;
            _bagService = bagService;
            _productCommentService = productCommentService;
            _productRepository = unitOfWork.Set<Product>();
            _productFeatureRepository = unitOfWork.Set<ProductFeature>();
            _productTagRepository = unitOfWork.Set<ProductTag>();
            _productSpecificationRepository = unitOfWork.Set<ProductSpecification>();
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _notificationService = notificationService;
            _keywordService = keywordService;
            _productLikeService = productLikeService;
            _specificationOptionService = specificationOptionService;
            _specificationService = specificationService;
            _cityService = cityService;
            _catalogRepository = unitOfWork.Set<Catalog>();
            _productKeywordRepository = unitOfWork.Set<ProductKeyword>();
            _categoryRepository = unitOfWork.Set<Category>();
            _userRepository = unitOfWork.Set<User>();
            _companyRepository = unitOfWork.Set<Company>();
            _productReviewService = productReviewService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="aggregateMember"></param>
        /// <returns></returns>
        public async Task<decimal?> AverageByRequestAsync(ProductSearchRequest request, string aggregateMember)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var products = QueryByRequest(request);
            switch (aggregateMember)
            {
                case ProductAggregateMember.Price:
                    var memberAverage = await products.AverageAsync(model => model.Price);
                    return memberAverage;
            }

            return null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="code"></param>
        /// <param name="slug"></param>
        /// <returns></returns>
        public async Task<bool> CompareCodeAndSlugAsync(string code, string slug)
        {
            if (string.IsNullOrEmpty(code))
                return false;

            if (string.IsNullOrEmpty(slug))
                return true;

            var product = await FindByCodeAsync(code);
            return product.Title.CastToSlug() == slug;
        }

        public async Task<bool> IsApprovedAsync(string code)
        {
            return await _productRepository.AnyAsync(model => model.Code == code && model.State == StateType.Approved);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<int> CountAllAsync()
        {
            var request = new ProductSearchRequest();
            return await CountByRequestAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productState"></param>
        /// <returns></returns>
        public async Task<int> CountByStateAsync(StateType productState)
        {
            var request = new ProductSearchRequest
            {
                State = productState
            };
            return await CountByRequestAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<int> CountByCategoryIdAsync(Guid categoryId)
        {
            var request = new ProductSearchRequest
            {
                CategoryId = categoryId
            };
            return await CountByRequestAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public async Task<int> CountByCompanyIdAsync(Guid companyId, StateType? state = null)
        {
            var request = new ProductSearchRequest
            {
                CompanyId = companyId,
                State = state
            };
            return await CountByRequestAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(ProductSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (isCurrentUser)
                request.UserId = _webContextManager.CurrentUserId;
            else if (userId != null)
                request.UserId = userId;
            else request.UserId = null;

            if (request.DistinctByCompanyId == true)
                return await QueryByRequest(request).GroupBy(model => model.CompanyId).CountAsync();
            return await QueryByRequest(request).CountAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public async Task<int> CountByUserIdAsync(Guid userId, StateType state)
        {
            var request = new ProductSearchRequest
            {
                State = state
            };
            return await CountByRequestAsync(request, userId: userId);
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ProductCreateValidator), "Create")]
        public async Task CreateByViewModelAsync(ProductCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var ownedBy = await _userRepository.FirstOrDefaultAsync(model => model.Id == _webContextManager.CurrentUserId);
            var company = await _companyRepository.FirstOrDefaultAsync(model => model.CreatedById == _webContextManager.CurrentUserId);

            var product = _mapper.Map<Product>(viewModel);
            product.Description = viewModel.Description.ToSafeHtml();
            product.Address = null;
            product.CreatedById = ownedBy.Id;
            product.CompanyId = company.Id;
            product.CategoryId = viewModel.CategoryId != Guid.Empty ? viewModel.CategoryId : (await _categoryRepository.FirstOrDefaultAsync(m => m.ParentId == null)).Id;
            product.Code = await GenerateCodeAsync();
            product.State = StateType.Pending;
            product.CreatedOn = DateTime.Now;

            var keywords = viewModel.ProductKeywords;
            var productKeywords = new List<ProductKeyword>();
            if (keywords != null)
            {
                foreach (var keyword in keywords)
                {
                    var productKeyword = new ProductKeyword();
                    Guid isGuid;
                    Guid.TryParse(keyword, out isGuid);
                    if (isGuid != Guid.Empty)
                        productKeyword.KeywordId = keyword.ToGuid();
                    else
                        productKeyword.Title = keyword;

                    productKeywords.Add(productKeyword);
                }
            }
            product.ProductKeywords = productKeywords;

            var features = _mapper.Map<List<ProductFeature>>(viewModel.Features);
            product.Features = features.Where(feature => !string.IsNullOrEmpty(feature.Title?.Trim())).ToList();

            var images = _mapper.Map<List<ProductImage>>(viewModel.Images);
            product.Images = images;

            var tags = _mapper.Map<List<ProductTag>>(viewModel.ProductTags);
            product.Tags = tags;
            product.CreatedById = _webContextManager.CurrentUserId;

            if (viewModel.Specifications != null)
            {
                var productSpecifications = new List<ProductSpecification>();
                foreach (var specification in viewModel.Specifications)
                {
                    if (specification.SpecificationOptionIdList != null)
                    {
                        foreach (var specificationOption in specification.SpecificationOptionIdList)
                        {
                            var productSpecification = new ProductSpecification
                            {
                                SpecificationId = specification.Id,
                                SpecificationOptionId = specificationOption
                            };
                            productSpecifications.Add(productSpecification);
                        }
                    }
                    else if (specification.Value != null)
                    {
                        var productSpecification = new ProductSpecification
                        {
                            SpecificationId = specification.Id,
                            Value = specification.Value
                        };
                        productSpecifications.Add(productSpecification);
                    }
                }
                product.Specifications = productSpecifications;
            }

            _productRepository.Add(product);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(product);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ProductBulkCreateValidator),"BulkCreate")]
        public async Task CreateBulkByViewModelAsync(ProductBulkCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            foreach (var productBulk in viewModel.ProductBulks)
            {
                var request = new ProductSearchRequest
                {
                    ColorType = productBulk.Color,
                    GuaranteeId = productBulk.GuaranteeId != null && productBulk.GuaranteeId.IsValidGuid() ? productBulk.GuaranteeId.ToNullableGuid(): null,
                    CatalogId = productBulk.CatalogId,
                    IsSecondHand = productBulk.IsSecondHand,
                    SecondHandCode = productBulk.SecondHandCode

                };
                var anyCatalog = await AnyByRequestAsync(request);
                if (anyCatalog)
                    continue;

                var product = _mapper.Map<Product>(productBulk);
                product.IsCatalog = true;
                product.Code = await _catalogRepository.AsNoTracking()
                    .Where(model => model.Id == productBulk.CatalogId)
                    .Select(model => model.Code).SingleOrDefaultAsync();
                product.State = StateType.Approved;
                product.CreatedOn = DateTime.Now;
                product.ModifiedOn = DateTime.Now;
                product.CompanyId = _webContextManager.CurrentCompanyId;
                product.Sell = productBulk.AvailableCount > 0 ? SellType.Available : SellType.Unavailable;
                product.CreatedById = _webContextManager.CurrentUserId;
                product.CreatedOn = DateTime.Now;
                product.IsSecondHand = productBulk.IsSecondHand;
                if (productBulk.IsSecondHand == true)
                {
                    product.SecondHandCode = productBulk.SecondHandCode;
                    product.Description = productBulk.Description;
                }
                if (productBulk.GuaranteeId != null && productBulk.GuaranteeId.IsValidGuid())
                    product.GuaranteeId = productBulk.GuaranteeId.ToNullableGuid();
                else
                    product.GuaranteeTitle = productBulk.GuaranteeId;

                _productRepository.Add(product);

                await _unitOfWork.SaveAllChangesAsync();

                _eventPublisher.EntityInserted(product);
            }
        }

        public async Task<bool> AnyByRequestAsync(ProductSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).AnyAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ProductBulkEditValidator), "BulkEdit")]
        public async Task EditBulkByViewModelAsync(ProductBulkEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            foreach (var productBulk in viewModel.ProductBulks)
            {
                if (productBulk.Id == null)
                {
                    var request = new ProductSearchRequest
                    {
                        ColorType = productBulk.Color,
                        GuaranteeId = productBulk.GuaranteeId != null && productBulk.GuaranteeId.IsValidGuid() ? productBulk.GuaranteeId.ToNullableGuid() : null,
                        CatalogId = productBulk.CatalogId,
                        IsSecondHand = productBulk.IsSecondHand,
                        SecondHandCode = productBulk.SecondHandCode
                    };
                    var anyCatalog = await AnyByRequestAsync(request);
                    if (anyCatalog)
                        continue;

                    var product = _mapper.Map<Product>(productBulk);
                    product.IsCatalog = true;
                    product.CategoryId = productBulk.CategoryId;
                    product.CatalogId = productBulk.CatalogId;
                    product.Code = await _catalogRepository.AsNoTracking()
                        .Where(model => model.Id == productBulk.CatalogId)
                        .Select(model => model.Code).SingleOrDefaultAsync();
                    product.State = StateType.Approved;
                    product.ModifiedOn = DateTime.Now;
                    product.CompanyId = _webContextManager.CurrentCompanyId;
                    product.Sell = productBulk.AvailableCount > 0 ? SellType.Available : SellType.Unavailable;
                    product.CreatedById = _webContextManager.CurrentUserId;
                    product.IsSecondHand = productBulk.IsSecondHand;
                    if (productBulk.IsSecondHand == true)
                    {
                        product.SecondHandCode = productBulk.SecondHandCode;
                        product.Description = productBulk.Description;
                    }
                    if (productBulk.GuaranteeId != null && productBulk.GuaranteeId.IsValidGuid())
                        product.GuaranteeId = productBulk.GuaranteeId.ToNullableGuid();
                    else
                        product.GuaranteeTitle = productBulk.GuaranteeId;

                    _productRepository.Add(product);

                    await _unitOfWork.SaveAllChangesAsync();

                    //_eventPublisher.EntityUpdated(product);
                }
                else
                {
                    var originalProuct = await FindByIdAsync(productBulk.Id.Value);
                    originalProuct.Color = productBulk.Color;
                    originalProuct.Price = productBulk.Price;
                    originalProuct.AvailableCount = productBulk.AvailableCount;
                    originalProuct.Sell = productBulk.AvailableCount > 0 ? SellType.Available : SellType.Unavailable;
                    originalProuct.IsSecondHand = productBulk.IsSecondHand;
                    originalProuct.ModifiedOn = DateTime.Now;
                    if (productBulk.IsSecondHand == true)
                    {
                        originalProuct.SecondHandCode = productBulk.SecondHandCode;
                        originalProuct.Description = productBulk.Description;
                    }
                    if (productBulk.GuaranteeId != null && productBulk.GuaranteeId.IsValidGuid())
                        originalProuct.GuaranteeId = productBulk.GuaranteeId.ToNullableGuid();
                    else
                        originalProuct.GuaranteeTitle = productBulk.GuaranteeId;

                    await _unitOfWork.SaveAllChangesAsync();

                    //_eventPublisher.EntityUpdated(originalProuct);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public async Task EditCatalogByViewModelAsync(ProductEditCatalogViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var originalProuct = await FindByIdAsync(viewModel.Id.Value);
            originalProuct.GuaranteeId = viewModel.GuaranteeId;
            originalProuct.Color = viewModel.Color;
            originalProuct.Price = viewModel.Price;
            originalProuct.AvailableCount = viewModel.AvailableCount;
            originalProuct.Sell = viewModel.AvailableCount > 0 ? SellType.Available : SellType.Unavailable;
            originalProuct.ModifiedOn = DateTime.Now;
            originalProuct.IsSecondHand = viewModel.IsSecondHand;
            if (viewModel.IsSecondHand == true)
            {
                originalProuct.SecondHandCode = viewModel.SecondHandCode;
                originalProuct.Description = viewModel.Description;
            }
            await _unitOfWork.SaveAllChangesAsync();

            //_eventPublisher.EntityUpdated(originalProuct);
        }

        /// <summary>
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public async Task DeleteByCodeAsync(string productCode, bool isCurrentUser = false)
        {

            var product = await _productRepository.FirstOrDefaultAsync(model => model.Code == productCode);
            if (isCurrentUser &&  product.CreatedById != _webContextManager.CurrentUserId)
                return;

            await _productImageService.RemoveRangeAsync(product.Images.ToList());
            await _productFeatureService.RemoveRangeAsync(product.Features.ToList());
            await _productTagService.RemoveRangeAsync(product.Tags.ToList());
            await _productSpecificationService.RemoveRangeAsync(product.Specifications.ToList());
            await _productVisitService.RemoveRangeAsync(product.Visits.ToList());
            await _productReviewService.RemoveRangeAsync(product.Reviews.ToList());
            await _productCommentService.RemoveRangeAsync(product.Comments.ToList());
            await _bagService.RemoveRangeAsync(product.Bags.ToList());
            await _productLikeService.RemoveRangeAsync(product.Likes.ToList());
            _productRepository.Remove(product);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(product);
        }

        public async Task<IList<ProductViewModel>> GetByIdsAsync(IEnumerable<Guid?> listId)
        {
            List<Product> products = new List<Product>();
            foreach (var catalogId in listId)
            {
                var ss = await _productRepository.Where(model => model.CatalogId == catalogId).ToListAsync();
                if (ss != null)
                    foreach (var item in ss)
                    {
                        products.Add(item);
                    }
            }
            return _mapper.Map<IList<ProductViewModel>>(products);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task DeleteByUserIdAsync(Guid userId)
        {
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));

            var products = await GetProductsByUserIdAsync(userId);

            if (products.Count > 0)
                foreach (var product in products)
                    await DeleteByCodeAsync(product.Code);
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ProductEditValidator),"Edit")]
        public async Task EditApproveByViewModelAsync(ProductEditViewModel viewModel)
        {
            var product = await _productRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            var oldProduct = (Product)product.Clone();

            await EditAsync(viewModel, product);
            product.ApprovedById = _webContextManager.CurrentUserId;
            product.State = StateType.Approved;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(oldProduct);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="originalProduct"></param>
        /// <returns></returns>
        public async Task EditAsync(ProductEditViewModel viewModel, Product originalProduct)
        {
            // Product
            _mapper.Map(viewModel, originalProduct);
            originalProduct.Description = viewModel.Description.ToSafeHtml();

            // Product Images
            var images = _mapper.Map<List<ProductImage>>(viewModel.Images);
            if (images == null)
            {
                _productImageRepository.Where(model => model.ProductId == viewModel.Id).Delete();
            }
            else
            {
                _productImageRepository.Where(model => model.ProductId == viewModel.Id).Delete();
                originalProduct.Images.AddRange(images.ToArray());
            }

            //  Product Keywords
            var keywords = viewModel.ProductKeywords;
            if (keywords == null)
            {
                _productKeywordRepository.Where(model => model.ProductId == viewModel.Id).Delete();
            }
            else
            {
                _productKeywordRepository.Where(model => model.ProductId == viewModel.Id).Delete();
                var productKeywords = new List<ProductKeyword>();
                foreach (var keyword in keywords)
                {
                    var productKeyword = new ProductKeyword();
                    Guid isGuid;
                    Guid.TryParse(keyword, out isGuid);
                    if (isGuid != Guid.Empty)
                        productKeyword.KeywordId = keyword.ToGuid();
                    else
                        productKeyword.Title = keyword;

                    productKeywords.Add(productKeyword);
                }
                //originalProduct.ProductKeywords.Clear();
                //.ProductKeywords = new List<ProductKeyword>();
                originalProduct.ProductKeywords.AddRange(productKeywords.ToArray());
            }

            // Product Features
            var features = _mapper.Map<List<ProductFeature>>(viewModel.Features);
            if (features == null)
            {
                _productFeatureRepository.Where(model => model.ProductId == viewModel.Id).Delete();
            }
            else
            {
                _productFeatureRepository.Where(model => model.ProductId == viewModel.Id).Delete();
                originalProduct.Features.AddRange(features.Where(feature => !string.IsNullOrEmpty(feature.Title?.Trim())).ToArray());
            }

            // Product Tags
            var productTags = _mapper.Map<List<ProductTag>>(viewModel.ProductTags);
            if (productTags == null)
            {
                _productTagRepository.Where(model => model.ProductId == viewModel.Id).Delete();
            }
            else
            {
                _productTagRepository.Where(model => model.ProductId == viewModel.Id).Delete();
                originalProduct.Tags.AddRange(productTags.ToArray());
            }

            // Product Specifications
            if (viewModel.Specifications == null)
            {
                _productSpecificationRepository.Where(model => model.ProductId == viewModel.Id).Delete();
            }
            else
            {
                _productSpecificationRepository.Where(model => model.ProductId == viewModel.Id).Delete();
                var productSpecifications = new List<ProductSpecification>();
                foreach (var specification in viewModel.Specifications)
                {
                    if (specification.SpecificationOptionIdList != null)
                    {
                        foreach (var specificationOption in specification.SpecificationOptionIdList)
                        {
                            var productSpecification = new ProductSpecification
                            {
                                SpecificationId = specification.Id,
                                SpecificationOptionId = specificationOption
                            };
                            productSpecifications.Add(productSpecification);
                        }
                    }
                    else if (specification.Value != null)
                    {
                        var productSpecification = new ProductSpecification
                        {
                            SpecificationId = specification.Id,
                            Value = specification.Value
                        };
                        productSpecifications.Add(productSpecification);
                    }
                }
                originalProduct.Specifications.AddRange(productSpecifications.ToArray());
            }
        }

        /// <inheritdoc />

        [Validation(typeof(ProductEditValidator),"Edit")]
        public async Task EditByViewModelAsync(ProductEditViewModel viewModel, bool isCurrentUser = false)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var originalProduct = await _productRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            if(isCurrentUser && originalProduct.CreatedById != _webContextManager.CurrentUserId)
                return;

            originalProduct.ModifiedOn = DateTime.Now;
            await EditAsync(viewModel, originalProduct);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(originalProduct);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ProductEditValidator),"Edit")]
        public async Task EditRejectByViewModelAsync(ProductEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var product = await _productRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            await EditAsync(viewModel, product);
            product.ApprovedById = _webContextManager.CurrentUserId;
            product.State = StateType.Rejected;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(product);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<Product> FindByIdAsync(Guid productId)
        {
            return await _productRepository.FirstOrDefaultAsync(model => model.Id == productId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public async Task<Product> FindByCodeAsync(string productCode)
        {
            return await _productRepository.FirstOrDefaultAsync(model => model.Code == productCode);
        }


        public async Task<IList<Product>> GetByCodeWithCurrentUser(string productCode)
        {
            return await _productRepository.AsNoTracking()
                .Where(model => model.Code == productCode && model.CreatedById == _webContextManager.CurrentUserId)
                .ToListAsync();
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<Product> FindByUserIdWithCodeAsync(Guid userId, string code)
        {
            return await _productRepository.FirstOrDefaultAsync(model => model.CreatedById == userId && model.Code == code);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<string> GenerateCodeAsync()
        {
            var lastProductCode = await _productRepository.AsNoTracking()
                .Select(model => model.Code)
                .ToListAsync();

            var lastCatalogCode = await _catalogRepository.AsNoTracking()
                .Select(model => model.Code)
                .ToListAsync();

            return (lastProductCode.Concat(lastCatalogCode).Max(Convert.ToInt32).ToInt32() + 1).ToString() ?? "1";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<Address> GetAddressByIdAsync(Guid productId)
        {
            return await _productRepository
                  .AsNoTracking()
                  .Include(model => model.Address)
                  .Select(model => model.Address)
                  .FirstOrDefaultAsync(model => model.Id == productId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IList<SelectListItem>> GetAllCurrentUserAsSelectListItem()
        {
            return await _productRepository.AsNoTracking()
                .Where(model => model.State == StateType.Approved && model.CreatedById == _webContextManager.CurrentUserId)
                .Select(record => new SelectListItem
                {
                    Value = record.Id.ToString(),
                    Text = record.Title
                }).ToListAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<IList<ProductViewModel>> GetApprovedByCompanyIdAsync(Guid companyId)
        {
            var request = new ProductSearchRequest
            {
                PageSize = PageSize.All,
                CompanyId = companyId,
                State = StateType.Approved
            };
            var products = await GetByRequestAsync(request);
            var productsViewModel = _mapper.Map<IList<ProductViewModel>>(products);
            for (var i = 0; i < productsViewModel.Count; i++)
            {
                productsViewModel[i].IsExist = await _bagService.IsExistByProductIdAsync(productsViewModel[i].Id, _webContextManager.CurrentUserId);
            }
            return productsViewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product GetByIdAsync(Guid productId)
        {
            return _productRepository
                 .AsNoTracking()
                 .FirstOrDefault(model => model.Id == productId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IList<Product>> GetByRequestAsync(ProductSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid productId)
        {
            return (await _productRepository.AsNoTracking()
                    .Where(model => model.Id == productId)
                    .Select(model => new
                    {
                        model.Id,
                        model.ImageFileName
                    }).ToListAsync())
                .Select(model => new FineUploaderObject
                {
                    id = model.Id.ToString(),
                    uuid = model.Id.ToString(),
                    name = model.ImageFileName,
                    thumbnailUrl = FileConst.ImagesWebPath.PlusWord(model.ImageFileName),
                    size = new FileInfo(HttpContext.Current.Server.MapPath(FileConst.ImagesWebPath.PlusWord(model.ImageFileName))).Length.ToString()
                }).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IList<SelectListItem>> GetAsSelectListAsync()
        {
            return await _productRepository.AsNoTracking()
                .Where(model => model.State == StateType.Approved)
                .Select(model => new SelectListItem
                {
                    Value = model.Id.ToString(),
                    Text = model.Title
                }).ToListAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<IList<FineUploaderObject>> GetFilesAsFineUploaderModelByIdAsync(Guid productId)
        {
            return (await _productRepository.AsNoTracking()
                .Include(model => model.Images)
                    .Where(model => model.Id == productId)
                    .Select(model => model.Images)
                    .SingleOrDefaultAsync())
                .Select(model => new FineUploaderObject
                {
                    id = model.Id.ToString(),
                    uuid = model.Id.ToString(),
                    name = model.FileName,
                    thumbnailUrl = FileConst.ImagesWebPath.PlusWord(model.FileName),
                    size = new FileInfo(HttpContext.Current.Server.MapPath(FileConst.ImagesWebPath.PlusWord(model.FileName))).Length.ToString()
                }).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<ProductLikeListViewModel> GetMyListProductLikeAsync()
        {
            var listProductId = await _productRepository
                .AsNoTracking()
                .Where(model => model.CreatedById == _webContextManager.CurrentUserId)
                .Select(model => model.Id).ToListAsync();

            var viewModel = await _productLikeService.GetByProductsAsync(listProductId);
            return new ProductLikeListViewModel
            {
                ProductLikes = viewModel
            };
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IList<Product>> GetProductsByUserIdAsync(Guid userId)
        {
            return await _productRepository
                .AsNoTracking()
                .Where(model => model.CreatedById == userId).ToListAsync();
        }

        public async Task<bool> IsMineByCodeAsync(string productCode)
        {
            if (HttpContext.Current.User.IsInRole("CanProductEdit"))
                return true; 
            return await _productRepository.AsNoTracking().AnyAsync(model => model.Code == productCode && model.CreatedById == _webContextManager.CurrentUserId);
        }
      

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="agg"></param>
        /// <returns></returns>
        public async Task<decimal?> MaxByRequestAsync(ProductSearchRequest request, Expression<Func<Product, decimal?>> agg)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).MaxAsync(agg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<string> MaxCodeByRequestAsync(ProductSearchRequest request , Expression<Func<Product, string>> code)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            ;
           return await QueryByRequest(request).MaxAsync(code);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="aggregateMember"></param>
        /// <returns></returns>
        public async Task<decimal?> MinByRequestAsync(ProductSearchRequest request, Expression<Func<Product, decimal?>> agg)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

           return await QueryByRequest(request).MinAsync(agg);

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<Product> QueryByRequest(ProductSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var products = _productRepository.AsNoTracking().AsQueryable().AsExpandable()
                .Include(model => model.CreatedBy)
                .Include(model => model.CreatedBy.Meta)
                .Include(model => model.Company)
                .Include(model => model.Images)
                .Include(model => model.Category)
                .Include(model => model.Address);

            if (request.MaxPrice.HasValue)
                products = products.Where(model => model.Price <= request.MaxPrice);
            if (request.MinPrice.HasValue)
                products = products.Where(model => model.Price >= request.MinPrice);
           
            //if (request.CategoryAlias != null && request.CategoryAlias != "Category-All")
            //    products = products.Where(model => model.Category.Alias == request.CategoryAlias);
            //if (request.CategoryId != null && request.CategoryId != Guid.Parse("666c3824-0105-9e5b-b86b-0226a45db0d2"))
            //    products = products.Where(model => model.CategoryId == request.CategoryId);
           if (request.CatalogId != null)
                products = products.Where(model => model.CatalogId == request.CatalogId);
            if (request.Code != null)
                products = products.Where(model => model.Code == request.Code);
            if (request.CompanyId.HasValue)
                products = products.Where(product => product.CompanyId == request.CompanyId);
            if (request.UserId.HasValue)
                products = products.Where(product => product.CreatedById == request.UserId);
            if (request.StateId.HasValue)
                products = products.Where(model => model.Company.Address.CityId == request.StateId);
            if (request.ColorType.HasValue)
                products = products.Where(product => product.Color == request.ColorType);
            if (request.GuaranteeId.HasValue)
                products = products.Where(product => product.GuaranteeId == request.GuaranteeId);
            if (request.CategoryAlias != null && request.CategoryWithMany != true)
                products = products.Where(product => product.Category.Alias == request.CategoryAlias);
           

            //if (request.CategoryId != null && request.CategoryWithMany == true)
            //{
            //    var categories = _categoryRepository.Where(model => model.Id == request.CategoryId)
            //        .SelectMany(model => model.Childrens).Select(model => model.Id).ToList();
            //    products = products.Where(product => categories.Contains(product.CategoryId.Value) || product.Category.Id == request.CategoryId);
            //}
            if (request.Ids != null && request.Ids.Any())
                products = products.Where(model => request.Ids.Contains(model.Id));
            if (request.CreatedById.HasValue)
                products = products.Where(model => model.CreatedById == request.CreatedById);
            if (request.Term.HasValue())
                products = products.Where(product => product.Title.Contains(request.Term) || product.Description.Contains(request.Term) || product.Catalog.Title.Contains(request.Term));
            if (request.State.HasValue)
                if (request.State != StateType.All)
                    products = products.Where(product => product.State == request.State);
            if (request.Sell.HasValue)
                products = products.Where(product => product.Sell == request.Sell);
            if (request.AvailableCountGreater.HasValue)
                products = products.Where(product => product.AvailableCount > request.AvailableCountGreater);

            if (request.SpecificationsDictionary != null && request.SpecificationsDictionary.Any())
            {
                var predicate = PredicateBuilder.False<Product>();
                foreach (var dictionary in request.SpecificationsDictionary)
                {
                    foreach (var value in dictionary.Value)
                    {
                        var specId = _specificationService.GetIdByTitle(dictionary.Key, request.CategoryId.Value);
                        if (specId != null)
                        {
                            var specOptionId = _specificationOptionService.GetIdByTitle(value, specId.Value);
                            predicate = predicate.Or(model => model.Specifications.Any(m => m.SpecificationOptionId == specOptionId && m.SpecificationId == specId) ||
                                model.Catalog.Specifications.Any(m => m.SpecificationOptionId == specOptionId && m.SpecificationId == specId));
                            products = products.Where(predicate);
                        }
                    }
                }
            }
            if (request.CategoryAlias != null && request.CategoryWithMany == true)
            {
                var predicate = PredicateBuilder.False<Product>();
                if (request.CategoryAlias.HasValue())
                    predicate = predicate.Or(product => product.Category.Alias == request.CategoryAlias);
                var categoryByAlias = _categoryRepository.AsNoTracking().SingleOrDefault(category => category.Alias == request.CategoryAlias);
                var categories = _categoryRepository.AsNoTracking().ToList().GetAllChildsById(categoryByAlias);
                foreach (var category in categories)
                {
                    Guid? categoryId = category.Id;
                    predicate = predicate.Or(product => product.CategoryId == categoryId);
                }
              products = products.Where(predicate);
            }
            if (request.Colors != null && request.Colors.Any())
            {
                var predicate = PredicateBuilder.False<Product>();
                foreach (var color in request.Colors)
                {
                    var enumValue = EnumHelper.GetEnumByValue<ColorType>(color.ToInt32());
                    predicate = predicate.Or(model => model.Color == enumValue);
                }
                products = products.Where(predicate);
            }

            //if (request.GroupBy != null)
            //    products = products.GroupBy(request.GroupBy).Select(grouping => grouping.FirstOrDefault());

            products = products.OrderBy($"{request.SortMember ?? SortMember.CreatedOn} {request.SortDirection ?? SortDirection.Desc}");
            //products = request.SortDirection == SortDirection.Asc ?
            //    products.AddOrAppendOrderBy(request.SortMember) :
            //    products.AddOrAppendOrderByDescending(request.SortMember);

            return products;
        }

        public async Task<IList<SelectListItem>> CastQueryDictionaryToRequestValues(Dictionary<string, List<string>> queryDictionary)
        {
            var titleList = await _specificationService.GetTitlesAsync();
            if (queryDictionary != null)
            {
                var requestValues = new List<SelectListItem>();
                foreach (var keyValuePair in queryDictionary)
                {
                    switch (keyValuePair.Key)
                    {
                        case "price":

                            requestValues.Add(new SelectListItem
                            {
                                Value = keyValuePair.Key,
                                Text = keyValuePair.Value[0],
                                Description = $"قیمت از {keyValuePair.Value[0].Split("-")[0].CastToRegularCurrency()} تا {keyValuePair.Value[0].Split("-")[1].CastToRegularCurrency()}"
                            });

                            break;

                        case "color":
                            foreach (var color in keyValuePair.Value)
                            {
                                var colorName = EnumHelper.GetDescription<ColorType>(color.ToInt32());
                                requestValues.Add(new SelectListItem
                                {
                                    Value = keyValuePair.Key,
                                    Text = keyValuePair.Value[0],
                                    Description = $" رنگ  :{colorName}"
                                });
                            }

                            break;

                        case "StateId":
                            var cityName = await _cityService.GetNameByIdAsync(keyValuePair.Value[0].ToGuid());
                            requestValues.Add(new SelectListItem
                            {
                                Value = keyValuePair.Key,
                                Text = keyValuePair.Value[0],
                                Description = $": شهر {cityName}"
                            });
                            break;

                        default:
                            if (titleList.Contains(keyValuePair.Key))
                            {
                                foreach (var valuePair in keyValuePair.Value)
                                {
                                    requestValues.Add(new SelectListItem
                                    {
                                        Value = keyValuePair.Key,
                                        Text = valuePair,
                                        Description = $"{keyValuePair.Key} : {valuePair}"
                                    });
                                }
                            }
                            break;
                    }
                }
                return requestValues;
            }
            return null;
        }

        public async Task<IList<ProductViewModel>> GetByCatalogIdAsync(Guid catalogId)
        {
            var products = await _productRepository.AsNoTracking().Where(model => model.CatalogId == catalogId)
                .ToListAsync();
            return _mapper.Map<List<ProductViewModel>>(products);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="aggregateMember"></param>
        /// <returns></returns>
        public async Task<decimal?> SumByRequestAsync(ProductSearchRequest request, string aggregateMember)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var products = QueryByRequest(request);
            switch (aggregateMember)
            {
                case ProductAggregateMember.Price:
                    var memberSum = await products.SumAsync(model => model.Price);
                    return memberSum;
            }

            return null;
        }

        public async Task SetStateByIdAsync(Guid productId, StateType state)
        {
            var product = await FindByIdAsync(productId);
            product.State = state;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(product);
        }


        #endregion Public Methods
    }
}