using Advertise.Core.Domains.Locations;
using Advertise.Core.Domains.Receipts;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Address;
using Advertise.Core.Models.City;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Receipt;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Locations;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Validators.Receipts;
using Z.EntityFramework.Plus;

namespace Advertise.Service.Services.Receipts
{
    /// <summary>
    ///
    /// </summary>
    public class ReceiptService : IReceiptService
    {
        #region Private Fields

        private readonly IAddressService _addressService;
        private readonly IBagService _bagService;
        private readonly IMapper _mapper;
        private readonly IDbSet<ReceiptOption> _receiptOptionRepository;

        // private readonly IReceiptOptionService _receiptOptionService;
        private readonly IDbSet<Receipt> _receiptRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="receiptOptionService"></param>
        /// <param name="bagService"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        /// <param name="addressService"></param>
        public ReceiptService(IMapper mapper, IBagService bagService, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IAddressService addressService)
        {
            _mapper = mapper;
            _bagService = bagService;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _addressService = addressService;
            _receiptRepository = unitOfWork.Set<Receipt>();
            _receiptOptionRepository = unitOfWork.Set<ReceiptOption>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<bool> HasByCurrentUserAsync()
        {
          return  await _receiptRepository.AnyAsync(model => model.CreatedById == _webContextManager.CurrentUserId);
            
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(ReceiptSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

          return  await QueryByRequest(request).CountAsync();
            
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ReceiptCreateValidator), "CheckOut")]
        public async Task CreateByViewModel(ReceiptViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var receipt = _mapper.Map<Receipt>(viewModel);

            var bags = await _bagService.GetByUserIdAsync(_webContextManager.CurrentUserId);
            var receiptOptions = bags.Select(model => new ReceiptOption
            {
                CategoryCode = model.Product.Category.Code,
                CategoryTitle = model.Product.Category.Title,
                Code = model.Product.Code,
                CompanyCode = model.Product.Company.Code,
                Count = model.ProductCount,
                CompanyTitle = model.Product.Company.Title,
                PreviousPrice = model.Product.PreviousPrice,
                DiscountPercent = model.Product.DiscountPercent,
                Price = model.Product.Price,
                Title = model.Product.Title,
                TotalPrice = model.ProductCount * model.Product.Price,
                SaledById = model.Product.CreatedById
            }).ToList();

            receipt.Options = receiptOptions;
            receipt.TotalProductsPrice = receiptOptions.Sum(model => model.TotalPrice);

            var address = _mapper.Map<Address>(viewModel.Address);
            if (address == null)
            {
                receipt.Address = null;
            }
            else
            {
                address.City = null;
                address.CityId = viewModel.Address.City.Id;
                receipt.Address = address;
            }

            receipt.CreatedById = _webContextManager.CurrentUserId;
            receipt.IsBuy = false;
            receipt.CreatedById = _webContextManager.CurrentUserId;
            receipt.CreatedOn =DateTime.Now;
            _receiptRepository.Add(receipt);

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="receiptId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid receiptId)
        {
            var receipt = await _receiptRepository.FirstOrDefaultAsync(model => model.Id == receiptId);
            receipt?.Options.Clear();
            _receiptRepository.Remove(receipt);

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="receiptId"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public async Task EditAddressByIdAsync(Guid receiptId, Address address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            var userMeta = await _receiptRepository.FirstOrDefaultAsync(model => model.Id == receiptId);
            if (userMeta != null)
            {
                userMeta.Address.Latitude = address.Latitude;
                userMeta.Address.Longitude = address.Longitude;
                userMeta.Address.Extra = address.Extra;
                userMeta.Address.PostalCode = address.PostalCode;
                userMeta.Address.Street = address.Street;
                userMeta.Address.CityId = address.CityId;
            }

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ReceiptCreateValidator), "CheckOut")]
        public async Task EditByViewModelAsync(ReceiptViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var address = _mapper.Map<Address>(viewModel.Address);

            var receiptOrginal = await _receiptRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            if (address == null)
            {
                viewModel.Address = new AddressCreateViewModel { City = new CityViewModel() };
            }
            else
            {
                viewModel.Address = _mapper.Map<AddressCreateViewModel>(address);
                if (viewModel.Address.City == null)
                    viewModel.Address.City = new CityViewModel();
            }
            await EditAddressByIdAsync(receiptOrginal.Id, address);

            var receiptOptionList = _mapper.Map<List<ReceiptOption>>(receiptOrginal.Options);
            if (receiptOptionList == null)
            {
                _receiptOptionRepository.Where(model => model.ReceiptId == viewModel.Id).Delete();
            }
            else
            {
                _receiptOptionRepository.Where(model => model.ReceiptId == viewModel.Id).Delete();
                receiptOrginal.Options.AddRange(receiptOptionList.ToArray());
            }
             _mapper.Map(viewModel, receiptOrginal);
            receiptOrginal.IsBuy = false;
            
            var bags = await _bagService.GetByUserIdAsync(_webContextManager.CurrentUserId);
            var receiptOptions = bags.Select(model => new ReceiptOption
            {
                CategoryCode = model.Product.Category.Code,
                CategoryTitle = model.Product.Category.Title,
                Code = model.Product.Code,
                CompanyCode = model.Product.Company.Code,
                Count = model.ProductCount,
                CompanyTitle = model.Product.Company.Title,
                PreviousPrice = model.Product.PreviousPrice,
                DiscountPercent = model.Product.DiscountPercent,
                Price = model.Product.Price,
                Title = model.Product.Title,
                TotalPrice = model.ProductCount * model.Product.Price,
            })
                .ToList();
            receiptOrginal.TotalProductsPrice = receiptOptions.Sum(model => model.TotalPrice);

            foreach (var option in receiptOptions)
                receiptOrginal?.Options.Add(option);

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ReceiptCreateValidator), "CheckOut")]
        public async Task FinalUpdateByViewModel(ReceiptViewModel viewModel)
        {
            var exist = await IsExistByUserIdAsync(_webContextManager.CurrentUserId, true);
            var notExist = await IsExistByUserIdAsync(_webContextManager.CurrentUserId, false);
            if ( notExist)
            {
                var reciept = await _receiptRepository.FirstOrDefaultAsync(model =>
                    model.CreatedById == _webContextManager.CurrentUserId && model.IsBuy == false);
                viewModel.Id = reciept.Id;
                await EditByViewModelAsync(viewModel);
            }
            else
                 await CreateByViewModel(viewModel);
           
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="receiptId"></param>
        /// <returns></returns>
        public async Task<Receipt> FindByIdAsync(Guid receiptId)
        {
            return  await _receiptRepository.FirstOrDefaultAsync(model => model.Id == receiptId);
            
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isBuy"></param>
        /// <returns></returns>
        public async Task<Receipt> FindByUserIdAsync(Guid userId, bool? isBuy = null)
        {
            var query = _receiptRepository.AsQueryable().Where(model => model.CreatedById == userId);

            if (isBuy.HasValue)
                query = query.Where(model => model.IsBuy == isBuy.Value);
            return  await query.FirstOrDefaultAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Receipt> FindLastAddressByUserIdAsync(Guid userId)
        {
            return  await _receiptRepository
                .Where(model => model.CreatedById == userId && model.IsBuy == true)
                .OrderByDescending(model => model.CreatedOn)
                .FirstOrDefaultAsync();
            
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<string> GenerateCodeForReceiptAsync()
        {
            var request = new ReceiptSearchRequest
            {
                PageSize = PageSize.All
            };
            var maxCode = await MaxCodeByRequestAsync(request, ReceiptAggregateMember.InvoiceNumber);

            if (maxCode == null)
                return (CodeConst.BeginNumber5Digit);
           return  maxCode.ExtractNumeric();
            
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Address> GetAddressByUserId(Guid userId)
        {
            var receipt = await _receiptRepository
                .Include(model => model.CreatedBy.Meta.Address)
                .FirstOrDefaultAsync(model => model.CreatedById == userId);

            return  receipt?.CreatedBy?.Meta?.Address;
            
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="receiptId"></param>
        /// <returns></returns>
        public async Task<AddressViewModel> GetAddressViewModelAsync(Guid receiptId)
        {
            var receipt = await FindByIdAsync(receiptId);
            var address = await _addressService.FindByIdAsync(receipt.AddressId.GetValueOrDefault()) ?? new Address();
           return  _mapper.Map<AddressViewModel>(address);
        }


        public async Task<IList<Receipt>> GetByRequestAsync(ReceiptSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

           return  await QueryByRequest(request).ToPagedListAsync(request);
            
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsExistByUserIdAsync(Guid userId, bool? isBuy = null)
        {
            var query = _receiptRepository.AsQueryable().Where(model => model.CreatedById == userId);
            if (isBuy.HasValue)
                query = query.Where(model => model.IsBuy == isBuy.Value);
          return  await query.AnyAsync();
            
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="aggregateMember"></param>
        /// <returns></returns>
        public async Task<string> MaxCodeByRequestAsync(ReceiptSearchRequest request, string aggregateMember)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var products = QueryByRequest(request);
            switch (aggregateMember)
            {
                case ReceiptAggregateMember.InvoiceNumber:
                    var memberMax = await products.MaxAsync(model => model.InvoiceNumber);
                    return memberMax;
            }

            return null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<Receipt> QueryByRequest(ReceiptSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var receipts = _receiptRepository.AsNoTracking().AsQueryable();
            if (request.CreatedById.HasValue)
                receipts = receipts.Where(model => model.CreatedById == request.CreatedById);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            receipts = receipts.OrderBy($"{request.SortMember} {request.SortDirection}");

            return receipts;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="receiptId"></param>
        /// <param name="invoiceNumber"></param>
        /// <returns></returns>
        public async Task SetInvoiceNumberAsync(Guid receiptId, string invoiceNumber)
        {
            var receipt = await _receiptRepository.FirstOrDefaultAsync(model => model.Id == receiptId);
            receipt.InvoiceNumber = invoiceNumber;

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="receiptId"></param>
        /// <param name="isBuy"></param>
        /// <returns></returns>
        public async Task SetIsBuyByReceiptIdAsync(Guid receiptId, bool isBuy)
        {
            var receipt = await _receiptRepository.FirstOrDefaultAsync(model => model.Id == receiptId);
            receipt.IsBuy = isBuy;

            await _unitOfWork.SaveAllChangesAsync();
        }

        #endregion Public Methods
    }
}