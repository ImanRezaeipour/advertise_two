using Advertise.Core.Domains.Categories;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Domains.Notifications;
using Advertise.Core.Domains.Products;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Notification;
using Advertise.Core.Types;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Managers.Events;

namespace Advertise.Service.Services.Notifications
{

    public class NotificationService : INotificationService
    {
        #region Private Fields

        private readonly IDbSet<Category> _categoryRepository;
        private readonly IDbSet<Company> _companyRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<Notification> _notificationRepository;
        private readonly IDbSet<Product> _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        public NotificationService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _categoryRepository = unitOfWork.Set<Category>();
            _companyRepository = unitOfWork.Set<Company>();
            _productRepository = unitOfWork.Set<Product>();
            _notificationRepository = unitOfWork.Set<Notification>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(NotificationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        public async Task CreateAsync(Guid productId)
        {
            var notification = new Notification();

            var product = await _productRepository.FirstOrDefaultAsync(model => model.Id == productId);
            var companyList = await _companyRepository.Include(model => model.Follows).FirstOrDefaultAsync(model => model.Id == product.CompanyId);
            var userCompanyList = companyList.Follows.Select(model => model.FollowedBy);
            var categoryList = await _categoryRepository.Include(model => model.Follows).FirstOrDefaultAsync(model => model.Id == product.CategoryId);
            var userCategoryList = categoryList.Follows.Select(model => model.FollowedBy);

            var userList = userCompanyList.Concat(userCategoryList);
            foreach (var user in userList)
            {
                notification.CreatedById = user.Id;
                notification.Message = "محصول " + product.Title.PlusWord(" ") + " اضافه شد ";
                notification.TargetId = productId;
                notification.Type = NotificationType.NewProduct;
                notification.TargetTitle = product.Title;
                notification.OwnedById = user.Id;
                notification.IsRead = false;
                notification.CreatedOn = DateTime.Now;
                _notificationRepository.Add(notification);
            }
            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityInserted(notification);
        }

        /// <summary>
        /// ایجاد اعلان جدید
        /// </summary>
        /// <returns></returns>
        public async Task CreateByViewModelAsync()
        {
            var notification = new Notification();

            var product = await _productRepository.FirstOrDefaultAsync(model => model.Id == notification.TargetId.Value);
            var companyList = await _companyRepository.Include(model => model.Follows).FirstOrDefaultAsync(model => model.Id == product.CompanyId);
            var userCompanyList = companyList.Follows.Select(model => model.FollowedBy);
            var categoryList = await _categoryRepository.Include(model => model.Follows).FirstOrDefaultAsync(model => model.Id == product.CategoryId);
            var userCategoryList = categoryList.Follows.Select(model => model.FollowedBy);

            var userList = userCompanyList.Concat(userCategoryList);
            foreach (var user in userList)
            {
                notification.CreatedById = user.Id;
                notification.Message = "محصول  " + notification.TargetTitle.PlusWord(" ") + " اضافه شد ";
                _notificationRepository.Add(notification);
                await _unitOfWork.SaveAllChangesAsync();
            }

            _eventPublisher.EntityInserted(notification);
        }


        public async Task DeleteAllReadByCurrentUserAsync()
        {
            var notifications = await _notificationRepository.Where(model => model.IsRead == true && model.CreatedById == _webContextManager.CurrentUserId).ToListAsync();
            foreach (var notification in notifications)
            {
                _notificationRepository.Remove(notification);
            }

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid notificationId)
        {
            var notification = await _notificationRepository.FirstOrDefaultAsync(model => model.Id == notificationId);
            _notificationRepository.Remove(notification);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(notification);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        public async Task<Notification> FindByIdAsync(Guid notificationId)
        {
            return await _notificationRepository
                 .FirstOrDefaultAsync(model => model.Id == notificationId);
        }


        public async Task<IList<Notification>> GetByRequestAsync(NotificationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }


        public IQueryable<Notification> QueryByRequest(NotificationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var notifications = _notificationRepository.AsNoTracking().AsQueryable();
            if (request.CreatedById.HasValue)
                notifications = notifications.Where(model => model.CreatedById == request.CreatedById);
            if (request.CreatedById.HasValue)
                notifications = notifications.Where(model => model.CreatedById == request.CreatedById);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            notifications = notifications.OrderBy($"{request.SortMember} {request.SortDirection}");

            return notifications;
        }


        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}