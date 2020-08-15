using System;
using System.Threading.Tasks;
using Advertise.Core.Domains.Users;
using Advertise.Core.Models.Account;
using Advertise.Core.Models.User;
using Advertise.Core.Models.UserOperator;
using Microsoft.AspNet.Identity.Owin;

namespace Advertise.Service.Services.Users
{
    public interface IAccountService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task ConfirmForgotPasswordAsync(ForgotPasswordViewModel viewModel);


        Task ConfirmPhoneNumberAsync(UserVerifyPhoneNumberViewModel viewModel);


        Task ConfirmResetPasswordAsync(ResetPasswordViewModel viewModel);

        Task SendForgotPasswordConfirmationTokenAsync(Guid userId);


        Task RegisterByEmailAsync(RegisterViewModel viewModel);

        Task RegisterEasyAsync(UserOperatorCreateViewModel viewModel);


        Task RegisterByExternalLinkAsync();


        Task RegisterByPhoneNumberAsync(UserAddPhoneNumberViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task SendEmailConfirmationTokenAsync(Guid userId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        Task SendPhoneNumberConfirmationTokenAsync(Guid userId, string phoneNumber);


        Task SignOutCurrentUserAsync();

        /// <summary>
        ///
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        Task ChangePasswordByCurrentUserAsync(string oldPassword, string newPassword);


        Task<SignInStatus> PasswordSignInAsync(LoginViewModel viewModel);

        Task SetCurrentUserPasswordAsync(string password);


        Task<SignInStatus> SignInByIdAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="auditUserId"></param>
        /// <returns></returns>
        Task UpdateAuditFieldsAsync(User user, Guid auditUserId);
    }
}