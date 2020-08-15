using Advertise.Core.Domains.Companies;
using Advertise.Data.DbContexts;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Advertise.Service.Services.Companies
{
    public class CompanyReserveService : ICompanyReserveService
    {
        #region Private Fields

        private readonly IDbSet<CompanyReserve> _companyReserves;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        public CompanyReserveService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _companyReserves = unitOfWork.Set<CompanyReserve>();
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<bool> IsExistByAlias(string alias)
        {
            return await _companyReserves.AsNoTracking()
                 .AnyAsync(model => model.Alias == alias);
        }

        #endregion Public Methods
    }
}