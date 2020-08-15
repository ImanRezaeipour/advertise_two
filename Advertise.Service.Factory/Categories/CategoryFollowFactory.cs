using Advertise.Core.Models.CategoryFollow;
using Advertise.Service.Services.Categories;
using Advertise.Service.Services.List;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Service.Services.WebContext;
using AutoMapper;

namespace Advertise.Service.Factories.Categories
{

    public class CategoryFollowFactory : ICategoryFollowFactory
    {
        #region Private Fields

        private readonly ICategoryFollowService _categoryFollowService;
        private readonly IListManager _listManager;
        private readonly IWebContextManager _webContextManager;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryFollowService"></param>
        /// <param name="listManager"></param>
        public CategoryFollowFactory(ICategoryFollowService categoryFollowService, IListManager listManager, IWebContextManager webContextManager, IMapper mapper)
        {
            _categoryFollowService = categoryFollowService;
            _listManager = listManager;
            _webContextManager = webContextManager;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<CategoryFollowListViewModel> PrepareListViewModelAsync(bool isCurrentUser = false, Guid? userId = null)
        {
            var request = new CategoryFollowSearchRequest
            {
                IsFollow = true
            };
            if (isCurrentUser)
                request.FollowedById = _webContextManager.CurrentUserId;
            else if (userId != null)
                request.FollowedById = userId;
            else
                request.FollowedById = null;
            var categoryFollows = await _categoryFollowService.GetByRequestAsync(request);
            request.TotalCount = categoryFollows.Count;
            var categoryFollowsViewModel = _mapper.Map<IList<CategoryFollowViewModel>>(categoryFollows);
            var listVieModel = new CategoryFollowListViewModel
            {
                SearchRequest = request,
                CategoryFollows = categoryFollowsViewModel
            };

            listVieModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            listVieModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();

            return listVieModel;
        }

        

        #endregion Public Methods
    }
}