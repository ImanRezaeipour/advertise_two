using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertise.Service.Services.Products
{
    public interface IProductKeywordService
    {
        Task<List<string>> GetTitlesByProductIdAsync(Guid productId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<List<Guid?>> GetIdsByProductIdAsync(Guid productId);
    }
}