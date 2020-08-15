using Advertise.Core.Domains.Newsletters;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Newsletter;
using Advertise.Core.Types;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading;
using System.Threading.Tasks;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Managers.Events;
using Advertise.Service.Services.WebContext;
using Advertise.Service.Validators.Newsletters;

namespace Advertise.Service.Services.Newsletters
{

    public class NewsletterService : INewsletterService
    {
        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<Newsletter> _newsletterRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="eventPublisher"></param>
        public NewsletterService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher, IWebContextManager webContextManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _webContextManager = webContextManager;
            _newsletterRepository = unitOfWork.Set<Newsletter>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(NewsletterSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException();

            return await QueryByRequest(request).CountAsync();
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(NewsletterCreateValidator),"Create")]
        public async Task CreateByViewModelAsync(NewsletterCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var newsletter = _mapper.Map<Newsletter>(viewModel);
            newsletter.CreatedById = _webContextManager.CurrentUserId;
            _newsletterRepository.Add(newsletter);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(newsletter);
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="newsletterId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid newsletterId)
        {
            if (newsletterId == Guid.Empty)
                throw new ArgumentNullException(nameof(newsletterId));

            var newsletter = await _newsletterRepository.FirstOrDefaultAsync(model => model.Id == newsletterId);
            _newsletterRepository.Remove(newsletter);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(newsletter);
        }


        public async Task<IList<Newsletter>> GetByRequestAsync(NewsletterSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException();

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> IsEmailExistAsync(string email, Guid? userId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = _newsletterRepository.AsQueryable();
            query = query.Where(model => model.Email.ToLower() == email.ToLower());
            if (userId.HasValue)
                query = query.Where(model => model.CreatedById == userId);

            return await query.AnyAsync();
        }

        /// <inheritdoc />
        ///  <summary>
        ///  </summary>
        ///  <param name="request"></param>
        ///  <returns></returns>
        public IQueryable<Newsletter> QueryByRequest(NewsletterSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException();

            var newsletter = _newsletterRepository.AsNoTracking().AsQueryable();
            if (request.CreatedById.HasValue)
                newsletter = newsletter.Where(model => model.CreatedById == request.CreatedById);
            if (request.Meet.HasValue)
                newsletter = newsletter.Where(model => model.Meet == request.Meet);
            if (request.Email.HasValue)
                newsletter = newsletter.Where(model => model.Email.Contains(request.Term));
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            newsletter = newsletter.OrderBy($"{request.SortMember} {request.SortDirection}");

            return newsletter;
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(NewsletterCreateValidator),"Create")]
        public async Task SubscribeByViewModelAsync(NewsletterCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException();

            var newsletter = _mapper.Map<Newsletter>(viewModel);
            newsletter.Meet = MeetType.Guest;
            _newsletterRepository.Add(newsletter);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(newsletter);
        }

        #endregion Public Methods
    }
}