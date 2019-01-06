using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;

using League.Data.Sql;
using League.Entity.WebApi.Response;
using League.Entity.WebApi.Parameters;
using League.Entity.Database;

namespace LeagueApiFunction.Handlers
{
    public static class SeasonMembershipHandlers
    {
        private static string connectionString;

        static SeasonMembershipHandlers()
        {
            connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        }

        #region Properties

        public static async Task<object> Create(string parameters)
        {
            var p = JsonConvert.DeserializeObject<SeasonMembershipCreateParameter>(parameters);

            using (var session = new LeagueSqlSession(connectionString))
            {
                var memberships = new List<SeasonMembership>();

                foreach (var team in p.TeamIds)
                {
                    var membership = await session.SeasonMemberships.CreateAsync(team, p.SeasonId);

                    memberships.Add(membership);
                }

                session.Commit();

                return new SeasonMembershipCreateResponse
                {
                    SeasonMemberships = memberships.AsReadOnly()
                };
            }
        }

        public static async Task<object> GetByTeam(string parameters)
        {
            var p = JsonConvert.DeserializeObject<SeasonMembershipGetByTeamParameter>(parameters);

            using (var session = new LeagueSqlSession(connectionString))
            {
                var memberships = await session.SeasonMemberships.GetByTeam(p.TeamId);

                return new SeasonMembershipGetByTeamResponse
                {
                    SeasonMemberships = memberships
                };
            }
        }

        public static async Task<object> GetBySeason(string parameters)
        {
            var p = JsonConvert.DeserializeObject<SeasonMembershipGetBySeasonParameter>(parameters);

            using (var session = new LeagueSqlSession(connectionString))
            {
                var memberships = await session.SeasonMemberships.GetBySeason(p.SeasonId);

                return new SeasonMembershipGetBySeasonResponse
                {
                    SeasonMemberships = memberships
                };
            }
        }

        #endregion
    }
}
