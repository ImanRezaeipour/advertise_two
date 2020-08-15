using Advertise.Core.Domains.Smses;
using Advertise.Core.Models.SmsOperator;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.SmsOperators
{
    public class SmsOperatorProfile : BaseProfile
    {
        #region Public Constructors

        public SmsOperatorProfile()
        {
            CreateMap<SmsOperator, SmsOperatorViewModel>(MemberList.None).ReverseMap();

            CreateMap<SmsOperator, SmsOperatorCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<SmsOperator, SmsOperatorEditViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}