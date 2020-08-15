using System;
using System.Data.Entity.Core.Mapping;
using System.Web;
using Advertise.Core.Infrastructure.DependencyManagement;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.WebContext;

namespace Advertise.Service.Services.Products
{
    /// <summary>
    /// 
    /// </summary>
    public static  class ProductExtensions
    {
        public static IProductService ProductService { get; set; } = ContainerManager.Container.GetInstance<IProductService>();
        public static IWebContextManager WebContextManager { get; set; } = ContainerManager.Container.GetInstance<IWebContextManager>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static bool CanEditThisProduct(this Guid productId)
        {
            if (HttpContext.Current.User.IsInRole(PermissionConst.CanProductEdit))
                return true;
            
            var product = ProductService.GetByIdAsync(productId);
            if(HttpContext.Current.User.IsInRole(PermissionConst.CanProductMyEdit) && product.CreatedById == WebContextManager.CurrentUserId)
                return true;

            return false;
        }
    }
}
