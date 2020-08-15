using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Models.CatalogImage;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CatalogImages
{
    public class CatalogImageProfile : BaseProfile
    {
        #region Public Constructors

        public CatalogImageProfile()
        {
            CreateMap<CatalogImage, CatalogImageViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}