using Advertise.Core.Models.Common;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.News
{
    public class NewsListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> ActiveList { get; set; }
        public string Body { get; set; }
        public DateTime CreatedOn { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<NewsViewModel> News { get; set; }

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public NewsSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }
        public string Title { get; set; }

        #endregion Public Properties
    }
}