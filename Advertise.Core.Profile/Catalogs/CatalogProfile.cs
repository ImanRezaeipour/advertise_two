using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Models.Catalog;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Catalogs
{

    public class CatalogProfile : BaseProfile
    {
        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        public CatalogProfile()
        {
            CreateMap<Catalog, CatalogCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<Catalog, CatalogEditViewModel>(MemberList.None);
               

            CreateMap<CatalogEditViewModel, Catalog>(MemberList.None)
                .ForMember(dest => dest.Code, opt => opt.Ignore());

            CreateMap<Catalog, CatalogExportViewModel>(MemberList.None).ReverseMap();

            CreateMap<CatalogCreateViewModel, CatalogExportViewModel>(MemberList.None).ReverseMap();

            CreateMap<CatalogEditViewModel, CatalogExportViewModel>(MemberList.None).ReverseMap();

            CreateMap<Catalog, CatalogViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}