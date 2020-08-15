using Advertise.Core.Constants;
using Advertise.Service.Services.Companies;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class CompanyTagController : Controller
    {
        #region Private Fields

        private readonly ICompanyTagService _companyTagService;

        #endregion Private Fields

        #region Public Constructors

     
        public CompanyTagController(ICompanyTagService companyTagService)
        {
            _companyTagService = companyTagService;
        }

        #endregion Public Constructors

        #region Public Methods


        public virtual async Task<JsonResult> GetTagsAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var tags = await _companyTagService.GetByCompanyIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(tags), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}