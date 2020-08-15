using Advertise.Core.Domains.Newsletters;
using Advertise.Core.Models.Newsletter;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Newsletters
{
    public class NewsletterProfile : BaseProfile
    {
        #region Public Constructors

        public NewsletterProfile()
        {
            CreateMap<NewsletterCreateViewModel, Newsletter>(MemberList.None).ReverseMap();

            CreateMap<Newsletter, NewsletterViewModel>(MemberList.None).ReverseMap();

            CreateMap<Newsletter, NewsletterListViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}