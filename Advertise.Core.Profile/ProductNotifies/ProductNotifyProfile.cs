using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductNotify;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.ProductNotifies
{
    public class ProductNotifyProfile : BaseProfile
    {
        #region Public Constructors

        public ProductNotifyProfile()
        {
            CreateMap<ProductNotify, ProductNotifyViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}