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
    public partial class ProductCommentController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ProductCommentController(Dummy d) { }

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
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> CreateAjax()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.CreateAjax);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> DeleteAjax()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.DeleteAjax);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> EditApprove()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditApprove);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> EditReject()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditReject);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> List()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.List);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> MyDeleteAjax()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.MyDeleteAjax);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> MyEdit()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.MyEdit);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> MyList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.MyList);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> ApproveAjax()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.ApproveAjax);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> RejectAjax()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.RejectAjax);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ProductCommentController Actions { get { return MVC.ProductComment; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "ProductComment";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "ProductComment";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Create = "Create";
            public readonly string CreateAjax = "CreateAjax";
            public readonly string DeleteAjax = "DeleteAjax";
            public readonly string EditApprove = "EditApprove";
            public readonly string EditReject = "EditReject";
            public readonly string List = "List";
            public readonly string MyDeleteAjax = "MyDeleteAjax";
            public readonly string MyEdit = "MyEdit";
            public readonly string MyList = "MyList";
            public readonly string ApproveAjax = "ApproveAjax";
            public readonly string RejectAjax = "RejectAjax";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Create = "Create";
            public const string CreateAjax = "CreateAjax";
            public const string DeleteAjax = "DeleteAjax";
            public const string EditApprove = "EditApprove";
            public const string EditReject = "EditReject";
            public const string List = "List";
            public const string MyDeleteAjax = "MyDeleteAjax";
            public const string MyEdit = "MyEdit";
            public const string MyList = "MyList";
            public const string ApproveAjax = "ApproveAjax";
            public const string RejectAjax = "RejectAjax";
        }


        static readonly ActionParamsClass_CreateAjax s_params_CreateAjax = new ActionParamsClass_CreateAjax();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CreateAjax CreateAjaxParams { get { return s_params_CreateAjax; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CreateAjax
        {
            public readonly string viewModel = "viewModel";
        }
        static readonly ActionParamsClass_DeleteAjax s_params_DeleteAjax = new ActionParamsClass_DeleteAjax();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DeleteAjax DeleteAjaxParams { get { return s_params_DeleteAjax; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DeleteAjax
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_EditApprove s_params_EditApprove = new ActionParamsClass_EditApprove();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditApprove EditApproveParams { get { return s_params_EditApprove; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditApprove
        {
            public readonly string viewModel = "viewModel";
        }
        static readonly ActionParamsClass_EditReject s_params_EditReject = new ActionParamsClass_EditReject();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditReject EditRejectParams { get { return s_params_EditReject; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditReject
        {
            public readonly string viewModel = "viewModel";
        }
        static readonly ActionParamsClass_List s_params_List = new ActionParamsClass_List();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_List ListParams { get { return s_params_List; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_List
        {
            public readonly string request = "request";
        }
        static readonly ActionParamsClass_MyDeleteAjax s_params_MyDeleteAjax = new ActionParamsClass_MyDeleteAjax();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_MyDeleteAjax MyDeleteAjaxParams { get { return s_params_MyDeleteAjax; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_MyDeleteAjax
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_MyEdit s_params_MyEdit = new ActionParamsClass_MyEdit();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_MyEdit MyEditParams { get { return s_params_MyEdit; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_MyEdit
        {
            public readonly string viewModel = "viewModel";
        }
        static readonly ActionParamsClass_MyList s_params_MyList = new ActionParamsClass_MyList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_MyList MyListParams { get { return s_params_MyList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_MyList
        {
            public readonly string request = "request";
        }
        static readonly ActionParamsClass_ApproveAjax s_params_ApproveAjax = new ActionParamsClass_ApproveAjax();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ApproveAjax ApproveAjaxParams { get { return s_params_ApproveAjax; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ApproveAjax
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_RejectAjax s_params_RejectAjax = new ActionParamsClass_RejectAjax();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_RejectAjax RejectAjaxParams { get { return s_params_RejectAjax; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_RejectAjax
        {
            public readonly string id = "id";
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
                public readonly string _Create = "_Create";
                public readonly string _DetailItem = "_DetailItem";
                public readonly string _DetailListMore = "_DetailListMore";
                public readonly string _Item = "_Item";
                public readonly string _ListMore = "_ListMore";
                public readonly string List = "List";
            }
            public readonly string _Create = "~/Views/ProductComment/_Create.cshtml";
            public readonly string _DetailItem = "~/Views/ProductComment/_DetailItem.cshtml";
            public readonly string _DetailListMore = "~/Views/ProductComment/_DetailListMore.cshtml";
            public readonly string _Item = "~/Views/ProductComment/_Item.cshtml";
            public readonly string _ListMore = "~/Views/ProductComment/_ListMore.cshtml";
            public readonly string List = "~/Views/ProductComment/List.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_ProductCommentController : Advertise.Web.Controllers.ProductCommentController
    {
        public T4MVC_ProductCommentController() : base(Dummy.Instance) { }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Create()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            CreateOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void CreateAjaxOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, Advertise.Core.Models.ProductComment.ProductCommentCreateViewModel viewModel);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> CreateAjax(Advertise.Core.Models.ProductComment.ProductCommentCreateViewModel viewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.CreateAjax);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "viewModel", viewModel);
            CreateAjaxOverride(callInfo, viewModel);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [NonAction]
        partial void DeleteAjaxOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, System.Guid? id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> DeleteAjax(System.Guid? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.DeleteAjax);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DeleteAjaxOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [NonAction]
        partial void EditApproveOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Advertise.Core.Models.ProductComment.ProductCommentEditViewModel viewModel);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> EditApprove(Advertise.Core.Models.ProductComment.ProductCommentEditViewModel viewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditApprove);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "viewModel", viewModel);
            EditApproveOverride(callInfo, viewModel);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void EditRejectOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Advertise.Core.Models.ProductComment.ProductCommentEditViewModel viewModel);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> EditReject(Advertise.Core.Models.ProductComment.ProductCommentEditViewModel viewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditReject);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "viewModel", viewModel);
            EditRejectOverride(callInfo, viewModel);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Advertise.Core.Models.ProductComment.ProductCommentSearchRequest request);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> List(Advertise.Core.Models.ProductComment.ProductCommentSearchRequest request)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.List);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "request", request);
            ListOverride(callInfo, request);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void MyDeleteAjaxOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, System.Guid? id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> MyDeleteAjax(System.Guid? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.MyDeleteAjax);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            MyDeleteAjaxOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [NonAction]
        partial void MyEditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Advertise.Core.Models.ProductComment.ProductCommentEditViewModel viewModel);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> MyEdit(Advertise.Core.Models.ProductComment.ProductCommentEditViewModel viewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.MyEdit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "viewModel", viewModel);
            MyEditOverride(callInfo, viewModel);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void MyListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Advertise.Core.Models.ProductComment.ProductCommentSearchRequest request);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> MyList(Advertise.Core.Models.ProductComment.ProductCommentSearchRequest request)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.MyList);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "request", request);
            MyListOverride(callInfo, request);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ApproveAjaxOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, System.Guid? id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> ApproveAjax(System.Guid? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.ApproveAjax);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ApproveAjaxOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [NonAction]
        partial void RejectAjaxOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, System.Guid? id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> RejectAjax(System.Guid? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.RejectAjax);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            RejectAjaxOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
