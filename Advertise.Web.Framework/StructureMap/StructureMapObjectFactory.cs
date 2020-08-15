﻿using Advertise.Core.Configuration;
using Advertise.Core.Infrastructure.DependencyManagement;
using Advertise.Data.DbContexts;
using Advertise.Service.Events;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Providers.SessionProvider;
using Advertise.Web.Framework.Providers.TempDataProvider;
using Advertise.Web.Framework.StructureMap.Registeries;
using AutoMapper;
using StructureMap;
using StructureMap.Web;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Advertise.Service.Managers.Caching;
using Advertise.Service.Managers.Events;

namespace Advertise.Web.Framework.StructureMap
{
    public static class StructureMapObjectFactory
    {
        #region Public Methods

        public static void DefaultContainer()
        {
            ContainerManager.Container.Configure(expression =>
            {
                expression.For<IIdentity>().Use(() => HttpContext.Current != null && HttpContext.Current.User != null ? HttpContext.Current.User.Identity : null);
                expression.For<IUnitOfWork>().HybridHttpOrThreadLocalScoped().Use<BaseDbContext>();
                expression.For<HttpContextBase>().Use(() => new HttpContextWrapper(HttpContext.Current));
                expression.For<HttpServerUtilityBase>().Use(() => new HttpServerUtilityWrapper(HttpContext.Current.Server));
                expression.For<HttpRequestBase>().Use(ctx => ctx.GetInstance<HttpContextBase>().Request);
                expression.For<ISessionProvider>().Use<BaseSessionProvider>();
                expression.For<IRemotingFormatter>().Use(ctx => new BinaryFormatter());
                expression.For<ITempDataProvider>().Use<CookieTempDataProvider>();

                expression.For<InternationalizationAttribute>().Use<InternationalizationAttribute>();
                expression.For<IConfigurationManager>().Use<ConfigurationManager>();
                //ioc.For<IZarinpalGatewayManager>().Use<ZarinpalGatewayManager>();
                //ioc.For<IListManager>().Use<ListManager>();
                //ioc.For<IWebContextManager>().Use<WebContextManager>();
                //ioc.For<IRedisConnectionWrapper>().Use<RedisConnectionWrapper>();
                expression.For<ICacheManager>().Use<RedisCacheManager>();

                expression.For(typeof(IEventHandler<>)).Use(typeof(SeoEvents));
                expression.For(typeof(IEventHandler<>)).Use(typeof(SmsEvents));
                expression.For(typeof(IEventHandler<>)).Use(typeof(CacheEvents));
                expression.For(typeof(IEventHandler<>)).Use(typeof(NotificationEvents));

                expression.AddRegistry<AutoMapperRegistery>();
                expression.AddRegistry<ServiceLayerRegistery>();
                expression.AddRegistry<TaskRegistry>();
                expression.AddRegistry<AspNetIdentityRegistery>();

                expression.Scan(scanner => scanner.WithDefaultConventions());

                expression.Policies.SetAllProperties(convention => convention.OfType<HttpContextBase>());
                expression.Policies.SetAllProperties(convention => convention.OfType<ExceptionRequestValidationErrorFilter>());
                expression.Policies.SetAllProperties(convention => convention.OfType<ExceptionHandledErrorLoggerFilter>());
            });

            ConfigureAutoMapper(ContainerManager.Container);
        }

        #endregion Public Methods

        #region Private Methods

        private static void ConfigureAutoMapper(IContainer container)
        {
            // Exception - unmapped member
            container.GetInstance<IMapper>().ConfigurationProvider.AssertConfigurationIsValid();
        }

        #endregion Private Methods
    }
}