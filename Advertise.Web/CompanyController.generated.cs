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
    public partial class CompanyController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected CompanyController(Dummy d) { }

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
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> DetailInfoAjax()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.DetailInfoAjax);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Edit()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> GetCountCompanyInCategoryAjax()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetCountCompanyInCategoryAjax);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> GetFileAjax()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetFileAjax);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> GetFileCoverAjax()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetFileCoverAjax);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> IsExistAliasAjax()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.IsExistAliasAjax);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Detail()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Detail);
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
        public CompanyController Actions { get { return MVC.Company; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Company";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Company";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string DetailInfoAjax = "DetailInfoAjax";
            public readonly string Edit = "Edit";
            public readonly string GetAllCompaniesAjax = "GetAllCompaniesAjax";
            public readonly string GetCountCompanyInCategoryAjax = "GetCountCompanyInCategoryAjax";
            public readonly string GetFileAjax = "GetFileAjax";
            public readonly string GetFileCoverAjax = "GetFileCoverAjax";
            public readonly string IsExistAliasAjax = "IsExistAliasAjax";
            public readonly string MyEdit = "MyEdit";
            public readonly string Detail = "Detail";
            public readonly string Near = "Near";
            public readonly string ApproveAjax = "ApproveAjax";
            public readonly string RejectAjax = "RejectAjax";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string DetailInfoAjax = "DetailInfoAjax";
            public const string Edit = "Edit";
            public const string GetAllCompaniesAjax = "GetAllCompaniesAjax";
            public const string GetCountCompanyInCategoryAjax = "GetCountCompanyInCategoryAjax";
            public const string GetFileAjax = "GetFileAjax";
            public const string GetFileCoverAjax = "GetFileCoverAjax";
            public const string IsExistAliasAjax = "IsExistAliasAjax";
            public const string MyEdit = "MyEdit";
            public const string Detail = "Detail";
            public const string Near = "Near";
            public const string ApproveAjax = "ApproveAjax";
            public const string RejectAjax = "RejectAjax";
        }


        static readonly ActionParamsClass_DetailInfoAjax s_params_DetailInfoAjax = new ActionParamsClass_DetailInfoAjax();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DetailInfoAjax DetailInfoAjaxParams { get { return s_params_DetailInfoAjax; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DetailInfoAjax
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Edit s_params_Edit = new ActionParamsClass_Edit();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Edit EditParams { get { return s_params_Edit; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Edit
        {
            public readonly string alias = "alias";
        }
        static readonly ActionParamsClass_GetCountCompanyInCategoryAjax s_params_GetCountCompanyInCategoryAjax = new ActionParamsClass_GetCountCompanyInCategoryAjax();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetCountCompanyInCategoryAjax GetCountCompanyInCategoryAjaxParams { get { return s_params_GetCountCompanyInCategoryAjax; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetCountCompanyInCategoryAjax
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_GetFileAjax s_params_GetFileAjax = new ActionParamsClass_GetFileAjax();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetFileAjax GetFileAjaxParams { get { return s_params_GetFileAjax; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetFileAjax
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_GetFileCoverAjax s_params_GetFileCoverAjax = new ActionParamsClass_GetFileCoverAjax();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetFileCoverAjax GetFileCoverAjaxParams { get { return s_params_GetFileCoverAjax; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetFileCoverAjax
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_IsExistAliasAjax s_params_IsExistAliasAjax = new ActionParamsClass_IsExistAliasAjax();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_IsExistAliasAjax IsExistAliasAjaxParams { get { return s_params_IsExistAliasAjax; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_IsExistAliasAjax
        {
            public readonly string companyAlias = "companyAlias";
        }
        static readonly ActionParamsClass_MyEdit s_params_MyEdit = new ActionParamsClass_MyEdit();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_MyEdit MyEditParams { get { return s_params_MyEdit; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_MyEdit
        {
            public readonly string viewModel = "viewModel";
        }
        static readonly ActionParamsClass_Detail s_params_Detail = new ActionParamsClass_Detail();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Detail DetailParams { get { return s_params_Detail; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Detail
        {
            public readonly string alias = "alias";
            public readonly string slug = "slug";
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
                public readonly string _Item = "_Item";
                public readonly string _ListMore = "_ListMore";
                public readonly string _ProductItemList = "_ProductItemList";
                public readonly string Detail = "Detail";
                public readonly string Edit = "Edit";
                public readonly string Near = "Near";
            }
            public readonly string _Item = "~/Views/Company/_Item.cshtml";
            public readonly string _ListMore = "~/Views/Company/_ListMore.cshtml";
            public readonly string _ProductItemList = "~/Views/Company/_ProductItemList.cshtml";
            public readonly string Detail = "~/Views/Company/Detail.cshtml";
            public readonly string Edit = "~/Views/Company/Edit.cshtml";
            public readonly string Near = "~/Views/Company/Near.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_CompanyController : Advertise.Web.Controllers.CompanyController
    {
        public T4MVC_CompanyController() : base(Dummy.Instance) { }

        [NonAction]
        partial void DetailInfoAjaxOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, string id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> DetailInfoAjax(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.DetailInfoAjax);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DetailInfoAjaxOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [NonAction]
        partial void EditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string alias);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Edit(string alias)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "alias", alias);
            EditOverride(callInfo, alias);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void GetAllCompaniesAjaxOverride(T4MVC_System_Web_Mvc_JsonResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> GetAllCompaniesAjax()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetAllCompaniesAjax);
            GetAllCompaniesAjaxOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [NonAction]
        partial void GetCountCompanyInCategoryAjaxOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, System.Guid? id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> GetCountCompanyInCategoryAjax(System.Guid? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetCountCompanyInCategoryAjax);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            GetCountCompanyInCategoryAjaxOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [NonAction]
        partial void GetFileAjaxOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, System.Guid? id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> GetFileAjax(System.Guid? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetFileAjax);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            GetFileAjaxOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [NonAction]
        partial void GetFileCoverAjaxOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, System.Guid? id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> GetFileCoverAjax(System.Guid? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetFileCoverAjax);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            GetFileCoverAjaxOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [NonAction]
        partial void IsExistAliasAjaxOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, string companyAlias);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> IsExistAliasAjax(string companyAlias)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.IsExistAliasAjax);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "companyAlias", companyAlias);
            IsExistAliasAjaxOverride(callInfo, companyAlias);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [NonAction]
        partial void MyEditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> MyEdit()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.MyEdit);
            MyEditOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void MyEditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Advertise.Core.Models.Company.CompanyEditViewModel viewModel);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> MyEdit(Advertise.Core.Models.Company.CompanyEditViewModel viewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.MyEdit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "viewModel", viewModel);
            MyEditOverride(callInfo, viewModel);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void DetailOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string alias, string slug);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Detail(string alias, string slug)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Detail);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "alias", alias);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "slug", slug);
            DetailOverride(callInfo, alias, slug);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void NearOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Near()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Near);
            NearOverride(callInfo);
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
