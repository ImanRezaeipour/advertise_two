using System;
using Advertise.Core.Domains.Categories;
using Advertise.Core.Models.Category;
using Advertise.Data.DbContexts;
using System.Data.Entity;
using System.Linq;
using Advertise.Service.Managers.Node;
using Z.EntityFramework.Plus;

namespace Advertise.Service.Initializers.Categories
{

    public class CategoryInitializer : ICategoryInitializer
    {
        #region Private Fields

        private readonly IDbSet<Category> _categorieRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="unitOfWork"></param>
        public CategoryInitializer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categorieRepository = unitOfWork.Set<Category>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        public void AddOrUpdate()
        {
        }

        /// <summary>
        ///
        /// </summary>
        public void Update()
        {
            //_unitOfWork.AutoDetectChangesEnabled = false;                     

            var categories = _categorieRepository.ToList();

            var categoriesViewModel = categories
                .Select(category => new CategoryViewModel
                {
                    Id = category.Id,
                    ParentId = category.ParentId
                })
                .ToList();
            var rootNode = NodeManager<CategoryViewModel>.CreateTree(categoriesViewModel, node => node.Id, node => node.ParentId).Single();

            categories.ForEach(model =>
                {
                    model.Level = rootNode.All.Where(node => node.Value.Id == model.Id).Select(node => node.Level).FirstOrDefault();
                    model.HasChild = model.Childrens.Any();
                }
            );

            //_categorieRepository.Update(category => new Category
            //{
            //    Level = rootNode.All.Where(node => node.Value.Id == Guid.NewGuid()).Select(node => node.Level).FirstOrDefault(),
            //    HasChild = category.Childrens.Any()
            //});

            _unitOfWork.SaveAllChanges();
        }

        #endregion Public Methods
    }
}