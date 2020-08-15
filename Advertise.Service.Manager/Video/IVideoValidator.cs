using System.Threading.Tasks;

namespace Advertise.Service.Validators.Video
{
    public interface IVideoValidator
    {
        Task GetFormatAsync(string file);
    }
}
