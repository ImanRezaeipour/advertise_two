using Advertise.Core.Infrastructure.DependencyManagement;
using Advertise.Core.Models.SeoSetting;
using Advertise.Core.Models.Setting;
using Advertise.Service.Managers.Localization;
using Advertise.Service.Services.Seo;
using Advertise.Service.Services.Settings;

namespace Advertise.Web.Framework.ViewEngines.Razor
{
    /// <summary>
    /// Web view page
    /// </summary>
    public abstract class WebViewPage : WebViewPage<dynamic>
    {
    }

    /// <summary>
    /// Web view page
    /// </summary>
    /// <typeparam name="TModel">Model</typeparam>
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
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

        /// <summary>
        /// 
        /// </summary>
        public SeoSettingViewModel SeoSetting
        {
            get
            {
                var service = ContainerManager.Container.GetInstance<ISeoSettingService>();
                var viewModel = service.GetFirst();
                return viewModel;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SettingViewModel Setting
        {
            get
            {
                var service = ContainerManager.Container.GetInstance<ISettingService>();
                var viewModel = service.GetFirst();
                return viewModel;
            }
        }

        #endregion Public Methods
    }
}