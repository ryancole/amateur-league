using System;
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

        public static async Task<TeamGetAllResponse> GetAllTeams()
        {
            var response = await m_client.GetAsync("/team");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TeamGetAllResponse>(content);
        }

        #endregion
    }
}
