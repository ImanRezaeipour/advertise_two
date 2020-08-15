using System.Data.Entity.ModelConfiguration;
using Advertise.Core.Domains.Common;

namespace Advertise.Data.Mappings.Common
{
    /// <inheritdoc />
    /// <summary>
    /// class is BaseEntity or Identity
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseConfig<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : class 
    {
        protected BaseConfig()
        {
            PostInitialize();
        }

        protected virtual void PostInitialize()
        {

        }
    }
}