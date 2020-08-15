using Advertise.Core.Infrastructure.DependencyManagement;
using Advertise.Service.Initializers.Categories;
using Advertise.Web.Framework.StructureMap;

namespace Advertise.Web.Framework.Configs
{
    public class DataBaseConfig
    {
        #region Public Methods

        public static void RegisterDataBase()
        {
            ContainerManager.Container.GetInstance<ICategoryInitializer>().AddOrUpdate();
            ContainerManager.Container.GetInstance<ICategoryInitializer>().Update();
        }

        #endregion Public Methods
    }
}