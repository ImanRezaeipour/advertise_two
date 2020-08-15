using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Categories;
using Advertise.Core.Domains.Users;
using Advertise.Core.Models.CategoryFollow;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Categories
{
    public interface ICategoryFollowService {
        Task<int> CountByCategoryIdAsync(Guid categoryId);
      
        /// <summary>
        /// تعداد فالوهایی کاربر
        /// </summary>
        /// <returns></returns>
        Task<int> CountByUserIdAsync(Guid userId);

        Task<CategoryFollow> FindByCategoryIdAsync(Guid categoryId, Guid? userId = null);

       
        /// <summary>
        /// لیست آی دی افرادی که این دسته را فالو کرده اند
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<IList<User>> GetUsersByCategoryIdAsync(Guid categoryId);

        /// <summary>
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<bool> IsFollowCurrentUserByCategoryIdAsync(Guid categoryId);

        /// <summary>
        /// به محض ورود کاربر به جزئیات هر دسته فالو یا عدم فالو نشان داده شود
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="userId">    </param>
        /// <returns></returns>
        Task<bool> IsFollowByCategoryIdAsync(Guid categoryId, Guid? userId = null);


        Task SeedAsync();


        ///  <summary>
        /// 
        ///  </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task ToggleFollowCurrentUserByCategoryIdAsync(Guid categoryId);

        Task<int> CountAllFollowByCategoryIdAsync(Guid categoryId);


        Task<IList<CategoryFollow>> GetByRequestAsync(CategoryFollowSearchRequest request);

        Task<int> CountByRequestAsync(CategoryFollowSearchRequest request);


        IQueryable<CategoryFollow> QueryByRequest(CategoryFollowSearchRequest request);
    }
}