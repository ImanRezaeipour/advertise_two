using Advertise.Core.Domains.Newsletters;
using Advertise.Core.Models.Newsletter;
using Advertise.Service.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Advertise.Service.Services.Newsletters
{
    public interface INewsletterService
    {
        #region Public Methods

        Task<int> CountByRequestAsync(NewsletterSearchRequest request);

        Task CreateByViewModelAsync(NewsletterCreateViewModel viewModel);

        Task DeleteByIdAsync(Guid newsletterId);

        Task<IList<Newsletter>> GetByRequestAsync(NewsletterSearchRequest request);

        Task<bool> IsEmailExistAsync(string email, Guid? userId = null, CancellationToken cancellationToken = default (CancellationToken));


        IQueryable<Newsletter> QueryByRequest(NewsletterSearchRequest request);

        Task SubscribeByViewModelAsync(NewsletterCreateViewModel viewModel);

        #endregion Public Methods
    }
}