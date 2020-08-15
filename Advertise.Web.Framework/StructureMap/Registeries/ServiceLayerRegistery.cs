using Advertise.Core.Extensions;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Services.Categories;
using Advertise.Service.Services.Logs;
using Advertise.Service.Services.Products;
using Advertise.Service.Services.Users;
using StructureMap;
using StructureMap.Building.Interception;
using StructureMap.DynamicInterception;
using StructureMap.Pipeline;
using StructureMap.TypeRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Advertise.Web.Framework.StructureMap.Registeries
{
    public class ServiceLayerRegistery : Registry
    {
        #region Public Constructors

        public ServiceLayerRegistery()
        {
            Scan(scanner =>
            {
                scanner.Assembly("Advertise.Service");
                scanner.WithDefaultConventions();
                scanner.AssemblyContainingType<UserService>();
            });

            Policies.SetAllProperties(action => action.OfType<IActivityLogService>());

            Policies.Interceptors(new DynamicProxyInterceptorPolicy((type, instance) => instance.ReturnedType.GetMethods().Any(info => info.HasAttribute<ValidationAttribute>()) && type.Assembly == Assembly.Load("Advertise.Service") && type != typeof(IExceptionLogService) && type != typeof(IUserSettingService) /*&& type != typeof(UserService)*/, typeof(ValidationInterceptor)));
        }

        #endregion Public Constructors
    }

    public class CustomInterception : IInterceptorPolicy
    {
        public string Description => "good interception policy";

        public IEnumerable<IInterceptor> DetermineInterceptors(Type pluginType, Instance instance)
        {
            if (pluginType == typeof(ICategoryService))
            {
                yield return new DecoratorInterceptor(typeof(IProductService), typeof(ProductService));
            }
        }
    }
}