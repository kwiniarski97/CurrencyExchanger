namespace exchange_cli
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using exchange_cli.JsonRespones;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class Api
    {
        private static HttpClient httpClient = new HttpClient();

        public static async Task<Latest> GetCurrentRatesByBaseAsync(string @base)
        {
            Latest jsonLatest = null;
            var response = await httpClient.GetAsync($"https://api.fixer.io/latest?base={@base}");
            if (response.IsSuccessStatusCode)
            {
                jsonLatest = JsonConvert.DeserializeObject<Latest>(await response.Content.ReadAsStringAsync());
            }

            return jsonLatest;
        }
    }
}