using Advertise.Core.Models.Seo;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Advertise.Service.Services.Seo
{

    public class SeoService : ISeoService
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IDbSet<Core.Domains.Seos.Seo> _seoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <param name="webContextManager"></param>
        public SeoService(IUnitOfWork unitOfWork, IMapper mapper, IWebContextManager webContextManager)
        {
            _unitOfWork = unitOfWork;
            _seoRepository = unitOfWork.Set<Core.Domains.Seos.Seo>();
            _mapper = mapper;
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task CreateByViewModelAsync(SeoCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var seo = _mapper.Map<Core.Domains.Seos.Seo>(viewModel);
           _seoRepository.Add(seo);

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="seoId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid seoId)
        {
            if (seoId == Guid.Empty)
                throw new ArgumentNullException(nameof(seoId));

            var seo = await _seoRepository.FirstOrDefaultAsync(model => model.Id == seoId);
            _seoRepository.Remove(seo);

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId">
        /// منظور همان آلیاس است
        /// </param>
        /// <returns></returns>
        public async Task<bool> IsExistCategoryByIdAsync(string categoryId)
        {
            return await _seoRepository.AnyAsync(model => model.IsActive == true && model.EntityName == "Category" && model.EntityId == categoryId);
        }

        #endregion Public Methods
    }
}