using System;
using Advertise.Core.Domains.Manufacturers;
using Advertise.Core.Models.Common;
using Advertise.Data.DbContexts;
using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Core.Exceptions;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Manufacturer;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Validators.Manufacturers;

namespace Advertise.Service.Services.Manufacturers
{

    public class ManufacturerService : IManufacturerService
    {
        #region Private Fields

        private readonly IDbSet<Manufacturer> _manufacturerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public ManufacturerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _manufacturerRepository = unitOfWork.Set<Manufacturer>();
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<IList<SelectListItem>> GetAllAsSelectListAsync()
        {
            return await _manufacturerRepository.AsNoTracking()
                .Select(model => new SelectListItem
                {
                    Text = model.Name,
                    Value = model.Id.ToString()
                })
                .ToListAsync();
        }

        public async Task<Manufacturer> FindByIdAsync(Guid id)
        {
            return await _manufacturerRepository.SingleOrDefaultAsync(model => model.Id == id);
        }

        [Validation(typeof(ManufacturerEditValidator),"Edit")]
        public async Task EditByViewMoodelAsync(ManufacturerEditViewModel viewModel)
        {
            var manufaturer = await FindByIdAsync(viewModel.Id);
            if(manufaturer == null)
                throw new ServiceException();

            _mapper.Map(viewModel, manufaturer);
            await _unitOfWork.SaveAllChangesAsync();

        }

        [Validation(typeof(ManufacturerCreateValidator),"Create")]
        public async Task CreateByViewModelAsync(ManufacturerCreateViewModel viewModel)
        {
            var manufaturer = _mapper.Map<Manufacturer>(viewModel);
            _manufacturerRepository.Add(manufaturer);
            await _unitOfWork.SaveAllChangesAsync();
        }

        public IQueryable<Manufacturer> QueryByRequest(ManufacturerSearchRequest request)
        {
            var manufaturers = _manufacturerRepository.AsNoTracking().AsQueryable();

            if (request.Country.HasValue)
                manufaturers = manufaturers.Where(model => model.Country == request.Country);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            return manufaturers.OrderBy($"{request.SortMember} {request.SortDirection}");

        }

        public async Task<int> CountByRequestAsync(ManufacturerSearchRequest request)
        {
            if (request == null)
                throw new ServiceException();

            return await QueryByRequest(request).CountAsync();
        }

        public async Task<IList<Manufacturer>> GetByRequestAsync(ManufacturerSearchRequest request)
        {
            if (request == null)
                throw new ServiceException();

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var manufaturer = await FindByIdAsync(id);
            if (manufaturer == null)
                throw new ServiceException();

            _manufacturerRepository.Remove(manufaturer);
            await _unitOfWork.SaveAllChangesAsync();
        }


        #endregion Public Methods
    }
}