using System.Threading.Tasks;

using League.Data.Sql;
using League.Entity.WebApi.Response;

namespace LeagueApiFunction.Handlers
{
    public static class TeamHandlers
    {
        #region Properties

        public static async Task<object> GetAll(string parameters)
        {
            var session = new LeagueSqlSession(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=league;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            var teams = await session.Teams.GetAllAsync();

            return new TeamGetAllResponse
            {
                Teams = teams
            };
        }

        #endregion
    }
}
