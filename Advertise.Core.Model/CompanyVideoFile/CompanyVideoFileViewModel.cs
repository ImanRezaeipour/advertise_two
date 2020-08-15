using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.CompanyVideoFile
{
    public class CompanyVideoFileViewModel : BaseViewModel
    {
        #region Public Properties

        public string FileExtension { get; set; }
        public string FileName { get; set; }
        public string FileResolution { get; set; }
        public string FileSize { get; set; }
        public Guid Id { get; set; }
        public bool? IsWatermark { get; set; }
        public int? Order { get; set; }
        public string RejectDescription { get; set; }
        public StateType? State { get; set; }
        public string ThumbName { get; set; }
        public string WatermarkName { get; set; }

        #endregion Public Properties
    }
}