using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyQuestion;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyQuestionService {


        Task  CreateByViewModelAsync(CompanyQuestionCreateViewModel viewModel);

        Task  RemoveRangeByCompanyId(Guid companyId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyQuestionId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid companyQuestionId);


        Task<CompanyQuestion> FindByIdAsync(Guid companyQuestionId);
        Task<IList<CompanyQuestion>> GetByCompanyIdAsync(Guid companyId);



        Task  ApproveByViewModelAsync(CompanyQuestionEditViewModel viewModel);


        Task  EditByViewModelAsync(CompanyQuestionEditViewModel viewModel);


        Task  RejectByViewModelAsync(CompanyQuestionEditViewModel viewModel);

        Task<int> CountByRequestAsync(CompanyQuestionSearchRequest request);


        Task<IList<CompanyQuestion>> GetByRequestAsync(CompanyQuestionSearchRequest request);


        IQueryable<CompanyQuestion> QueryByRequest(CompanyQuestionSearchRequest request);

        Task<IList<CompanyQuestion>> GetAllByCompanyIdAsync(Guid companyId);
    }
}