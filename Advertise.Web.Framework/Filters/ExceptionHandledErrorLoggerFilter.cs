using Advertise.Service.Services.Logs;
using StructureMap.Attributes;
using System.Web.Mvc;

namespace Advertise.Web.Framework.Filters
{

    public class ExceptionHandledErrorLoggerFilter : IExceptionFilter
    {
        #region Private Fields

        private IExceptionLogService _exceptionLogService;

        public ExceptionHandledErrorLoggerFilter(IExceptionLogService exceptionLogService)
        {
            _exceptionLogService = exceptionLogService;
        }

        #endregion Private Fields

        #region Public Properties

        //[SetterProperty]
        //public IExceptionLogService ExceptionLogService
        //{
        //    set { _exceptionLogService = value; }
        //}

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                _exceptionLogService.Raise(filterContext.Exception);
        }

        #endregion Public Methods
    }
}