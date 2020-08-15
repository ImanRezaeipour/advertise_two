using Advertise.Core.Domains.Categories;
using Advertise.Core.Models.Category;
using Advertise.Core.Profiles.Common;

namespace Advertise.Core.Profiles.Categories
{
    /// <summary>
    /// 
    /// </summary>
    public static class CategoryExtension
    {
        #region Category Model

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static TModel ToModel<TModel>(this Category entity)
        {
            return entity.MapTo<Category, TModel>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static TEntity ToEntity<TEntity>(this CategoryViewModel model)
        {
            return model.MapTo<CategoryViewModel, TEntity>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static TEntity ToEntity<TEntity>(this CategoryViewModel model, TEntity destination)
        {
            return model.MapTo(destination);
        }

        #endregion
    }
}
