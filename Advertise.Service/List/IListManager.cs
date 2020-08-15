using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Models.Common;

namespace Advertise.Service.Services.List
{
    public interface IListManager {

        Task<IList<SelectListItem>> GetIsBanListAsync();


        Task<IList<SelectListItem>> GetIsVerifyListAsync();


        Task<IList<SelectListItem>> GetPageSizeListAsync();


        Task<IList<SelectListItem>> GetSortDirectionFilterListAsync();


        Task<IList<SelectListItem>> GetSortDirectionListAsync();


        Task<IList<SelectListItem>> GetSortMemberFilterListAsync();


        //public async Task<IList<SelectListItem>> GetSortMemberListAsync()
        //{
        //    var sortList = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Value = SortMember.CreatedOn,
        //            Text = "تاریخ درج"
        //        },
        //        new SelectListItem
        //        {
        //            Value = SortMember.ModifiedOn,
        //            Text = "آخرین تغییر"
        //        }
        //    };

        //    return sortList;
        //}


        Task<IList<SelectListItem>> GetSortMemberListByTitleAsync();
    }
}