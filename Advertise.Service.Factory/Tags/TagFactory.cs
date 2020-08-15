using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Helpers;
using Advertise.Core.Models.Tag;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Tags;
using AutoMapper;
using Advertise.Core.Utilities;
using Advertise.Core.Types;

namespace Advertise.Service.Factories.Tags
{
    public class TagFactory : ITagFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly ITagService _tagService;

        #endregion Private Fields

        #region Public Constructors

        public TagFactory(IListManager listManager, ICommonService commonService, IMapper mapper, ITagService tagService)
        {
            _listManager = listManager;
            _commonService = commonService;
            _mapper = mapper;
            _tagService = tagService;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<TagCreateViewModel> PrepareCreateViewModelAsync(TagCreateViewModel viewModelPrepare= null)
        {
            var viewModel = viewModelPrepare?? new TagCreateViewModel();
            viewModel.ColorTypeList = EnumHelper.CastToSelectListItems<ColorType>();

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public async Task<TagEditViewModel> PrepareEditViewModelAsync(Guid tagId, TagEditViewModel viewModelPrepare = null)
        {
            if (tagId == null)
                throw new ArgumentNullException(nameof(tagId));

            var tag = await _tagService.FindByIdAsync(tagId);
            var viewModel = viewModelPrepare ?? _mapper.Map<TagEditViewModel>(tag);
            viewModel.ColorTypeList = EnumHelper.CastToSelectListItems<ColorType>();

            return viewModel;
        }


        public async Task<TagListViewModel> PrepareListViewModelAsync(TagSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _tagService.CountByRequestAsync(request);
            var tag = await _tagService.GetByRequestAsync(request);
            var tagViewModel = _mapper.Map<IList<TagViewModel>>(tag);
            var viewModel = new TagListViewModel
            {
                SearchRequest = request,
                Tags = tagViewModel
            };
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();
            viewModel.ActiveList = EnumHelper.CastToSelectListItems<ActiveType>(); //await _listManager.GetActiveListAsync();
            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();

            return viewModel;
        }

        #endregion Public Methods
    }
}