using Advertise.Core.Exceptions;
using Advertise.Core.Models.Address;
using Advertise.Core.Models.CategoryOption;
using Advertise.Core.Models.City;
using Advertise.Core.Models.Company;
using Advertise.Core.Models.CompanyAttachment;
using Advertise.Core.Models.CompanyConversation;
using Advertise.Core.Models.CompanyImage;
using Advertise.Core.Models.CompanyQuestion;
using Advertise.Core.Models.CompanyReview;
using Advertise.Core.Models.CompanyVideo;
using Advertise.Core.Models.Home;
using Advertise.Core.Models.Product;
using Advertise.Core.Types;
using Advertise.Service.Services.Categories;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Locations;
using Advertise.Service.Services.Products;
using Advertise.Service.Services.Users;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Helpers;
using Advertise.Core.Utilities;

namespace Advertise.Service.Factories.Companies
{

    public class CompanyFactory : ICompanyFactory
    {

        #region Private Fields

        private readonly IAddressService _addressService;
        private readonly ICategoryService _categoryService;
        private readonly ICommonService _commonService;
        private readonly ICompanyAttachmentService _companyAttachmentService;
        private readonly ICompanyConversationService _companyConversationService;
        private readonly ICompanyFollowService _companyFollowService;
        private readonly ICompanyImageService _companyImageService;
        private readonly ICompanyQuestionService _companyQuestionService;
        private readonly ICompanyReviewService _companyReviewService;
        private readonly ICompanyService _companyService;
        private readonly ICompanySocialService _companySocialService;
        private readonly ICompanyTagService _companyTagService;
        private readonly ICompanyVideoService _companyVideoService;
        private readonly ICompanyVisitService _companyVisitService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyService"></param>
        /// <param name="mapper"></param>
        /// <param name="webContextManager"></param>
        /// <param name="companyVisitService"></param>
        /// <param name="commonService"></param>
        /// <param name="companyFollowService"></param>
        /// <param name="companyImageService"></param>
        /// <param name="companyTagService"></param>
        /// <param name="categoryService"></param>
        /// <param name="productService"></param>
        /// <param name="userService"></param>
        /// <param name="companySocialService"></param>
        /// <param name="companyConversationService"></param>
        /// <param name="addressService"></param>
        /// <param name="companyReviewService"></param>
        /// <param name="listManager"></param>
        public CompanyFactory(ICompanyService companyService, IMapper mapper, IWebContextManager webContextManager, ICompanyVisitService companyVisitService, ICommonService commonService, ICompanyFollowService companyFollowService, ICompanyImageService companyImageService, ICompanyTagService companyTagService, ICategoryService categoryService, IProductService productService, IUserService userService, ICompanySocialService companySocialService, ICompanyConversationService companyConversationService, IAddressService addressService, ICompanyReviewService companyReviewService, IListManager listManager, ICompanyAttachmentService companyAttachmentService, ICompanyVideoService companyVideoService, ICompanyQuestionService companyQuestionService)
        {
            _companyService = companyService;
            _mapper = mapper;
            _webContextManager = webContextManager;
            _companyVisitService = companyVisitService;
            _commonService = commonService;
            _companyFollowService = companyFollowService;
            _companyImageService = companyImageService;
            _companyTagService = companyTagService;
            _categoryService = categoryService;
            _productService = productService;
            _userService = userService;
            _companySocialService = companySocialService;
            _companyConversationService = companyConversationService;
            _addressService = addressService;
            _companyReviewService = companyReviewService;
            _listManager = listManager;
            _companyAttachmentService = companyAttachmentService;
            _companyVideoService = companyVideoService;
            _companyQuestionService = companyQuestionService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="companyAlias"></param>
        /// <returns></returns>
        public async Task<CompanyDetailInfoViewModel> PrepareDetailInfoViewModelAsync(string companyAlias)
        {
            var company = await _companyService.FindByAliasAsync(companyAlias);
            if (company == null)
                throw new FactoryException();
            var viewModel = _mapper.Map<CompanyDetailInfoViewModel>(company);

            //viewModel.Address = company.Address?.Extra;

            if (company.CreatedById != null)
            {
                var social = await _companySocialService.FindByUserIdAsync(company.CreatedById.Value);
                if (social != null)
                {
                    viewModel.FacebookLink = social.FacebookLink;
                    viewModel.GooglePlusLink = social.GooglePlusLink;
                    viewModel.TwitterLink = social.TwitterLink;
                    viewModel.YoutubeLink = social.YoutubeLink;
                    viewModel.TelegramLink = social.TelegramLink;
                    viewModel.InstagramLink = social.InstagramLink;
                }
            }

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="companyAlias"></param>
        /// <returns></returns>
        public async Task<CompanyDetailViewModel> PrepareDetailViewModelAsync(string companyAlias, string slug)
        {
            var isExist = await _companyService.IsExistByAliasAsync(companyAlias);
            if (!isExist)
                throw new FactoryException("کمپانی وجود ندارد");

            var result = await _companyService.IsApprovedByAliasAsync(companyAlias);
            if (!result)
                throw new FactoryException("کمپانی تایید نشده است");

            var slugResult = await _companyService.CompareNameAndSlugAsync(companyAlias, slug);
            if (!slugResult)
                throw new FactoryException("عدم تطابق اسلاگ");


            var company = await _companyService.FindByAliasAsync(companyAlias);
            if (company == null)
                throw new FactoryException();
            var viewModel = _mapper.Map<CompanyDetailViewModel>(company);

            await _companyVisitService.CreateByCompanyIdAsync(company.Id);

            //  COMPANY COUNTS
            viewModel.ImageCount = await _companyImageService.CountAllByCompanyIdAsync(viewModel.Id);
            viewModel.FollowerCount = await _companyFollowService.CountAllFollowByCompanyIdAsync(viewModel.Id);
            viewModel.ProductCount = await _productService.CountByCompanyIdAsync(viewModel.Id);
            viewModel.TagCount = await _companyTagService.CountAllTagByCompanyIdAsync(viewModel.Id);
            viewModel.VisitCount = await _companyVisitService.CountByCompanyIdAsync(viewModel.Id);

            //  USER DETAILS
            var user = await _userService.FindByUserIdAsync(viewModel.CreatedById);
            viewModel.FullName = user.Meta.FullName ?? "";
            viewModel.UserEmail = user.Email;
            viewModel.UserUserName = user.UserName;

            //  OTHER
            viewModel.CategoryTitle = (await _categoryService.FindByIdAsync(viewModel.CategoryId)).Title;
            viewModel.InitFollow = await _companyFollowService.IsFollowByCurrentUserAsync(viewModel.Id);

            //  CATEGORY OPTION
            if (company.CategoryId != null)
            {
                var categoryOption = await _categoryService.GetCategoryOptionByIdAsync(company.CategoryId.Value);
                viewModel.CategoryOption = _mapper.Map<CategoryOptionViewModel>(categoryOption);
            }

            //  COMPANY CONVERSATIONS
            viewModel.ConversationList = await _companyConversationService.GetListByUserIdAsync(viewModel.CreatedById);
            
            //  COMPANY IMAGES
            var images = await _companyImageService.GetApprovedsByCompanyIdAsync(viewModel.Id);
            viewModel.ImageList = _mapper.Map<IList<CompanyImageViewModel>>(images);
           
            //  COMPANY PRODUCTS
            var products = await _productService.GetApprovedByCompanyIdAsync(viewModel.Id);
            viewModel.ProductList = new ProductListViewModel
            {
                Products = _mapper.Map<List<ProductViewModel>>(products)
            };
            viewModel.ProductList.Products = viewModel.ProductList.Products.GroupBy(model => model.Code).Select(model => model.First()).ToList();
            foreach (var productViewModel in viewModel.ProductList.Products)
            {
                if (productViewModel.IsCatalog == true)
                {
                    productViewModel.HighestPrice = await _productService.MaxByRequestAsync(new ProductSearchRequest { CatalogId = productViewModel.CatalogId, Sell = SellType.Available, AvailableCountGreater = 0 }, product => product.Price);
                    productViewModel.LowestPrice = await _productService.MinByRequestAsync(new ProductSearchRequest { CatalogId = productViewModel.CatalogId, Sell = SellType.Available, AvailableCountGreater = 0 }, product => product.Price);
                    productViewModel.CatalogCompanyCount = await _productService.CountByRequestAsync(new ProductSearchRequest {DistinctByCompanyId = true,CatalogId = productViewModel.CatalogId, Sell = SellType.Available, AvailableCountGreater = 0 });
                }
            }

            //  COMPANY ATTACHMENTS
            var companyAttachments = await _companyAttachmentService.GetApprovedByCompanyIdAsync(viewModel.Id);
            viewModel.AttachmentList = new CompanyAttachmentListViewModel
            {
                CompanyAttachments = _mapper.Map<IList<CompanyAttachmentViewModel>>(companyAttachments)
            };

            //  COMPANY REVIEWS
            var companyReview = await _companyReviewService.GetByCompanyIdAsync(viewModel.Id);
            viewModel.ReviewList = new CompanyReviewListViewModel
            {
                CompanyReviews = _mapper.Map<IList<CompanyReviewViewModel>>(companyReview)
            };

            //  COMPANY VIDEOS
            var companyVideo = await _companyVideoService.GetApprovedByCompanyIdAsync(viewModel.Id);
            viewModel.VideoList = _mapper.Map<IList<CompanyVideoViewModel>>(companyVideo);
           
            //  COMPANY QUESTIONS
            var companyQuestions = await _companyQuestionService.GetAllByCompanyIdAsync(viewModel.Id);
            var viewModelQuestion = _mapper.Map<IList<CompanyQuestionViewModel>>(companyQuestions);
            viewModel.QuestionList = new CompanyQuestionListViewModel
            {
                CompanyQuestions = viewModelQuestion
            };

            //  IS MY SELF
            viewModel.IsMyself = await _companyService.IsMySelfAsync(viewModel.Id);
            viewModelQuestion.ForEach(p => p.IsMyself = viewModel.IsMyself);

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyAlias"></param>
        /// <returns></returns>
        public async Task<CompanyEditViewModel> PrepareEditViewModelAsync(string companyAlias = null, bool applyCurrentUser = false, CompanyEditViewModel viewModelApply = null)
        {
            var company = await _companyService.FindByAliasAsync(companyAlias);
            if (companyAlias == null)
                company = await _companyService.FindByUserIdAsync(_webContextManager.CurrentUserId);

            var viewModel = viewModelApply ?? _mapper.Map<CompanyEditViewModel>(company);

            var address = await _companyService.GetAddressViewModelByIdAsync(viewModel.Id);
            if (address != null)
            {
                viewModel.Address = _mapper.Map<AddressViewModel>(address);
                if (viewModel.Address.City == null)
                    viewModel.Address.City = new CityViewModel();
            }
            else
            {
                viewModel.Address = new AddressViewModel
                {
                    City = new CityViewModel()
                };
            }
            viewModel.CategoryRoot = await _categoryService.IsRootAsync(viewModel.CategoryId);
            viewModel.IsSetAlias = await _companyService.IsExistAliasByIdAsync(viewModel.Id);
            viewModel.AddressProvince = await _addressService.GetProvinceAsSelectListItemAsync();
            viewModel.ClearingList = EnumHelper.CastToSelectListItems<ClearingType>();// _listManager.GetClearingTypeList();
            viewModel.EmployeeRangeList = EnumHelper.CastToSelectListItems<EmployeeRangeType>();

            if (applyCurrentUser)
                viewModel.IsMine = true;

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<CompanyImageListViewModel> PrepareImageListViewModelAsync(Guid companyId)
        {
            var companyImages = await _companyImageService.GetApprovedsByCompanyIdAsync(companyId);
            var companyImagesViewModel = _mapper.Map<IList<CompanyImageViewModel>>(companyImages);
            var listViewModel = new CompanyImageListViewModel
            {
                CompanyImages = companyImagesViewModel
            };

            return listViewModel;
        }


        public async Task<CompanyListViewModel> PrepareListViewModelAsync(CompanySearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _companyService.CountByRequestAsync(request);
            var companies = await _companyService.GetByRequestAsync(request);
            var companyViewModel = _mapper.Map<IList<CompanyViewModel>>(companies);

            foreach (var viewModel in companyViewModel)
            {
                viewModel.ProductCount = await _productService.CountByCompanyIdAsync(viewModel.Id, StateType.Approved);
                viewModel.InitFollow = await _companyFollowService.IsFollowByCurrentUserAsync(viewModel.Id);
            }

            var companyList = new CompanyListViewModel
            {
                SearchRequest = request,
                Companies = companyViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                SortMemberList = await _listManager.GetSortMemberListByTitleAsync(),
                StateList = EnumHelper.CastToSelectListItems<StateType>()
            };

            if (isCurrentUser)
                companyList.Companies.ForEach(p => p.IsMine = true);

            return companyList;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<ProductListViewModel> PrepareProductListViewModelAsync(Guid companyId)
        {
            var request = new ProductSearchRequest
            {
                CompanyId = companyId,
                State = StateType.Approved
            };
            var companyProducts = await _productService.GetByRequestAsync(request);
            var companyProductViewModel = _mapper.Map<IList<ProductViewModel>>(companyProducts);
            var listViewModel = new ProductListViewModel
            {
                Products = companyProductViewModel,
                SearchRequest = request
            };

            return listViewModel;
        }


        public async Task<ProfileMenuViewModel> PrepareProfileMenuViewModelAsync()
        {
            var company = await _companyService.FindByUserIdAsync(_webContextManager.CurrentUserId);
            var viewModel = _mapper.Map<ProfileMenuViewModel>(company);

            if (company.CategoryId != null)
            {
                var categoryOption = await _categoryService.GetCategoryOptionByIdAsync(company.CategoryId.Value);
                viewModel.CategoryOption = _mapper.Map<CategoryOptionViewModel>(categoryOption);
            }

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<CompanyReviewListViewModel> PrepareReviewListViewModelAsync(Guid companyId)
        {
            var companyReviews = await _companyReviewService.GetByCompanyIdAsync(companyId);
            var companyReviewViewModel = _mapper.Map<IList<CompanyReviewViewModel>>(companyReviews);
            var listViewModel = new CompanyReviewListViewModel
            {
                CompanyReviews = companyReviewViewModel
            };

            return listViewModel;
        }

        #endregion Public Methods

    }
}