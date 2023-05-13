using PruebaDiego.Interfaces;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PruebaDiego.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _client;

        public HttpService(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object request)
        {
            return await _client.PostAsJsonAsync(new Uri(url), request);
        }
    }
}