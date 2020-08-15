using System.Threading.Tasks;
using Advertise.Core.Domains.Categories;
using Advertise.Core.Events;
using Advertise.Core.Models.Seo;
using Advertise.Core.Types;
using Advertise.Service.Managers.Events;
using Advertise.Service.Services.Seo;

namespace Advertise.Service.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class SeoEvents :
        IEventHandler<EntityDeleted<Category>>
    {
        #region Private Fields

        private readonly ISeoService _seoService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seoService"></param>
        public SeoEvents(ISeoService seoService)
        {
            _seoService = seoService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventMessage"></param>
        public async Task HandleEvent(EntityDeleted<Category> eventMessage)
        {
            var seoViewModel = new SeoCreateViewModel
            {
                IsActive = true,
                EntityId = eventMessage.Entity.Alias,
                EntityName = "Category",
                Language = LanguageType.Persian,
                Slug = eventMessage.Entity.MetaTitle
            };
            await _seoService.CreateByViewModelAsync(seoViewModel);
        }

        #endregion Public Methods
    }
}