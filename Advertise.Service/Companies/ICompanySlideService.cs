using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Categories;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.Category;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanySlide;
using Advertise.Core.Objects;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanySlideService
    {
        #region Public Methods
        

        #endregion Public Methods


        Task CreateByViewModelAsync(CompanySlideCreateViewModel viewModel);
        Task EditByViewModelAsync(CompanySlideEditViewModel viewModel);
        Task<CompanySlide> FindByIdAsync(Guid companySlideId);
        Task DeleteByIdAsync(Guid companySlideId);
        IQueryable<CompanySlide> QueryByRequest(CompanySlideSearchRequest request);
        Task<IList<CompanySlide>> GetByRequestAsync(CompanySlideSearchRequest request);
        Task<int> CountByRequestAsync(CompanySlideSearchRequest request);
        Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid companySlideId);
    }
}