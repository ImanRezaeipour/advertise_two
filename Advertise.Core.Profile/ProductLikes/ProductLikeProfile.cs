using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductLike;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.ProductLikes
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductLikeProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public ProductLikeProfile()
        {
            CreateMap<ProductLike, ProductLikeEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductLike, ProductLikeCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductLike, ProductLikeViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductLike, ProductLikeListViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductLike, ProductLikeSearchRequest>(MemberList.None).ReverseMap();
        }
    }
}