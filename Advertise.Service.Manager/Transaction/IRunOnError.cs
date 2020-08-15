namespace Advertise.Service.Managers.Transaction
{
    /// <summary>
    ///     اجرای وظایف در زمان بروز خطا یا استثناء‌های مدیریت نشده‌ی برنامه
    /// </summary>
    public interface IRunOnError
    {
        /// <summary>
        /// </summary>
        void Execute();
    }
}