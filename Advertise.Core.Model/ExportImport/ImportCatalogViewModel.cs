using Advertise.Core.Models.Common;
using System;
using System.Web;

namespace Advertise.Core.Models.ExportImport
{

    public class ImportCatalogViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public HttpPostedFileBase CatalogFile { get; set; }

        #endregion Public Properties
    }
}