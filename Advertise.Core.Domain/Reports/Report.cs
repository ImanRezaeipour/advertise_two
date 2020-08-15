using System;
using Advertise.Core.Domains.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Reports
{

    public class Report : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        [Column(TypeName = "xml")]
        public virtual string Content { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual int Order { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// </summary>
        [NotMapped]
        public virtual XElement XmlContent
        {
            get { return XElement.Parse(Content); }
            set { Content = value.ToString(); }
        }

        /// <summary>
        /// </summary>
        public virtual bool? HasChild { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int? Level { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        public virtual Report Parent { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ParentId { get; set; }

        #endregion Public Properties
    }
}