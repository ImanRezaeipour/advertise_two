using Advertise.Core.Domains.Smses;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Sms;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.Communications;
using AutoMapper;
using Microsoft.AspNet.Identity;
using SmsIrRestful;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Core.Configuration;
using Advertise.Service.Managers.Events;

namespace Advertise.Service.Services.Messages
{

    public class SmsService : IIdentityMessageService, ISmsService
    {

        #region Private Fields

        private readonly IConfigurationManager _configurationManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<Sms> _smsRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="configurationManager"></param>
        public SmsService(IMapper mapper, IUnitOfWork unitOfWork, IConfigurationManager configurationManager, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _configurationManager = configurationManager;
            _eventPublisher = eventPublisher;
            _smsRepository = unitOfWork.Set<Sms>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(SmsSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var smses = await QueryByRequest(request).CountAsync();

            return smses;
        }


        public async Task CreateByViewModelAsync(SmsCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var sms = _mapper.Map<Sms>(viewModel);
            _smsRepository.Add(sms);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(sms);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="smsId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid smsId)
        {
            var sms = await _smsRepository.FirstOrDefaultAsync(model => model.Id == smsId);
            _smsRepository.Remove(sms);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(sms);
        }


        public async Task EditByViewModelAsync(SmsEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var sms = await _smsRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, sms);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(sms);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="smsId"></param>
        /// <returns></returns>
        public async Task<Sms> FindByIdAsync(Guid smsId)
        {
            return  await _smsRepository
                .FirstOrDefaultAsync(model => model.Id == smsId);
            }


        public async Task<IList<Sms>> GetByRequestAsync(SmsSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return  await QueryByRequest(request).ToPagedListAsync(request);
            }


        public IQueryable<Sms> QueryByRequest(SmsSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var smses = _smsRepository.AsNoTracking().AsQueryable();
            return smses.OrderBy($"{request.SortMember} {request.SortDirection}");

        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendAsync(IdentityMessage message)
        {
            if (_configurationManager.SmsEnabled.ToBoolean() == false)
                return Task.FromResult(0);

            var token = new Token().GetToken(_configurationManager.SmsUserApiKey, _configurationManager.SmsSecretKey);

            var messageSendObject = new MessageSendObject
            {
                Messages = new List<string>
                {
                    message.Body
                }.ToArray(),
                MobileNumbers = new List<string>
                {
                    message.Destination
                }.ToArray(),
                LineNumber = _configurationManager.SmsLineNumber,
                SendDateTime = null,
                CanContinueInCaseOfError = true
            };
            var messageSendResponseObject = new MessageSend().Send(token, messageSendObject);

            if (messageSendResponseObject.IsSuccessful)
            {
            }
            return Task.FromResult(0);
        }

        #endregion Public Methods
    }
}