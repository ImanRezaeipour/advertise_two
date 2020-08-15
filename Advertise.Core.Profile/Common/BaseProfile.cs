using AutoMapper;

namespace Advertise.Core.Profiles.Common
{
    public class BaseProfile : Profile
    {
        #region Protected Constructors


        #endregion Protected Constructors

        #region Public Properties

        public override string ProfileName => GetType().Name;

        #endregion Public Properties
    }
}