using Advertise.Service.Services.Catalogs;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Keywords;
using Advertise.Service.Services.List;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Models.Catalog;
using Advertise.Core.Models.CatalogSpecification;
using Advertise.Service.Services.Specifications;

namespace Advertise.Service.Factories.Catalogs
{
    /// <summary>
    /// 
    /// </summary>
    public class CatalogFactory : ICatalogFactory
    {
        #region Private Fields

        private readonly ICatalogService _catalogService;
        private readonly ICatalogSpecificationService _catalogSpecificationService;
        private readonly ISpecificationService _specificationService;
        private readonly ICommonService _commonService;
        private readonly IKeywordService _keywordService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        /// <param name="mapper"></param>
        /// <param name="keywordService"></param>
        /// <param name="catalogService"></param>
        public CatalogFactory(IListManager listManager, ICommonService commonService, IMapper mapper, IKeywordService keywordService, ICatalogService catalogService, ICatalogSpecificationService catalogSpecificationService, ISpecificationService specificationService)
        {
            _listManager = listManager;
            _commonService = commonService;
            _mapper = mapper;
            _keywordService = keywordService;
            _catalogService = catalogService;
            _catalogSpecificationService = catalogSpecificationService;
            _specificationService = specificationService;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<CatalogCreateViewModel> PrepareCreateViewModelAsync(CatalogCreateViewModel viewModelPrepare = null)
        {
            var viewModel = viewModelPrepare ?? new CatalogCreateViewModel();

            viewModel.KeywordList = await _keywordService.GetAllActiveAsSelectListAsync();

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="catalogId"></param>
        /// <returns></returns>
        public async Task<CatalogEditViewModel> PrepareEditViewModelAsync(Guid catalogId)
        {
            var catalog = await _catalogService.FindByIdAsync(catalogId);
            var viewModel = _mapper.Map<CatalogEditViewModel>(catalog);

            var allSpecifications = await _specificationService.GetByCategoryIdAsync(viewModel.CategoryId);
            var catalogSpecificationViewModel = _mapper.Map<IList<CatalogSpecificationViewModel>>(allSpecifications);
            var catalogSpecifications = await _catalogSpecificationService.GetByCatalogIdAsync(catalogId);

            //var f = _mapper.Map<IList<CatalogSpecificationViewModel>>(viewModel.Specifications);
            //for (var i = 0; i < f.Capacity; i++)
            //{
            //    f[i].SpecificationOptionIdList = productSpecifications.Where(model => model.SpecificationId == f[i].Id)
            //        .Select(model => model.SpecificationOptionId.Value).ToList();
            //}
            foreach (var item in catalogSpecificationViewModel)
            {
                item.Value = catalogSpecifications.FirstOrDefault(model => model.SpecificationId == item.Id)?.Value;
                item.SpecificationOptionIdList = catalogSpecifications.Where(model => model.SpecificationId == item.Id)
                    .Select(model => model.SpecificationOptionId).ToList();
            }
            viewModel.Specifications = catalogSpecificationViewModel;

            viewModel.KeywordList = await _keywordService.GetAllActiveAsSelectListAsync();

            return viewModel;
        }


        public async Task<CatalogListViewModel> PrepareListViewModelAsync(CatalogSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            var catalogs = await _catalogService.GetByRequestAsync(request);
            var catalogViewModel = _mapper.Map<IList<CatalogViewModel>>(catalogs);
            request.TotalCount = await _catalogService.CountByRequestAsync(request);

            var viewModel = new CatalogListViewModel
            {
                Catalogs = catalogViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                SearchRequest = request
            };

            if (isCurrentUser)
            {
                viewModel.IsMine = true;
                viewModel.Catalogs.ForEach(p => p.IsMine = true);
            }

            return viewModel;
        }

        #endregion Public Methods
    }
}