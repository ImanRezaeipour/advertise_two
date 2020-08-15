using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Domains.Settings;
using Advertise.Core.Models.Common;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.SettingTransactions
{
    public class SettingTransactionProfile :BaseProfile
    {
        public SettingTransactionProfile()
        {
            CreateMap<SettingTransaction, SelectListItem>(MemberList.None)
                .ForMember(dest => dest.Text, opts => opts.MapFrom(src => src.BankName))
                .ForMember(dest => dest.Value, opts => opts.MapFrom(src => src.Id));
        }
    }
}
