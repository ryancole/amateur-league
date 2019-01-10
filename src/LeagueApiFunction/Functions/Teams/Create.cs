using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using League.Data.Sql;
using League.Entity.WebApi.Response;
using League.Entity.WebApi.Parameters;
using League.Entity.Database;

namespace LeagueApiFunction.Functions.Teams
{
    public static class Create
    {
        private static readonly string connectionString;

        static Create()
        {
            connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        }

        #region Methods

        [FunctionName("TeamCreate")]
        public static async Task<IActionResult> Run([HttpTrigger("POST", Route = "team")] HttpRequest req, ILogger log)
        {
            var body = string.Empty;

            using (var reader = new StreamReader(req.Body))
            {
                body = await reader.ReadToEndAsync();
            }

            if (string.IsNullOrWhiteSpace(body))
            {
                return new BadRequestResult();
            }

            using (var session = new LeagueSqlSession(connectionString))
            {
                var deserialized = JsonConvert.DeserializeObject<TeamCreateParameters>(body);

                var team = await session.Teams.CreateAsync(new Team
                {
                    Name = deserialized.Name
                });

                session.Commit();

                var response = new TeamCreateResponse
                {
                    Team = team
                };

                return new JsonResult(response);
            }
        }

        #endregion
    }
}
