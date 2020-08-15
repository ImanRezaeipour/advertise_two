using Advertise.Core.Models.CompanyQuestion;
using Advertise.Core.Types;
using Advertise.Core.Utilities;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.List;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Helpers;

namespace Advertise.Service.Factories.Companies
{

    public class CompanyQuestionFactory : ICompanyQuestionFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly ICompanyQuestionService _companyQuestionService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="companyQuestionService"></param>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        public CompanyQuestionFactory(IMapper mapper, ICompanyQuestionService companyQuestionService, IListManager listManager, ICommonService commonService)
        {
            _mapper = mapper;
            _companyQuestionService = companyQuestionService;
            _listManager = listManager;
            _commonService = commonService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyQuestionId"></param>
        /// <returns></returns>
        public async Task<CompanyQuestionDetailViewModel> PrepareDetailViewModelAsync(Guid companyQuestionId)
        {
            var companyQuestion = await _companyQuestionService.FindByIdAsync(companyQuestionId);
            var viewModel = _mapper.Map<CompanyQuestionDetailViewModel>(companyQuestion);

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="companyQuestionId"></param>
        /// <returns></returns>
        public async Task<CompanyQuestionEditViewModel> PrepareEditViewModelAsync(Guid companyQuestionId)
        {
            var companyQuestion = await _companyQuestionService.FindByIdAsync(companyQuestionId);
            var viewModel = _mapper.Map<CompanyQuestionEditViewModel>(companyQuestion);

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<CompanyQuestionListViewModel> PrepareListViewModelAsync(CompanyQuestionSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _companyQuestionService.CountByRequestAsync(request);
            var companyQuestions = await _companyQuestionService.GetByRequestAsync(request);
            var companyQuestionViewModel = _mapper.Map<IList<CompanyQuestionViewModel>>(companyQuestions);
            var companyQuestionList = new CompanyQuestionListViewModel
            {
                SearchRequest = request,
                CompanyQuestions = companyQuestionViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                StateTypeList = EnumHelper.CastToSelectListItems<StateType>()//await _listManager.GetStateTypeListAsync()
            };

            if (isCurrentUser)
                companyQuestionList.IsMine = true;

            return companyQuestionList;
        }

        #endregion Public Methods
    }
}