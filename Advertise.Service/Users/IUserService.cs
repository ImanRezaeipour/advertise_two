using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Advertise.Core.Domains.Locations;
using Advertise.Core.Domains.Users;
using Advertise.Core.Models.Account;
using Advertise.Core.Models.User;
using Advertise.Core.Objects;
using Advertise.Service.Services.Common;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;

namespace Advertise.Service.Services.Users
{
    public interface IUserService:IDisposable
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        bool AutoCommitEnabled { get; set; }

        IClaimsIdentityFactory<User, Guid> ClaimsIdentityFactory { get; set; }
        TimeSpan DefaultAccountLockoutTimeSpan { get; set; }
        IIdentityMessageService EmailService { get; set; }
        int MaxFailedAccessAttemptsBeforeLockout { get; set; }
        IPasswordHasher PasswordHasher { get; set; }
        IIdentityValidator<string> PasswordValidator { get; set; }
        IIdentityMessageService SmsService { get; set; }
        bool SupportsQueryableUsers { get; }
        bool SupportsUserClaim { get; }
        bool SupportsUserEmail { get; }
        bool SupportsUserLockout { get; }
        bool SupportsUserLogin { get; }
        bool SupportsUserPassword { get; }
        bool SupportsUserPhoneNumber { get; }
        bool SupportsUserRole { get; }
        bool SupportsUserSecurityStamp { get; }
        bool SupportsUserTwoFactor { get; }
        IDictionary<string, IUserTokenProvider<User, Guid>> TwoFactorProviders { get; }
        bool UserLockoutEnabledByDefault { get; set; }
        IQueryable<User> Users { get; }
        IUserTokenProvider<User, Guid> UserTokenProvider { get; set; }
        IIdentityValidator<User> UserValidator { get; set; }

        #endregion Public Properties

        #region Public Methods

        Task<IdentityResult> AccessFailedAsync(Guid userId);

        Task<IdentityResult> AddClaimAsync(Guid userId, Claim claim);

        Task<IdentityResult> AddLoginAsync(Guid userId, UserLoginInfo login);

        Task<IdentityResult> AddPasswordAsync(Guid userId, string password);

        Task<IdentityResult> AddToRoleAsync(Guid userId, string role);

       
        Task AddToRoleByIdAsync(Guid userId, UserRole userRole);

        Task<IdentityResult> AddToRolesAsync(Guid userId, params string[] roles);


        Task<IdentityResult> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);

        Task<IdentityResult> ChangePhoneNumberAsync(Guid userId, string phoneNumber, string token);

        Task<bool> CheckPasswordAsync(User user, string password);


        Task<IdentityResult> ConfirmEmailAsync(Guid userId, string token);


        Task<int> CountAllAsync();


        Task<int> CountByRequestAsync(UserSearchRequest request);

        Task<IdentityResult> CreateAsync(User user);

        Task<IdentityResult> CreateAsync(User user, string password);


        Task CreateByViewModelAsync(UserCreateViewModel viewModel);

        Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType);

        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task CreateUserMetaByUserIdAsync(Guid userId);

        Task<IdentityResult> DeleteAsync(User user);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(Guid userId);

        void Dispose();


        Task EditByViewModelAsync(UserEditViewModel viewModel);

        Task EditMetaByViewModelAsync(UserEditMeViewModel viewModel, bool isCurrentUser = false);

      

        Task<User> FindAsync(string userName, string password);

        Task<User> FindAsync(UserLoginInfo login);


        Task<UserMeta> FindUserMetaByCurrentUserAsync();

        Task<User> FindByEmailAsync(string email, CancellationToken cancellationToken = default(CancellationToken));

        Task<User> FindByEmailAsync(string email);

        Task<User> FindByIdAsync(Guid userId);

        Task<User> FindByNameAsync(string userName);

        /// <summary>
        ///
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        Task<User> FindByPhoneNumberAsync(string phoneNumber);

        Task<User> FindByUserNameAsync(string username);


        Task<User> GetSystemUserAsync();

        Task<User> FindByUserIdAsync(Guid userId, bool isCurrentUser = false);

        Task<string> GenerateChangePhoneNumberTokenAsync(Guid userId, string phoneNumber);

        Task<string> GenerateEmailConfirmationTokenAsync(Guid userId);

        Task<string> GeneratePasswordResetTokenAsync(Guid userId);


        IQueryable<User> QueryByRequest(UserSearchRequest request);

        Task<string> GenerateTwoFactorTokenAsync(Guid userId, string twoFactorProvider);

        /// <summary>
        /// </summary>
        /// <param name="service"></param>
        /// <param name="user">   </param>
        /// <returns></returns>
        Task<ClaimsIdentity> GenerateUserIdentityAsync(UserService service, User user);

        Task<string> GenerateUserTokenAsync(string purpose, Guid userId);

        Task<int> GetAccessFailedCountAsync(Guid userId);


        Task<User> GetCurrentUserAsync();

        /// <summary>
        /// </summary>
        /// <param name="email">   </param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<User> GetByEmailAndPasswordAsync(string email, string password, CancellationToken cancellationToken = default (CancellationToken));

        Task<IList<Claim>> GetClaimsAsync(Guid userId);

        Task<string> GetEmailAsync(Guid userId);


        IUserEmailStore<User, Guid> GetEmailStore();

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid userId);

        Task<bool> GetLockoutEnabledAsync(Guid userId);

        Task<DateTimeOffset> GetLockoutEndDateAsync(Guid userId);

        Task<IList<UserLoginInfo>> GetLoginsAsync(Guid userId);


        Task<UserMeta> GetUserMetaByIdAsync(Guid id);


        Task<string> GetCurrentUserNameAsync();

        Task<string> GetPhoneNumberAsync(Guid userId);

        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IList<string>> GetRolesAsync(Guid userId);

        Task<string> GetSecurityStampAsync(Guid userId);

        Task<bool> GetTwoFactorEnabledAsync(Guid userId);


        Task<IList<User>> GetUsersByRequestAsync(UserSearchRequest request);

        Task<IList<string>> GetValidTwoFactorProvidersAsync(Guid userId);

        Task<bool> HasPasswordAsync(Guid userId);


        Task<bool> HasUserNameByCurrentUserAsync();

        /// <summary>
        /// </summary>
        void UserManagerOptions();

        /// <summary>
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> IsBanByUserNameAsync(string userName);

        Task<bool> IsEmailConfirmedAsync(Guid userId);

        /// <summary>
        /// </summary>
        /// <param name="email"> </param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> IsExistByEmailAsync(string email, Guid? userId = null);

        Task<bool> IsInRoleAsync(Guid userId, string role);

        Task<bool> IsLockedOutAsync(Guid userId );
        Task<bool> IsLockedOutAsync(Guid userId , CancellationToken cancellationToken );

        Task<bool> IsPhoneNumberConfirmedAsync(Guid userId);

        /// <summary>
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userId">  </param>
        /// <returns></returns>
        Task<int> IsExistByUserNameAsync(string userName, Guid? userId= null, Guid? exceptUserId = null);

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="aggregateMember"></param>
        /// <returns></returns>
        Task<string> MaxByRequestAsync(UserSearchRequest request, string aggregateMember);

        Task<IdentityResult> NotifyTwoFactorTokenAsync(Guid userId, string twoFactorProvider, string token);


        Func<CookieValidateIdentityContext, Task> OnValidateIdentity();


        void RegisterTwoFactorProvider(string twoFactorProvider, IUserTokenProvider<User, Guid> provider);

        Task<IdentityResult> RemoveClaimAsync(Guid userId, Claim claim);

        Task<IdentityResult> RemoveFromRoleAsync(Guid userId, string role);

        Task<IdentityResult> RemoveFromRolesAsync(Guid userId, params string[] roles);

        Task<IdentityResult> RemoveLoginAsync(Guid userId, UserLoginInfo login);

        Task<IdentityResult> RemovePasswordAsync(Guid userId);

        Task<IdentityResult> ResetAccessFailedCountAsync(Guid userId);

        Task<IdentityResult> ResetPasswordAsync(Guid userId, string token, string newPassword);

        /// <summary>
        /// </summary>
        void SeedDatabase();

        Task SendEmailAsync(Guid userId, string subject, string body);

        Task SendSmsAsync(Guid userId, string message);

        Task<IdentityResult> SetEmailAsync(Guid userId, string email);

        Task<IdentityResult> SetLockoutEnabledAsync(Guid userId, bool enabled);

        Task<IdentityResult> SetLockoutEndDateAsync(Guid userId, DateTimeOffset lockoutEnd);

        Task<IdentityResult> SetPhoneNumberAsync(Guid userId, string phoneNumber);

        Task<IdentityResult> SetTwoFactorEnabledAsync(Guid userId, bool enabled);

        Task<IdentityResult> UpdateAsync(User user);

        Task<IdentityResult> UpdateSecurityStampAsync(Guid userId);

        Task<bool> VerifyChangePhoneNumberTokenAsync(Guid userId, string token, string phoneNumber);

        Task<bool> VerifyTwoFactorTokenAsync(Guid userId, string twoFactorProvider, string token);

        Task<bool> VerifyUserTokenAsync(Guid userId, string purpose, string token);

        #endregion Public Methods

        Task<string> GenerateUserNameAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        Task<IList<string>> GetPhoneNumbersByUserIdsAsync(IList<Guid?> userIds);

        Task CreateUserMetaByViewModelAsync(UserCreateViewModel viewModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<IList<User>> GetUsersByRoleIdAsync(Guid roleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Address> GetAddressByIdAsync(Guid userId);

        Task<bool> IsExistByEmailCancellationTokenAsync(string email,  CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> IsEmailConfirmedByEmailAsync(string email,HttpContext httpContext, CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> IsExistByIdCancellationTokenAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> IsBanByIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<bool> IsExistByUserNameCancellationTokenAsync(string userName, CancellationToken cancellationToken);
        Task<bool> IsExistByEmailAndPasswordAsync(string email, string password, CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> IsBanByEmailAsync(string email, CancellationToken cancellationToken);
        Task<bool> IsLockedOutAsync(string email, CancellationToken cancellationToken);
    }
}