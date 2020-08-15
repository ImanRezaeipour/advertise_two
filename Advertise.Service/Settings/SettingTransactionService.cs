using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Domains.Settings;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.SettingTransaction;
using Advertise.Data.DbContexts;
using AutoMapper.QueryableExtensions;

namespace Advertise.Service.Services.Settings
{
    public class SettingTransactionService : ISettingTransactionService
    {
        private readonly IDbSet<SettingTransaction> _settingTransactions;
        private readonly IUnitOfWork _unitOfWork;

        public SettingTransactionService( IUnitOfWork unitOfWork)
        {
            _settingTransactions = unitOfWork.Set<SettingTransaction>();
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<SelectListItem>> GetAllAsSelectItemListAsync()
        {
            var request = new SettingTransactionSearchRequest
            {
                PageSize = PageSize.All
            };

           return  await QueryByRequest(request).ProjectTo<SelectListItem>().ToPagedListAsync();
          }


        public IQueryable<SettingTransaction> QueryByRequest(SettingTransactionSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companies = _settingTransactions.AsNoTracking().AsQueryable();
            
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            companies = companies.OrderBy($"{request.SortMember} {request.SortDirection}");

            return companies;
        }
    }
}
