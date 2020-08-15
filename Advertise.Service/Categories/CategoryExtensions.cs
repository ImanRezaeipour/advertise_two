using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Categories;
using Advertise.Core.Models.Category;

namespace Advertise.Service.Services.Categories
{
    /// <summary>
    /// 
    /// </summary>
    public static class CategoryExtensions
    {
        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        public static IEnumerable<CategoryViewModel> GetSubLevelOneByAlias(this IEnumerable<CategoryViewModel> categories, string alias)
        {
            var category = categories.FirstOrDefault(model => model.Alias == alias);
            if (category != null)
            {
                var subCategories = categories.Where(model => model.ParentId == category.Id).OrderBy(model => model.Order).ToList();
                return subCategories;
            }
            return null;
        }

        public static IEnumerable<Category> GetAllParentsByIdAsync(this IEnumerable<Category> categoryList, Category category)
        {
            var parent = categoryList.FirstOrDefault(model => model.Id == category.ParentId);

            if (parent == null)
                return Enumerable.Empty<Category>();

            return new[] { parent }.Concat(GetAllParentsByIdAsync(categoryList, parent));
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryList"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public static IEnumerable<Category> GetAllChildsById(this IList<Category> categoryList, Category category)
        {
            var childs = categoryList.Where(model => model.ParentId == category.Id).ToList();

            if (childs.Count <= 0)
                return Enumerable.Empty<Category>();

            var childList = new List<Category>();
            foreach (var child in childs)
            {
                childList.AddRange(new[] { child }.Concat(GetAllChildsById(categoryList, child)));
            }

            return childList;
        }

        #endregion Public Methods
    }
}