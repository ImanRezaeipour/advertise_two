using Advertise.Core.Domains.Users;
using Advertise.Core.Exceptions;
using Advertise.Core.Models.Account;
using Advertise.Core.Models.Company;
using Advertise.Core.Models.User;
using Advertise.Core.Models.UserOperator;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.Plans;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using Advertise.Core.Configuration;
using Advertise.Core.Helpers;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Managers.Events;
using Advertise.Service.Validators.Accounts;
using Advertise.Service.Validators.Users;

namespace Advertise.Service.Services.Users
{
    /// <summary>
    ///
    /// </summary>
    public class AccountService : IAccountService
    {
        #region Private Fields

        private readonly IAuthenticationManager _authenticationManager;
        private readonly ICompanyService _companyService;
        private readonly IConfigurationManager _configurationManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IPlanService _planService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<UserMeta> _userMetaRepository;
        private readonly IUserOperationServive _userOperationServive;
        private readonly IUserService _userService;
        private readonly IUserSettingService _userSettingService;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="configurationManager"></param>
        /// <param name="mapper"></param>
        /// <param name="companyService"></param>
        /// <param name="userSettingService"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        /// <param name="planService"></param>
        /// <param name="userOperationServive"></param>
        /// <param name="eventPublisher"></param>
        /// <param name="authenticationManager"></param>
        public AccountService(IUserService userService, IConfigurationManager configurationManager, IMapper mapper, ICompanyService companyService, IUserSettingService userSettingService, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IPlanService planService, IUserOperationServive userOperationServive, IEventPublisher eventPublisher, IAuthenticationManager authenticationManager)
        {
            _userService = userService;
            _configurationManager = configurationManager;
            _mapper = mapper;
            _companyService = companyService;
            _userSettingService = userSettingService;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _planService = planService;
            _userOperationServive = userOperationServive;
            _eventPublisher = eventPublisher;
            _authenticationManager = authenticationManager;
            _userMetaRepository = unitOfWork.Set<UserMeta>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public async Task ChangePasswordByCurrentUserAsync(string oldPassword, string newPassword)
        {
            await _userService.ChangePasswordAsync(_webContextManager.CurrentUserId, oldPassword, newPassword);

            var user = await _userService.FindByIdAsync(_webContextManager.CurrentUserId);

            _authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _userService.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = false
            }, identity);
        }


        [Validation(typeof(ForgotPasswordValidator), "forgotpasswordconfirm")]
        public async Task ConfirmForgotPasswordAsync(ForgotPasswordViewModel viewModel)
        {
            if (viewModel.Email == null)
                throw new ArgumentNullException(nameof(viewModel.Email));

            var user = await _userService.FindByEmailAsync(viewModel.Email);
            if (user == null)
                throw new ServiceException();

            await SendForgotPasswordConfirmationTokenAsync(user.Id);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public async Task ConfirmPhoneNumberAsync(UserVerifyPhoneNumberViewModel viewModel)
        {
            var user = await _userService.FindByIdAsync(viewModel.UserId);
            await _userService.ChangePhoneNumberAsync(viewModel.UserId, viewModel.PhoneNumber, viewModel.Code);
            await _userService.AddPasswordAsync(viewModel.UserId, viewModel.Password);
            await _userService.UpdateSecurityStampAsync(user.Id);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ResetPasswordValidator))]
        public async Task ConfirmResetPasswordAsync(ResetPasswordViewModel viewModel)
        {
            viewModel.Code = viewModel.Code.Replace(" ", "+");
            var user = await _userService.FindByEmailAsync(viewModel.Email);
            await _userService.ResetPasswordAsync(user.Id, viewModel.Code, viewModel.Password);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(LoginValidator),"Login")]
        public async Task<SignInStatus> PasswordSignInAsync(LoginViewModel viewModel)
        {
            var result = viewModel.UserName.StartsWith(CodeConst.Novinak);
            if (result)
                return SignInStatus.Failure;

            var user = await _userService.FindByEmailAsync(viewModel.UserName);
            if (user == null)
                throw new ServiceException();
            viewModel.UserName = user.UserName;

            var trust = await _userService.CheckPasswordAsync(user, viewModel.Password);
            if (!trust)
                return SignInStatus.Failure;

            var identity = await _userService.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = viewModel.RememberMe
            }, identity);

            await _userService.SendSmsAsync(user.Id, $"{user.UserName} عزیز به سامانه نویناک خوش آمدید. آخرین ورود شما {user.LastLoginedOn}");
            return SignInStatus.Success;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(RegisterValidator), "emailregister")]
        public async Task RegisterByEmailAsync(RegisterViewModel viewModel)
        {
            var user = _mapper.Map<User>(viewModel);
            user.UserName = await _userService.GenerateUserNameAsync();
            var superUser = await _userService.GetSystemUserAsync();
            await UpdateAuditFieldsAsync(user, superUser.Id);
            await _userService.CreateAsync(user, viewModel.Password);

            var userSaved = await _userService.FindByEmailAsync(viewModel.Email);
            await _userService.AddToRoleAsync(userSaved.Id, "کاربران");
            await _userService.CreateUserMetaByUserIdAsync(userSaved.Id);
            await _companyService.CreateByUserIdAsync(userSaved.Id);
            await _userSettingService.CreateByUserIdAsync(userSaved.Id);
            var userMeta = await _userMetaRepository.FirstOrDefaultAsync(model => model.CreatedById == user.Id);
            user.MetaId = userMeta.Id;
            user.CompanyId = (await _companyService.FindByUserIdAsync(userSaved.Id)).Id;

            await _unitOfWork.SaveAllChangesAsync(auditUserId: user.Id);

            await SendEmailConfirmationTokenAsync(userSaved.Id);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task RegisterByExternalLinkAsync()
        {
            var externalLoginInfo = await _authenticationManager.GetExternalLoginInfoAsync();

            await _userService.IsExistByEmailAsync(externalLoginInfo.Email);

            var user = _mapper.Map<User>(new RegisterViewModel());
            user.Email = externalLoginInfo.Email;
            var superUser = await _userService.GetSystemUserAsync();
            await UpdateAuditFieldsAsync(user, superUser.Id);

            var userSaved = await _userService.FindByEmailAsync(externalLoginInfo.Email);
            await _userService.AddToRoleAsync(userSaved.Id, "کاربران");
            await _userService.CreateUserMetaByUserIdAsync(userSaved.Id);
            await _companyService.CreateByUserIdAsync(userSaved.Id);
            user.MetaId = (await _userMetaRepository.FirstOrDefaultAsync(model => model.CreatedById == user.Id)).Id;
            user.CompanyId = (await _companyService.FindByIdAsync(userSaved.Id)).Id;

            await _unitOfWork.SaveAllChangesAsync(auditUserId: user.Id);

            await SendEmailConfirmationTokenAsync(userSaved.Id);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public async Task RegisterByPhoneNumberAsync(UserAddPhoneNumberViewModel viewModel)
        {
            var user = _mapper.Map<User>(viewModel);
            user.UserName = await _userService.GenerateUserNameAsync();
            var superUser = await _userService.GetSystemUserAsync();
            await UpdateAuditFieldsAsync(user, superUser.Id);
            await _userService.CreateAsync(user, viewModel.Number);

            var userSaved = await _userService.FindByPhoneNumberAsync(viewModel.Number);
            await _userService.AddToRoleAsync(userSaved.Id, "کاربران");
            await _userService.CreateUserMetaByUserIdAsync(userSaved.Id);
            await _companyService.CreateByUserIdAsync(userSaved.Id);
            user.MetaId = (await _userMetaRepository.FirstOrDefaultAsync(model => model.CreatedById == user.Id)).Id;
            user.CompanyId = (await _companyService.FindByIdAsync(userSaved.Id)).Id;

            await _unitOfWork.SaveAllChangesAsync(auditUserId: user.Id);

            await SendEmailConfirmationTokenAsync(userSaved.Id);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(UserOperatorCreateValidator), "EasyRegister")]
        public async Task RegisterEasyAsync(UserOperatorCreateViewModel viewModel)
        {
            //  CREATE USER
            var user = _mapper.Map<User>(viewModel);
            user.UserName = await _userService.GenerateUserNameAsync();
            user.EmailConfirmed = true;
            user.IsBan = false;
            await UpdateAuditFieldsAsync(user, _webContextManager.CurrentUserId);
            await _userService.CreateAsync(user, viewModel.Password);


            //  UPDATE USER ROLE
            var userSaved = await _userService.FindByEmailAsync(viewModel.Email);
            var role = await _planService.FindByIdAsync(viewModel.RoleId.GetValueOrDefault());
            var userRole = new UserRole
            {
                UserId = userSaved.Id,
                RoleId = role.RoleId.GetValueOrDefault()
            };
            await _userService.AddToRoleByIdAsync(userSaved.Id, userRole);

            //  CREATE COMPANY
            var companyViewModel = new CompanyCreateViewModel
            {
                Alias = viewModel.Alias,
                Email = viewModel.Email,
                MobileNumber = viewModel.MobileNumber,
                Title = viewModel.CompanyTitle,
                CategoryId = viewModel.CategoryId.GetValueOrDefault(),
                CreatedById = userSaved.Id
            };
            await _companyService.CreateEasyByViewModelAsync(companyViewModel);

            //  CREATE USER META
            var userMetaViewModel = new UserCreateViewModel
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                CreatedById = userSaved.Id
            };
            await _userService.CreateUserMetaByViewModelAsync(userMetaViewModel);

            //  UPDATE USER META
            user.MetaId = (await _userMetaRepository.FirstOrDefaultAsync(model => model.CreatedById == user.Id)).Id;
            user.CompanyId = (await _companyService.FindByUserIdAsync(userSaved.Id)).Id;

            //  CREATE USER OPERATION
            var userOperator = new UserOperator
            {
                Amount = viewModel.Amount,
                Description = viewModel.Description,
                CreatedById = userSaved.Id
            };
            await _userOperationServive.CreateByModelAsync(userOperator);

            await _unitOfWork.SaveAllChangesAsync(auditUserId: userSaved.Id);
            _eventPublisher.EntityInserted(user);

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task  SendEmailConfirmationTokenAsync(Guid userId)
        {
            var code = await _userService.GenerateEmailConfirmationTokenAsync(userId);
            var url = HttpContext.Current.Request.Url;
            var callbackUrl = $"{url.Scheme}://{url.Authority}/{_configurationManager.ConfirmationEmailUrl}?id={userId}&code={code.Base64ForUrlEncode()}";
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

            await _userService.SendEmailAsync(userId, subject, body);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task SendForgotPasswordConfirmationTokenAsync(Guid userId)
        {
            var code = await _userService.GeneratePasswordResetTokenAsync(userId);
            var url = HttpContext.Current.Request.Url;
            var callbackUrl = $"{url.Scheme}://{url.Authority}/{_configurationManager.ConfirmationResetPasswordUrl}?userid={userId}&code={code}";
            var subject = "بازیابی کلمه عبور";
            var body = "<span>" +
                       "لطفا جهت بازیابی پسورد خود" +
                       $" <a href='{callbackUrl}'>اینجا کلیک کنید</a>" +
                       "</span>" +
                       "<hr/>" +
                       "<br/>".Repeat(2) +
                       "<span> در صورتی که لینک بالا کار نکرد ، لینک زیر را به صورت دستی در مرورگر خود وارد کنید</span>" +
                       "<br/>".Repeat(2) +
                       $"<span>{callbackUrl}</span>";

            await _userService.SendEmailAsync(userId, subject, body);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public async Task SendPhoneNumberConfirmationTokenAsync(Guid userId, string phoneNumber)
        {
            if (phoneNumber == null)
                return;

            var code = await _userService.GenerateChangePhoneNumberTokenAsync(userId, phoneNumber);
            if (_userService.SmsService == null)
                return;

            var message = new IdentityMessage
            {
                Destination = phoneNumber,
                Body = "کد امنیتی : " + code
            };
            await _userService.SmsService.SendAsync(message);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task SetCurrentUserPasswordAsync(string password)
        {
            await _userService.AddPasswordAsync(_webContextManager.CurrentUserId, password);
            var user = await _userService.FindByIdAsync(_webContextManager.CurrentUserId);
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _userService.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
        }


        public async Task<SignInStatus> SignInByIdAsync(Guid id)
        {
            var user = await _userService.FindByIdAsync(id);
            if (user == null)
                return SignInStatus.Failure;

            var identity = await _userService.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, identity);

            return SignInStatus.Success;
        }

        /// <inheritdoc />
        ///  <summary>
        ///  </summary>
        ///  <returns></returns>
        public async Task SignOutCurrentUserAsync()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        /// <inheritdoc />
        ///  <summary>
        ///  </summary>
        ///  <param name="user"></param>
        ///  <param name="auditUserId"></param>
        ///  <returns></returns>
        public async Task UpdateAuditFieldsAsync(User user, Guid auditUserId)
        {
            user.Id = SequentialGuidGenerator.NewSequentialGuid();
            user.CreatedOn = DateTime.Now;
            //user.ModifiedOn = auditDate;
            //user.Audit = AuditType.Create;
           // user.CreatorIp = auditUserIp;
           // user.ModifierIp = auditUserIp;
           // user.CreatorAgent = auditUserAgent;
           // user.ModifierAgent = auditUserAgent;
            user.Version = 1;
            user.CreatedById = auditUserId;
            //user.ModifiedById = auditUserId;
        }

        #endregion Public Methods
    }
}