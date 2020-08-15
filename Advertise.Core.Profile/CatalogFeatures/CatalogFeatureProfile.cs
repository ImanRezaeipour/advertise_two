using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Models.CatalogFeature;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CatalogFeatures
{
    public class CatalogFeatureProfile : BaseProfile
    {
        #region Public Constructors

        public CatalogFeatureProfile()
        {
            CreateMap<CatalogFeature, CatalogFeatureViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}