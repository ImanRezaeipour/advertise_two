namespace Advertise.Service.Managers.Attachments
{
    public interface IAttachmentManager
    {
        IAttachmentValidator AttachmentValidator { get; }
    }
}