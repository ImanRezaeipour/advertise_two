using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Guarantees;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Guarantee;
using Advertise.Core.Objects;

namespace Advertise.Service.Services.Guarantees
{
    public interface IGuaranteeService
    {
        Task<int> CountByRequestAsync(GuaranteeSearchRequest request);
        Task CreateByViewModelAsync(GuaranteeCreateViewModel viewModel);
        Task DeleteByIdAsync(Guid id);
        Task EditByViewMoodelAsync(GuaranteeEditViewModel viewModel);
        Task<Guarantee> FindByIdAsync(Guid id);


        Task<IList<SelectListItem>> GetAsSelectListAsync();

        Task<IList<Guarantee>> GetByRequestAsync(GuaranteeSearchRequest request);
        IQueryable<Guarantee> QueryByRequest(GuaranteeSearchRequest request);
        Task<IList<Select2Object>> GetAsSelect2ObjectAsync();
    }
}