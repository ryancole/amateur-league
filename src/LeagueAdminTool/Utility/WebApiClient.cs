using System;
using System.Text;
using System.Net.Http;
using System.Configuration;
using System.Threading.Tasks;

using Newtonsoft.Json;

using League.Entity.WebApi.Request;
using League.Entity.WebApi.Response;

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

        private static async Task<string> PostJsonAsync(string url, object data = null)
        {
            // serialize our payload data to json string
            var serialized = JsonConvert.SerializeObject(data);

            // build json payload for request
            var requestContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            // actually dispatch the http request
            var response = await m_client.PostAsync(url, requestContent);

            response.EnsureSuccessStatusCode();

            // read response content to string
            var responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }

        public static async Task<TeamCreateResponse> CreateTeamAsync(TeamCreateRequest request)
        {
            var response = await PostJsonAsync("team", request);

            return JsonConvert.DeserializeObject<TeamCreateResponse>(response);
        }

        public static async Task<SeasonCreateResponse> CreateSeasonAsync()
        {
            var response = await PostJsonAsync("season");

            return JsonConvert.DeserializeObject<SeasonCreateResponse>(response);
        }

        public static async Task<TeamGetAllResponse> GetAllTeamsAsync()
        {
            var response = await m_client.GetStringAsync("team");

            return JsonConvert.DeserializeObject<TeamGetAllResponse>(response);
        }

        public static async Task<SeasonGetAllResponse> GetAllSeasonsAsync()
        {
            var response = await m_client.GetStringAsync("season");

            return JsonConvert.DeserializeObject<SeasonGetAllResponse>(response);
        }

        public static async Task<SeasonMembershipCreateResponse> CreateSeasonMembershipsAsync(SeasonMembershipCreateRequest request)
        {
            var response = await PostJsonAsync("season-membership", request);

            return JsonConvert.DeserializeObject<SeasonMembershipCreateResponse>(response);
        }

        #endregion
    }
}