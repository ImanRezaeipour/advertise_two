using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class ErrorController : BaseController
    {
        #region Public Methods


        public virtual async Task<ActionResult> BadRequest()
        {
            // Don't show IIS custom errors.
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return View(MVC.Error.Views.BadRequest);
        }


        public virtual async Task<ActionResult> Forbidden()
        {
            // Don't show IIS custom errors.
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return View(MVC.Error.Views.Forbidden);
        }


        public virtual async Task<ActionResult> InternalServerError()
        {
            // Don't show IIS custom errors.
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View(MVC.Error.Views.InternalServerError);
        }


        public virtual async Task<ActionResult> MethodNotAllowed()
        {
            // Don't show IIS custom errors.
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
            return View(MVC.Error.Views.MethodNotAllowed);
        }


        public virtual async Task<ActionResult> NotFound()
        {
            // Don't show IIS custom errors.
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View(MVC.Error.Views.NotFound);
        }


        public virtual async Task<ActionResult> Unauthorized()
        {
            // Don't show IIS custom errors.
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return View(MVC.Error.Views.Unauthorized);
        }

        #endregion Public Methods
    }
}