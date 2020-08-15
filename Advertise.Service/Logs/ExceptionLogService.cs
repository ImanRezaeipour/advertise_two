using Elmah;
using System;
using System.Web;

namespace Advertise.Service.Services.Logs
{

    public class ExceptionLogService : IExceptionLogService
    {
        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="exception"></param>
        public void Log(Exception exception)
        {
            ErrorLog.GetDefault(HttpContext.Current).Log(new Error(exception));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="exception"></param>
        public void Raise(Exception exception)
        {
            ErrorSignal.FromCurrentContext().Raise(exception);
        }

        #endregion Public Methods
    }
}