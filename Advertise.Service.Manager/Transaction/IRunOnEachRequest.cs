namespace Advertise.Service.Managers.Transaction
{
    /// <summary>
    ///     اجرای وظایف در ابتدای هر درخواست
    /// </summary>
    public interface IRunOnEachRequest
    {
        /// <summary>
        /// </summary>
        void Execute();
    }
}