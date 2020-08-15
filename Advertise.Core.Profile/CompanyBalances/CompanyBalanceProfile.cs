using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyBalance;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanyBalances
{
    public class CompanyBalanceProfile : BaseProfile
    {
        #region Public Constructors

        public CompanyBalanceProfile()
        {
            CreateMap<CompanyBalance, CompanyBalanceViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyBalance, CompanyBalanceCreateViewModel>(MemberList.None).ReverseMap();
            CreateMap<CompanyBalance, CompanyBalanceListViewModel>(MemberList.None).ReverseMap();
            CreateMap<CompanyBalance, CompanyBalanceEditViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}