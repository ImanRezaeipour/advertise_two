using Advertise.Core.Domains.Emails;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Email;
using Advertise.Data.DbContexts;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net.Mail;
using System.Threading.Tasks;
using Advertise.Service.Managers.Events;

namespace Advertise.Service.Services.Messages
{

    public class EmailService : IIdentityMessageService, IEmailService
    {

        #region Private Fields

        private readonly IDbSet<Email> _emailRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public EmailService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _emailRepository = unitOfWork.Set<Email>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(EmailSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }


        public async Task CreateByViewModelAsync(EmailCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var email = _mapper.Map<Email>(viewModel);
            _emailRepository.Add(email);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(email);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid emailId)
        {
            var email = await _emailRepository.FirstOrDefaultAsync(model => model.Id == emailId);
            _emailRepository.Remove(email);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(email);
        }


        public async Task EditByViewModelAsync(EmailEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var email = await _emailRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, email);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityUpdated(email);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        public async Task<Email> FindByIdAsync(Guid emailId)
        {
            return await _emailRepository.FirstOrDefaultAsync(model => model.Id == emailId);
        }


        public async Task<IList<Email>> GetByRequestAsync(EmailSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }


        public IQueryable<Email> QueryByRequest(EmailSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var emails = _emailRepository.AsNoTracking().AsQueryable();
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            emails = emails.OrderBy($"{request.SortMember} {request.SortDirection}");

            return emails;
        }
        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendAsync(IdentityMessage message)
        {
            var mailMessage = new MailMessage
            {
                To =
                {
                    new MailAddress(message.Destination)
                },
                Priority = MailPriority.High,
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true
            };
            var smtpClient = new SmtpClient();

            return smtpClient.SendMailAsync(mailMessage);
        }

        #endregion Public Methods
    }
}