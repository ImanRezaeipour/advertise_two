namespace Advertise.Service.Managers.Localization
{
    /// <summary>
    /// 
    /// </summary>
    public class ResourceService : IResourceService
    {
        #region Public Methods

        /// <summary>
        /// Get a localized resources
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public string L(string resource, string culture = null)
        {
            return ResourceExtensions.GetLocalize(resource, culture);
        }

        /// <summary>
        /// Get a localized resources
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public string Lang(string resource, string culture = null)
        {
            return ResourceExtensions.GetLocalize(resource, culture);
        }

        #endregion Public Methods
    }
}