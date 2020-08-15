using Advertise.Core.Domains.Categories;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Category;
using Advertise.Core.Models.Common;
using Advertise.Core.Objects;
using Advertise.Core.Types;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Managers.Events;
using Advertise.Service.Managers.File;
using Advertise.Service.Validators.Categories;
using Advertise.Service.Validators.Product;

namespace Advertise.Service.Services.Categories
{
    /// <summary>
    ///
    /// </summary>
    public class CategoryService : ICategoryService
    {
        #region Private Fields

        private readonly IDbSet<Category> _categoryRepository;
        private readonly ICompanyService _companyService;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        ///   <summary>
        ///
        ///   </summary>
        ///   <param name="mapper"></param>
        ///  <param name="unitOfWork"></param>
        ///  <param name="companyService"></param>
        /// <param name="webContextManager"></param>
        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork, ICompanyService companyService, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _categoryRepository = unitOfWork.Set<Category>();
            _unitOfWork = unitOfWork;
            _companyService = companyService;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<int> CountAllAsync()
        {
            var request = new CategorySearchRequest
            {
                PageSize = PageSize.All,
            };
            var result = await CountByRequestAsync(request);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(CategorySearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var categories = await QueryByRequest(request).CountAsync();

            return categories;
        }

        /// <summary>
        ///ایجاد دسته
        /// </summary>
        /// <param name="viewModel"></param>
        [Validation(typeof(CategoryCreateValidator), "Create")]
        public async Task CreateByViewModelAsync(CategoryCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException(nameof(viewModel));

            var category = _mapper.Map<Category>(viewModel);
            category.IsActive = true;
            category.MetaTitle = category.Title;
            category.MetaDescription = category.Description;
            category.Alias = viewModel.Alias;
            category.Order = viewModel.Order;
            category.CreatedById = _webContextManager.CurrentUserId;
            _categoryRepository.Add(category);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(category);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryAlias"></param>
        /// <returns></returns>
        public async Task DeleteByAliasAsync(string categoryAlias)
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(model => model.Alias == categoryAlias);
            _categoryRepository.Remove(category);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(category);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid categoryId)
        {
            var category = await FindByIdAsync(categoryId);
            _categoryRepository.Remove(category);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(category);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CategoryEditValidator),"Edit")]

        public async Task EditByViewModelAsync(CategoryEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var orginalCategory = await _categoryRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, orginalCategory);
            orginalCategory.ParentId = viewModel.ParentId;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(orginalCategory);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryAlias"></param>
        /// <returns></returns>
        public async Task<Category> FindByAliasAsync(string categoryAlias)
        {
            return await _categoryRepository.FirstOrDefaultAsync(model => model.Alias == categoryAlias);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <returns></returns>
        public async Task<Category> FindByCodeAsync(string categoryCode)
        {
            return await _categoryRepository.FirstOrDefaultAsync(model => model.Code == categoryCode);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<Category> FindByIdAsync(Guid categoryId)
        {
            return await _categoryRepository.FirstOrDefaultAsync(model => model.Id == categoryId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<Category> FindParentAsync(Guid categoryId)
        {
            var child = await _categoryRepository.FirstOrDefaultAsync(model => model.Id == categoryId);
            var parent = await _categoryRepository.FirstOrDefaultAsync(model => model.Id == child.ParentId);

            return parent;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetAllAsSelectListAsync()
        {
            return await _categoryRepository
                .Where(model => model.IsActive == true)
                .Select(model => new SelectListItem
                {
                    Value = model.Id.ToString(),
                    Text = model.Title
                }).ToListAsync();
        }


        public async Task<object> GetAllAsync()
        {
            var request = new CategorySearchRequest
            {
                SortMember = SortMember.HasChild,
                SortDirection = SortDirection.Desc
            };
            var categories = QueryByRequest(request);
            var categoriesViewModel = await categories.ProjectTo<CategoryViewModel>().ToListAsync();
            return categoriesViewModel.Select(model => new
            {
                model.Id,
                model.HasChild,
                model.Title,
                model.Alias,
                model.Icon,
                model.ParentId,
                Type = model.Type.ToString()
            });
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IList<CategoryViewModel>> GetAllSalableTypeAsync()
        {
            var request = new CategorySearchRequest
            {
                SortMember = SortMember.HasChild,
                SortDirection = SortDirection.Desc,
                Type = CategoryType.Salable,
                WithRoot = true
            };
            var categories = QueryByRequest(request);
            return await categories.ProjectTo<CategoryViewModel>().ToListAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IList<Category>> GetByRequestAsync(CategorySearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IList<CategoryViewModel>> GetAsViewModelByRequestAsync(CategorySearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ProjectTo<CategoryViewModel>().ToPagedListAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public async Task<IList<CategoryViewModel>> GetCategoriesByParentId(Guid parentId)
        {
            var request = new CategorySearchRequest
            {
                PageSize = PageSize.All,
                SortMember = SortMember.Title,
                ParentId = parentId,
                IsActive = true
            };
            var categories = QueryByRequest(request);
            var viewModel = await categories.ProjectTo<CategoryViewModel>().ToListAsync();

            return viewModel;
        }


        public async Task<CategoryOption> GetCategoryOptionByIdAsync(Guid id)
        {
            return await _categoryRepository
                  .AsNoTracking()
                  .Include(model => model.CategoryOption)
                  .Where(model => model.Id == id)
                  .Select(model => model.CategoryOption)
                  .FirstOrDefaultAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<IList<Category>> GetChildsByIdAsync(Guid categoryId)
        {
            var childs = await _categoryRepository
                .AsNoTracking()
                .Where(model => model.ParentId == categoryId)
                .ToListAsync();

            return childs;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid categoryId)
        {
            return (await _categoryRepository.AsNoTracking()
                    .Where(model => model.Id == categoryId)
                    .Select(model => new
                    {
                        model.Id,
                        model.ImageFileName
                    }).ToListAsync())
                .Select(model => new FineUploaderObject
                {
                    id = model.Id.ToString(),
                    uuid = model.Id.ToString(),
                    name = model.ImageFileName,
                    thumbnailUrl = FileConst.ImagesWebPath.PlusWord(model.ImageFileName),
                    size = new FileInfo(HttpContext.Current.Server.MapPath(FileConst.ImagesWebPath.PlusWord(model.ImageFileName))).Length.ToString()
                }).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public async Task<Guid> GetIdByAliasAsync(string alias)
        {
            return await _categoryRepository.AsNoTracking()
                .Where(model => model.Alias == alias)
                .Select(model => model.Id)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IList<SelectListItem>> GetMainCategoriesAsSelectListItemAsync()
        {
            var request = new CategorySearchRequest
            {
                PageSize = PageSize.Count100,
                SortMember = SortMember.Title,
                ParentId = (await GetRootAsync()).Id,
                IsActive = true
            };
            var categories = await GetByRequestAsync(request);
            return categories.Select(model => new SelectListItem
            {
                Value = model.Id.ToString(),
                Text = model.Title
            }).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IList<CategoryViewModel>> GetMainCategoriesAsync()
        {
            var request = new CategorySearchRequest
            {
                PageSize = PageSize.Count100,
                SortMember = SortMember.Title,
                ParentId = (await GetRootAsync()).Id,
                IsActive = true
            };
            var categories = QueryByRequest(request);
            return await categories.ProjectTo<CategoryViewModel>().ToListAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="withRoot"></param>
        /// <returns></returns>
        public async Task<IList<Category>> GetParentsByIdAsync(Guid categoryId, bool? withRoot = false)
        {
            var category = await _categoryRepository.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == categoryId);

            if (category == null)
                return null;

            if (category.ParentId == null && category.Level == 0 && withRoot == true)
                return new[] {category};

            if (category.ParentId == null)
                return new List<Category>();

            return new[] {category}.Concat(await GetParentsByIdAsync(category.ParentId.Value, withRoot)).Reverse().ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryAlias"></param>
        /// <returns></returns>
        public async Task<IList<CategoryViewModel>> GetRaletedCategoriesByAliasAsync(string categoryAlias)
        {
            var categoryId = await GetIdByAliasAsync(categoryAlias);
            var categoryChilds = await GetChildsByIdAsync(categoryId);
            var categoryParents = await GetParentsByIdAsync(categoryId, true);
            //if (categoryParents.Capacity > 1)
            //    categoryParents[1].ParentId = null;
            //else
            //    categoryParents[1].ParentId = null;
            var categoryList = _mapper.Map<IList<CategoryViewModel>>(categoryChilds.Union(categoryParents));
            return categoryList;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<Category> GetRootAsync()
        {
            return await _categoryRepository
                .AsNoTracking()
                .FirstOrDefaultAsync(model => model.ParentId == null);
        }

        /// <summary>
        /// لیست دسته های مجاز برای ثبت محصول برای کاربر جاری
        /// </summary>
        /// <returns></returns>
        public async Task<IList<SelectListItem>> GetAllowedAsSelectListAsync()
        {
            var subCategories = await GetAllChildsByIdAsync(_webContextManager.CurrentCategoryId);

            return await _categoryRepository.AsNoTracking()
                .Where(model => subCategories.Contains(model.Id))
                .Select(model => new SelectListItem
                {
                    Text = model.Title,
                    Value = model.Id.ToString()
                })
                .ToListAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Select2Object>> GetAllowedAsSelect2ObjectAsync()
        {
            var rootCategory = await FindByIdAsync(_webContextManager.CurrentCategoryId);
            var allCategories = await _categoryRepository.AsNoTracking().OrderBy(model => model.Order).ToListAsync();
            var subCategories = await GetAllChildsByIdAsync(allCategories, rootCategory);

            return subCategories.Select(model => new Select2Object
            {
                id = model.Id,
                text = model.Title,
                level = model.Level.Value,
                disabled = model.HasChild.Value
            })
                .ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<IList<Guid>> GetAllChildsByIdAsync(Guid categoryId)
        {
            var allCategories = (await GetByRequestAsync(new CategorySearchRequest
            {
                PageSize = PageSize.All
            })).ToList();
            var category = await FindByIdAsync(_webContextManager.CurrentCategoryId);
            return (await GetAllChildsByIdAsync(allCategories, category))
                .Select(model => model.Id)
                .ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryList"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Category>> GetAllChildsByIdAsync(List<Category> categoryList, Category category)
        {
            var childs = categoryList.Where(model => model.ParentId == category.Id).ToList();

            if (childs.Count <= 0)
                return Enumerable.Empty<Category>();

            var childList = new List<Category>();
            foreach (var child in childs)
            {
                childList.AddRange(new[] { child }.Concat(await GetAllChildsByIdAsync(categoryList, child)));
            }

            return childList;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public async Task<object> GetSubCategoriesByParentIdAsync(Guid parentId)
        {
            return await _categoryRepository
                .AsNoTracking()
                .Where(model => model.ParentId == parentId)
                .Select(model => new { model.Id, model.Title })
                .OrderBy(model => model.Title)
                .ToListAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<object> GetSubCatergoriesWithRootByIdAsync(Guid categoryId)
        {
            var categories = await _categoryRepository.AsNoTracking().ToListAsync();
            var category = categories.FirstOrDefault(model => model.Id == categoryId);

            var parentIds = categories.GetAllParentsByIdAsync(category).Select(model => model.Id);
            var childIds = categories.GetAllChildsById(category).Select(model => model.Id);

            var categoryList = _categoryRepository
                .AsNoTracking()
                .AsQueryable()
                .Where(model => model.Id == categoryId || parentIds.Contains(model.Id) || childIds.Contains(model.Id));

            var categoryListViewModel = await categoryList.ProjectTo<CategoryViewModel>().ToListAsync();
            var result = categoryListViewModel.Select(model => new
            {
                model.Id,
                model.HasChild,
                model.Title,
                model.Alias,
                model.Icon,
                model.ParentId,
                Type = model.Type.ToString()
            });

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="alias"></param>
        /// <param name="slug"></param>
        /// <returns></returns>
        public async Task<bool> IsCompareNameAndSlugAsync(string alias, string slug)
        {
            if (string.IsNullOrEmpty(alias))
                return false;

            if (string.IsNullOrEmpty(slug))
                return true;

            var category = await _categoryRepository.AsNoTracking().SingleOrDefaultAsync(model => model.Alias == alias);
            return category.MetaTitle.CastToSlug() == slug;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<bool> IsRootAsync(Guid categoryId)
        {
            return await _categoryRepository.AnyAsync(model => model.Id == categoryId && model.ParentId == null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<Category> QueryByRequest(CategorySearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var categories = _categoryRepository.AsNoTracking().AsQueryable()
                .Include(model => model.CategoryOption);

            if (request.CreatedById.HasValue)
                categories = categories.Where(model => model.CreatedById == request.CreatedById);
            if (request.Term.HasValue())
                categories = categories.Where(model => model.Title.Contains(request.Term) || model.Description.Contains(request.Term));
            if (request.IsActive.HasValue)
                if (request.IsActive.Value || request.IsActive.Value == false)
                    categories = categories.Where(model => model.IsActive == request.IsActive);
            if (request.ParentId.HasValue && request.WithMany == null)
                categories = categories.Where(model => model.ParentId == request.ParentId);
            if (request.ParentId.HasValue && request.WithMany == true)
                categories = categories.Where(model => model.ParentId == request.ParentId).SelectMany(model => model.Childrens);
            if (request.Id.HasValue && request.WithMany == null)
                categories = categories.Where(model => model.Id == request.Id);
            if (request.Id.HasValue && request.WithMany == true)
                categories = categories.Where(model => model.Id == request.Id).SelectMany(model => model.Childrens);
            if (request.Type.HasValue)
                categories = categories.Where(model => model.Type == request.Type);
            if (request.WithRoot == true)
                categories = categories.Where(model => model.ParentId == null);

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;

            categories = categories.OrderBy($"{request.SortMember} {request.SortDirection}");

            return categories;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {
            var category = new Category()
            {
                ParentId = null,
                CreatedById = _webContextManager.CurrentUserId
            };
            _categoryRepository.Add(category);

            await _unitOfWork.SaveAllChangesAsync();
        }

        #endregion Public Methods
    }
}