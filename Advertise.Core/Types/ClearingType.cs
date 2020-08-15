using System.ComponentModel;

namespace Advertise.Core.Types
{
    /// <summary>
    /// انواع روش های تسویه حساب مالی
    /// </summary>
    public enum ClearingType
    {
        [Description("هفتگی")]
        ByWeekly = 1,

        [Description("ماهانه")]
        ByMonthly = 2,

        [Description("اعلام توسط تماس تلفنی")]
        ByPhone = 3,

        [Description("بالاتر از سقف مشخص شده")]
        ByThreshold = 4
    }
}