using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Settings;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.SettingTransaction;

namespace Advertise.Service.Services.Settings
{
    public interface ISettingTransactionService
    {
        Task<IList<SelectListItem>> GetAllAsSelectItemListAsync();
        IQueryable<SettingTransaction> QueryByRequest(SettingTransactionSearchRequest request);
    }
}