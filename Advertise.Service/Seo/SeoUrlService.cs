using Advertise.Core.Domains.Seos;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.SeoUrl;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Validators.Seo;

namespace Advertise.Service.Services.Seo
{
    /// <summary>
    ///
    /// </summary>
    public class SeoUrlService : ISeoUrlService
    {

        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IDbSet<SeoUrl> _seoUrlRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors
/// <summary>
/// 
/// </summary>
/// <param name="unitOfWork"></param>
/// <param name="mapper"></param>
        public SeoUrlService(IUnitOfWork unitOfWork, IMapper mapper, IWebContextManager webContextManager)
        {
            _unitOfWork = unitOfWork;
            _seoUrlRepository = unitOfWork.Set<SeoUrl>();
            _mapper = mapper;
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(SeoUrlSearchRequest request)
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
        [Validation(typeof(SeoUrlCreateValidator),"Create")]
        public async Task CreateByViewModelAsync(SeoUrlCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var seoUrl = _mapper.Map<SeoUrl>(viewModel);
               seoUrl.CreatedOn = DateTime.Now;
            seoUrl.CreatedById = _webContextManager.CurrentUserId;
            _seoUrlRepository.Add(seoUrl);

            await _unitOfWork.SaveAllChangesAsync();
        }


        public async Task DeleteByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            var seoUrl = await _seoUrlRepository.FirstOrDefaultAsync(model => model.Id == id);
            _seoUrlRepository.Remove(seoUrl);

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(SeoUrlEditValidator),"Edit")]
        public async Task EditByViewModelAsync(SeoUrlEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var originalSeoUrl = await _seoUrlRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, originalSeoUrl);

            await _unitOfWork.SaveAllChangesAsync();
        }


        public async Task<SeoUrl> FindByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            return await _seoUrlRepository.FirstOrDefaultAsync(model => model.Id == id);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAll()
        {
            return _seoUrlRepository
                .AsNoTracking()
                .Where(model => model.IsActive == true)
                .Select(model => new { model.AbsoulateUrl, model.CurrentUrl })
                .AsEnumerable()
                .ToDictionary(model => model.AbsoulateUrl, model => model.CurrentUrl);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IList<SeoUrl>> GetByRequestAsync(SeoUrlSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<SeoUrl> QueryByRequest(SeoUrlSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var seoUrls = _seoUrlRepository.AsNoTracking().AsQueryable();
            if (request.CreatedById != null)
                seoUrls = seoUrls.Where(model => model.CreatedById == request.CreatedById);
            if (request.Term != null)
                seoUrls = seoUrls.Where(model => model.AbsoulateUrl.Contains(request.Term) || model.CurrentUrl.Contains(request.Term));
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            seoUrls = seoUrls.OrderBy($"{request.SortMember} {request.SortDirection}");

            return seoUrls;
        }

        #endregion Public Methods

    }
}