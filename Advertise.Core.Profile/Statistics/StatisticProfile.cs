using Advertise.Core.Domains.Statistics;
using Advertise.Core.Models.Statistic;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Statistics
{
    public class StatisticProfile : BaseProfile
    {
        public StatisticProfile()
        {
            CreateMap<Statistic, StatisticCreateViewModel>(MemberList.None).ReverseMap();
        }
    }
}
