using Advertise.Web.Framework.Configs;
using System;
using System.Web;

namespace Advertise.Web
{

    public class MvcApplication : HttpApplication
    {
        #region Protected Methods

        /// <summary>
        /// Fired before the ASP.NET page framework sends HTTP headers to a requesting client (browser).
        /// </summary>
        protected void Applcation_PreSendRequestHeaders()
        {
        }

        /// <summary>
        /// Fired when the ASP.NET page framework gets the current state (Session state) related to the current request.
        /// </summary>
        protected void Application_AcquireRequestState()
        {
        }

        /// <summary>
        /// Fired when the security module has established the current user's identity as valid. At this point, the user's credentials have been validated.
        /// </summary>
        protected void Application_AuthenticateRequest()
        {
        }

        /// <summary>
        /// Fired when the security module has verified that a user can access resources.
        /// </summary>
        protected void Application_AuthorizeRequest()
        {
        }

        /// <summary>
        /// Fired when an application request is received. It is the first event fired for a request, which is often a page request (URL) that a user enters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">     </param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            StartupConfig.ApplicationBeginRequest();
        }

        /// <summary>
        /// Fired just before an application is destroyed. This is the ideal location for cleaning up previously used resources.
        /// </summary>
        protected void Application_Disposed()
        {
        }

        /// <summary>
        /// Fired when the last instance of an HttpApplication class is destroyed. It is fired only once during an application's lifetime.
        /// </summary>
        protected void Application_End()
        {
        }

        /// <summary>
        /// The last event fired for an application request.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">     </param>
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            StartupConfig.ApplicationEndRequest();
        }

        /// <summary>
        /// Fired when an unhandled exception is encountered within the application.
        /// </summary>
        protected void Application_Error()
        {
            StartupConfig.ApplicationError();
        }

        /// <summary>
        /// Fired when an application initializes or is first called. It is invoked for all HttpApplication object instances.
        /// </summary>
        protected void Application_Init()
        {
            StartupConfig.ApplicationInit();
        }

        /// <summary>
        /// Fired when the ASP.NET page framework has finished executing an event handler.
        /// </summary>
        protected void Application_PostRequestHandlerExecute()
        {
        }

        /// <summary>
        /// Fired before the ASP.NET page framework begins executing an event handler like a page or Web service.
        /// </summary>
        protected void Application_PreRequestHandlerExecute()
        {
        }

        /// <summary>
        /// Fired before the ASP.NET page framework send content to a requesting client (browser).
        /// </summary>
        protected void Application_PreSendContent()
        {
        }

        /// <summary>
        /// Fired when the ASP.NET page framework completes execution of all event handlers. This results in all state modules to save their current state data.
        /// </summary>
        protected void Application_ReleaseRequestState()
        {
        }

        /// <summary>
        /// Fired when the ASP.NET page framework completes an authorization request. It allows caching modules to serve the request from the cache, thus bypassing handler execution.
        /// </summary>
        protected void Application_ResolveRequestCache()
        {
        }

        /// <summary>
        /// Fired when an unhandled exception is encountered within the application.
        /// </summary>
        protected void Application_Start()
        {
            StartupConfig.ApplicationStart();
        }

        /// <summary>
        /// Fired when the ASP.NET page framework completes handler execution to allow caching modules to store responses to be used to handle subsequent requests.
        /// </summary>
        protected void Application_UpdateRequestCache()
        {
        }

        /// <summary>
        /// Fired when a user's session times out, ends, or they leave the application Web site.
        /// </summary>
        protected void Session_End()
        {
            StartupConfig.SessionEnd(Session.SessionID);
        }

        /// <summary>
        /// Fired when a new user visits the application Web site.
        /// </summary>
        protected void Session_Start()
        {
            StartupConfig.SessionStart(Session.SessionID);
        }

        #endregion Protected Methods
    }
}