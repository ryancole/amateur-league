using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using League.Entity.WebApi;
using League.Entity.Database;
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

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TeamCreateRequest request)
        {
            var parameters = new Team
            {
                Name = request.Name
            };

            var team = await m_db.Teams.CreateAsync(parameters);

            m_db.Commit();

            var response = new TeamCreateResponse
            {
                Team = team
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var teams = await m_db.Teams.GetAllAsync();

            var response = new TeamGetAllResponse
            {
                Teams = teams
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            var team = await m_db.Teams.GetByIdAsync(id);

            var response = new TeamGetByIdResponse
            {
                Team = team
            };

            return Ok(response);
        }

        #endregion
    }
}
