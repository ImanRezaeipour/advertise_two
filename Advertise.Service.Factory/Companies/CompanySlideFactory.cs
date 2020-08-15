using Advertise.Core.Models.CompanySlide;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Products;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Service.Services.WebContext;

namespace Advertise.Service.Factories.Companies
{
    public class CompanySlideFactory : ICompanySlideFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly ICompanySlideService _companySlideService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        public CompanySlideFactory(ICompanySlideService companySlideService, IMapper mapper, IProductService productService, ICommonService commonService, IListManager listManager, IWebContextManager webContextManager)
        {
            _companySlideService = companySlideService;
            _mapper = mapper;
            _productService = productService;
            _commonService = commonService;
            _listManager = listManager;
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<CompanySlideCreateViewModel> PrepareCreateViewModelAsync()
        {
            var viewModel = new CompanySlideCreateViewModel
            {
                EntityList = await _productService.GetAllCurrentUserAsSelectListItem()
            };

            return viewModel;
        }

        public async Task<CompanySlideEditViewModel> PrepareEditViewModelAsync(Guid companySlideId)
        {
            var companySlide = await _companySlideService.FindByIdAsync(companySlideId);
            var companySlideViewModel = _mapper.Map<CompanySlideEditViewModel>(companySlide);
            companySlideViewModel.EntityList = await _productService.GetAllCurrentUserAsSelectListItem();

            return companySlideViewModel;
        }

        public async Task<CompanySlideBulkEditViewModel> PrepareBulkEditViewModelAsync()
        {
            var request = new CompanySlideSearchRequest
            {
                CompanyId = _webContextManager.CurrentCompanyId
            };
            var companySlides = await _companySlideService.GetByRequestAsync(request);
            var companySlideViewModel = _mapper.Map<IList<CompanySlideViewModel>>(companySlides);
            var viewModel = new CompanySlideBulkEditViewModel
            {
                ProductList = await _productService.GetAllCurrentUserAsSelectListItem(),
                SlideList = companySlideViewModel
            };

            return viewModel;
        }

        public async Task<CompanySlideListViewModel> PrepareListViewModelAsync(CompanySlideSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CompanyId = _webContextManager.CurrentCompanyId;
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _companySlideService.CountByRequestAsync(request);
            var companySlides = await _companySlideService.GetByRequestAsync(request);
            var companySlideViewModel = _mapper.Map<IList<CompanySlideViewModel>>(companySlides);
            var companySlideList = new CompanySlideListViewModel
            {
                SearchRequest = request,
                CompanySlides = companySlideViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                SortMemberList = await _listManager.GetSortMemberListByTitleAsync()
            };

            if (isCurrentUser)
            {
                companySlideList.IsMine = true;
                companySlideList.CompanySlides.ForEach(p => p.IsMine = true);
            }
               

            return companySlideList;
        }

        #endregion Public Methods
    }
}