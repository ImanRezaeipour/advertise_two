using System.Threading.Tasks;
using System.Web;

namespace Advertise.Service.Managers.Image
{
    public interface IImageValidator
    {
        Task<string> GetFormatImage(HttpPostedFileBase file);
        Task<string> GetFormatAttachment(HttpPostedFileBase file);
    }
}