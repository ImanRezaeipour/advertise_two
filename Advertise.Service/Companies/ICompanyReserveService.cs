using System.Threading.Tasks;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyReserveService
    {
        Task<bool> IsExistByAlias(string alias);
    }
}