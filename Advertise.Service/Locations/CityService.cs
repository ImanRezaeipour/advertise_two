using Advertise.Core.Domains.Locations;
using Advertise.Core.Extensions;
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
using Advertise.Service.Managers.Events;

namespace Advertise.Service.Services.Locations
{

    public class CityService : ICityService
    {

        #region Private Fields

        private readonly IDbSet<City> _cityRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="mapper"></param>
        ///  <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        public CityService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _cityRepository = unitOfWork.Set<City>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(CitySearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return  await QueryByRequest(request).CountAsync();
            
        }


        public async Task CreateByViewModelAsync(CityCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException(nameof(viewModel));

            var city = _mapper.Map<City>(viewModel);
            _cityRepository.Add(city);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(city);
        }

        /// <summary>
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid cityId)
        {
            var city = await _cityRepository.AsNoTracking().FirstOrDefaultAsync(model => model.Id == cityId);
            _cityRepository.Remove(city);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityDeleted(city);
        }

        public async Task<CityViewModel> GetLocationAsync(Guid cityId)
        {
            var city =await _cityRepository.FirstOrDefaultAsync(model => model.Id == cityId);
            return _mapper.Map<CityViewModel>(city);
        }


        public async Task EditByViewModelAsync(CityEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var city = await _cityRepository.AsNoTracking().FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, city);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(city);
        }


        public async Task<City> FindByIdAsync(Guid id)
        {
           return  await _cityRepository
                .FirstOrDefaultAsync(model => model.Id == id);
            }


        public async Task<Guid?> GetIdByNameAsync(string cityName)
        {
            return await _cityRepository.AsNoTracking()
                .Where(model => model.Name == cityName && model.IsState == false)
                .Select(model => model.Id)
                .SingleOrDefaultAsync();
        }

        public async Task<City> FindDefaultAsync()
        {
            return  await _cityRepository
                .AsNoTracking()
                .FirstOrDefaultAsync(model => model.Latitude == "0");
            }


        public async Task<IList<City>> GetByRequestAsync(CitySearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

          return  await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public async Task<IList<SelectListItem>> GetCityAsSelectListItemAsync(Guid cityId)
        {
            var request = new CitySearchRequest
            {
                SortDirection = SortDirection.Asc,
                SortMember = SortMember.Name,
                PageSize = PageSize.Count100,
                ParentId = cityId
            };
            var cityList = await GetByRequestAsync(request);
           return  cityList.Select(city => new SelectListItem
            {
                Text = city.Name,
                Value = city.Id.ToString()
            }).ToList();
            }


        public async Task<object> GetStatesAsync()
        {
            var request = new CitySearchRequest
            {
                SortDirection = SortDirection.Asc,
                SortMember = SortMember.Name,
                PageSize = PageSize.Count100,
                IsActive = true,
                IsState = true
            };
            var states = await GetByRequestAsync(request);

            var viewModel = _mapper.Map<List<CityViewModel>>(states);
           return  viewModel.Select(model => new
            {
                model.Name,
                model.ParentId,
                model.Longitude,
                model.Latitude
            }).ToList();
            }

        public async Task<string> GetNameByIdAsync(Guid cityId)
        {
            return (await _cityRepository.AsNoTracking().FirstOrDefaultAsync(model => model.Id == cityId)).Name;
        }


        public IQueryable<City> QueryByRequest(CitySearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var cities = _cityRepository.AsNoTracking().AsQueryable();
           if (request.IsState.HasValue)
                cities = cities.Where(city => city.IsState == request.IsState);
            if (request.IsActive.HasValue)
                cities = cities.Where(city => city.IsActive == request.IsActive);
            if (request.ParentId.HasValue)
                cities = cities.Where(city => city.ParentId == request.ParentId);
            if (request.Term.HasValue())
                cities = cities.Where(city => city.Name == request.Term);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            cities = cities.OrderBy($"{request.SortMember} {request.SortDirection}");

            return cities;
        }


        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods

    }
}