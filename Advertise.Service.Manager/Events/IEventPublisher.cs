namespace Advertise.Service.Managers.Events
{
    public interface IEventPublisher
    {
        #region Public Methods

        void Publish<T>(T eventMessage);

        #endregion Public Methods
    }
}