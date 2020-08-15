using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.ProductVisit
{

    public class ProductVisitCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public bool IsVisit { get; set; }
        public Guid ProductId { get; set; }

        #endregion Public Properties
    }
}