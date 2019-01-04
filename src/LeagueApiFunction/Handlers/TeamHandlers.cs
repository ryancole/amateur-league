using System;
using System.Threading.Tasks;

using Newtonsoft.Json;

using League.Data.Sql;
using League.Entity.WebApi.Response;
using League.Entity.WebApi.Parameters;
using League.Entity.Database;

namespace LeagueApiFunction.Handlers
{
    public static class TeamHandlers
    {
        private static string connectionString;

        static TeamHandlers()
        {
            connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        }

        #region Properties

        public static async Task<object> Create(string parameters)
        {
            var session = new LeagueSqlSession(connectionString);

            var deserialized = JsonConvert.DeserializeObject<TeamCreateParameters>(parameters);

            var team = await session.Teams.CreateAsync(new Team
            {
                Name = deserialized.Name
            });

            session.Commit();

            return new TeamCreateResponse
            {
                Team = team
            };
        }

        public static async Task<object> GetAll(string parameters)
        {
            var session = new LeagueSqlSession(connectionString);

            var teams = await session.Teams.GetAllAsync();

            return new TeamGetAllResponse
            {
                Teams = teams
            };
        }

        #endregion
    }
}
