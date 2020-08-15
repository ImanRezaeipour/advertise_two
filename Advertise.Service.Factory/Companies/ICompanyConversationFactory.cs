using System;
using System.Threading.Tasks;
using Advertise.Core.Models.CompanyConversation;

namespace Advertise.Service.Factories.Companies
{
    public interface ICompanyConversationFactory
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<CompanyConversationListViewModel> PrepareListViewModelAsync(CompanyConversationSearchRequest request, bool isCurrentUser = false, Guid? userId = null);

        /// <summary>
        ///
        /// </summary>
        /// <param name="conversationId"></param>
        /// <returns></returns>
        Task<CompanyConversationEditViewModel> PrepareEditViewModelAsync(Guid conversationId);
    }
}