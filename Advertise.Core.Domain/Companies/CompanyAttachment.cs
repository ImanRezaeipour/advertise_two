using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Companies
{

    public class CompanyAttachment : BaseEntity
    {
        #region Properties

        public virtual string Title { get; set; }
        /// <summary>
        /// </summary>
        public virtual string Description { get; set; }

        public virtual int? Order { get; set; }
        /// <summary>
        /// </summary>
        public virtual AttachmentType? Type { get; set; }

        /// <summary>
        ///تائید یا عدم تائید
        /// </summary>
        public virtual StateType? State { get; set; }

        /// <summary>
        /// توضیح برای عدم تائید
        /// </summary>
        public virtual string RejectDescription { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CompanyId { get; set; }

        /// <summary>
        ///     کاربری که نقد و بررسی را تائید کرده است
        /// </summary>
        public virtual User ApprovedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ApprovedById { get; set; }

        public virtual ICollection<CompanyAttachmentFile> AttachmentFiles { get; set; }


        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }


        #endregion
    }
}