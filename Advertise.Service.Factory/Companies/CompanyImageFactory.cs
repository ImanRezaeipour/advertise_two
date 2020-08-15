using Advertise.Core.Models.CompanyImage;
using Advertise.Core.Types;
using Advertise.Core.Utilities;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.List;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Exceptions;
using Advertise.Core.Helpers;

namespace Advertise.Service.Factories.Companies
{

    public class CompanyImageFactory : ICompanyImageFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly ICompanyImageService _companyImageService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="commonService"></param>
        /// <param name="companyImageService"></param>
        /// <param name="listManager"></param>
        /// <param name="mapper"></param>
        public CompanyImageFactory(ICommonService commonService, ICompanyImageService companyImageService, IListManager listManager, IMapper mapper)
        {
            _commonService = commonService;
            _companyImageService = companyImageService;
            _listManager = listManager;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyImageId"></param>
        /// <param name="applyCurrentUser"></param>
        /// <param name="viewModelPrepare"></param>
        /// <returns></returns>
        public async Task<CompanyImageEditViewModel> PrepareEditViewModelAsync(Guid companyImageId, bool applyCurrentUser = false, CompanyImageEditViewModel  viewModelPrepare = null)
        {
            var isMine = await _companyImageService.IsMineAsync(companyImageId);
            if (!isMine)
                throw new FactoryException("عدم دسترسی");

            var companyImage = await _companyImageService.FindByIdAsync(companyImageId);
            var viewModel = viewModelPrepare ?? _mapper.Map<CompanyImageEditViewModel>(companyImage);

            if (applyCurrentUser)
                viewModel.IsMine = true;

            return viewModel;
        }


        public async Task<CompanyImageListViewModel> PrepareListViewModelAsync(CompanyImageSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _companyImageService.CountByRequestAsync(request);
            var companyImages = await _companyImageService.GetByRequestAsync(request);
            var companyImageViewModel = _mapper.Map<IList<CompanyImageViewModel>>(companyImages);
            var companyImageList = new CompanyImageListViewModel
            {
                SearchRequest = request,
                CompanyImages = companyImageViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                StateList = EnumHelper.CastToSelectListItems<StateType>()
            };

            if (isCurrentUser)
            {
                companyImageList.IsMine = true;
                companyImageList.CompanyImages.ForEach(p => p.IsMine = true);
            }

            return companyImageList;
        }

        #endregion Public Methods
    }
}