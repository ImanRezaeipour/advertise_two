﻿using System;

namespace Advertise.Core.Domains.Common
{
    public class BaseSlideReserve : BaseEntity
    {
        /// <summary>
        ///     روز نمایش هر اسلاید
        /// </summary>
        public virtual DateTime? Day { get; set; }

    }
}
