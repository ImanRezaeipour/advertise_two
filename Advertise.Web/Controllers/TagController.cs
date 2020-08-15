using Advertise.Core.Constants;
using Advertise.Core.Models.Tag;
using Advertise.Service.Factories.Tags;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Tags;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class TagController : Controller
    {
        #region Private Fields

        private readonly ITagFactory _tagFactory;
        private readonly ITagService _tagService;

        #endregion Private Fields

        #region Public Constructors


        public TagController(ITagService tag, ITagFactory tagFactory)
        {
            _tagService = tag;
            _tagFactory = tagFactory;
        }

        #endregion Public Constructors

        #region Public Methods


    



        [MvcAuthorize(PermissionConst.CanTagDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _tagService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


      

     

        public virtual async Task<JsonResult> GetFileAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var file = await _tagService.GetFileAsFineUploaderModelByIdAsync(id.Value);
            return Json(file, JsonRequestBehavior.AllowGet);
        }



        #endregion Public Methods
    }
}