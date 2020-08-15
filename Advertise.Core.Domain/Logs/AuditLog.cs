using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Logs
{
    /// <summary>
    ///     نشان دهنده لاگ سیستم
    /// </summary>
    public class AuditLog :BaseEntity
    {
        #region Properties

       
        

        /// <summary>
        ///     gets or sets IP Address of Creator
        /// </summary>
        public virtual string CreatorIp { get; set; }

        /// <summary>
        ///     gets or set IP Address of Modifier
        /// </summary>
        public virtual string ModifierIp { get; set; }

        /// <summary>
        ///     به منظور ممانعت از ویرایش
        /// </summary>
        public virtual bool? IsModifyLock { get; set; }

        /// <summary>
        ///     gets or sets date that this entity was created
        /// </summary>
        /// <summary>
        ///     gets or sets Date that this entity was updated
        /// </summary>
        public virtual DateTime? ModifiedOn { get; set; }



        /// <summary>
        ///     gets or sets information of user agent of modifier
        /// </summary>
        public virtual string ModifierAgent { get; set; }

        /// <summary>
        ///     gets or sets information of user agent of Creator
        /// </summary>
        public virtual string CreatorAgent { get; set; }

       /// <summary>
        ///     gets or sets action (create,update,softDelete)
        /// </summary>
        public virtual AuditType? Audit { get; set; }

        /// <summary>
        ///     sets or gets description of Log
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        ///     sets or gets when log is operated
        /// </summary>
        public virtual DateTime? OperatedOn { get; set; }

        /// <summary>
        ///     sets or gets Type Of Entity
        /// </summary>
        public virtual string Entity { get; set; }

        /// <summary>
        ///     gets or sets  Old value of  Properties before modification
        /// </summary>
        public virtual string XmlOldValue { get; set; }

        /// <summary>
        ///     gets or sets XML Base OldValue of Properties (NotMapped)
        /// </summary>
        [NotMapped]
        public virtual XElement XmlOldValueWrapper
        {
            get { return XElement.Parse(XmlOldValue); }
            set { XmlOldValue = value.ToString(); }
        }

        /// <summary>
        ///     gets or sets new value of  Properties after modification
        /// </summary>
        public virtual string XmlNewValue { get; set; }

        /// <summary>
        ///     gets or sets XML Base NewValue of Properties (NotMapped)
        /// </summary>
        [NotMapped]
        public virtual XElement XmlNewValueWrapper
        {
            get { return XElement.Parse(XmlNewValue); }
            set { XmlNewValue = value.ToString(); }
        }

        /// <summary>
        ///     gets or sets Identifier Of Entity
        /// </summary>
        public virtual string EntityId { get; set; }

        /// <summary>
        ///     gets or sets user agent information
        /// </summary>
        public virtual string Agent { get; set; }

        /// <summary>
        ///     gets or sets user's ip address
        /// </summary>
        public virtual string OperantIp { get; set; }

       #endregion

        #region NavigationProperties

        /// <summary>
        ///     sets or gets log's creator
        /// </summary>
        public virtual User OperantedBy { get; set; }

        /// <summary>
        ///     sets or gets identifier of log's creator
        /// </summary>
        public virtual Guid? OperantedById { get; set; }


        /// <summary>
        ///     به عنوان ایجاد کننده
        /// </summary>
        public virtual User CreatedBy { get; set; }

        /// <summary>
        ///     به عنوان ایجاد کننده
        /// </summary>
        public virtual Guid? CreatedById { get; set; }

        /// <summary>
        ///     به عنوان آخرین تغییر دهنده
        /// </summary>
        public virtual User ModifiedBy { get; set; }

        /// <summary>
        ///     به عنوان آخرین تغییر دهنده
        /// </summary>
        public virtual Guid? ModifiedById { get; set; }



        #endregion
    }
}