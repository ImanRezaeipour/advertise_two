using Advertise.Core.Constants;
using Advertise.Service.Factories.Locations;
using Advertise.Service.Services.Locations;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class CityController : Controller
    {
        #region Private Fields

        private readonly ICityFactory _cityFactory;
        private readonly ICityService _cityService;

        #endregion Private Fields

        #region Public Constructors

 
        public CityController(ICityFactory cityFactory, ICityService cityService)
        {
            _cityFactory = cityFactory;
            _cityService = cityService;
        }

        #endregion Public Constructors

        #region Public Methods


        public virtual async Task<JsonResult> GetCityAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var cities = await _cityService.GetCityAsSelectListItemAsync(id.Value);
            return Json(AjaxResult.Succeeded(cities), JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<JsonResult> GetStateAjax()
        {
            var states = await _cityService.GetStatesAsync();
            return Json(AjaxResult.Succeeded(states), JsonRequestBehavior.AllowGet);
        }

        public virtual async Task<JsonResult> GetLocationAjax(Guid id)
        {
            var city = await _cityService.GetLocationAsync(id);
            return Json(AjaxResult.Succeeded(city), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}