using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Tags;
using Advertise.Core.Models.Tag;
using Advertise.Core.Objects;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Tags
{
    public interface ITagService {
        Task<int> CountByRequestAsync(TagSearchRequest request);


        Task  CreateByViewModelAsync(TagCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid tagId);

        Task<Tag> FindByIdAsync(Guid tagId);
        Task<string> GenerateCodeForTagAsync();
        Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid tagId);

        Task<string> MaxCodeByRequestAsync(TagSearchRequest request, string aggregateMember);


        Task  SeedAsync();


        Task  EditByViewModelAsync(TagEditViewModel viewModel);

        Task<IList<Tag>> GetActiveAsync();


        Task<IList<Tag>> GetByRequestAsync(TagSearchRequest request);


        IQueryable<Tag> QueryByRequest(TagSearchRequest request);
    }
}