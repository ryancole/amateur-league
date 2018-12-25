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
        private static readonly HttpClient m_client;

        static WebApiClient()
        {
            m_client = new HttpClient();
            m_client.BaseAddress = new Uri(ConfigurationManager.AppSettings["api"]);
        }

        #region Methods

        public static async Task<TeamCreateResponse> CreateAsync(TeamCreateRequest request)
        {
            var response = await m_client.PostAsync(
                "/team",
                new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TeamCreateResponse>(content);
        }

        public static async Task<TeamGetAllResponse> GetAllTeamsAsync()
        {
            var response = await m_client.GetAsync("/team");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TeamGetAllResponse>(content);
        }

        #endregion
    }
}
