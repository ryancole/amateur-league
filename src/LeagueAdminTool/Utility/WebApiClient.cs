using System;
using System.Text;
using System.Net.Http;
using System.Configuration;
using System.Threading.Tasks;

using Newtonsoft.Json;

using League.Entity.WebApi;

namespace LeagueAdminTool.Utility
{
    public static class WebApiClient
    {
        private static readonly Uri m_url;
        private static readonly HttpClient m_client;

        static WebApiClient()
        {
            m_url = new Uri(ConfigurationManager.AppSettings["api"]);
            m_client = new HttpClient();
        }

        #region Methods

        public static async Task<Out> SubmitCommand<Out>(LeagueApiRequestCommand command)
        {
            var request = new LeagueApiRequest
            {
                Command = command
            };

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var content = new StringContent(JsonConvert.SerializeObject(request, settings), Encoding.UTF8, "application/json");

            var response = await m_client.PostAsync(m_url, content);

            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Out>(body);
        }

        public static async Task<Out> SubmitCommand<In, Out>(LeagueApiRequestCommand command, In parameters = null) where In : class
        {
            var request = new LeagueApiRequest
            {
                Command = command,
                SerializedParameters = parameters == null ? null : JsonConvert.SerializeObject(parameters)
            };

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var content = new StringContent(JsonConvert.SerializeObject(request, settings), Encoding.UTF8, "application/json");

            var response = await m_client.PostAsync(m_url, content);

            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Out>(body);
        }

        #endregion
    }
}
