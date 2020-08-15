using System;

namespace Advertise.Service.Services.Logs
{
    public interface IExceptionLogService
    {
        void Raise(Exception exception);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        void Log(Exception exception);
    }
}