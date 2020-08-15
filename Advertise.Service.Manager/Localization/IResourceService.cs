namespace Advertise.Service.Managers.Localization
{
    public interface IResourceService
    {
        /// <summary>
        /// Get a localized resources
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        string L(string resource, string culture = null);

        /// <summary>
        /// Get a localized resources
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        string Lang(string resource, string culture = null);
    }
}
