using Advertise.Core.Domains.Plans;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Plan;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Plans
{

    public class PlanProfile : BaseProfile
    {
        #region Public Constructors

        /// <summary>
        /// </summary>
        public PlanProfile()
        {
            CreateMap<PlanCreateViewModel, Plan>(MemberList.None);

            CreateMap<PlanEditViewModel, Plan>(MemberList.None).ReverseMap();

            CreateMap<PlanListViewModel, Plan>(MemberList.None).ReverseMap();

            CreateMap<PlanViewModel, Plan>(MemberList.None).ReverseMap();
            CreateMap<SelectListItem, Plan>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}