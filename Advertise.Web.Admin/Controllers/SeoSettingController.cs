using Advertise.Core.Models.SeoSetting;
using Advertise.Service.Factories.Seos;
using Advertise.Service.Services.Seo;
using Advertise.Web.Framework.Extensions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Web.Framework.Filters;

namespace Advertise.Web.Controllers
{

    public partial class SeoSettingController : BaseController
    {
        #region Private Fields

        private readonly ISeoSettingFactory _seoSettingFactory;
        private readonly ISeoSettingService _seoSettingService;

        #endregion Private Fields

        #region Public Constructors


        public SeoSettingController(ISeoSettingService seoSettingService, ISeoSettingFactory seoSettingFactory)
        {
            _seoSettingService = seoSettingService;
            _seoSettingFactory = seoSettingFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [ImportModelData(typeof(SeoSettingEditViewModel))]
        public virtual async Task<ActionResult> Edit()
        {
            var viewModel = await _seoSettingFactory.PrepareEditViewModelAsync();
            return View(MVC.SeoSetting.Views.Edit, viewModel);
        }


        [HttpPost]
        public virtual async Task<ActionResult> Edit(SeoSettingEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _seoSettingService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.SeoSetting.Edit());
        }

        #endregion Public Methods
    }
}