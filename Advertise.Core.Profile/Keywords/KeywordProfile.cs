using Advertise.Core.Domains.Keywords;
using Advertise.Core.Models.Keyword;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Keywords
{
    public class KeywordProfile : BaseProfile
    {
        #region Public Constructors

        public KeywordProfile()
        {
            CreateMap<Keyword, KeywordViewModel>(MemberList.None).ReverseMap();

            CreateMap<Keyword, KeywordCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<Keyword, KeywordEditViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}