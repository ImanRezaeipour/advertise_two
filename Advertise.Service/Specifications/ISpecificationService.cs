using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Specifications;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Specification;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Specifications
{
    public interface ISpecificationService {


        Task  CreateByViewModelAsync(SpecificationCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="specificationId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid specificationId);

        Task<Specification> FindByIdAsync(Guid specificationId);

        /// <summary>
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<IList<SelectListItem>> GetAsSelectListItemAsync(Guid categoryId);

        /// <summary>
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<object> GetObjectByCategoryAsync(Guid categoryId);


        Task  EditByViewModelAsync(SpecificationEditViewModel viewModel);

        Task<IList<Specification>> GetByCategoryIdAsync(Guid categoryId);


        Task<IList<Specification>> GetByRequestAsync(SpecificationSearchRequest request);

        Task<int> CountByRequestAsync(SpecificationSearchRequest request);


        Task<IQueryable<Specification>> QueryByRequest(SpecificationSearchRequest request);

        Task<IList<SpecificationViewModel>> GetViewModelByCategoryAliasAsync(string categoryId);
        Guid? GetIdByTitle(string specificationTitle, Guid categoryId );
        Task<List<string>> GetTitlesAsync();
    }
}