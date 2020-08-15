using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.CompanyImage;

namespace Advertise.Service.Factories.Companies
{
    public interface ICompanyImageFactory
    {

        Task<CompanyImageListViewModel> PrepareListViewModelAsync(CompanyImageSearchRequest request, bool isCurrentUser = false, Guid? userId = null);

        Task<CompanyImageEditViewModel> PrepareEditViewModelAsync(Guid companyImageId, bool applyCurrentUser = false, CompanyImageEditViewModel viewModelPrepare = null);
    }
}
