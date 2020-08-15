using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Domains.Users;
using Advertise.Core.Models.UserOperator;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.UserOperators
{
    public class UserOperatorProfile :BaseProfile
    {
        public UserOperatorProfile()
        {
            CreateMap<UserOperator, UserOperatorSearchRequest>(MemberList.None).ReverseMap();
            CreateMap<UserOperator, UserOperatorListViewModel>(MemberList.None).ReverseMap();
            CreateMap<UserOperator, UserOperatorCreateViewModel>(MemberList.None).ReverseMap();
            CreateMap<UserOperator, UserOperatorViewModel>(MemberList.None).ReverseMap();
        }
    }
}
