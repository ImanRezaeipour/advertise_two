using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Models.Company;
using Advertise.Core.Models.Home;

namespace Advertise.Service.Factories.Home
{
    public interface IHomeFactory
    {
        Task<PanelBoardViewModel> PrepareDashBoardViewModelAsync(Guid userId);
        Task<PanelBoardViewModel> PrepareDashBoardViewModelAsync();


        Task<LandingPageViewModel> PrepareLandingPageViewModelAsync();
        Task<ProfileViewModel> PrepareProfileViewModelAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listCompany"></param>
        /// <returns></returns>
        Task PrepareCompanyViewModelAsync(IList<CompanyViewModel> listCompany);
    }
}