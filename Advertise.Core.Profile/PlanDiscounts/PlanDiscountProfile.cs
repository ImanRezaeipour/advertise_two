using Advertise.Core.Domains.Plans;
using Advertise.Core.Models.Plan;
using Advertise.Core.Models.PlanDiscount;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.PlanDiscounts
{

    public class PlanDiscountDiscountProfile : BaseProfile
    {
        #region Public Constructors

        /// <summary>
        /// </summary>
        public PlanDiscountDiscountProfile()
        {
            CreateMap<PlanDiscountCreateViewModel, PlanDiscount>(MemberList.None);

            CreateMap<PlanDiscountEditViewModel, PlanDiscount>(MemberList.None).ReverseMap();

            CreateMap<PlanDiscountListViewModel, PlanDiscount>(MemberList.None).ReverseMap();

            CreateMap<PlanDiscountViewModel, PlanDiscount>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}