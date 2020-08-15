using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductKeyword;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.ProductKeywords
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductKeywordProfile : BaseProfile
    {
        #region Public Constructors

        public ProductKeywordProfile()
        {
            CreateMap<ProductKeyword, ProductKeywordViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductKeyword, ProductKeywordCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductKeyword, ProductKeywordEditViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}