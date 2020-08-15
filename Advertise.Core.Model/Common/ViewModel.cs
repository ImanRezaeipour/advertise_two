using Advertise.Core.Types;

namespace Advertise.Core.Models.Common
{

    public abstract class ViewModel
    {
        #region Public Properties

        /// <summary>
        /// نوع اکشن انجام شده
        /// </summary>
        public AuditType? Audit { get; set; }

        #endregion Public Properties
    }
}