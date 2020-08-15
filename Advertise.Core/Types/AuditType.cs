using System.ComponentModel;

namespace Advertise.Core.Types
{
    /// <summary>
    /// نشان دهنده انواع علمیاتی است که میتواند انجام شود
    /// </summary>
    public enum AuditType
    {
       
        [Description("درج رکود")]
        Create = 1,

        [Description("ویرایش")]
        Edit = 2,

        [Description("حذف فیزیکی")]

        Delete = 3,

        [Description("حذف نرم")]
        SoftDelete = 4,

        [Description("جستجو")]
        Search = 5,

        [Description(" ثبت نام")]
        Register = 6,

        [Description("ویرایش")]
        EditMe = 7

    }
}