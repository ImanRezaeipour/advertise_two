using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Keywords;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Keyword;

namespace Advertise.Service.Services.Keywords
{
    public interface IKeywordService
    {
        Task CreateByViewModelAsync(KeywordCreateViewModel viewModel);
        Task DeleteByIdAsync(Guid keywordId);
        Task<Keyword> FindByIdAsync(Guid keywordId, bool? applyCurrentUser = false);
        Task<List<Keyword>> GetAllActiveAsync();
        IQueryable<Keyword> QueryByRequest(KeywordSearchRequest request);


        Task<List<SelectListItem>> GetAllActiveAsSelectListAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keywordId"></param>
        /// <returns></returns>
        Task<bool> IsExistByIdAsync(Guid keywordId);
    }
}