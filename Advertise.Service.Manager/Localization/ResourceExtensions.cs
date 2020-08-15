using System.Globalization;

namespace Advertise.Service.Managers.Localization
{
    /// <summary>
    /// 
    /// </summary>
    public static class ResourceExtensions
    {
        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string GetLocalize(string resource, string culture = null)
        {
            if (culture == null)
                return Core.Languages.Admin.ResourceManager.GetObject(resource, Core.Languages.Admin.Culture) as string;

            var cultureInfo = new CultureInfo(culture);
            return Core.Languages.Admin.ResourceManager.GetObject(resource, cultureInfo) as string;
        }

        #endregion Public Methods
    }
}