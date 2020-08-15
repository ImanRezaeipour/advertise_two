using System;
using System.Threading.Tasks;
using Advertise.Core.Models.UserViolation;

namespace Advertise.Service.Factories.Users
{
    public interface IUserViolationFactory
    {
        Task<UserViolationDetailViewModel> PrepareDetailViewModelAsync(Guid userReportId);
        Task<UserViolationEditViewModel> PrepareEditViewModelAsync(Guid userReportId);
        Task<UserViolationListViewModel> PrepareListViewModelAsync(UserViolationSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}