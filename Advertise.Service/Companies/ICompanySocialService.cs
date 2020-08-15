using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanySocial;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanySocialService {

        Task  CreateByViewModelAsync(CompanySocialCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="socialId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid socialId);

        Task<CompanySocial> FindAsync(Guid companySocialId);
        Task<CompanySocial> FindByUserIdAsync(Guid userId);

        Task  RemoveRangeAsync(IList<CompanySocial> companySocials);


        Task  SeedAsync();


        Task  EditByViewModelAsync(CompanySocialEditViewModel viewModel, bool isCurrentUser = false);


        Task<IList<CompanySocial>> GetByRequestAsync(CompanySocialSearchRequest request);

        /// <returns></returns>
        Task<int> CountByRequestAsync(CompanySocialSearchRequest request);


      IQueryable<CompanySocial> QueryByRequest(CompanySocialSearchRequest request);
    }
}