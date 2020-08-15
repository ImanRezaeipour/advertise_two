using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductRate;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.ProductRates
{
    public class ProductRateProfile : BaseProfile
    {
        #region Public Constructors

        public ProductRateProfile()
        {
            CreateMap<ProductRate, ProductRateViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductRate, ProductRateCreateViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}