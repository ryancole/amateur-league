using System;
using System.Threading.Tasks;

using League.Data.Sql;
using League.Entity.WebApi.Response;

namespace LeagueApiFunction.Handlers
{
    public static class SeasonHandlers
    {
        private static string connectionString;

        static SeasonHandlers()
        {
            connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        }

        #region Properties

        public static async Task<object> Create(string parameters)
        {
            var session = new LeagueSqlSession(connectionString);

            var season = await session.Seasons.CreateAsync();

            return new SeasonCreateResponse
            {
                Season = season
            };
        }

        public static async Task<object> GetAll(string parameters)
        {
            var session = new LeagueSqlSession(connectionString);

            var seasons = await session.Seasons.GetAllAsync();

            return new SeasonGetAllResponse
            {
                Seasons = seasons
            };
        }

        #endregion
    }
}
