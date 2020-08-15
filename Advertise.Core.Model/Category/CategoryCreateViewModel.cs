using Advertise.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Category
{
    public class CategoryCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public string Alias { get; set; }

        public IEnumerable<SelectListItem> CategoryOptionList { get; set; }

        public string Description { get; set; }

        public string ImageFileName { get; set; }

        public string MetaTitle { get; set; }

        public int Order { get; set; }

        public Guid? ParentId { get; set; }

        public string Title { get; set; }

        #endregion Public Properties
    }
}