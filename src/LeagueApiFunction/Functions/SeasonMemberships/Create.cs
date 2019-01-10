using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using League.Data.Sql;
using League.Entity.WebApi.Request;
using League.Entity.WebApi.Response;
using League.Entity.Database;

namespace LeagueApiFunction.Functions.SeasonMemberships
{
    public static class Create
    {
        private static readonly string connectionString;

        static Create()
        {
            connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        }

        #region Methods

        [FunctionName("SeasonMembershipCreate")]
        public static async Task<IActionResult> Run([HttpTrigger("POST", Route = "season-membership")] HttpRequest req, ILogger log)
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

            var deserialized = JsonConvert.DeserializeObject<SeasonMembershipCreateRequest>(body);

            using (var session = new LeagueSqlSession(connectionString))
            {
                var memberships = new List<SeasonMembership>();

                foreach (var team in deserialized.TeamIds)
                {
                    var membership = await session.SeasonMemberships.CreateAsync(team, deserialized.SeasonId);

                    memberships.Add(membership);
                }

                session.Commit();

                var response = new SeasonMembershipCreateResponse
                {
                    SeasonMemberships = memberships
                };

                return new JsonResult(response);
            }
        }

        #endregion
    }
}
