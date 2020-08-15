namespace Advertise.Web.Framework.Configs
{
    /// <summary>
    /// 
    /// </summary>
    public class EntityFrameworkProfilerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void RegisterEntityFrameworkProfiler()
        {
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
        }
    }
}
