using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Sms;

namespace Advertise.Service.Factories.Messages
{
    public interface ISmsFactory
    {
        Task<SmsListViewModel> PrepareListViewModelAsync(SmsSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
    }
}