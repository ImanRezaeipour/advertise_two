using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyVideo;
using Advertise.Core.Objects;
using Advertise.Core.Types;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyVideoService
    {
        //Task<string> PrepareEditViewModelAsync(Guid idValue);
        Task<int> CountAllVideoByCompanyIdAsync(Guid companyId);

        Task<int> CountByRequestAsync(CompanyVideoSearchRequest request);

        Task  CreateByViewModelAsync(CompanyVideoCreateViewModel viewModel);

        Task  DeleteByIdAsync(Guid companyVideoId, bool isCurrentUser  =false);

        Task<IList<CompanyVideo>> GetApprovedByCompanyIdAsync(Guid companyId);

        Task<IList<CompanyVideo>> GetByRequestAsync(CompanyVideoSearchRequest request);


        Task<IList<FineUploaderObject>> GetFilesAsFineUploaderModelByIdAsync(Guid companyVideoId);

        Task  RemoveRangeAsync(IList<CompanyVideo> companyVideos);


        Task  EditApproveByViewModelAsync(CompanyVideoEditViewModel viewModel);

        Task  EditByViewModelAsync(CompanyVideoEditViewModel viewModel, bool isCurrentUser = false);
        Task  EditRejectByViewModelAsync(CompanyVideoEditViewModel viewModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IQueryable<CompanyVideo> QueryByRequest(CompanyVideoSearchRequest request);

        Task<CompanyVideo> FindByIdAsync(Guid? companyVideoId = null ,Guid? userId= null);
        Task SetStateByIdAsync(Guid companyVideoId, StateType state);
    }
}
