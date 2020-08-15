using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Models.CatalogKeyword;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CatalogKeywords
{
    public class CatalogKeywordProfile : BaseProfile
    {
        #region Public Constructors

        public CatalogKeywordProfile()
        {
            CreateMap<CatalogKeyword, CatalogKeywordViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}