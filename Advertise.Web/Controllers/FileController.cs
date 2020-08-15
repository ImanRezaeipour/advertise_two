using Advertise.Core.Constants;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Advertise.Service.Managers.File;

namespace Advertise.Web.Controllers
{

    public partial class FileController : BaseController
    {
        #region Private Fields

        private readonly IFileManager _fileManager;

        #endregion Private Fields

        #region Public Constructors

      
        public FileController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        #endregion Public Constructors

        #region Public Methods

    
        [HttpPost]
        [MvcAuthorize(PermissionConst.CanFileCreateFromUploadAjax)]
        public virtual async Task<JsonResult> CreateFromUploadAjax(string name, string path)
        {
            var webPath = Path.Combine(Server.MapPath(FileConst.UploadPath), path);
            var folder = await _fileManager.CreateAsync(name, webPath);
            var thumbPath = Path.Combine(Server.MapPath(FileConst.ThumbPath), path);
            var thumbFolder = await _fileManager.CreateAsync(name, thumbPath);
            return Json(AjaxResult.Succeeded(folder), JsonRequestBehavior.AllowGet);
        }

    
        [HttpPost]
        public virtual async Task<JsonResult> DeleteFromImageWebAjax(string[] fileNames)
        {
            var path = Server.MapPath(FileConst.ImagesWebPath);
            await _fileManager.DeleteAsync(fileNames, path);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

      
        [HttpPost]
        public virtual async Task<JsonResult> DeleteFromUploadAjax(string[] fileNames)
        {
            var path = Server.MapPath(FileConst.UploadPath);
            await _fileManager.DeleteAsync(fileNames, path);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

      
        [MvcAuthorize(PermissionConst.CanFileGetFileFromThumb)]
        public virtual async Task<FileResult> GetFileFromThumb(string path)
        {
            return await _fileManager.GetFileFromThumbAsync(path);
        }

      
        [MvcAuthorize(PermissionConst.CanFileGetFileFromUpload)]
        public virtual async Task<FileResult> GetFileFromUpload(string path)
        {
            var name = Path.GetFileName(path);
            if (name == null)
                return null;

            var directory = Path.GetDirectoryName(path);
            if (directory == null)
                return null;

            path = Path.Combine(Server.MapPath(FileConst.UploadPath), directory, name);
            return File(path, "image/png");
        }

     
        [MvcAuthorize(PermissionConst.CanFileListFromUploadAjax)]
        public virtual async Task<JsonResult> ListFromUploadAjax(string path)
        {
            if (path == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            path = Path.Combine(Server.MapPath(FileConst.UploadPath), path);
            var files = await _fileManager.GetListAsync(path);
            return Json(AjaxResult.Succeeded(files), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [MvcAuthorize(PermissionConst.CanFileRemoveAjax)]
        public virtual async Task<JsonResult> RemoveAjax()
        {
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

   
        [HttpPost]
        public virtual async Task<JsonResult> SaveFromAttachmentAjax(IEnumerable<HttpPostedFileBase> files)
        {
            var path = Server.MapPath(FileConst.AttachmentPath);
            await _fileManager.SaveAsync(files, path);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

    
        [HttpPost]
        public virtual async Task<JsonResult> SaveFromImageWebAjax(IEnumerable<HttpPostedFileBase> files)
        {
            var path = Server.MapPath(FileConst.ImagesWebPath);
            var result = await _fileManager.SaveAsync(files, path);
            return Json(AjaxResult.Succeeded(result), JsonRequestBehavior.AllowGet);
        }

       
        [HttpPost]
        public virtual async Task<JsonResult> SaveFromUploadAjax(IEnumerable<HttpPostedFileBase> files)
        {
            var path = Server.MapPath(FileConst.UploadPath);
            await _fileManager.SaveAsync(files, path);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

     
        [MvcAuthorize(PermissionConst.CanFileSaveFromUploaderAjax)]
        public virtual async Task<JsonResult> SaveFromUploaderAjax(HttpPostedFileBase file, string path)
        {
            if (file == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var result = await _fileManager.SaveFromUploaderAsync(file, path);
            var kendo = new
            {
                result.Name,
                result.Size,
                result.Type
            };
            return Json(AjaxResult.Succeeded(kendo), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}