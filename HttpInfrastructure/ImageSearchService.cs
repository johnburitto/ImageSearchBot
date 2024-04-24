using ImageSearchBot.Entities;
using Newtonsoft.Json;

namespace ImageSearchBot.HttpInfrastructure
{
    public class ImageSearchService : IImageSearchService
    {
        public string? BaseAddress { get; set; } = "https://api.bing.microsoft.com/v7.0/images/search";

        private string _key;
        private HttpClient _client;

        public ImageSearchService(string key) 
        { 
            _key = key;
            _client = new HttpClient()
            {
                BaseAddress = new Uri(BaseAddress)
            };
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
        }

        public ImageSearchService(string key, string baseAddress) 
        {
            BaseAddress = baseAddress;
            _key = key;
            _client = new HttpClient()
            {
                BaseAddress = new Uri(BaseAddress)
            };
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
        }

        public async Task<ImageSearchResponse?> Search(string query, int count = 10)
        {
            var response = await _client.GetAsync($"?q={Uri.EscapeDataString(query)}&count={count}&safeSearch=off");

            return JsonConvert.DeserializeObject<ImageSearchResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}
