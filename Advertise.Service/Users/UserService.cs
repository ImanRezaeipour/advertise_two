using Advertise.Core.Domains.Locations;
using Advertise.Core.Domains.Users;
using Advertise.Core.Exceptions;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.User;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.Locations;
using Advertise.Service.Services.Products;
using Advertise.Service.Services.Users.Factories;
using Advertise.Service.Services.Users.Validators;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Advertise.Core.Configuration;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Managers.Events;
using Advertise.Service.Managers.File;
using Advertise.Service.Validators.Users;
using MvcSiteMapProvider.Matching;
using Stimulsoft.Report;
using FineUploaderObject = Advertise.Core.Objects.FineUploaderObject;

namespace Advertise.Service.Services.Users
{
    public class UserService : UserManager<User, Guid>, IUserService
    {

        #region Private Fields

        private readonly IAddressService _addressService;
        private readonly ICityService _cityService;
        private readonly ICommonService _commonService;
        private readonly ICompanyService _companyService;
        private readonly IConfigurationManager _configurationManager;
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IRoleService _roleService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<UserMeta> _userMetaRepository;
        private readonly IDbSet<User> _userRepository;
        private readonly IDbSet<UserRole> _userRoleRepository;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        public UserService(IMapper mapper, IUserStore<User, Guid> userStore, IDataProtectionProvider dataProtectionProvider, IIdentityMessageService smsService, IIdentityMessageService emailService, ICompanyService companyService, IProductService productService, IAddressService addressService, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IRoleService roleService, IConfigurationManager configurationManager, ICommonService commonService, IEventPublisher eventPublisher, ICityService cityService)
            : base(userStore)
        {
            _mapper = mapper;
            _dataProtectionProvider = dataProtectionProvider;
            _companyService = companyService;
            _productService = productService;
            _addressService = addressService;
            _userRepository = unitOfWork.Set<User>();
            _userMetaRepository = unitOfWork.Set<UserMeta>();
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _roleService = roleService;
            _configurationManager = configurationManager;
            _commonService = commonService;
            _eventPublisher = eventPublisher;
            _cityService = cityService;
            _userRoleRepository = unitOfWork.Set<UserRole>();
            SmsService = smsService;
            EmailService = emailService;
            AutoCommitEnabled = true;
            UserManagerOptions();
        }

        #endregion Public Constructors

        #region Public Properties

        public bool AutoCommitEnabled { get; set; }

        #endregion Public Properties

        #region Public Methods

        public async Task AddToRoleByIdAsync(Guid userId, UserRole userRole)
        {
            if (userRole == null)
                throw new ArgumentNullException(nameof(userRole));

            var user = await _userRepository.FirstOrDefaultAsync(model => model.Id == userId);
            user?.Roles.Clear();
            user?.Roles.Add(userRole);

            await _unitOfWork.SaveAllChangesAsync();
        }

        public async Task<int> CountAllAsync()
        {
            var request = new UserSearchRequest();
          return  await CountByRequestAsync(request);
            
        }

        public async Task<int> CountByRequestAsync(UserSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        public async Task CreateByViewModelAsync(UserCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var user = _mapper.Map<User>(viewModel);
            await CreateAsync(user, viewModel.Password);

            _eventPublisher.EntityInserted(user);
        }

        public async Task CreateUserMetaByUserIdAsync(Guid userId)
        {
            var userMeta = new UserMeta
            {
                IsActive = true,
                CreatedById = userId,
                Address = new Address()
            };
            _userMetaRepository.Add(userMeta);

            await _unitOfWork.SaveAllChangesAsync(auditUserId: userId);

            _eventPublisher.EntityInserted(userMeta);
        }

        public async Task CreateUserMetaByViewModelAsync(UserCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var userMeta = _mapper.Map<UserMeta>(viewModel);
            var defaultLocation = await _addressService.GetDefaultLocationAsync();
            userMeta.IsActive = true;
            //userMeta.CreatedById = _webContextManager.CurrentUserId;
            userMeta.Address = new Address
            {
                Latitude = defaultLocation.Item1,
                Longitude = defaultLocation.Item2,
                CityId = await _cityService.GetIdByNameAsync(defaultLocation.Item3)
            };
            _userMetaRepository.Add(userMeta);

            await _unitOfWork.SaveAllChangesAsync(auditUserId: viewModel.CreatedById);

            _eventPublisher.EntityInserted(userMeta);
        }

        public async Task DeleteByIdAsync(Guid userId)
        {
            var user = await FindByUserIdAsync(userId);
            await _productService.DeleteByUserIdAsync(userId);
            await _companyService.DeleteByUserIdAsync(userId);
            await _addressService.DeleteByIdAsync(user.Meta.AddressId.GetValueOrDefault());
            user.CompanyFollows.Clear();
            user.CompanyQuestions.Clear();
            user.ProductComments.Clear();
            user.ProductLikes.Clear();
            user.ProductsCommentLikes.Clear();
            user.Bags.Clear();
            user.Products.Clear();
            user.Receipts.Clear();
            _userRepository.Remove(user);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(user);
        }

        [Validation(typeof(UserEditValidator),"Edit")]
        public async Task EditByViewModelAsync(UserEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var originalUser = await FindByUserIdAsync(viewModel.Id);
            _mapper.Map(viewModel, originalUser);
            originalUser.Meta.AvatarFileName = viewModel.AvatarFileName;
            originalUser.Meta.FirstName = viewModel.FirstName;
            originalUser.Meta.LastName = viewModel.LastName;
            originalUser.Meta.HomeNumber = viewModel.HomeNumber;
            originalUser.Meta.NationalCode = viewModel.NationalCode;
            originalUser.Meta.Address.Latitude = viewModel.Address.Latitude;
            originalUser.Meta.Address.Longitude = viewModel.Address.Longitude;
            originalUser.Meta.Address.Extra = viewModel.Address.Extra;
            originalUser.Meta.Address.PostalCode = viewModel.Address.PostalCode;
            originalUser.Meta.Address.Street = viewModel.Address.Street;
            originalUser.Meta.Address.CityId = viewModel.Address.City.Id;
            originalUser.Meta.Gender = viewModel.Gender;

            var role = new UserRole
            {
                RoleId = viewModel.RoleId
            };
            originalUser.Roles.Clear();
            originalUser.Roles.Add(role);

            await _unitOfWork.SaveAllChangesAsync();
            this.UpdateSecurityStamp(viewModel.Id);

            _eventPublisher.EntityUpdated(originalUser);
        }

        [Validation(typeof(UserEditMeValidator), "Edit")]
        public async Task EditMetaByViewModelAsync(UserEditMeViewModel viewModel, bool isCurrentUser = false)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

          var originalUser = await _userRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            if (isCurrentUser && originalUser.CreatedById == _webContextManager.CurrentUserId)
                return;

            _mapper.Map(viewModel, originalUser);
            originalUser.Meta.AvatarFileName = viewModel.AvatarFileName;
            originalUser.Meta.FirstName = viewModel.FirstName;
            originalUser.Meta.LastName = viewModel.LastName;
            originalUser.Meta.HomeNumber = viewModel.HomeNumber;
            originalUser.Meta.NationalCode = viewModel.NationalCode;
            originalUser.Meta.Address.Latitude = viewModel.Address.Latitude;
            originalUser.Meta.Address.Longitude = viewModel.Address.Longitude;
            originalUser.Meta.Address.Extra = viewModel.Address.Extra;
            originalUser.Meta.Address.PostalCode = viewModel.Address.PostalCode;
            originalUser.Meta.Address.Street = viewModel.Address.Street;
            originalUser.Meta.Address.CityId = viewModel.Address.City.Id;
            originalUser.Meta.Gender = viewModel.Gender;

            await _unitOfWork.SaveAllChangesAsync();
        }

        public Task<User> FindByEmailAsync(string email, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _userRepository.AsNoTracking().SingleOrDefaultAsync(model => model.Email == email, cancellationToken);
        }

        public async Task<User> FindByPhoneNumberAsync(string phoneNumber)
        {
            return await _userRepository.FirstOrDefaultAsync(model => model.PhoneNumber == phoneNumber);
        }

        public async Task<User> FindByUserIdAsync(Guid userId, bool isCurrentUser = false)
        {
            var query = _userRepository.AsQueryable()
                .Include(model => model.Meta);
            query = isCurrentUser ? query.Where(model => model.Id == _webContextManager.CurrentUserId) : query.Where(model => model.Id == userId);
            var user = await query.FirstOrDefaultAsync();

            return user;
        }

        public async Task<User> FindByUserNameAsync(string username)
        {
            return await _userRepository.FirstOrDefaultAsync(model => model.UserName == username);
        }

        public async Task<UserMeta> FindUserMetaByCurrentUserAsync()
        {
            return await _userMetaRepository
                .FirstOrDefaultAsync(model => model.CreatedById == _webContextManager.CurrentUserId);
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserService service, User user)
        {
            return await service.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        }

        public async Task<string> GenerateUserNameAsync()
        {
            var randomNumber = _commonService.RandomNumberByCount(100000000, 999999999);
            var generatedUserName = CodeConst.Novinak + randomNumber;
            if (await _userRepository.AsNoTracking().AnyAsync(model => model.UserName == generatedUserName))
                return await GenerateUserNameAsync();
            return generatedUserName;
        }

        public async Task<Address> GetAddressByIdAsync(Guid userId)
        {
            return await _userRepository
                .Include(model => model.Meta.Address)
                .Where(model => model.Id == userId)
                .Select(model => model.Meta.Address)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetByEmailAndPasswordAsync(string email, string password, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (email == null)
                throw new ArgumentNullException(nameof(email));

            if (password == null)
                throw new ArgumentNullException(nameof(password));

            var user = await FindByEmailAsync(email);
            var result = await CheckPasswordAsync(user, password);

            return result ? user : null;
        }

        public async Task<bool> IsExistByEmailAndPasswordAsync(string email, string password, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (email == null)
                throw new ArgumentNullException(nameof(email));

            if (password == null)
                throw new ArgumentNullException(nameof(password));

            var user = await FindByEmailAsync(email);
            var result = await CheckPasswordAsync(user, password);

            return result;
        }

        public async Task<User> GetCurrentUserAsync()
        {
            return await _userRepository.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == _webContextManager.CurrentUserId);
        }

        public async Task<string> GetCurrentUserNameAsync()
        {
            var userMeta = await _userMetaRepository.AsNoTracking()
                .Include(model => model.CreatedBy)
                .FirstOrDefaultAsync(model => model.CreatedById == _webContextManager.CurrentUserId);

            if (userMeta.DisplayName != null)
                return userMeta.DisplayName;
            if (userMeta.FullName != " ")
                return userMeta.FullName;
            return userMeta.CreatedBy.UserName ?? userMeta.CreatedBy.Email;
        }

        public IUserEmailStore<User, Guid> GetEmailStore()
        {
            var cast = Store as IUserEmailStore<User, Guid>;
            if (cast == null)
                throw new NotSupportedException();

            return cast;
        }

        public async Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid userId)
        {
            var s =
                (await _userRepository.AsNoTracking()
                .Include(model => model.Meta)
                    .Where(model => model.Id == userId)
                    .Select(model => model.Meta)
                    .ToListAsync())
                .Select(model => new FineUploaderObject
                {
                    id = model.Id.ToString(),
                    uuid = model.Id.ToString(),
                    name = model.AvatarFileName,
                    thumbnailUrl = FileConst.ImagesWebPath.PlusWord(model.AvatarFileName),
                    size = new FileInfo(HttpContext.Current.Server.MapPath(FileConst.ImagesWebPath.PlusWord(model.AvatarFileName))).Length.ToString()
                }).ToList();
            return s;
        }

        public async Task<IList<string>> GetPhoneNumbersByUserIdsAsync(IList<Guid?> userIds)
        {
            return await _userRepository.AsNoTracking()
                .Where(model => userIds.Contains(model.Id))
                .Select(model => model.PhoneNumber)
                .ToListAsync();
        }

        public override async Task<IList<string>> GetRolesAsync(Guid userId)
        {
            return await _roleService.GetPermissionNamesByUserIdAsync(userId);
        }

        public async Task<User> GetSystemUserAsync()
        {
            return await _userRepository.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IsSystemAccount == true);
        }

        public async Task<UserMeta> GetUserMetaByIdAsync(Guid userId)
        {
            return await _userMetaRepository.AsNoTracking()
                .FirstOrDefaultAsync(model => model.CreatedById == userId);
        }

        public async Task<IList<User>> GetUsersByRequestAsync(UserSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            //request.GroupBy = user => user.Code;

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        public async Task<IList<User>> GetUsersByRoleIdAsync(Guid roleId)
        {
            var userIds = await _userRoleRepository.AsNoTracking()
                .Where(model => model.RoleId == roleId)
                .Select(model => model.UserId)
                .ToListAsync();

            return await _userRepository.AsNoTracking()
                .Where(model => userIds.Contains(model.Id))
                .ToListAsync();
        }

        public async Task<bool> HasUserNameByCurrentUserAsync()
        {
            var novinak = "Novinak";
           return  !await _userRepository.AsNoTracking()
                .Where(model => model.Id == _webContextManager.CurrentUserId && model.UserName.Contains(novinak))
                .Select(model => model.UserName)
                .AnyAsync();
        }

        public async Task<bool> IsBanByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _userRepository.AsNoTracking()
                .AnyAsync(user => user.Id == userId && user.IsBan == true);
        }

        public async Task<bool> IsBanByUserNameAsync(string userName)
        {
            return await _userRepository.AsNoTracking()
                .AnyAsync(user => user.UserName == userName.ToLower() && user.IsBan == true);
        }

        public async Task<bool> IsEmailConfirmedByEmailAsync(string email, HttpContext httpContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            var user = await _userRepository.AsNoTracking().SingleOrDefaultAsync(model => model.Email == email.ToLower());
            if (user == null)
                return true;

            if (!user.EmailConfirmed)
            {
                var code = await GenerateEmailConfirmationTokenAsync(user.Id);
                var url = httpContext.Request.Url;
                var callbackUrl =
                    $"{url.Scheme}://{url.Authority}/{_configurationManager.ConfirmationEmailUrl}?id={user.Id}&code={code.Base64ForUrlEncode()}";
                var subject = "تایید حساب کاربری";
                var body = "<span>" +
                           "لطفا جهت تایید حساب کاربری خود" +
                           $" <a href='{callbackUrl}'>اینجا کلیک کنید</a>" +
                           "</span>" +
                           "<hr/>" +
                           "<br/>".Repeat(2) +
                           "<span> در صورتی که لینک بالا کار نکرد ، لینک زیر را به صورت دستی در مرورگر خود وارد کنید</span>" +
                           "<br/>".Repeat(2) +
                           $"<span>{callbackUrl}</span>";

                await SendEmailAsync(user.Id, subject, body);
            }
            return user.EmailConfirmed;
        }

        public async Task<bool> IsExistByEmailAsync(string email, Guid? userId = null )
        {
            var query = _userRepository.AsQueryable();
            query = query.Where(user => user.Email == email.ToLower());

            if (userId.HasValue)
                query = query.Where(user => user.Id == userId);
            return await query.AnyAsync();
        }

        public async Task<bool> IsExistByEmailCancellationTokenAsync(string email,  CancellationToken cancellationToken = default(CancellationToken))
        {
          var dd = await _userRepository.AsNoTracking().AnyAsync(user => user.Email == email.ToLower());
            return dd;
        }

        public async Task<bool> IsExistByIdCancellationTokenAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _userRepository.AsNoTracking().AnyAsync(user => user.Id == id, cancellationToken);
        }

        public async Task<int> IsExistByUserNameAsync(string userName, Guid? userId= null, Guid? exceptUserId = null)
        {
            var query = _userRepository.AsQueryable();
            query = query.Where(user => user.UserName == userName);
            if (userId.HasValue)
                query = query.Where(user => user.Id == userId);
            if (exceptUserId.HasValue)
                query = query.Where(user => user.Id != exceptUserId);
            var list =  await query.ToListAsync();
            return list.Count();
        }

        public async Task<bool> IsExistByUserNameCancellationTokenAsync(string userName, CancellationToken cancellationToken)
        {
           var originUser =  await _userRepository.AsNoTracking().SingleOrDefaultAsync(user => user.Id == _webContextManager.CurrentUserId, cancellationToken);
            if (userName.StartsWith(CodeConst.Novinak) || userName == originUser.UserName)
                return true;

            var result = await _userRepository.AsNoTracking().AnyAsync(user => user.UserName == userName, cancellationToken);
            return !result;
        }

        public async Task<bool> IsLockedOutAsync(Guid userId, CancellationToken cancellationToken)
        {
            var user = await _userRepository.AsNoTracking().SingleOrDefaultAsync(model => model.Id == userId);
            if (user == null)
                return true;
            return user.LockoutEnabled;
        }

        public async Task<bool> IsLockedOutAsync(string email, CancellationToken cancellationToken)
        {
            var user =await _userRepository.AsNoTracking().SingleOrDefaultAsync(model => model.Email == email);
            if (user == null)
                return true;
            return user.LockoutEnabled;
        }

        public async Task<bool> IsBanByEmailAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _userRepository.AsNoTracking().SingleOrDefaultAsync(model => model.Email == email);
            if (user == null)
                return true;
            return user.IsBan != null && !user.IsBan.Value;
        }

        public async Task<string> MaxByRequestAsync(UserSearchRequest request, string aggregateMember)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var users = QueryByRequest(request);
            switch (aggregateMember)
            {
                case UserAggregateMember.Code:
                    var memberMax = await users.MaxAsync(model => model.Code);
                    return memberMax;
            }

            return null;
        }

        public Func<CookieValidateIdentityContext, Task> OnValidateIdentity()
        {
            return ApplicationSecurityStampValidator.OnValidateIdentity(TimeSpan.FromMinutes(0), GenerateUserIdentityAsync, identity => Guid.Parse(identity.GetUserId()));
        }

        public IQueryable<User> QueryByRequest(UserSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var users = _userRepository.AsNoTracking().AsQueryable()
                .Include(model => model.Meta);

            if (request.IsActive.HasValue)
                users = users.Where(model => model.IsActive == request.IsActive);
            if (request.IsBan.HasValue)
                if (request.IsBan.Value.ToString() != "-1")
                    users = users.Where(model => model.IsBan == request.IsBan);
            if (request.IsVerify.HasValue)
                if (request.IsVerify.Value.ToString() != "-1")
                    users = users.Where(model => model.IsVerify == request.IsVerify);
            if (request.Term.HasValue())
                users = users.Where(model => model.Email.Contains(request.Term) || model.UserName.Contains(request.Term) || model.Email.Contains(request.Term) || model.PhoneNumber.Contains(request.Term));

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;

            //if(request.GroupBy != null)
            //    users = users.GroupBy(request.GroupBy).SelectMany(grouping => grouping);

            users = users.OrderBy($"{request.SortMember} {request.SortDirection}");

            return users;
        }

        public async void SeedDatabase()
        {
            var adminUser = _userRepository.FirstOrDefault(user => user.IsSystemAccount == true);
            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = _configurationManager.AdminUserName,
                    IsSystemAccount = true,
                    Email = _configurationManager.AdminEmail
                };
                adminUser = new User
                {
                    IsActive = true,
                    CreatedById = adminUser.Id
                };
                this.Create(adminUser, _configurationManager.AdminPassword);
                this.SetLockoutEnabled(adminUser.Id, false);
            }
            var userRoles = await _roleService.GetRoleNamesByUserIdAsync(adminUser.Id);
            if (userRoles.Any(role => role == "مدیران"))
                return;
            this.AddToRole(adminUser.Id, "مدیران");
        }

        public void UserManagerOptions()
        {
            ClaimsIdentityFactory = new ApplicationClaimsIdentityFactory();
            UserValidator = new ApplicationUserValidator<User, Guid>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };
            PasswordValidator = new ApplicationPasswordValidator
            {
                RequiredLength = 5,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };
            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 5;
            if (_dataProtectionProvider == null) return;
            var dataProtector = _dataProtectionProvider.Create("Application Identity");
            UserTokenProvider = new DataProtectorTokenProvider<User, Guid>(dataProtector);
        }

        #endregion Public Methods
    }
}