using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Newsletter
{
    public class NewsletterListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> MeetList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<NewsletterViewModel> Newsletter { get; set; }

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public NewsletterSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}