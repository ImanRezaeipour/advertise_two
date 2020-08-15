using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.Seo
{
    public class SeoViewModel : BaseViewModel
    {
        #region Public Properties

        public string EntityId { get; set; }

        public string EntityName { get; set; }

        public Guid Id { get; set; }

        public bool IsActive { get; set; }

        public LanguageType? Language { get; set; }

        public string Slug { get; set; }

        #endregion Public Properties
    }
}