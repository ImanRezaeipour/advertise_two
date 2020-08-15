using Advertise.Core.Constants;
using Advertise.Core.Models.Account;
using Advertise.Core.Models.User;
using Advertise.Core.Models.UserOperator;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Users;
using Advertise.Service.Validators.Accounts;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using Microsoft.AspNet.Identity.Owin;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Service.Factories.Accounts;

namespace Advertise.Web.Controllers
{

    public partial class AccountController : BaseController
    {
        #region Private Fields

        private readonly IAccountFactory _accountFactory;
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        #endregion Private Fields

        #region Public Constructors


        public AccountController(IUserService userManager, IAccountService accountService, IAccountFactory accountFactory)
        {
            _userService = userManager;
            _accountService = accountService;
            _accountFactory = accountFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "تغییر پسورد", Key = "Profile_User_CanChangePassword")]
        [MvcAuthorize(PermissionConst.CanAccountChangePassword)]
        public virtual async Task<ActionResult> ChangePassword()
        {
            return View(MVC.User.Views.ChangePassword);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [MvcAuthorize(PermissionConst.CanAccountChangePassword)]
        public virtual async Task<ActionResult> ChangePassword(UserChangePasswordViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            if (!ModelState.IsValid)
                return View(MVC.User.Views.ChangePassword, viewModel);

            await _accountService.ChangePasswordByCurrentUserAsync(viewModel.OldPassword, viewModel.NewPassword);
            return RedirectToAction(MVC.Account.SignOut());
        }

        public virtual async Task<ActionResult> ConfirmationEmail(Guid? id, string code)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            if (code == null)
                return View(MVC.Error.Views.BadRequest);

            var result = await _userService.ConfirmEmailAsync(id.Value, code.Base64ForUrlDecode());
            return View(result.Succeeded ? MVC.Account.Views.EmailConfirmed : MVC.Error.Views.InternalServerError);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> ConfirmationForgotPassword(ForgotPasswordViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _accountService.ConfirmForgotPasswordAsync(viewModel);
            return RedirectToAction(MVC.Account.ForgotPasswordConfirmed());
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> ConfirmationPhoneNumber(UserVerifyPhoneNumberViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _accountService.ConfirmPhoneNumberAsync(viewModel);
            return View(MVC.Account.Views.PhoneNumberConfirmed);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> ConfirmationResetPassword(ResetPasswordViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

           
            await _accountService.ConfirmResetPasswordAsync(viewModel);
            return View(MVC.Account.Views.ResetPasswordConfirmed);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [MvcAuthorize(PermissionConst.CanUserEasyRegister)]
        public virtual async Task<ActionResult> EasyRegister(UserOperatorCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _accountService.RegisterEasyAsync(viewModel);
            this.MessageSuccess("ثبت نام انجام شد");
            return RedirectToAction(MVC.Account.EasyRegister());
        }


      
        public virtual async Task<ActionResult> EmailConfirm()
        {
            return View(MVC.Account.Views.EmailConfirm);
        }

     
        public virtual async Task<ActionResult> EmailConfirmed()
        {
            return View(MVC.Account.Views.EmailConfirmed);
        }

   
        [ImportModelData(typeof(RegisterViewModel))]
        public virtual async Task<ActionResult> EmailRegister()
        {
            return View(MVC.Account.Views.EmailRegister);
        }

     
        public virtual async Task<ActionResult> ExternalLogin(string provider, string returnUrl)
        {
            return new ChallengeResult("Google", Url.Action(MVC.Account.ExternalLoginCallback(returnUrl)));
        }

       
        public virtual async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            await _accountService.RegisterByExternalLinkAsync();
            return Url.IsLocalUrl(returnUrl) ? RedirectToAction(returnUrl) : RedirectToAction(MVC.Home.LandingPage());
        }


        public virtual async Task<ActionResult> ExternalLoginConfirmation()
        {
            throw new NotImplementedException();
        }

      
        public virtual async Task<ActionResult> ForgotPasswordConfirm()
        {
            return View(MVC.Account.Views.ForgotPasswordConfirm);
        }

      
        public virtual async Task<ActionResult> ForgotPasswordConfirmed()
        {
            return View(MVC.Account.Views.ForgotPasswordConfirmed);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [MvcAuthorize(PermissionConst.CanAccountIsExistEmailAjax)]
        public virtual async Task<JsonResult> IsExistEmailAjax(string email, Guid? id)
        {
            if (email == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var isEmailExist = await _userService.IsExistByEmailAsync(email, id);
            switch (isEmailExist)
            {
                case true:
                    return Json(AjaxResult.Succeeded(true), JsonRequestBehavior.AllowGet);

                case false:
                    return Json(AjaxResult.Succeeded(false), JsonRequestBehavior.AllowGet);

                default:
                    return Json(AjaxResult.Failed(AjaxErrorStatus.InternalServerError), JsonRequestBehavior.AllowGet);
            }
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [MvcAuthorize(PermissionConst.CanAccountIsExistUserNameAjax)]
        public virtual async Task<JsonResult> IsExistUserNameAjax(string userName, Guid? id)
        {
            if (userName == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var countEmailExist = await _userService.IsExistByUserNameAsync(userName, id);
            bool isEmailExist;
            if (countEmailExist == 1)
                isEmailExist = true;
            else
            isEmailExist = false;
           
            switch (isEmailExist)
            {
                case true:
                    return Json(AjaxResult.Succeeded(true), JsonRequestBehavior.AllowGet);

                case false:
                    return Json(AjaxResult.Succeeded(true), JsonRequestBehavior.AllowGet);

                default:
                    return Json(AjaxResult.Failed(AjaxErrorStatus.InternalServerError), JsonRequestBehavior.AllowGet);
            }
        }


        public virtual async Task<ActionResult> Lockout()
        {
            return View(MVC.Account.Views.Lockout);
        }

     
        [ImportModelData(typeof(LoginViewModel))]
        public virtual async Task<ActionResult> Login(string returnUrl)
        {
            if (HttpContext.Request.IsAuthenticated)
                return RedirectToAction(MVC.Profile.Dashboard());

            ViewBag.ReturnUrl = returnUrl;
            return View(MVC.Account.Views.Login);
        }

     
        [HttpPost]
        public virtual async Task<ActionResult> Login(string returnUrl, LoginViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            
            var result = await _accountService.PasswordSignInAsync(viewModel);
            switch (result)
            {
                case SignInStatus.Success:
                    if (Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return RedirectToAction(MVC.Profile.Dashboard());

                case SignInStatus.LockedOut:
                    ModelState.AddModelError("UserName", $@"دقیقه دوباره امتحان کنید {_userService.DefaultAccountLockoutTimeSpan} حساب شما قفل شد ! لطفا بعد از ");
                    return View(MVC.Account.Views.Login, viewModel);

                case SignInStatus.Failure:
                    ModelState.AddModelError("UserName", @"نام کاربری یا کلمه عبور  صحیح نمی باشد");
                    return View(MVC.Account.Views.Login, viewModel);

                case SignInStatus.RequiresVerification:

                    ModelState.AddModelError("UserName", @"می بایست ابتدا حساب کاربری خود را تایید نمایید");
                    return View(MVC.Account.Views.Login, viewModel);

                default:
                    ModelState.AddModelError("UserName", @"در این لحظه امکان ورود به  سابت وجود ندارد . مراتب را با مسئولان سایت در میان بگذارید");
                    return View(MVC.Account.Views.Login, viewModel);
            }
        }

       
        [ImportModelData(typeof(UserVerifyPhoneNumberViewModel))]
        public virtual async Task<ActionResult> PhoneNumberConfirm(Guid? id, string phoneNumber)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            if (phoneNumber == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = new UserVerifyPhoneNumberViewModel
            {
                UserId = id.Value,
                PhoneNumber = phoneNumber
            };
            return View(MVC.Account.Views.PhoneNumberConfirm, viewModel);
        }


        public virtual async Task<ActionResult> PhoneNumberConfirmed()
        {
            return View(MVC.Account.Views.PhoneNumberConfirmed);
        }

     
        [AllowAnonymous]
        public virtual async Task<ActionResult> PhoneNumberRegister()
        {
            return View(MVC.Account.Views.PhoneNumberRegister);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [ValidateCaptcha]
        public virtual async Task<ActionResult> RegisterByEmail(RegisterViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _accountService.RegisterByEmailAsync(viewModel);
            return View(MVC.Account.Views.EmailConfirm);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> RegisterByPhoneNumber(UserAddPhoneNumberViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _accountService.RegisterByPhoneNumberAsync(viewModel);
            return View(MVC.Account.Views.PhoneNumberConfirm);
        }

     
        /// <returns></returns>
        public virtual async Task<ActionResult> ResetPasswordConfirm(ResetPasswordViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

           
            return View(MVC.Account.Views.ResetPasswordConfirm, viewModel);
        }

      
        public virtual async Task<ActionResult> ResetPasswordConfirmed()
        {
            return View(MVC.Account.Views.ResetPasswordConfirmed);
        }


      

      

    
        [MvcAuthorize(PermissionConst.CanAccountSignOut)]
        public virtual async Task<ActionResult> SignOut()
        {
            await _accountService.SignOutCurrentUserAsync();
            return RedirectToAction(MVC.Home.LandingPage());
        }

        #endregion Public Methods
    }
}