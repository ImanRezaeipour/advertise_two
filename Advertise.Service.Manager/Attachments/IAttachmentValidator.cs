using System.Threading.Tasks;
using System.Web;

namespace Advertise.Service.Managers.Attachments
{
    public interface IAttachmentValidator
    {
        Task<string> GetFormatAsync(HttpPostedFileBase file);
        Task<string> GetSizeAsync(HttpPostedFileBase file);
    }
}