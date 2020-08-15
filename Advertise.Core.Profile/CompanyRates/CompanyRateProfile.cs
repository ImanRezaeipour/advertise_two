using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyRate;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanyRates
{
    public class CompanyRateProfile : BaseProfile
    {
        #region Public Constructors

        public CompanyRateProfile()
        {
            CreateMap<CompanyRate, CompanyRateViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}