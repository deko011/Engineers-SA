using System.Net.Http;
using System.Threading.Tasks;

namespace PruebaDiego.Interfaces
{
    public interface IHttpService
    {
        Task<HttpResponseMessage> PostAsync(string url, object request);
    }
}