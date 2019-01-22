using System;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using League.Data.Sql;
using League.Entity.WebApi.Response;

namespace LeagueApiFunction.Functions.Seasons
{
    public static class Create
    {
        private static readonly string connectionString;

        static Create()
        {
            connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        }

        #region Methods

        [FunctionName("SeasonCreate")]
        public static async Task<IActionResult> Run([HttpTrigger("POST", Route = "season")] HttpRequest req, ILogger log)
        {
            using (var session = new LeagueSqlSession(connectionString))
            {
                var season = await session.Seasons.CreateAsync();

                session.Commit();

                var response = new SeasonCreateResponse
                {
                    Season = season
                };

                return new JsonResult(response);
            }
        }

        #endregion
    }
}
