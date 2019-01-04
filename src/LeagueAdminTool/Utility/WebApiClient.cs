using System;
using System.Text;
using System.Net.Http;
using System.Configuration;
using System.Threading.Tasks;

using Newtonsoft.Json;

using League.Entity.WebApi;
using League.Entity.WebApi.Response;
using League.Entity.WebApi.Parameters;

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

        private static async Task<string> SubmitCommand(LeagueApiRequestCommand command, object parameters = null)
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

            return body;
        }

        public static async Task<TeamCreateResponse> CreateTeamAsync(TeamCreateParameters request)
        {
            var parameters = new TeamCreateParameters
            {
                Name = request.Name
            };

            var response = await SubmitCommand(LeagueApiRequestCommand.TeamCreate, parameters);

            return JsonConvert.DeserializeObject<TeamCreateResponse>(response);
        }

        public static async Task<SeasonCreateResponse> CreateSeasonAsync()
        {
            var response = await SubmitCommand(LeagueApiRequestCommand.SeasonCreate);

            return JsonConvert.DeserializeObject<SeasonCreateResponse>(response);
        }

        public static async Task<TeamGetAllResponse> GetAllTeamsAsync()
        {
            var response = await SubmitCommand(LeagueApiRequestCommand.TeamGetAll);

            return JsonConvert.DeserializeObject<TeamGetAllResponse>(response);
        }

        public static async Task<SeasonGetAllResponse> GetAllSeasonsAsync()
        {
            var response = await SubmitCommand(LeagueApiRequestCommand.SeasonGetAll);

            return JsonConvert.DeserializeObject<SeasonGetAllResponse>(response);
        }

        #endregion
    }
}
