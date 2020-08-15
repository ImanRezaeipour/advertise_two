// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Advertise.Web.Controllers
{
    public partial class CompanyFollowController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected CompanyFollowController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> CountAjax()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.CountAjax);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> MyFollowListMoreAjax()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.MyFollowListMoreAjax);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> MyIsFollowAjax()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.MyIsFollowAjax);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> MyToggleAjax()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.MyToggleAjax);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public CompanyFollowController Actions { get { return MVC.CompanyFollow; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "CompanyFollow";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "CompanyFollow";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string CountAjax = "CountAjax";
            public readonly string MyFollowerList = "MyFollowerList";
            public readonly string MyFollowList = "MyFollowList";
            public readonly string MyFollowListMoreAjax = "MyFollowListMoreAjax";
            public readonly string MyIsFollowAjax = "MyIsFollowAjax";
            public readonly string MyToggleAjax = "MyToggleAjax";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string CountAjax = "CountAjax";
            public const string MyFollowerList = "MyFollowerList";
            public const string MyFollowList = "MyFollowList";
            public const string MyFollowListMoreAjax = "MyFollowListMoreAjax";
            public const string MyIsFollowAjax = "MyIsFollowAjax";
            public const string MyToggleAjax = "MyToggleAjax";
        }


        static readonly ActionParamsClass_CountAjax s_params_CountAjax = new ActionParamsClass_CountAjax();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CountAjax CountAjaxParams { get { return s_params_CountAjax; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CountAjax
        {
            public readonly string companyId = "companyId";
        }
        static readonly ActionParamsClass_MyFollowListMoreAjax s_params_MyFollowListMoreAjax = new ActionParamsClass_MyFollowListMoreAjax();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_MyFollowListMoreAjax MyFollowListMoreAjaxParams { get { return s_params_MyFollowListMoreAjax; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_MyFollowListMoreAjax
        {
            public readonly string request = "request";
        }
        static readonly ActionParamsClass_MyIsFollowAjax s_params_MyIsFollowAjax = new ActionParamsClass_MyIsFollowAjax();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_MyIsFollowAjax MyIsFollowAjaxParams { get { return s_params_MyIsFollowAjax; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_MyIsFollowAjax
        {
            public readonly string companyId = "companyId";
        }
        static readonly ActionParamsClass_MyToggleAjax s_params_MyToggleAjax = new ActionParamsClass_MyToggleAjax();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_MyToggleAjax MyToggleAjaxParams { get { return s_params_MyToggleAjax; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_MyToggleAjax
        {
            public readonly string companyId = "companyId";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _FollowerItem = "_FollowerItem";
                public readonly string _FollowerListMore = "_FollowerListMore";
                public readonly string _FollowItem = "_FollowItem";
                public readonly string _FollowListMore = "_FollowListMore";
                public readonly string MyFollowerList = "MyFollowerList";
                public readonly string MyFollowList = "MyFollowList";
            }
            public readonly string _FollowerItem = "~/Views/CompanyFollow/_FollowerItem.cshtml";
            public readonly string _FollowerListMore = "~/Views/CompanyFollow/_FollowerListMore.cshtml";
            public readonly string _FollowItem = "~/Views/CompanyFollow/_FollowItem.cshtml";
            public readonly string _FollowListMore = "~/Views/CompanyFollow/_FollowListMore.cshtml";
            public readonly string MyFollowerList = "~/Views/CompanyFollow/MyFollowerList.cshtml";
            public readonly string MyFollowList = "~/Views/CompanyFollow/MyFollowList.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_CompanyFollowController : Advertise.Web.Controllers.CompanyFollowController
    {
        public T4MVC_CompanyFollowController() : base(Dummy.Instance) { }

        [NonAction]
        partial void CountAjaxOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, System.Guid? companyId);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> CountAjax(System.Guid? companyId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.CountAjax);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "companyId", companyId);
            CountAjaxOverride(callInfo, companyId);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [NonAction]
        partial void MyFollowerListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> MyFollowerList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.MyFollowerList);
            MyFollowerListOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void MyFollowListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> MyFollowList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.MyFollowList);
            MyFollowListOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void MyFollowListMoreAjaxOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, Advertise.Core.Models.CompanyFollow.CompanyFollowSearchRequest request);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> MyFollowListMoreAjax(Advertise.Core.Models.CompanyFollow.CompanyFollowSearchRequest request)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.MyFollowListMoreAjax);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "request", request);
            MyFollowListMoreAjaxOverride(callInfo, request);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [NonAction]
        partial void MyIsFollowAjaxOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, System.Guid? companyId);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> MyIsFollowAjax(System.Guid? companyId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.MyIsFollowAjax);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "companyId", companyId);
            MyIsFollowAjaxOverride(callInfo, companyId);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [NonAction]
        partial void MyToggleAjaxOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, System.Guid? companyId);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> MyToggleAjax(System.Guid? companyId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.MyToggleAjax);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "companyId", companyId);
            MyToggleAjaxOverride(callInfo, companyId);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114