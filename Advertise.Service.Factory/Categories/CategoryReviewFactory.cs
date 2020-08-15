using Advertise.Core.Models.CategoryReview;
using Advertise.Core.Types;
using Advertise.Core.Utilities;
using Advertise.Service.Services.Categories;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Helpers;

namespace Advertise.Service.Factories.Categories
{

    public class CategoryReviewFactory : ICategoryReviewFactory
    {
        #region Private Fields

        private readonly ICategoryReviewService _categoryReviewService;
        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryReviewService"></param>
        /// <param name="listManager"></param>
        /// <param name="mapper"></param>
        /// <param name="commonService"></param>
        public CategoryReviewFactory(ICategoryReviewService categoryReviewService, IListManager listManager, IMapper mapper, ICommonService commonService)
        {
            _categoryReviewService = categoryReviewService;
            _listManager = listManager;
            _mapper = mapper;
            _commonService = commonService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryReviewId"></param>
        /// <returns></returns>
        public async Task<CategoryReviewDetailViewModel> PrepareDetailViewModelAsync(Guid categoryReviewId)
        {
            var catgoryReview = await _categoryReviewService.FindByIdAsync(categoryReviewId);
            var viewModel = _mapper.Map<CategoryReviewDetailViewModel>(catgoryReview);

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryReviewId"></param>
        /// <returns></returns>
        public async Task<CategoryReviewEditViewModel> PrepareEditViewModelAsync(Guid categoryReviewId)
        {
            var categoryReview = await _categoryReviewService.FindByIdAsync(categoryReviewId);
            var viewModel = _mapper.Map<CategoryReviewEditViewModel>(categoryReview);

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<CategoryReviewListViewModel> PrepareListViewModelAsync(CategoryReviewSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _categoryReviewService.CountByRequestAsync(request);
            var categryReviews = await _categoryReviewService.GetByRequestAsync(request);
            var categoryReviewViewModel = _mapper.Map<IList<CategoryReviewViewModel>>(categryReviews);
            var categoryReviewList = new CategoryReviewListViewModel
            {
                SearchRequest = request,
                CategoryReviews = categoryReviewViewModel,
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                ActiveList = EnumHelper.CastToSelectListItems<ActiveType>()
            };
            //await _listManager.GetActiveListAsync();

            return categoryReviewList;
        }

        #endregion Public Methods
    }
}