using Advertise.Core.Domains.Receipts;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ReceiptOption;
using Advertise.Core.Types;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.WebContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace Advertise.Service.Services.Receipts
{

    public class ReceiptOptionService : IReceiptOptionService
    {
        #region Private Fields

        private readonly IDbSet<ReceiptOption> _receiptOptionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        public ReceiptOptionService(IUnitOfWork unitOfWork, IWebContextManager webContextManager)
        {
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _receiptOptionRepository = unitOfWork.Set<ReceiptOption>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(ReceiptOptionSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }


        public async Task<IList<ReceiptOption>> GetByRequestAsync(ReceiptOptionSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="receiptId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IList<ReceiptOption>> GetMyReceiptOptionsByReceiptIdAsync(Guid receiptId, Guid? userId = null)
        {
            if (userId == null)
            {
                userId = _webContextManager.CurrentUserId;
            }
            var request = new ReceiptOptionSearchRequest
            {
                PageSize = PageSize.Count100,
                SortMember = SortMember.ModifiedOn,
                UserId = userId,
                ReceiptId = receiptId
            };

            return await GetByRequestAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal? GetSumTotalPriceAsync(Guid userId)
        {
          return  _receiptOptionRepository
                .Where(model => model.CreatedById == userId)
                .Sum(model => model.TotalPrice);

          
        }


        public IQueryable<ReceiptOption> QueryByRequest(ReceiptOptionSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var receiptOptions = _receiptOptionRepository.AsNoTracking().AsQueryable();

            if (request.ListType == null && request.UserId.HasValue)
                receiptOptions = receiptOptions.Where(model => model.CreatedById == request.UserId);
            if (request.ListType == ReceiptOptionListType.Buy && request.UserId.HasValue)
                receiptOptions = receiptOptions.Where(model => model.CreatedById == request.UserId);
            if (request.ListType == ReceiptOptionListType.Sale && request.UserId.HasValue)
                receiptOptions = receiptOptions.Where(model => model.SaledById == request.UserId);
            if (request.ReceiptId.HasValue)
                receiptOptions = receiptOptions.Where(model => model.ReceiptId == request.ReceiptId);

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;

            receiptOptions = receiptOptions.OrderBy($"{request.SortMember} {request.SortDirection}");

            return receiptOptions;
        }

        #endregion Public Methods
    }
}