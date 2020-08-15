using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Smses;
using Advertise.Core.Models.Sms;
using Advertise.Service.Services.Common;
using Microsoft.AspNet.Identity;

namespace Advertise.Service.Services.Communications
{

    public interface ISmsService {

        Task  CreateByViewModelAsync(SmsCreateViewModel viewModel);

        Task<Sms> FindByIdAsync(Guid smsId);


        /// <summary>
        ///
        /// </summary>
        /// <param name="smsId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid smsId);

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendAsync(IdentityMessage message);


        Task  EditByViewModelAsync(SmsEditViewModel viewModel);


        Task<IList<Sms>> GetByRequestAsync(SmsSearchRequest request);

        Task<int> CountByRequestAsync(SmsSearchRequest request);


       IQueryable<Sms> QueryByRequest(SmsSearchRequest request);
    }
}