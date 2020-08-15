using System.Data.Entity.Migrations;
using Advertise.Data.Constants;
using Advertise.Data.DbContexts;
using Advertise.Data.Migrations;

namespace Advertise.Data.DbConfigs
{

    public sealed class ApplicationDbMigrationsConfiguration : DbMigrationsConfiguration<BaseDbContext>
    {
        #region Public Constructors

        /// <summary>
        /// </summary>
        public ApplicationDbMigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            SetSqlGenerator(UowConst.SqlClientNamespace, new ApplicationSqlServerMigrationSqlGenerator());
        }

        #endregion Public Constructors

        #region Protected Methods

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(BaseDbContext context)
        {
        }

        #endregion Protected Methods
    }
}