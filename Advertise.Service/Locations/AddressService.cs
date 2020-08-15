using Advertise.Core.Extensions;
using Advertise.Core.Models.Address;
using Advertise.Core.Models.City;
using Advertise.Core.Models.Common;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Core.Domains.Locations;
using Advertise.Service.Managers.Events;
using Advertise.Service.Services.WebContext;

namespace Advertise.Service.Services.Locations
{

    public class AddressService : IAddressService
    {

        #region Private Fields

        private readonly IDbSet<Address> _addressRepository;
        private readonly ICityService _cityService;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="cityService"></param>
        public AddressService(IMapper mapper, IUnitOfWork unitOfWork, ICityService cityService, IEventPublisher eventPublisher, IWebContextManager webContextManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cityService = cityService;
            _eventPublisher = eventPublisher;
            _webContextManager = webContextManager;
            _addressRepository = unitOfWork.Set<Address>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(AddressSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
            
        }


        public async Task CreateByViewModelAsync(AddressCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException(nameof(viewModel));

            var address = _mapper.Map<Address>(viewModel);
            address.CreatedById = _webContextManager.CurrentUserId;
            _addressRepository.Add(address);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(address);
        }

        /// <summary>
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid addressId)
        {
            var address = await _addressRepository.FirstOrDefaultAsync(model => model.Id == addressId);
            _addressRepository.Remove(address);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(address);
        }


        public async Task EditByViewModelAsync(AddressEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var orginalAddress = await _addressRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, orginalAddress);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(orginalAddress);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public async Task<Address> FindByIdAsync(Guid addressId)
        {
            return  await _addressRepository.FirstOrDefaultAsync(model => model.Id == addressId);
        }


        public async Task<Address> FindDefaultAsync()
        {
            var address = await _addressRepository
                .AsNoTracking()
                .FirstOrDefaultAsync(model => model.Latitude == "0");

            return address;
        }

        /// <summary>
        /// item1 = lat
        /// item2 = long
        /// item3 = cityname
        /// </summary>
        /// <returns></returns>
        public async Task<Tuple<string, string,string>> GetDefaultLocationAsync()
        {
            return Tuple.Create("35.67751121777174", "51.394007801427506","تهران");
        }


        public async Task<IList<Address>> GetByRequestAsync(AddressSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

           return  await QueryByRequest(request).ToPagedListAsync(request);
        }


        public async Task<IList<SelectListItem>> GetProvinceAsSelectListItemAsync()
        {
            var request = new CitySearchRequest
            {
                SortDirection = SortDirection.Asc,
                SortMember = SortMember.Name,
                PageSize = PageSize.Count100,
                IsState = true,
                IsActive = true
            };
            var cityList = await _cityService.GetByRequestAsync(request);
            return cityList.Select(city => new SelectListItem
            {
                Text = city.Name,
                Value = city.Id.ToString()
            }).ToList();
        }


        public IQueryable<Address> QueryByRequest(AddressSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var addresses = _addressRepository.AsNoTracking().AsQueryable();
            if (request.UserId.HasValue)
                addresses = addresses.Where(address => address.CreatedById == request.UserId);
            return  addresses.OrderBy($"{request.SortMember} {request.SortDirection}");
        }

        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods

    }
}