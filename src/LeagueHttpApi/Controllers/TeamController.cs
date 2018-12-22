using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using League.Entity.WebApi;
using League.Data.Sql.Interface;

namespace LeagueHttpApi.Controllers
{
    [ApiController, Route("team")]
    public class TeamController : ControllerBase
    {
        private readonly ILeagueSqlSession m_db;

        public TeamController(ILeagueSqlSession db)
        {
            m_db = db;
        }

        #region Methods

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            var team = await m_db.Teams.GetByIdAsync(id);

            var result = new TeamGetByIdResponse
            {
                Team = team
            };

            return Ok(result);
        }

        #endregion
    }
}
