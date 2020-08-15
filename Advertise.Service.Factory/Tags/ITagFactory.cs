using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Tag;

namespace Advertise.Service.Factories.Tags
{
    public interface ITagFactory
    {
        Task<TagCreateViewModel> PrepareCreateViewModelAsync(TagCreateViewModel viewModelPrepare = null);
        Task<TagEditViewModel> PrepareEditViewModelAsync(Guid tagId, TagEditViewModel viewModelPrepare = null);
        Task<TagListViewModel> PrepareListViewModelAsync(TagSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}