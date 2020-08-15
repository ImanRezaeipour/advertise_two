using Advertise.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.CategoryOption
{

    public class CategoryOptionViewModel : BaseViewModel
    {
        #region Public Properties

        public string Companies { get; set; }
        public string CompanyInfo { get; set; }
        public string CompanyManagement { get; set; }
        public Guid Id { get; set; }

        public string MyCompany { get; set; }

        public string ProductDescription { get; set; }

        public string Products { get; set; }

        public string ProductsManagement { get; set; }

        [Required]
        public string Title { get; set; }

        public bool? HasPrice { get; set; }

        #endregion Public Properties
    }
}