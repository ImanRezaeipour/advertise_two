using Advertise.Core.Domains.Notifications;
using Advertise.Core.Models.Notification;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Notifications
{

    public class NotificationProfile : BaseProfile
    {
        #region Public Constructors

        /// <summary>
        /// </summary>
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationListViewModel>(MemberList.None).ReverseMap();

            CreateMap<Notification, NotificationCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<Notification, NotificationViewModel>(MemberList.None)
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Target.Code));
        }

        #endregion Public Constructors
    }
}