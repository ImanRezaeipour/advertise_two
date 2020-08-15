using Advertise.Core.Domains.Guarantees;
using Advertise.Core.Models.Guarantee;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Guarantees
{
    public class GuaranteeProfile : BaseProfile
    {
        #region Public Constructors

        public GuaranteeProfile()
        {
            CreateMap<Guarantee, GuaranteeCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<Guarantee, GuaranteeEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<GuaranteeViewModel, Guarantee>(MemberList.None).ReverseMap();

            CreateMap<Guarantee, GuaranteeListViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}