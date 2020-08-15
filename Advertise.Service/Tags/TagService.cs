using Advertise.Core.Domains.Tags;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Tag;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Managers.Events;
using Advertise.Service.Managers.File;
using Advertise.Service.Validators.Tags;
using FineUploaderObject = Advertise.Core.Objects.FineUploaderObject;

namespace Advertise.Service.Services.Tags
{
    /// <summary>
    ///
    /// </summary>
    public class TagService : ITagService
    {

        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<Tag> _tagRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="eventPublisher"></param>
        public TagService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _tagRepository = unitOfWork.Set<Tag>();
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(TagSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(TagCreateValidator),"Create")]
        public async Task CreateByViewModelAsync(TagCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var tag = _mapper.Map<Tag>(viewModel);
            tag.Code = await GenerateCodeForTagAsync();
            tag.CreatedOn = DateTime.Now;
            _tagRepository.Add(tag);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityInserted(tag);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid tagId)
        {
            if (tagId == null)
                throw new ArgumentNullException(nameof(tagId));

            var tag = await _tagRepository.FirstOrDefaultAsync(model => model.Id == tagId);
            _tagRepository.Remove(tag);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityDeleted(tag);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(TagEditValidator),"Edit")]
        public async Task EditByViewModelAsync(TagEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var tag = await _tagRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, tag);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityUpdated(tag);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public async Task<Tag> FindByIdAsync(Guid tagId)
        {
            return await _tagRepository
                  .FirstOrDefaultAsync(model => model.Id == tagId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<string> GenerateCodeForTagAsync()
        {
            var request = new TagSearchRequest
            {
                PageSize = PageSize.All
            };
            var maxCode = await MaxCodeByRequestAsync(request, TagAggregateMember.Code);

            if (maxCode == null)
                return (CodeConst.BeginNumber5Digit);
            return maxCode.ExtractNumeric();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Tag>> GetActiveAsync()
        {
            var request = new TagSearchRequest
            {
                SortDirection = SortDirection.Asc,
                SortMember = SortMember.CreatedOn,
                PageSize = PageSize.Count100,
                PageIndex = 1,
                IsActive = true
            };
            return await GetByRequestAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IList<Tag>> GetByRequestAsync(TagSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public async Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid tagId)
        {
            return (await _tagRepository.AsNoTracking()
                    .Where(model => model.Id == tagId)
                    .Select(model => new
                    {
                        model.Id,
                        model.LogoFileName
                    }).ToListAsync())
                .Select(model => new FineUploaderObject
                {
                    id = model.Id.ToString(),
                    uuid = model.Id.ToString(),
                    name = model.LogoFileName,
                    thumbnailUrl = FileConst.ImagesWebPath.PlusWord(model.LogoFileName),
                    size = new FileInfo(HttpContext.Current.Server.MapPath(FileConst.ImagesWebPath.PlusWord(model.LogoFileName))).Length.ToString()
                }).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="aggregateMember"></param>
        /// <returns></returns>
        public async Task<string> MaxCodeByRequestAsync(TagSearchRequest request, string aggregateMember)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var products = QueryByRequest(request);
            switch (aggregateMember)
            {
                case TagAggregateMember.Code:
                    var memberMax = await products.MaxAsync(model => model.Code);
                    return memberMax;
            }

            return null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<Tag> QueryByRequest(TagSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var tags = _tagRepository.AsNoTracking().AsQueryable();
            if (request.Term.HasValue())
                tags = tags.Where(model => model.Title.Contains(request.Term) || model.Description.Contains(request.Term));
            if (request.IsActive.HasValue)
                tags = tags.Where(model => model.IsActive == request.IsActive);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            tags = tags.OrderBy($"{request.SortMember} {request.SortDirection}");

            return tags;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods

    }
}