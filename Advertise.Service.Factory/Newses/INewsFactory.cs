using System;
using System.Threading.Tasks;
using Advertise.Core.Models.News;

namespace Advertise.Service.Factories.Newses
{
    public interface INewsFactory
    {
        Task<NewsEditViewModel> PrepareEditViewModelAsync(Guid newsId);
        Task<NewsListViewModel> PrepareListViewModelAsync(NewsSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}