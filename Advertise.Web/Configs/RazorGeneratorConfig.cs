using System.Reflection;
using RazorGenerator.Mvc;
using System.Web.WebPages;

//[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(RazorGeneratorConfig), "RegisterRazorGenerator")]

namespace Advertise.Web.Framework.Configs
{
    /// <summary>
    ///
    /// </summary>
    public static class RazorGeneratorConfig
    {
        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        public static void RegisterRazorGenerator()
        {
            // todo: typeof(RazorGeneratorConfig).Assembly
            var engine = new PrecompiledMvcEngine(Assembly.Load("Advertise.Web"))
            {
                UsePhysicalViewsIfNewer = false// HttpContext.Current.Request.IsLocal
            };

            System.Web.Mvc.ViewEngines.Engines.Insert(0, engine);

            // StartPage lookups are done by WebPages.
            VirtualPathFactoryManager.RegisterVirtualPathFactory(engine);
        }

        #endregion Public Methods
    }
}