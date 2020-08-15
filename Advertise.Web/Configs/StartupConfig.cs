using Advertise.Web.Framework.StructureMap;
using StructureMap.Web.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Advertise.Core.Infrastructure.DependencyManagement;
using Advertise.Core.Models.UserOnline;
using Advertise.Service.Managers.Transaction;
using Advertise.Service.Services.Users;

namespace Advertise.Web.Framework.Configs
{

    public class StartupConfig
    {


        #region Public Methods

        public static void ApplicationBeginRequest()
        {
            foreach (var task in ContainerManager.Container.GetAllInstances<IRunOnEachRequest>())
            {
                task.Execute();
            }
        }

        public static void ApplicationEndRequest()
        {
            try
            {
                foreach (var task in ContainerManager.Container.GetAllInstances<IRunAfterEachRequest>())
                {
                    task.Execute();
                }
            }
            catch (Exception)
            {
                HttpContextLifecycle.DisposeAndClearAll();
            }
        }

        public static void ApplicationError()
        {
            foreach (var task in ContainerManager.Container.GetAllInstances<IRunOnError>())
            {
                task.Execute();
            }
        }

        public static void ApplicationInit()
        {
            foreach (var task in ContainerManager.Container.GetAllInstances<IRunAtInit>())
            {
                task.Execute();
            }
        }

        public static void ApplicationStart()
        {
            try
            {
                StructureMapConfig.RegisterStructureMap();
                MvcConfig.RegisterMvc();
                //EntityFrameworkProfilerConfig.RegisterEntityFrameworkProfiler();
                AreaRegistration.RegisterAllAreas();
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                FilterConfig.RegisterFilters(GlobalFilters.Filters);
                //RazorGeneratorConfig.RegisterRazorGenerator();
                EntityFrameworkConfig.RegisterEntityFramework();
                AutoMapperConfig.RegisterAutoMapper();
                ElmahConfig.RegisterElmah();
                DataBaseConfig.RegisterDataBase();
                Configuration();
            }
            catch
            {
                // سبب ری استارت برنامه و آغاز مجدد آن با درخواست بعدی می‌شود
                HttpRuntime.UnloadAppDomain();
                throw;
            }
        }

        public static void Configuration()
        {
        }

        public static void SessionEnd(string sessionId)
        {
            ContainerManager.Container.GetInstance<IUserOnlineService>().DeleteBySessionId(sessionId);
        }

        public static void SessionStart(string sessionId)
        {
            var viewModel = new UserOnlineViewModel
            {
                SessionId = sessionId,
                IsActive = true
            };
            ContainerManager.Container.GetInstance<IUserOnlineService>().CreateByViewModel(viewModel);
        }

        #endregion Public Methods

        #region Private Methods

        private void SetPermissions(IEnumerable<string> permissions)
        {
            HttpContext.Current.User = new GenericPrincipal(HttpContext.Current.User.Identity, permissions.ToArray());
        }

        private bool ShouldIgnoreRequest()
        {
            string[] reservedPath =
            {
                "/__browserLink",
                "/Scripts",
                "/Content"
            };

            var rawUrl = HttpContext.Current.Request.RawUrl;
            if (reservedPath.Any(path => rawUrl.StartsWith(path, StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }

            return
                BundleTable.Bundles.Select(bundle => bundle.Path.TrimStart('~')).Any(bundlePath => rawUrl.StartsWith(bundlePath, StringComparison.OrdinalIgnoreCase));
        }

        #endregion Private Methods
    }
}