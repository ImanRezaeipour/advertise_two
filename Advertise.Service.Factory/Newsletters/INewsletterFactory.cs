using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Newsletter;

namespace Advertise.Service.Factories.Newsletters
{
    public interface INewsletterFactory
    {
        Task<NewsletterCreateViewModel> PrepareCreateViewModelAsync(NewsletterCreateViewModel viewModelPrepare = null);
        Task<NewsletterListViewModel> PrepareListViewModelAsync(NewsletterSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}