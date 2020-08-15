using Advertise.Core.Domains.Categories;
using Advertise.Core.Domains.Products;
using Advertise.Core.Events;
using Advertise.Service.Services.Communications;
using Advertise.Service.Services.Products;
using Advertise.Service.Services.Users;
using System;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Domains.Users;
using Advertise.Service.Managers.Events;
using Advertise.Service.Services.WebContext;
using Microsoft.AspNet.Identity;

namespace Advertise.Service.Events
{

    public class SmsEvents :
        IEventHandler<EntityInserted<Product>>,
        IEventHandler<EntityUpdated<Category>>,
        IEventHandler<EntityUpdated<Product>>,
        IEventHandler<EntityInserted<User>>
    {
        #region Private Fields

        private readonly IProductNotifyService _productNotifyService;
        private readonly IProductService _productService;
        private readonly ISmsService _smsService;
        private readonly IUserService _userService;
        private readonly IUserOperationServive _userOperationServive;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="smsService"></param>
        /// <param name="userService"></param>
        /// <param name="productNotifyService"></param>
        /// <param name="productService"></param>
        public SmsEvents(ISmsService smsService, IUserService userService, IProductNotifyService productNotifyService,
            IProductService productService, IUserOperationServive userOperationServive, IWebContextManager webContextManager)
        {
            _smsService = smsService;
            _userService = userService;
            _productNotifyService = productNotifyService;
            _productService = productService;
            _userOperationServive = userOperationServive;
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="eventMessage"></param>
        public async Task HandleEvent(EntityInserted<Product> eventMessage)
        {
            await _userService.SendSmsAsync(eventMessage.Entity.CreatedById.GetValueOrDefault(),
                $"محصول {eventMessage.Entity.Title} اضافه شد");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="eventMessage"></param>
        public async Task HandleEvent(EntityUpdated<Category> eventMessage)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="eventMessage"></param>
        /// <returns></returns>
        public async Task HandleEvent(EntityUpdated<Product> eventMessage)
        {
            await ChangeProductSellEventAsync(eventMessage);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="eventMessage"></param>
        /// <returns></returns>
        private async Task ChangeProductSellEventAsync(EntityUpdated<Product> eventMessage)
        {
            var originalProduct = await _productService.FindByIdAsync(eventMessage.Entity.Id);

            if (eventMessage.Entity.Sell != originalProduct.Sell)
            {
                var listenUsers = await _productNotifyService.GetUsersByProductIdAsync(eventMessage.Entity.Id);
                var phoneNumbers = await _userService.GetPhoneNumbersByUserIdsAsync(listenUsers);
                foreach (var phoneNumber in phoneNumbers)
                {
                    if (phoneNumber != null)
                    {
                        await _smsService.SendAsync(new IdentityMessage
                        {
                            Destination = phoneNumber,
                            Body =
                                $"کاربر گرامی محصول {originalProduct.Title} در حالت {originalProduct.Sell.ToString()} قرار گرفته است. نویناک"
                        });
                    }
                    //await _userService.SendSmsAsync(user.Value, $"کاربر گرامی محصول {originalProduct.Title} در حالت {originalProduct.Sell.ToString()} قرار گرفته است. نویناک");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventMessage"></param>
        /// <returns></returns>
        public async Task HandleEvent(EntityInserted<User> eventMessage)
        {
            await CreateUser(eventMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventMessage"></param>
        /// <returns></returns>
        private async  Task CreateUser(EntityInserted<User> eventMessage)
        {
            var user = await _userService.FindByIdAsync(eventMessage.Entity.Id);
            var userOperator = await _userOperationServive.FindByUserIdAsync(_webContextManager.CurrentUserId);
            var currentUser = await _userService.FindUserMetaByCurrentUserAsync();
                if (user.Company.MobileNumber != null)
            {
                await _smsService.SendAsync(new IdentityMessage
                {
                    Destination = user.Company.MobileNumber,
                    Body =$"{user.Meta.FirstName} {user.Meta.LastName} عزیز، پنل شما با نام کاربری {user.Email}به مبلغ {userOperator.Amount}ریال  ایجاد شد." +$"دامنه شما:{user.Company.Alias}.novinak.com "+ 
                          $"با تشکر نویناک"
                       
                });

            }
        }

        #endregion Private Methods
    }





}
 