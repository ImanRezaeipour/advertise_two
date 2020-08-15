using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyConversation;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyConversationService {

        Task<int> CountByRequestAsync(CompanyConversationSearchRequest request);


        Task  CreateByViewModelAsync(CompanyConversationCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="conversationId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid conversationId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="conversationId"></param>
        /// <returns></returns>
        Task<CompanyConversation> FindByIdAsync(Guid conversationId);


        Task<IList<CompanyConversation>> GetByRequestAsync(CompanyConversationSearchRequest request);


        Task  SeedAsync();


        Task  EditByViewModelAsync(CompanyConversationEditViewModel viewModel);

        Task<List<CompanyConversationViewModel>> GetListByUserIdAsync(Guid userId);
        Task<List<SelectListItem>> GetUsersAsSelectListAsync();


       IQueryable<CompanyConversation> QueryByRequest(CompanyConversationSearchRequest request);
    }
}