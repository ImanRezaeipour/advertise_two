//using Advertise.Core.TypeConverters;
using AutoMapper;
using System;

namespace Advertise.Core.Profiles.Common
{
    public class TypeConverterProfile : BaseProfile
    {
        #region Public Constructors

        public TypeConverterProfile()
        {
            //CreateMap<DateTime, string>().ConvertUsing(new DateTimeTypeConverter());

            //CreateMap<DateTime?, DateTime?>().ConvertUsing(new NullableDateTimeTypeConverter());

            CreateMap<DateTime?, DateTime?>().ProjectUsing(source => source ?? new DateTime(1989, 1, 15));
        }

        #endregion Public Constructors
    }
}