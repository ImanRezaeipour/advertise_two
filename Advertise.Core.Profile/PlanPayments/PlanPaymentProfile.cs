using Advertise.Core.Domains.Plans;
using Advertise.Core.Models.PlanPayment;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.PlanPayments
{

    public class PlanPaymentProfile : BaseProfile
    {
        #region Public Constructors

        /// <summary>
        /// </summary>
        public PlanPaymentProfile()
        {
            CreateMap<PlanPyamentCreateViewModel, PlanPayment>(MemberList.None).ReverseMap();

            CreateMap<PlanPaymentCallbackViewModel, PlanPayment>(MemberList.None).ReverseMap();

            CreateMap<PlanPayment , PlanPaymentViewModel >(MemberList.None)
                .ForMember(dest => dest.PlanTitle, opt=>opt.MapFrom(surc =>surc.Plan.Title));
            CreateMap<PlanPaymentViewModel, PlanPayment>(MemberList.None);
            CreateMap<PlanPaymentListViewModel, PlanPayment>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}