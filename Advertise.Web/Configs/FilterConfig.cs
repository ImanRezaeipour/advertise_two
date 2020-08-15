﻿using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.StructureMap;
using System.Web.Mvc;
using Advertise.Core.Infrastructure.DependencyManagement;

namespace Advertise.Web.Framework.Configs
{
    public static class FilterConfig
    {
        #region Public Methods

        public static void RegisterFilters(GlobalFilterCollection filters)
        {
            filters.Add(ContainerManager.Container.GetInstance<ExceptionHandledErrorLoggerFilter>());

            filters.Add(ContainerManager.Container.GetInstance<ExceptionRequestValidationErrorFilter>());

            filters.Add(ContainerManager.Container.GetInstance<RemoveServerHeaderFilterAttribute>());

            filters.Add(ContainerManager.Container.GetInstance<RemoveWhiteSpacesAttribute>());

            filters.Add(ContainerManager.Container.GetInstance<AutoAjaxAttribute>());

            filters.Add(ContainerManager.Container.GetInstance<InternationalizationAttribute>());

            //filters.Add(ContainerManager.Container.GetInstance<TempModelDataAttribute>());
        }

        #endregion Public Methods
    }
}