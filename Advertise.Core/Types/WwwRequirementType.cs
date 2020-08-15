namespace Advertise.Core.Types
{
    /// <summary>
    /// Represents WWW requirement
    /// </summary>
    public enum WwwRequirementType
    {
        [Descripion("پیش فرض")]
        NoMatter = 0,

        [Descripion("با www باشد")]
        WithWww = 10,

        [Descripion("بدون www باشد")]
        WithoutWww = 20,
    }
}