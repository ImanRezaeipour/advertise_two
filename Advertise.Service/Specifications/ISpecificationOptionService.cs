using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Specifications;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.SpecificationOption;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Specifications
{
    public interface ISpecificationOptionService {

        Task  CreateByViewModelAsync(SpecificationOptionCreateViewModel viewModel);


        /// <summary>
        ///
        /// </summary>
        /// <param name="specificationOptionId"></param>
        /// <returns></returns>
        Task<SpecificationOption> FindWithCategoryAsync(Guid specificationOptionId);

        /// <summary>
        /// </summary>
        /// <param name="specificationOptionId"></param>
        /// <returns></returns>
        Task<SpecificationOption> FindByIdAsync(Guid specificationOptionId);


        /// <summary>
        ///
        /// </summary>
        /// <param name="specificationOptionId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid specificationOptionId);

        /// <summary>
        /// </summary>
        /// <param name="specificationId"></param>
        /// <returns></returns>
        Task<IList<SpecificationOption>> GetSpecificationOptionsBySpecificationIdAsync(Guid specificationId);

        /// <summary>
        /// </summary>
        /// <param name="specificationId"></param>
        /// <returns></returns>
        Task<IList<SpecificationOptionViewModel>> GetViewModelBySpecificationIdAsync(Guid specificationId);


        Task  EditByViewModelAsync(SpecificationOptionEditViewModel viewModel);


        Task  SeedAsync();


        Task<IList<SpecificationOption>> GetByRequestAsync(SpecificationOptionSearchRequest request);

        Task<int> CountByRequestAsync(SpecificationOptionSearchRequest request);


        IQueryable<SpecificationOption> QueryByRequest(SpecificationOptionSearchRequest request);

        Task<IList<SelectListItem>> GetAsSelectListBySpecificationIdAsync(Guid specificationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specificationOptionTitle"></param>
        /// <param name="specificationId"></param>
        /// <returns></returns>
        Task<Guid?> GetIdByTitleAsync(string specificationOptionTitle, Guid specificationId);

        Guid? GetIdByTitle(string specificationOptionTitle, Guid specificationId);
    }
}