using Advertise.Core.Domains.Receipts;
using Advertise.Core.Models.Bag;
using Advertise.Core.Models.ReceiptOption;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.ReceiptOptions
{
    /// <summary>
    /// کلیه نگاشت ها برای محصولات فروخته شده
    /// </summary>
    public class ReceiptOptionProfile : BaseProfile
    {
        #region Public Constructors

        /// <summary>
        /// کلاس سازنده
        /// </summary>
        public ReceiptOptionProfile()
        {
            CreateMap<ReceiptOption, ReceiptOptionCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<ReceiptOption, ReceiptOptionListViewModel>(MemberList.None).ReverseMap();

            CreateMap<ReceiptOption, ReceiptOptionViewModel>(MemberList.None).ReverseMap();

            CreateMap<ReceiptOption, ReceiptOptionEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<ReceiptOption, ReceiptOptionDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<ReceiptOption, ReceiptOptionSearchRequest>(MemberList.None).ReverseMap();

            CreateMap<ReceiptOption, BagListViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}