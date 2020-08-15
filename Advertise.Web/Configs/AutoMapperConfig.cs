using Advertise.Core.Profiles.Categories;
using AutoMapper;
using System;
using System.Linq;

namespace Advertise.Web.Framework.Configs
{
    public class AutoMapperConfig
    {
        #region Public Methods

        public static void RegisterAutoMapper()
        {
            var profileAssembly = typeof(CategoryProfile).Assembly;
            var profiles = profileAssembly.GetTypes()
                .Where(t => typeof(Profile).IsAssignableFrom(t))
                .Select(t => (Profile)Activator.CreateInstance(t));

            Mapper.Initialize(expression =>
            {
                foreach (var profile in profiles)
                {
                    expression.AddProfile(profile);
                }
            });
        }

        #endregion Public Methods
    }
}