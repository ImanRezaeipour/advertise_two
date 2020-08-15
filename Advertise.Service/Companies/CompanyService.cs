using Advertise.Core.Domains.Categories;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Domains.Locations;
using Advertise.Core.Domains.Users;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Address;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Company;
using Advertise.Core.Types;
using Advertise.Data.DbContexts;
using Advertise.Service.Managers.Events;
using Advertise.Service.Managers.File;
using Advertise.Service.Managers.Html;
using Advertise.Service.Services.Locations;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Validators.Companies;
using Microsoft.AspNet.Identity;
using FineUploaderObject = Advertise.Core.Objects.FineUploaderObject;

namespace Advertise.Service.Services.Companies
{
    public class CompanyService : ICompanyService
    {
        #region Private Fields

        private readonly IAddressService _addressService;
        private readonly ICityService _cityService;
        private readonly IDbSet<Category> _categoryRepository;
        private readonly ICompanyAttachmentService _companyAttachmentService;
        private readonly IDbSet<CompanyFollow> _companyFollowRepository;
        private readonly ICompanyFollowService _companyFollowService;
        private readonly ICompanyImageService _companyImageService;
        private readonly ICompanyQuestionService _companyQuestionService;
        private readonly IDbSet<Company> _companyRepository;
        private readonly ICompanyReviewService _companyReviewService;
        private readonly ICompanySocialService _companySocialService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<User> _userRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        public CompanyService(IMapper mapper, ICompanyReviewService companyReviewService,
            ICompanyFollowService companyFollowService, ICompanyImageService companyImageService,
            ICompanyAttachmentService companyAttachmentService, ICompanyQuestionService companyQuestionService,
            ICompanySocialService companySocialService, IUnitOfWork unitOfWork,
            IWebContextManager webContextManager, IAddressService addressService, IEventPublisher eventPublisher, ICityService cityService)
        {
            _mapper = mapper;
            _companyReviewService = companyReviewService;
            _companyFollowService = companyFollowService;
            _companyImageService = companyImageService;
            _companyAttachmentService = companyAttachmentService;
            _companyQuestionService = companyQuestionService;
            _companySocialService = companySocialService;
            _companyRepository = unitOfWork.Set<Company>();
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _addressService = addressService;
            _eventPublisher = eventPublisher;
            _cityService = cityService;
            _categoryRepository = unitOfWork.Set<Category>();
            _companyFollowRepository = unitOfWork.Set<CompanyFollow>();
            _userRepository = unitOfWork.Set<User>();
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<int> CountAllAsync()
        {
            var request = new CompanySearchRequest
            {
                PageSize = PageSize.All
            };
            return await CountByRequestAsync(request);
        }

        public async Task<bool> HasAliasAsync(Guid input, CancellationToken cancellationToken)
        {
            return await HasAliasByCurrentUserAsync();
        }

        public async Task<int> CountByRequestAsync(CompanySearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        public async Task<int> CountByStateAsync(StateType companyState)
        {
            var request = new CompanySearchRequest
            {
                State = companyState
            };
            return await CountByRequestAsync(request);
        }

        public async Task<int> CountByCategoryIdAsync(Guid categoryId)
        {
            var request = new CompanySearchRequest
            {
                CategoryId = categoryId
            };
            return await CountByRequestAsync(request);
        }

        public async Task CreateByUserIdAsync(Guid userId)
        {
            var defaultLocation = await _addressService.GetDefaultLocationAsync();

            var company = new Company
            {
                CreatedById = userId,
                State = StateType.Approved,
                CategoryId = (await _categoryRepository.FirstOrDefaultAsync(model => model.ParentId == null)).Id,
                CreatedOn = DateTime.Now
            };
            company.Address = new Address
            {
                Latitude = defaultLocation.Item1,
                Longitude = defaultLocation.Item2,
                CityId = await _cityService.GetIdByNameAsync(defaultLocation.Item3),
                CreatedById = _webContextManager.CurrentUserId
            };
            _companyRepository.Add(company);

            await _unitOfWork.SaveAllChangesAsync(auditUserId: userId);

            _eventPublisher.EntityInserted(company);
        }

        [Validation(typeof(CompanyCreateValidator),"Create")]
        public async Task CreateEasyByViewModelAsync(CompanyCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var company = _mapper.Map<Company>(viewModel);
            company.State = StateType.Pending;
            company.CreatedOn = DateTime.Now;

            var defaultLocation = await _addressService.GetDefaultLocationAsync();
            company.Address = new Address
            {
                Latitude = defaultLocation.Item1,
                Longitude = defaultLocation.Item2,
                CityId = await _cityService.GetIdByNameAsync(defaultLocation.Item3),
                CreatedById = _webContextManager.CurrentUserId
            };

            _companyRepository.Add(company);

            await _unitOfWork.SaveAllChangesAsync(auditUserId: viewModel.CreatedById);

            _eventPublisher.EntityInserted(company);
        }

        public async Task DeleteByAliasAsync(string companyAlias, bool isCurrentUser = false)
        {
            var company = await FindByAliasAsync(companyAlias);
            if(isCurrentUser && company.CreatedById != _webContextManager.CurrentUserId)
                return;

            await _companyAttachmentService.RemoveRangeAsync(company.Attachments.ToList());
            await _companyFollowService.RemoveRangeAsync(company.Follows.ToList());
            await _companyImageService.RemoveRangeAsync(company.Images.ToList());
            await _companyReviewService.RemoveRangeAsync(company.Reviews.ToList());
            await _companySocialService.RemoveRangeAsync(company.Socials.ToList());
            await _companyQuestionService.RemoveRangeByCompanyId(company.Id);
            _companyRepository.Attach(company);
            _companyRepository.Remove(company);
            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(company);
        }

        public async Task DeleteByUserIdAsync(Guid userId)
        {
            var company = await GetByUserIdAsync(userId);
            await DeleteByAliasAsync(company.Alias);
        }

        [Validation(typeof(CompanyEditValidator),"Edit")]
        public async Task EditApproveByViewModelAsync(CompanyEditViewModel viewModel)
        {
            var orginalCompany = await _companyRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            await EditByViewModelAsync(viewModel);
            orginalCompany.Alias = orginalCompany.Alias;
            orginalCompany.State = StateType.Approved;
            orginalCompany.Description = viewModel.Description.ToSafeHtml();

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityUpdated(orginalCompany);
        }


        [Validation(typeof(CompanyEditValidator), "Edit")]
        public async Task EditByViewModelAsync(CompanyEditViewModel viewModel, bool isCurrentUser = false)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var addressOriginal = await _addressService.FindByIdAsync(viewModel.AddressId);
            if(isCurrentUser && addressOriginal.CreatedById != _webContextManager.CurrentUserId)
                return;

            addressOriginal.CityId = viewModel.Address.City.Id;
            addressOriginal.Latitude = viewModel.Address.Latitude;
            addressOriginal.Longitude = viewModel.Address.Longitude;
            addressOriginal.Extra = viewModel.Address.Extra;
            addressOriginal.PostalCode = viewModel.Address.PostalCode;
            addressOriginal.Street = viewModel.Address.Street;

            var originalCompany = await FindByIdAsync(viewModel.Id);
            if (originalCompany.Alias != null)
                viewModel.Alias = originalCompany.Alias;

            _mapper.Map(viewModel, originalCompany);
            originalCompany.Description = viewModel.Description.ToSafeHtml();

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(originalCompany);
        }


        public async Task<bool> IsExistAliasCancellationTokenAsync(string alias,HttpContext http, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(http.User.Identity.GetUserId());
            var originUser = await _companyRepository.AsNoTracking().SingleOrDefaultAsync(company => company.CreatedById == userId, cancellationToken);
            if (originUser != null && alias == originUser.Alias || http.User.IsInRole("CanCompanyEdit") )
                return false;

            return await _companyRepository.AsNoTracking().AnyAsync(company => company.Alias == alias, cancellationToken);
        }

        [Validation(typeof(CompanyEditValidator), "Edit")]
        public async Task EditRejectByViewModelAsync(CompanyEditViewModel viewModel)
        {
            var orginalCompany = await _companyRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            await EditByViewModelAsync(viewModel);
            orginalCompany.State = StateType.Rejected;
            orginalCompany.Alias = orginalCompany.Alias;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(orginalCompany);
        }

        public async Task<Company> FindByIdAsync(Guid companyId)
        {
            return await _companyRepository
                .FirstOrDefaultAsync(model => model.Id == companyId);
        }

        public async Task<Company> FindByAliasAsync(string companyAlias)
        {
            return await _companyRepository.AsNoTracking()
                .Include(model => model.Address)
                .FirstOrDefaultAsync(model => model.Alias == companyAlias);
        }

        public async Task<Company> FindByUserIdAsync(Guid userId)
        {
            var company = await _companyRepository
                .FirstOrDefaultAsync(model => model.CreatedById == userId);
            return company;
        }

        public async Task<Address> GetAddressByIdAsync(Guid companyId)
        {
            var company = await FindByIdAsync(companyId);
            return company.Address;
        }

        public async Task<AddressViewModel> GetAddressViewModelByIdAsync(Guid companyId)
        {
            var company = await FindByIdAsync(companyId);

            var address = await _addressService.FindByIdAsync(company.AddressId.GetValueOrDefault()) ?? new Address();
            return _mapper.Map<AddressViewModel>(address);
        }

        public async Task<object> GetAllNearAsync()
        {
            var request = new CompanySearchRequest
            {
                PageSize = PageSize.All,
                State = StateType.Approved
            };
            var companies = await GetByRequestAsync(request);
            var viewModel = _mapper.Map<List<CompanyViewModel>>(companies);
            return viewModel.Select(model => new
            {
                model.CategoryAlias,
                model.Title,
                model.Id,
                model.CategoryCode,
                model.Alias,
                model.Address.Latitude,
                model.Address.Longitude,
                model.CategoryMetaTitle,
                model.CategoryTitle
            });
        }

        public async Task<IList<SelectListItem>> GetAllAsSelectListItemAsync()
        {
            var request = new CompanySearchRequest
            {
                PageSize = PageSize.All
            };
            return await QueryByRequest(request).ProjectTo<SelectListItem>().ToListAsync();
        }

        public async Task<IList<Company>> GetByRequestAsync(CompanySearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        public async Task<Company> GetByUserIdAsync(Guid userId)
        {
            return await _companyRepository.FirstOrDefaultAsync(model => model.CreatedById == userId);
        }

        public async Task<int> GetCountMyFollowAsync()
        {
            var currentCompanyId = _webContextManager.CurrentCompanyId;
            return await _companyFollowRepository
            .Where(model => model.CompanyId == currentCompanyId && model.IsFollow == true)
            .Select(model => model.FollowedById)
            .Distinct().CountAsync();
        }

        public async Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid companyId)
        {
            return (await _companyRepository.AsNoTracking()
                    .Where(model => model.Id == companyId)
                    .Select(model => new
                    {
                        model.Id,
                        model.LogoFileName
                    }).ToListAsync())
                .Select(model => new FineUploaderObject
                {
                    id = model.Id.ToString(),
                    uuid = model.Id.ToString(),
                    name = model.LogoFileName,
                    thumbnailUrl = FileConst.ImagesWebPath.PlusWord(model.LogoFileName) ?? FileConst.NoLogo,
                    size = new FileInfo(HttpContext.Current.Server.MapPath(FileConst.ImagesWebPath.PlusWord(model.LogoFileName))).Length.ToString()
                }).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<IList<FineUploaderObject>> GetFileCoverAsFineUploaderModelByIdAsync(Guid companyId)
        {
            return (await _companyRepository.AsNoTracking()
                    .Where(model => model.Id == companyId)
                    .Select(model => new
                    {
                        model.Id,
                        model.CoverFileName
                    }).ToListAsync())
                .Select(model => new FineUploaderObject
                {
                    id = model.Id.ToString(),
                    uuid = model.Id.ToString(),
                    name = model.CoverFileName,
                    thumbnailUrl = FileConst.ImagesWebPath.PlusWord(model.CoverFileName) ?? FileConst.NoLogo,
                    size = new FileInfo(HttpContext.Current.Server.MapPath(FileConst.ImagesWebPath.PlusWord(model.CoverFileName))).Length.ToString()
                }).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>

        public async Task<bool> IsMySelfAsync(Guid companyId)
        {
            return await _companyRepository.AsNoTracking()
                .AnyAsync(model => model.CreatedById == _webContextManager.CurrentUserId && model.Id == companyId);
        }

        public async Task<string> GetMyNameByUserIdAsync(Guid userId)
        {
            var user = await _userRepository.FirstOrDefaultAsync(model => model.Id == userId);
            if (user == null)
            {
                return "";
            }

            if (user.Meta.DisplayName != null)
                return user.Meta.DisplayName;
            if (user.Meta.FullName != " ")
                return user.Meta.FullName;
            if (user.CreatedBy.UserName != null)
                return user.CreatedBy.UserName;
            return user.CreatedBy.Email;
        }

        public async Task<bool> IsApprovedByAliasAsync(string alias)
        {
            return await _companyRepository.AnyAsync(model => model.Alias == alias && model.State == StateType.Approved);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<bool> IsExistEmailByCompanyIdAsync(Guid companyId, string email, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (email == null)
                return false;

            return await _companyRepository.AnyAsync(model => model.Email == email && model.Id != companyId && email != null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<bool> HasAliasByCurrentUserAsync()
        {
            return await _companyRepository.AsNoTracking()
                .AnyAsync(model => model.CreatedById == _webContextManager.CurrentUserId && model.Alias != null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        public async Task<bool> IsExistByAliasAsync(string alias, Guid? companyId = null, bool applyCurrentUser = false)
        {
            var query = _companyRepository.AsNoTracking().AsQueryable();
            query = query.Where(model => model.Alias == alias);

            if (applyCurrentUser)
                query = query.Where(model => model.CreatedById == _webContextManager.CurrentUserId);

            if (companyId.HasValue)
            {
                query = query.Where(model => model.Id != companyId);
                query = query.Where(model => model.Id == companyId);
            }

            return await query.AnyAsync();
        }


        public async Task<bool> IsExistAliasByIdAsync(Guid companyId)
        {
            return await _companyRepository.AsNoTracking().AnyAsync(model => model.Id == companyId && model.Alias != null);
        }

        public async Task<bool> IsMineByIdAsync(Guid companyId, HttpContext http, CancellationToken cancellationToken = default(CancellationToken))
        {
            var company = await _companyRepository.FirstOrDefaultAsync(model => model.Id == companyId);
            return (company.CreatedById == http.User.Identity.GetUserId().ToGuid() || http.User.IsInRole(PermissionConst.CanCompanyEdit));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="alias"></param>
        /// <param name="slug"></param>
        /// <returns></returns>
        public async Task<bool> CompareNameAndSlugAsync(string alias, string slug)
        {
            if (slug == "")
                return true;

            var company = await _companyRepository.AsNoTracking().FirstOrDefaultAsync(model => model.Alias == alias);
            if (company.Title.CastToSlug() == slug)
                return true;

            return false;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<Company> QueryByRequest(CompanySearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companies = _companyRepository.AsNoTracking().AsQueryable();

            if (request.Term.HasValue())
                companies = companies.Where(company => company.Title.Contains(request.Term) || company.Description.Contains(request.Term));
            if (request.State.HasValue)
                companies = companies.Where(company => company.State == request.State);
            if (request.CategoryId.HasValue)
                companies = companies.Where(company => company.CategoryId == request.CategoryId);
            if (request.CompanyId.HasValue)
                companies = companies.Where(company => company.Id == request.CompanyId);
            if (request.CreatedById.HasValue)
                companies = companies.Where(model => model.CreatedById == request.CreatedById);

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;

            companies = companies.OrderBy($"{request.SortMember} {request.SortDirection}");

            return companies;
        }

        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SetStateByIdAsync(Guid companyId, StateType state)
        {
            var company = await FindByIdAsync(companyId);
            company.State = state;

            await _unitOfWork.SaveAllChangesAsync();
        }

        #endregion Public Methods
    }
}