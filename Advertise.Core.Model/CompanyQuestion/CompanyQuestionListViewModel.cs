using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanyQuestion
{

    public class CompanyQuestionListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<CompanyQuestionViewModel> CompanyQuestions { get; set; }

        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public CompanyQuestionSearchRequest SearchRequest { get; set; }

        public IEnumerable<SelectListItem> SortDirectionList { get; set; }
        public IEnumerable<SelectListItem> StateTypeList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        public bool? IsMySelf { get; set; }

        #endregion Public Properties
    }
}