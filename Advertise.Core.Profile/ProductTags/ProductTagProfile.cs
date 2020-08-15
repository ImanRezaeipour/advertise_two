using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductTag;
using Advertise.Core.Models.Tag;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.ProductTags
{

    public class ProductTagProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public ProductTagProfile()
        {
            CreateMap<ProductTag, ProductTagEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductTag, ProductTagListViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductTag, ProductTagCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductTag, ProductTagViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductTag, TagViewModel>(MemberList.None).ReverseMap();
        }
    }
}