namespace Advertise.Web.Framework.Configs
{
    public class EntityFrameworkProfilerConfig
    {
        public static void RegisterEntityFrameworkProfiler()
        {
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
        }
    }
}
