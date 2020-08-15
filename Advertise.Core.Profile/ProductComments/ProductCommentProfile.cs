using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductComment;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.ProductComments
{

    public class ProductCommentProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public ProductCommentProfile()
        {
            CreateMap<ProductComment, ProductCommentViewModel>(MemberList.None)
                .ForMember(dest => dest.UserUserName, opts => opts.MapFrom(src => src.CommentedBy.UserName))
                .ForMember(dest => dest.UserAvatar, opts => opts.MapFrom(src => src.CommentedBy.Meta.AvatarFileName))
                .ForMember(dest => dest.ProductTitle, opts => opts.MapFrom(src => src.Product.Title))
                .ForMember(dest => dest.ProductCode, opts => opts.MapFrom(src => src.Product.Code))
                .ForMember(dest => dest.ProductImageFileName, opts => opts.MapFrom(src => src.Product.ImageFileName))
                .ForMember(dest => dest.UserFullName, opts => opts.MapFrom(src => src.CommentedBy.Meta.FullName));

             CreateMap<ProductComment, ProductCommentCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductCommentEditViewModel, ProductComment>(MemberList.None)
                .ForMember(dest => dest.ProductId,opt =>opt.Ignore());

            CreateMap<ProductComment, ProductCommentEditViewModel>(MemberList.None);

            CreateMap<ProductComment, ProductCommentDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductComment, ProductCommentListViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductComment, ProductCommentSearchRequest>(MemberList.None).ReverseMap();
        }
    }
}