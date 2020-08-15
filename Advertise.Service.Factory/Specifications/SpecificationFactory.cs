using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Helpers;
using Advertise.Core.Models.Specification;
using Advertise.Core.Models.SpecificationOption;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Specifications;
using AutoMapper;
using Advertise.Core.Utilities;
using Advertise.Core.Types;

namespace Advertise.Service.Factories.Specifications
{

    public class SpecificationFactory : ISpecificationFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly ISpecificationService _specificationService;
        private readonly ISpecificationOptionService _specificationOptionService;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        /// 
        ///  </summary>
        ///  <param name="listManager"></param>
        ///  <param name="commonService"></param>
        ///  <param name="mapper"></param>
        /// <param name="specificationService"></param>
        public SpecificationFactory(IListManager listManager, ICommonService commonService, IMapper mapper, ISpecificationService specificationService, ISpecificationOptionService specificationOptionService)
        {
            _listManager = listManager;
            _commonService = commonService;
            _mapper = mapper;
            _specificationService = specificationService;
            _specificationOptionService = specificationOptionService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="specificationId"></param>
        /// <returns></returns>
        public async Task<SpecificationDetailViewModel> PrepareDetailViewModelAsync(Guid specificationId)
        {
            var specification = await _specificationService.FindByIdAsync(specificationId);
            var viewmodel = _mapper.Map<SpecificationDetailViewModel>(specification);

            return viewmodel;
        }


        public async Task<SpecificationCreateViewModel> PrepareCreateViewModelAsync(SpecificationCreateViewModel viewModelPrepare = null)
        {
            var viewModel = viewModelPrepare ?? new SpecificationCreateViewModel();
            viewModel.TypeList = EnumHelper.CastToSelectListItems<SpecificationType>(); //await _listManager.GetTypSpecificationeList();

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="specificationId"></param>
        /// <returns></returns>
        public async Task<SpecificationEditViewModel> PrepareEditViewModelAsync(Guid specificationId, SpecificationEditViewModel viewModelPrepare = null)
        {
            var specification = await _specificationService.FindByIdAsync(specificationId);
            var viewModel = viewModelPrepare?? _mapper.Map<SpecificationEditViewModel>(specification);

            var specificationOptions = await _specificationOptionService.GetSpecificationOptionsBySpecificationIdAsync(specificationId);
            if(specificationOptions != null)
                viewModel.Options = _mapper.Map<IList<SpecificationOptionViewModel>>(specificationOptions);

            viewModel.TypeList = EnumHelper.CastToSelectListItems<SpecificationType>();//await _listManager.GetTypSpecificationeList();

            return viewModel;
        }


        public async Task<SpecificationListViewModel> PrepareListViewModelAsync(SpecificationSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _specificationService.CountByRequestAsync(request);
            var specification = await _specificationService.GetByRequestAsync(request);
            var specificationViewModel = _mapper.Map<IList<SpecificationViewModel>>(specification);
            var viewModel = new SpecificationListViewModel
            {
                SearchRequest = request,
                Specifications = specificationViewModel
            };
            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();

            return viewModel;
        }

        #endregion Public Methods
    }
}