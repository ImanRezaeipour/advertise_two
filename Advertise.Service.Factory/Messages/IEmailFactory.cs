using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Email;

namespace Advertise.Service.Factories.Messages
{
    public interface IEmailFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<EmailListViewModel> PrepareListViewModelAsync(EmailSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
    }
}