using Advertise.Core.Domains.Newses;
using Advertise.Core.Models.News;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Newses
{

    public class NewsProfile : BaseProfile
    {
        #region Public Constructors

        /// <summary>
        /// </summary>
        public NewsProfile()
        {
            CreateMap<News, NewsCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<News, NewsDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<News, NewsListViewModel>(MemberList.None).ReverseMap();

            CreateMap<News, NewsViewModel>(MemberList.None).ReverseMap();

            CreateMap<News, NewsSearchRequest>(MemberList.None).ReverseMap();

            CreateMap<NewsEditViewModel, News>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}