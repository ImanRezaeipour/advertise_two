namespace Advertise.Service.Managers.Attachments
{
    public class AttachmentManager:IAttachmentManager
    {
        public IAttachmentValidator AttachmentValidator { get; }

        public AttachmentManager(IAttachmentValidator attachmentValidator)
        {
            AttachmentValidator = attachmentValidator;
        }
    }
}
