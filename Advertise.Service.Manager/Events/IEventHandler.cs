using System.Threading.Tasks;

namespace Advertise.Service.Managers.Events
{
    public interface IEventHandler<T>
    {
        #region Public Methods

        Task HandleEvent(T eventMessage);

        #endregion Public Methods
    }
}