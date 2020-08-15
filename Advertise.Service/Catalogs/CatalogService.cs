using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web;
using Advertise.Core.Models.Catalog;
using Advertise.Core.Models.Category;
using Advertise.Core.Objects;
using Advertise.Core.Types;
using Advertise.Service.Managers.Events;
using Advertise.Service.Managers.File;
using Advertise.Service.Managers.Html;
using Advertise.Service.Services.Categories;
using Advertise.Service.Services.Products;
using Advertise.Service.Services.WebContext;

namespace Advertise.Service.Services.Catalogs
{

    public class CatalogService : ICatalogService
    {

        #region Private Fields

        private readonly IDbSet<Catalog> _catalogRepository;
         private readonly IProductService _productService;
        private readonly ICatalogSpecificationService _catalogSpecificationService;

        private readonly ICategoryService _categoryService;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <param name="productService"></param>
        /// <param name="eventPublisher"></param>
        /// <param name="categoryService"></param>
        /// <param name="webContextManager"></param>
        /// <param name="catalogSpecificationService"></param>
        public CatalogService(IUnitOfWork unitOfWork, IMapper mapper,IProductService productService, IEventPublisher eventPublisher, ICategoryService categoryService, IWebContextManager webContextManager, ICatalogSpecificationService catalogSpecificationService)
        {
            _unitOfWork = unitOfWork;
            _catalogRepository = unitOfWork.Set<Catalog>();
            _mapper = mapper;
            _eventPublisher = eventPublisher;
            _categoryService = categoryService;
            _webContextManager = webContextManager;
            _productService = productService;
            _catalogSpecificationService = catalogSpecificationService;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(CatalogSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }


        public async Task CreateByViewModelAsync(CatalogCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var catalog = _mapper.Map<Catalog>(viewModel);
            catalog.Description = viewModel.Description.ToSafeHtml();
            catalog.CreatedById = _webContextManager.CurrentUserId;
            catalog.Code = await _productService.GenerateCodeAsync();

            if (viewModel.Features != null)
            {
                var features = _mapper.Map<IList<CatalogFeature>>(viewModel.Features);
                catalog.Features.Clear();
                foreach (var catalogFeature in features)
                {
                    catalog.Features.Add(catalogFeature);
                }
            }

            if (viewModel.Images != null)
            {
                var images = _mapper.Map<IList<CatalogImage>>(viewModel.Images);
                catalog.Images.Clear();
                foreach (var catalogImage in images)
                {
                    catalog.Images.Add(catalogImage);
                }
            }

            var keywords = viewModel.CatalogKeywords;
            var catalogKeywords = new List<CatalogKeyword>();
            if (keywords != null)
            {
                foreach (var keyword in keywords)
                {
                    var catalogKeyword = new CatalogKeyword();
                    Guid isGuid;
                    Guid.TryParse(keyword, out isGuid);
                    if (isGuid != Guid.Empty)
                        catalogKeyword.KeywordId = keyword.ToGuid();
                    else
                        catalogKeyword.Title = keyword;

                    catalogKeywords.Add(catalogKeyword);
                }
                catalog.Keywords = catalogKeywords;
            }

            //  Catalog Specification
            if (viewModel.Specifications != null)
            {
                var catalogSpecifications = new List<CatalogSpecification>();
                foreach (var specification in viewModel.Specifications)
                {
                    if (specification.SpecificationOptionIdList != null)
                    {
                        foreach (var specificationOption in specification.SpecificationOptionIdList)
                        {
                            var catalogSpecification = new CatalogSpecification
                            {
                                SpecificationId = specification.Id,
                                SpecificationOptionId = specificationOption
                            };
                            catalogSpecifications.Add(catalogSpecification);
                        }
                    }
                    else if (specification.Value != null)
                    {
                        var catalogSpecification = new CatalogSpecification
                        {
                            SpecificationId = specification.Id,
                            Value = specification.Value
                        };
                        catalogSpecifications.Add(catalogSpecification);
                    }
                }
                catalog.Specifications = catalogSpecifications;
            }

            _catalogRepository.Add(catalog);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(catalog);
        }


        public async Task CreateByViewModelAsync(CatalogExportViewModel viewModel)
        {
            var catalog = _mapper.Map<Catalog>(viewModel);
             catalog.Code = await _productService.GenerateCodeAsync();
            catalog.CreatedById = _webContextManager.CurrentUserId;
            catalog.Features = new HashSet<CatalogFeature>();

            if (string.IsNullOrEmpty(viewModel.FeatureTitle1) == false)
                catalog.Features.Add(new CatalogFeature
                {
                    Title = viewModel.FeatureTitle1
                });

            if (string.IsNullOrEmpty(viewModel.FeatureTitle2) == false)
                catalog.Features.Add(new CatalogFeature
                {
                    Title = viewModel.FeatureTitle2
                });

            if (string.IsNullOrEmpty(viewModel.FeatureTitle3) == false)
                catalog.Features.Add(new CatalogFeature
                {
                    Title = viewModel.FeatureTitle3
                });

            if (string.IsNullOrEmpty(viewModel.FeatureTitle4) == false)
                catalog.Features.Add(new CatalogFeature
                {
                    Title = viewModel.FeatureTitle4
                });

            if (string.IsNullOrEmpty(viewModel.FeatureTitle5) == false)
                catalog.Features.Add(new CatalogFeature
                {
                    Title = viewModel.FeatureTitle5
                });

            if (viewModel.Specifications == null)
                catalog.Specifications.Clear();
            else
            {
                catalog.Specifications.Clear();
                catalog.Specifications = new HashSet<CatalogSpecification>();
                var specifications = _mapper.Map<IList<CatalogSpecification>>(viewModel.Specifications);
                foreach (var specification in specifications)
                {
                    catalog.Specifications.Add(specification);
                }
            }

            _catalogRepository.Add(catalog);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(catalog);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="catalogId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid catalogId)
        {
            var catalog = await FindByIdAsync(catalogId);
            _catalogRepository.Remove(catalog);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(catalog);
        }


        public async Task EditByViewModelAsync(CatalogEditViewModel viewModel)
        {
            var catalog = await FindByIdAsync(viewModel.Id);
            _mapper.Map(viewModel, catalog);

            catalog.Description = viewModel.Description.ToSafeHtml();

            if (viewModel.Features != null)
            {
                var features = _mapper.Map<IList<CatalogFeature>>(viewModel.Features);
                catalog.Features.Clear();
                foreach (var catalogFeature in features)
                {
                    catalog.Features.Add(catalogFeature);
                }
            }
            else
            {
                catalog.Features.Clear();
            }

            if (viewModel.Images != null)
            {
                var images = _mapper.Map<IList<CatalogImage>>(viewModel.Images);
                catalog.Images.Clear();
                foreach (var catalogImage in images)
                {
                    catalog.Images.Add(catalogImage);
                }
            }
            else
            {
                catalog.Images.Clear();
            }

            var keywords = viewModel.CatalogKeywords;
            var catalogKeywords = new List<CatalogKeyword>();
            if (keywords != null)
            {
                foreach (var keyword in keywords)
                {
                    var catalogKeyword = new CatalogKeyword();
                    Guid isGuid;
                    Guid.TryParse(keyword, out isGuid);
                    if (isGuid != Guid.Empty)
                        catalogKeyword.KeywordId = keyword.ToGuid();
                    else
                        catalogKeyword.Title = keyword;

                    catalogKeywords.Add(catalogKeyword);
                }
                catalog.Keywords.Clear();
                foreach (var catalogKeyword in catalogKeywords)
                {
                    catalog.Keywords.Add(catalogKeyword);
                }
            }
            else
            {
                catalog.Keywords.Clear();
            }

            //  Catalog Specification
            if (viewModel.Specifications != null)
            {
                var catalogSpecifications = new List<CatalogSpecification>();
                foreach (var specification in viewModel.Specifications)
                {
                    if (specification.SpecificationOptionIdList != null)
                    {
                        foreach (var specificationOption in specification.SpecificationOptionIdList)
                        {
                            var catalogSpecification = new CatalogSpecification
                            {
                                SpecificationId = specification.Id,
                                SpecificationOptionId = specificationOption
                            };
                            catalogSpecifications.Add(catalogSpecification);
                        }
                    }
                    else if (specification.Value != null)
                    {
                        var catalogSpecification = new CatalogSpecification
                        {
                            SpecificationId = specification.Id,
                            Value = specification.Value
                        };
                        catalogSpecifications.Add(catalogSpecification);
                    }
                }
                catalog.Specifications.Clear();
                //catalog.Specifications = catalogSpecifications;
                foreach (var catalogSpecification in catalogSpecifications)
                {
                    catalog.Specifications.Add(catalogSpecification);
                }
            }
            else
            {
                catalog.Specifications.Clear();
            }

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(catalog);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="catalogId"></param>
        /// <returns></returns>
        public async Task<Catalog> FindByIdAsync(Guid catalogId)
        {
            return await _catalogRepository.SingleOrDefaultAsync(model => model.Id == catalogId);
        }


        public async Task<IList<Select2Object>> GetAsSelect2ObjectAsync()
        {
            var subCategories = await _categoryService.GetAllChildsByIdAsync(_webContextManager.CurrentCategoryId);

            return _catalogRepository.AsNoTracking()
                .Where(model => subCategories.Contains(model.CategoryId.Value))
                .Select(model => new Select2Object
                {
                    id = model.Id,
                    text = model.Title,
                    related_id = model.CategoryId.Value
                })
                .ToList();
        }


        public async Task<IList<SelectListItem>> GetAsSelectListAsync()
        {
            var subCategories = await _categoryService.GetAllChildsByIdAsync(_webContextManager.CurrentCategoryId);

            return _catalogRepository.AsNoTracking()
                .Where(model => subCategories.Contains(model.CategoryId.Value))
                .Select(model => new SelectListItem
                {
                    Text = model.Title,
                    Value = model.Id.ToString()
                })
                .ToList();
        }


        public async Task<IList<Catalog>> GetByRequestAsync(CatalogSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="catalogId"></param>
        /// <returns></returns>
        public async Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid catalogId)
        {
            return (await _catalogRepository.AsNoTracking()
                    .Where(model => model.Id == catalogId)
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
                    thumbnailUrl = FileConst.ImagesCatalogWebPath.PlusWord(model.ImageFileName),
                    size = new FileInfo(HttpContext.Current.Server.MapPath(FileConst.ImagesCatalogWebPath.PlusWord(model.ImageFileName))).Length.ToString()
                }).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="catalogId"></param>
        /// <returns></returns>
        public async Task<IList<FineUploaderObject>> GetFilesAsFineUploaderModelByIdAsync(Guid catalogId)
        {
            return (await _catalogRepository.AsNoTracking()
                .Include(model => model.Images)
                    .Where(model => model.Id == catalogId)
                    .Select(model => model.Images)
                    .SingleOrDefaultAsync())
                .Select(model => new FineUploaderObject
                {
                    id = model.Id.ToString(),
                    uuid = model.Id.ToString(),
                    name = model.FileName,
                    thumbnailUrl = FileConst.ImagesCatalogWebPath.PlusWord(model.FileName),
                    size = new FileInfo(HttpContext.Current.Server.MapPath(FileConst.ImagesCatalogWebPath.PlusWord(model.FileName))).Length.ToString()
                }).ToList();
        }


        public IQueryable<Catalog> QueryByRequest(CatalogSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var catalog = _catalogRepository.AsNoTracking().AsQueryable();

            if (request.CreatedById != null)
                catalog = catalog.Where(model => model.CreatedById == request.CreatedById);
            if (request.Term.HasValue())
                catalog = catalog.Where(model => model.Title.Contains(request.Term));

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;

            catalog = catalog.OrderBy($"{request.SortMember} {request.SortDirection}");

            return catalog;
        }

        #endregion Public Methods
    }
}