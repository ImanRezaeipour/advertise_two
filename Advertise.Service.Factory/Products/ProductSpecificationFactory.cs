using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Exceptions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductSpecification;
using Advertise.Core.Models.Specification;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Products;
using Advertise.Service.Services.Specifications;
using AutoMapper;

namespace Advertise.Service.Factories.Products
{
    public class ProductSpecificationFactory : IProductSpecificationFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IProductSpecificationService _productSpecificationService;
        private readonly ISpecificationService _specificationService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        /// <param name="specificationService"></param>
        /// <param name="productSpecificationService"></param>
        /// <param name="mapper"></param>
        /// <param name="productService"></param>
        public ProductSpecificationFactory(IListManager listManager, ICommonService commonService, ISpecificationService specificationService, IProductSpecificationService productSpecificationService, IMapper mapper, IProductService productService)
        {
            _listManager = listManager;
            _commonService = commonService;
            _specificationService = specificationService;
            _productSpecificationService = productSpecificationService;
            _mapper = mapper;
            _productService = productService;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<IList<ProductSpecificationCreateViewModel>> PrepareCreateViewModelAsync(Guid categoryId)
        {
            if (categoryId == null)
                throw new ArgumentNullException(nameof(categoryId));

            var specifications = await _specificationService.GetByCategoryIdAsync(categoryId);
            var viewModel = _mapper.Map<IList<ProductSpecificationCreateViewModel>>(specifications);

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="productSpecificationId"></param>
        /// <returns></returns>
        public async Task<ProductSpecificationDetailViewModel> PrepareDetailViewModelAsync(Guid productSpecificationId)
        {
            var productSpecification = await _productSpecificationService.FindByIdAsync(productSpecificationId);
            var viewmodel = _mapper.Map<ProductSpecificationDetailViewModel>(productSpecification);

            return viewmodel;
        }

        /// <summary>
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<IList<ProductSpecificationEditViewModel>> PrepareEditViewModelAsync(Guid productId)
        {
            var product = await _productService.FindByIdAsync(productId);
            if(product.CategoryId == null)
                throw new FactoryException();
            var specifications = await _specificationService.GetByCategoryIdAsync(product.CategoryId.Value);

            var viewModel = _mapper.Map<IList<ProductSpecificationEditViewModel>>(specifications);

            //viewModel = viewModel.Select(c =>
            //{
            //    c.SpecificationOptionIdList = new List<Guid>();
            //    return c;
            //}).ToList();

            var productSpecificationRequest = new ProductSpecificationSearchRequest
            {
                PageSize = PageSize.All,
                ProductId = productId
            };
            var productSpecifications = await _productSpecificationService.GetByRequestAsync(productSpecificationRequest);

            foreach (var item in viewModel)
            {
                item.Value = productSpecifications.SingleOrDefault(model => model.SpecificationId == item.Id)?.Value;
                item.SpecificationOptionIdList = productSpecifications.Where(model => model.SpecificationId == item.Id)
                    .Select(model => model.SpecificationOptionId).ToList();
            }

            //foreach (var productSpecification in productSpecifications)
            //{
            //    var specification = viewModel.FirstOrDefault(model => model.Id == productSpecification.SpecificationId);
            //    if (specification == null)
            //        continue;

            //    var index = viewModel.IndexOf(specification);
            //    viewModel[index].Value = productSpecification.Value;
            //    if (productSpecification.SpecificationOptionId != null)
            //    {
            //        viewModel[index].SpecificationOptionIdList.Add(productSpecification.SpecificationOptionId.Value);
            //    }
            //}

            //var specifications = (from spec in _specification
            //    join prod in _productSpecificationRepository on spec.Id equals prod.SpecificationId into p
            //    from sub in p.DefaultIfEmpty()
            //    where spec.CategoryId == categoryId
            //    select new { spec.Id, spec.Description, spec.Title, spec.Type, spec.Order, SpecificationOptionId = (sub == null ? Guid.Empty : sub.SpecificationOptionId), Value = (sub == null ? "" : sub.Value) }).ToList();

            //var list = new List<ProductSpecificationNewViewModel>();

            //foreach (var specification in specifications)
            //{
            //    list.Add(new ProductSpecificationNewViewModel()
            //    {
            //        Title = specification.Title,
            //        Description = specification.Description,
            //        Order = specification.Order.GetValueOrDefault(),
            //        SpecificationOptionId = specification.SpecificationOptionId.GetValueOrDefault(),
            //        Value = specification.Value,
            //        Type = specification.Type.GetValueOrDefault(),
            //        SpecificationOptions = await _specificationOptionService.GetViewModelBySpecificationIdAsync(specification.Id)
            //    });
            //}

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ProductSpecificationListViewModel> PrepareListViewModelAsync(ProductSpecificationSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _productSpecificationService.CountByRequestAsync(request);
            var productSpecifications = await _productSpecificationService.GetByRequestAsync(request);
            var productSpecificationViewModel = _mapper.Map<IList<ProductSpecificationViewModel>>(productSpecifications);
            var viewModel = new ProductSpecificationListViewModel
            {
                SearchRequest = request,
                ProductSpecifications = productSpecificationViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
            };

            return viewModel;
        }

        #endregion Public Methods
    }
}