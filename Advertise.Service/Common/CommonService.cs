using Advertise.Service.Services.WebContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Models.Common;

namespace Advertise.Service.Services.Common
{

    public class CommonService : ICommonService
    {
        #region Private Fields

        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="webContextManager"></param>
        public CommonService(IWebContextManager webContextManager)
        {
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Guid?> GetUserIdAsync(bool isCurrentUser, Guid? userId)
        {
            if (isCurrentUser)
                return _webContextManager.CurrentUserId;

            return userId;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int RandomNumberByCount(int min, int max)
        {
            var random = new Random().Next(min, max);
            return random;
        }

       

        #endregion Public Methods
    }
}