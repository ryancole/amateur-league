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
    public static class GetAll
    {
        private static readonly string connectionString;

        static GetAll()
        {
            connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        }

        #region Methods

        [FunctionName("SeasonGetAll")]
        public static async Task<IActionResult> Run([HttpTrigger("GET", Route = "season")] HttpRequest req, ILogger log)
        {
            using (var session = new LeagueSqlSession(connectionString))
            {
                var seasons = await session.Seasons.GetAllAsync();

                var response = new SeasonGetAllResponse
                {
                    Seasons = seasons
                };

                return new JsonResult(response);
            }
        }

        #endregion
    }
}
