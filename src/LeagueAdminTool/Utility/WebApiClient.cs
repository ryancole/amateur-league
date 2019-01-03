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

        public static async Task<TeamCreateResponse> CreateTeamAsync(TeamCreateRequest request)
        {
            var response = await m_client.PostAsync(
                "/team",
                new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TeamCreateResponse>(content);
        }

        public static async Task<SeasonCreateResponse> CreateSeasonAsync()
        {
            var response = await m_client.PostAsync(
                "/season",
                new StringContent(string.Empty, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SeasonCreateResponse>(content);
        }

        public static async Task<TeamGetAllResponse> GetAllTeamsAsync()
        {
            var response = await m_client.GetAsync("/team");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TeamGetAllResponse>(content);
        }

        public static async Task<SeasonGetAllResponse> GetAllSeasonsAsync()
        {
            var response = await m_client.GetAsync("/season");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SeasonGetAllResponse>(content);
        }

        #endregion
    }
}
