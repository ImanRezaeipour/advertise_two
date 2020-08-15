using Advertise.Core.Domains.Products;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductImage;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Managers.Events;
using Advertise.Service.Managers.File;

namespace Advertise.Service.Services.Products
{

    public class ProductImageService : IProductImageService
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IDbSet<ProductImage> _productImageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventPublisher _eventPublisher;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="eventPublisher"></param>
        public ProductImageService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _productImageRepository = unitOfWork.Set<ProductImage>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<int> CountAllByProductIdAsync(Guid productId)
        {
            var request = new ProductImageSearchRequest
            {
                ProductId = productId
            };
            return await CountByRequestAsync(request);
        }


        public async Task<int> CountByRequestAsync(ProductImageSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var productImages = await QueryByRequest(request).CountAsync();

            return productImages;
        }


        public async Task CreateByViewModelAsync(ProductImageCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productImage = _mapper.Map<ProductImage>(viewModel);
            _productImageRepository.Add(productImage);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityInserted(productImage);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productImageId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid productImageId)
        {
            if (productImageId == null)
                throw new ArgumentNullException(nameof(productImageId));

            var productImage = await _productImageRepository.FirstOrDefaultAsync(model => model.Id == productImageId);
            _productImageRepository.Remove(productImage);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityDeleted(productImage);
        }


        public async Task EditByViewModelAsync(ProductImageEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productImage = await _productImageRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, productImage);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityUpdated(productImage);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productImageId"></param>
        /// <returns></returns>
        public async Task<ProductImage> FindByIdAsync(Guid productImageId)
        {
            if (productImageId == null)
                throw new ArgumentNullException(nameof(productImageId));

            return await _productImageRepository
                 .FirstOrDefaultAsync(model => model.Id == productImageId);
        }


        public IQueryable<ProductImage> QueryByRequest(ProductImageSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var productImages = _productImageRepository.AsNoTracking().AsQueryable()
                .Include(model => model.CreatedBy)
                .Include(model => model.CreatedBy.Meta)
                .Include(model => model.Product.Company);

            if (request.Term.HasValue())
                productImages = productImages.Where(model => model.Product.Company.Title.Contains(request.Term));
            if (request.ProductId.HasValue)
                productImages = productImages.Where(model => model.ProductId == request.ProductId);

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;

            productImages = productImages.OrderBy($"{request.SortMember} {request.SortDirection}");

            return productImages;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<List<FileModel>> GetByProductIdAsFileModelAsync(Guid productId)
        {
            var request = new ProductImageSearchRequest
            {
                ProductId = productId
            };
            var result = await ListByRequestAsync(request);
            return result.ProductImages.Select(s => new FileModel
            {
                Id = s.Id,
                Extension = Path.GetExtension(s.FileName),
                Name = s.FileName,
                Path = Path.Combine(FileConst.ImagesWebPath + s.FileName),
                Size = 0,
                Type = FileConst.FileType
            }).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<IList<ProductImage>> GetByProductIdAsync(Guid productId)
        {
            var requestImage = new ProductImageSearchRequest
            {
                ProductId = productId,
                PageSize = PageSize.Count20
            };
            return await GetByRequestAsync(requestImage);
        }


        public async Task<IList<ProductImage>> GetByRequestAsync(ProductImageSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var productImages = await QueryByRequest(request).ToPagedListAsync(request);

            return productImages;
        }


        public async Task<ProductImageListViewModel> ListByRequestAsync(ProductImageSearchRequest request)
        {
            request.TotalCount = await CountByRequestAsync(request);
            var images = await GetByRequestAsync(request);
            var imageViewModel = _mapper.Map<IList<ProductImageViewModel>>(images);
            return new ProductImageListViewModel
            {
                SearchRequest = request,
                ProductImages = imageViewModel
            };
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productImages"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IList<ProductImage> productImages)
        {
            if (productImages == null)
                throw new ArgumentNullException(nameof(productImages));

            foreach (var productImage in productImages)
                _productImageRepository.Remove(productImage);
        }

        #endregion Public Methods
    }
}