using System.Net.Http;
using System.Threading.Tasks;

namespace WebAnchor
{
    public class HttpClientWrapper : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return await _httpClient.SendAsync(request).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}