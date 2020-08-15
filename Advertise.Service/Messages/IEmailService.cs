using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Emails;
using Advertise.Core.Models.Email;
using Advertise.Service.Services.Common;
using Microsoft.AspNet.Identity;

namespace Advertise.Service.Services.Messages
{
    public interface IEmailService {


        Task  CreateByViewModelAsync(EmailCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid emailId);

        Task<Email> FindByIdAsync(Guid emailId);

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendAsync(IdentityMessage message);


        Task  EditByViewModelAsync(EmailEditViewModel viewModel);


        Task<IList<Email>> GetByRequestAsync(EmailSearchRequest request);

        Task<int> CountByRequestAsync(EmailSearchRequest request);


        IQueryable<Email> QueryByRequest(EmailSearchRequest request);
    }
}