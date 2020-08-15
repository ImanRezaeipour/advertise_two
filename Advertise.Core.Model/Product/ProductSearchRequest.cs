using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.ModelBinding;

namespace Advertise.Core.Models.Product
{

    public class ProductSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        //public Expression<Func<Domains.Products.Product, string>> GroupBy { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string CategoryAlias { get; set; }
        public string SecondHandCode { get; set; }

        /// <summary>
        /// </summary>
        public Guid? CategoryId { get; set; }

        public Guid? CatalogId { get; set; }

        public IEnumerable<int> Colors { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? CategoryWithMany { get; set; }

        /// <summary>
        /// </summary>
        public Guid? CompanyId { get; set; }

        /// <summary>
        /// </summary>
        public Guid? CreatedById { get; set; }

        public IEnumerable<Guid> Ids { get; set; }

        /// <summary>
        /// </summary>
        public StateType? State { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? StateId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? UserId { get; set; }

        public string Code { get; set; }

        public SellType? Sell { get; set; }

        public int? AvailableCountGreater { get; set; }

        public bool? DistinctByCompanyId { get; set; }
        public bool? IsSecondHand { get; set; }
        public ColorType? ColorType { get; set; }
        public Guid? GuaranteeId { get; set; }

        public string QueryString { get; set; }
        public string Price { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public Dictionary<string, List<string>> SpecificationsDictionary { get; set; }

        #endregion Public Properties
    }
}