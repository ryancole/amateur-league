using System;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using League.Data.Sql;
using League.Entity.WebApi.Response;

namespace LeagueApiFunction.Functions.Teams
{
    public static class GetAll
    {
        private static readonly string connectionString;

        static GetAll()
        {
            connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        }

        #region Methods

        [FunctionName("TeamGetAll")]
        public static async Task<IActionResult> Run([HttpTrigger("GET", Route = "team")] HttpRequest req, ILogger log)
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
