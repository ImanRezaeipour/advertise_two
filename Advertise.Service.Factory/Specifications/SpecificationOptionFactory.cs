using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Models.SpecificationOption;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Specifications;
using AutoMapper;

namespace Advertise.Service.Factories.Specifications
{

    public class SpecificationOptionFactory : ISpecificationOptionFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly ISpecificationOptionService _specificationOptionService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        /// <param name="mapper"></param>
        /// <param name="specificationOptionService"></param>
        public SpecificationOptionFactory(IListManager listManager, ICommonService commonService, IMapper mapper, ISpecificationOptionService specificationOptionService)
        {
            _listManager = listManager;
            _commonService = commonService;
            _mapper = mapper;
            _specificationOptionService = specificationOptionService;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<SpecificationOptionCreateViewModel> PrepareCreateViewModelAsync()
        {
            var viewModel = new SpecificationOptionCreateViewModel();

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="specificationOptionId"></param>
        /// <returns></returns>
        public async Task<SpecificationOptionDetailViewModel> PrepareDetailViewModelAsync(Guid specificationOptionId)
        {
            var specificationOption = await _specificationOptionService.FindByIdAsync(specificationOptionId);
            var viewModel = _mapper.Map<SpecificationOptionDetailViewModel>(specificationOption);

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="specificationOptionId"></param>
        /// <returns></returns>
        public async Task<SpecificationOptionEditViewModel> PrepareEditViewModelAsync(Guid specificationOptionId)
        {
            var specificationOption = await _specificationOptionService.FindWithCategoryAsync(specificationOptionId);
            var viewModel = _mapper.Map<SpecificationOptionEditViewModel>(specificationOption);

            return viewModel;
        }


        public async Task<SpecificationOptionListViewModel> PrepareListViewModelAsync(SpecificationOptionSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _specificationOptionService.CountByRequestAsync(request);
            var specificationOption = await _specificationOptionService.GetByRequestAsync(request);
            var specificationOptionViewModel = _mapper.Map<IList<SpecificationOptionViewModel>>(specificationOption);
            var viewModel = new SpecificationOptionListViewModel
            {
                SearchRequest = request,
                SpecificationOptions = specificationOptionViewModel
            };
            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();

            return viewModel;
        }

        #endregion Public Methods
    }
}