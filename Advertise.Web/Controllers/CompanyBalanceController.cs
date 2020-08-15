using Advertise.Core.Constants;
using Advertise.Core.Models.CompanyBalance;
using Advertise.Service.Factories.Companies;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{
    /// <inheritdoc />

    public partial class CompanyBalanceController : BaseController
    {
        #region Private Fields

        private readonly ICompanyBalanceFactory _companyBalanceFactory;
        private readonly ICompanyBalanceService _companyBalanceService;

        #endregion Private Fields

        #region Public Constructors

     
        public CompanyBalanceController(ICompanyBalanceService companyBalanceService, ICompanyBalanceFactory companyBalanceFactory)
        {
            _companyBalanceService = companyBalanceService;
            _companyBalanceFactory = companyBalanceFactory;
        }

        #endregion Public Constructors

        #region Public Methods


      





        [MvcAuthorize(PermissionConst.CanCompanyBalanceGetFileAjax)]
        public virtual async Task<JsonResult> GetFileAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));

            var file = await _companyBalanceService.GetFileAsFineUploaderModelByIdAsync(id.Value);
            return Json(file, JsonRequestBehavior.AllowGet);
        }




        #endregion Public Methods
    }
}