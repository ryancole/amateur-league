using System;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using League.Data.Sql;
using League.Entity.WebApi.Response;

namespace LeagueApiFunction.Functions.SeasonMemberships
{
    public static class GetBySeason
    {
        private static readonly string connectionString;

        static GetBySeason()
        {
            connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        }

        #region Methods

        [FunctionName("SeasonMembershipGetBySeason")]
        public static async Task<IActionResult> Run([HttpTrigger("GET", Route = "season-membership")] HttpRequest req, ILogger log)
        {
            using (var session = new LeagueSqlSession(connectionString))
            {
                var teams = await session.Teams.GetAllAsync();

                var response = new TeamGetAllResponse
                {
                    Teams = teams
                };

                return new JsonResult(response);
            }
        }

        #endregion
    }
}
