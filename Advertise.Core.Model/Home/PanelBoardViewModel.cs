using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Home
{
    public class PanelBoardViewModel : BaseViewModel
    {
        #region Public Properties

        public int AllCategoryCount { get; set; }
        public int AllCompanyCount { get; set; }
        public int ApprovedCompanyCount { get; set; }
        public int RejectedCompanyCount { get; set; }
        public int PendingCompanyCount { get; set; }
        public int AllProductCount { get; set; }
        public int ApprovedProductCount { get; set; }
        public int RejectedProductCount { get; set; }
        public int PendingProductCount { get; set; }
        public int AllUserCount { get; set; }
        public int AllUserOnlineCount { get; set; }
        public int AllVisitCount { get; set; }
        public int ProductApprovedCount { get; set; }
        public int ProductPendingCount { get; set; }
        public int ProductRejectCount { get; set; }
        public decimal ReceiptSum { get; set; }
        public DateTime ServerTime { get; set; }
        public Guid UserId { get; set; }

        #endregion Public Properties
    }
}