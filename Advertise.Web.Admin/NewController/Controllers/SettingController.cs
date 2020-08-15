using Advertise.Core.Models.Setting;
using Advertise.Service.Factories.Settings;
using Advertise.Service.Services.Settings;
using Advertise.Web.Framework.Extensions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class SettingController : BaseController
    {
        #region Private Fields

        private readonly SettingFactory _settingFactory;
        private readonly SettingService _settingService;

        #endregion Private Fields

        #region Public Constructors

        public SettingController(SettingService settingService, SettingFactory settingFactory)
        {
            _settingService = settingService;
            _settingFactory = settingFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        public virtual async Task<ActionResult> Edit()
        {
            var viewModel = await _settingFactory.PrepareEditViewModel();
            return View(MVC.Setting.Views.Edit, viewModel);
        }


        [HttpPost]
        public virtual async Task<ActionResult> Edit(SettingEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _settingService.EditByViewModel(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Setting.Edit());
        }

        #endregion Public Methods
    }
}