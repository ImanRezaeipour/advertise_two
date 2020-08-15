using Advertise.Core.Domains.Complaints;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Complaint;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Managers.Events;
using Advertise.Service.Services.WebContext;
using Advertise.Service.Validators.Complaints;

namespace Advertise.Service.Services.Complaints
{
    /// <summary>
    ///
    /// </summary>
    public class ComplaintService : IComplaintService
    {
        #region Private Fields

        private readonly IDbSet<Complaint> _complaintRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        public ComplaintService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher, IWebContextManager webContextManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _webContextManager = webContextManager;
            _complaintRepository = unitOfWork.Set<Complaint>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(ComplaintSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var complaints = await QueryByRequest(request).CountAsync();

            return complaints;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ComplaintCreateValidator),"Create")]
        public async Task CreateByViewModel(ComplaintCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var complaint = _mapper.Map<Complaint>(viewModel);
            complaint.CreatedById = _webContextManager.CurrentUserId;
            complaint.CreatedOn = DateTime.Now;
            _complaintRepository.Add(complaint);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(complaint);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="complaintId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid complaintId)
        {
            var complaint = await _complaintRepository.FirstOrDefaultAsync(model => model.Id == complaintId);
            _complaintRepository.Remove(complaint);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(complaint);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="complaintId"></param>
        /// <returns></returns>
        public async Task<Complaint> FindByIdAsync(Guid complaintId)
        {
            return await _complaintRepository
                   .FirstOrDefaultAsync(model => model.Id == complaintId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IList<Complaint>> GetByRequestAsync(ComplaintSearchRequest request)
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
        public IQueryable<Complaint> QueryByRequest(ComplaintSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var complaints = _complaintRepository.AsNoTracking().AsQueryable();
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            if (request.Term.HasValue())
                complaints = complaints.Where(complaint => complaint.Title.Contains(request.Term));
            complaints = complaints.OrderBy($"{request.SortMember} {request.SortDirection}");

            return complaints;
        }

        #endregion Public Methods
    }
}