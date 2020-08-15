using System;
using System.Collections.Generic;
using Advertise.Core.Models.Ads;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Products;
using Advertise.Service.Services.WebContext;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Exceptions;
using Advertise.Core.Helpers;
using Advertise.Core.Models.AdsOption;
using Advertise.Service.Services.Ads;
using AutoMapper;
using Advertise.Core.Utilities;
using Advertise.Core.Types;
using Advertise.Service.Services.Categories;
using Newtonsoft.Json;

namespace Advertise.Service.Factories.Adses
{
    public class AdsFactory : IAdsFactory
    {
        #region Private Fields

        private readonly ICompanyService _companyService;
        private readonly IListManager _listManager;
        private readonly IProductService _productService;
        private readonly IWebContextManager _webContextManager;
        private readonly IAdsService _adsService;
        private readonly IMapper _mapper;
        private readonly IAdsOptionService _adsOptionService;
        private readonly ICategoryService _categoryService;

        #endregion Private Fields

        #region Public Constructors

        public AdsFactory(IProductService productService, IListManager listManager, ICompanyService companyService, IWebContextManager webContextManager, IAdsService adsService, IMapper mapper, IAdsOptionService adsOptionService, ICategoryService categoryService)
        {
            _productService = productService;
            _listManager = listManager;
            _companyService = companyService;
            _webContextManager = webContextManager;
            _adsService = adsService;
            _mapper = mapper;
            _adsOptionService = adsOptionService;
            _categoryService = categoryService;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<AdsCreateViewModel> PrepareCreateViewModel(AdsCreateViewModel viewModelPrepare = null)
        {
            var viewModel = viewModelPrepare ?? new AdsCreateViewModel();
            viewModel.EntityList = await _productService.GetAllCurrentUserAsSelectListItem();
            viewModel.DurationList = EnumHelper.CastToSelectListItems<DurationType>();
            viewModel.AdsOptionTypeList = EnumHelper.CastToSelectListItems<AdsType>();
            viewModel.AdsOptionPositionList = EnumHelper.CastToSelectListItems<AdsPositionType>();
            viewModel.CategeoryListJson = JsonConvert.SerializeObject(await _categoryService.GetAllowedAsSelect2ObjectAsync());

            var adsOptions = await _adsOptionService.GetByRequestAsync(new AdsOptionSearchRequest());
            viewModel.AdsOptions = _mapper.Map<IList<AdsOptionViewModel>>(adsOptions);

            var company = await _companyService.FindByUserIdAsync(_webContextManager.CurrentUserId);
            if (company != null)
                viewModel.CategoryId = company.CategoryId.GetValueOrDefault();

            return viewModel;
        }

        public async Task<AdsEditViewModel> PrepareEditViewModelAsync(Guid id)
        {
            var ads = await _adsService.FindByIdAsync(id);
            if (ads == null)
                throw new FactoryException();

           return _mapper.Map<AdsEditViewModel>(ads);
        }

        #endregion Public Methods
    }
}