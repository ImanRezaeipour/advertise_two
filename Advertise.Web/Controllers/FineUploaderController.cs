using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Advertise.Service.Managers.File;

namespace Advertise.Web.Controllers
{

    public partial class FineUploaderController : Controller
    {
        #region Private Fields

        private readonly IFileManager _fileManager;

        #endregion Private Fields

        #region Public Constructors

   
        public FineUploaderController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        #endregion Public Constructors

        #region Public Methods


        [HttpDelete]
        [Route("{lang}/upload/remove-image/{uuid}")]
        public virtual async Task<ActionResult> Remove(Guid uuid)
        {
            var result = new
            {
                success = true
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpDelete]
        [Route("{lang}/upload/remove-attachment/{uuid}")]
        public virtual async Task<ActionResult> RemoveAttachment(Guid uuid)
        {
            var result = new
            {
                success = true
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpDelete]
        [Route("{lang}/upload/remove-video/{uuid}")]
        public virtual async Task<ActionResult> RemoveVideo(Guid uuid)
        {
            var result = new
            {
                success = true
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

     
        [HttpPost]
        [Route("{lang}/upload/save-attachment")]
        public virtual async Task<ActionResult> SaveToAttachmentWeb(IEnumerable<HttpPostedFileBase> qqfile)
        {
            if (qqfile == null || !qqfile.Any())
            {
                var badRequest = new
                {
                    success = false
                };
                return Json(badRequest, JsonRequestBehavior.AllowGet);
            }

            var path = Server.MapPath(FileConst.AttachmentPath);
            var file = await _fileManager.SaveAttachmentAsync(qqfile, path);
            var result = new
            {
                success = true,
                result = file
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    
        [HttpPost]
        [Route("{lang}/upload/save-image")]
        public virtual async Task<ActionResult> SaveToImageWeb(IEnumerable<HttpPostedFileBase> qqfile, ImageProcessType imageType)
        {
            if (qqfile == null || !qqfile.Any())
            {
                var badRequest = new
                {
                    success = false
                };
                return Json(badRequest, JsonRequestBehavior.AllowGet);
            }

            var path = Server.MapPath(FileConst.ImagesWebPath);
            var file = await _fileManager.SaveImageAsync(qqfile, path, imageType);
            var result = new
            {
                success = true,
                result = file
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [Route("{lang}/upload/save-imageCatalog")]
        public virtual async Task<ActionResult> SaveToImageCatalogWeb(IEnumerable<HttpPostedFileBase> qqfile, ImageProcessType imageType)
        {
            if (qqfile == null || !qqfile.Any())
            {
                var badRequest = new
                {
                    success = false
                };
                return Json(badRequest, JsonRequestBehavior.AllowGet);
            }

            var path = Server.MapPath(FileConst.ImagesCatalogWebPath);
            var file = await _fileManager.SaveImageAsync(qqfile, path, imageType);
            var result = new
            {
                success = true,
                result = file
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

       
        [HttpPost]
        [Route("{lang}/upload/save-video")]
        public virtual async Task<ActionResult> SaveToVideoWeb(IEnumerable<HttpPostedFileBase> qqfile)
        {
            if (qqfile == null || !qqfile.Any())
            {
                var badRequest = new
                {
                    success = false
                };
                return Json(badRequest, JsonRequestBehavior.AllowGet);
            }

            var path = Server.MapPath(FileConst.VideosWebPath);
            var file = await _fileManager.SaveVideoAsync(qqfile, path);
            var result = new
            {
                success = true,
                result = file
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}