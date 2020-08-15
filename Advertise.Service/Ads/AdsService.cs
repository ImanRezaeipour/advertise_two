using Advertise.Core.Exceptions;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Ads;
using Advertise.Core.Models.AdsPayment;
using Advertise.Core.Models.AdsReserve;
using Advertise.Core.Models.Common;
using Advertise.Core.Objects;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web;
using Advertise.Service.Managers.File;

namespace Advertise.Service.Services.Ads
{
    public class AdsService : IAdsService
    {
        #region Private Fields

        private readonly IAdsOptionService _adsOptionService;
        private readonly IAdsPaymentService _adsPaymentService;
        private readonly IDbSet<Core.Domains.Adses.Ads> _adsRepository;
        private readonly IAdsReserveService _adsReserveService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        public AdsService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IAdsOptionService adsOptionService, IAdsPaymentService adsPaymentService, IAdsReserveService adsReserveService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _adsOptionService = adsOptionService;
            _adsPaymentService = adsPaymentService;
            _adsReserveService = adsReserveService;
            _adsRepository = unitOfWork.Set<Core.Domains.Adses.Ads>();
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task ApproveByIdAsync(Guid adsId)
        {
            var ads = await FindByIdAsync(adsId);
            if (ads == null)
                return;

            if (ads.IsApprove == true)
                return;

            ads.IsApprove = true;
            if (ads.DurationType != null)
            {
                var reserveViewModel = new AdsReserveCreateViewModel
                {
                    AdsId = adsId,
                    DurationType = ads.DurationType.Value,
                    AdsOptionId = ads.AdsOptionId
                };
                await _adsReserveService.CreateByViewModelAsync(reserveViewModel);
            }

            await _unitOfWork.SaveAllChangesAsync();
        }

        public async Task<int> CountByRequestAsync(AdsSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        public async Task<PaymentResult> CreateByViewModelAsync(AdsCreateViewModel viewModel, bool? isFreeOfCharge = null)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var ads = _mapper.Map<Core.Domains.Adses.Ads>(viewModel);
            if (viewModel.AdsOptionId != null)
            {
                var option = await _adsOptionService.FindByIdAsync(viewModel.AdsOptionId.Value);
                if (option == null)
                    throw new ServiceException();

                var finalPrice = viewModel.DurationType.ToInt32();
                ads.FinalPrice = option.Price * finalPrice;
            }
            ads.EntityName = "Product";
            if (ads.EntityId == null)
            {
                ads.EntityId = _webContextManager.CurrentCompanyId;
                ads.EntityName = "Company";
            }
            ads.TargetId = ads.EntityId;
            ads.OwnerId = _webContextManager.CurrentUserId;
            ads.IsApprove = isFreeOfCharge == true;
            _adsRepository.Add(ads);

            await _unitOfWork.SaveAllChangesAsync();

            if (isFreeOfCharge == true)
            {
                if (ads.DurationType != null)
                {
                    var reserveViewModel = new AdsReserveCreateViewModel
                    {
                        AdsId = ads.Id,
                        DurationType = ads.DurationType.Value,
                        AdsOptionId = ads.AdsOptionId
                    };
                    await _adsReserveService.CreateByViewModelAsync(reserveViewModel);
                }
                return PaymentResult.Success;
            }
            var zarinpalViewModel = new AdsPaymentCreateViewModel
            {
                Amount = ads.FinalPrice,
                AdsId = ads.Id,
            };
            return await _adsPaymentService.CreateWithZarinpalByViewModelAsync(zarinpalViewModel);
        }

        public async Task EditByViewModelAsync(AdsEditViewModel viewModel)
        {
            var ads = await FindByIdAsync(viewModel.Id);
            if (ads == null)
                throw new ServiceException();

            _mapper.Map(viewModel, ads);
            ads.IsApprove = true;

            await _unitOfWork.SaveAllChangesAsync();
        }

        public async Task<Core.Domains.Adses.Ads> FindByIdAsync(Guid bannerId)
        {
            return await _adsRepository.FirstOrDefaultAsync(model => model.Id == bannerId);
        }

        public async Task<IList<Core.Domains.Adses.Ads>> GetByRequestAsync(AdsSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        public async Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid categoryId)
        {
            return (await _adsRepository.AsNoTracking()
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

        public IQueryable<Core.Domains.Adses.Ads> QueryByRequest(AdsSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var adses = _adsRepository.AsNoTracking().AsQueryable()
                .Include(model => model.AdsOption);

            if (request.OwnerId.HasValue)
                adses = adses.Where(model => model.OwnerId == request.OwnerId);
            if (request.IsApprove.HasValue)
                adses = adses.Where(model => model.IsApprove == request.IsApprove);

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;

            adses = adses.OrderBy($"{request.SortMember} {request.SortDirection}");

            return adses;
        }

        public async Task RejectByIdAsync(Guid adsId)
        {
            var ads = await FindByIdAsync(adsId);
            if (ads == null)
                return;

            ads.IsApprove = false;

            await _unitOfWork.SaveAllChangesAsync();
        }

        #endregion Public Methods
    }
}