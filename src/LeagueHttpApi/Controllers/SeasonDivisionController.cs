using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using League.Entity.WebApi;
using League.Entity.Database;
using League.Data.Sql.Interface;

namespace LeagueHttpApi.Controllers
{
    [ApiController, Route("season-division")]
    public class SeasonDivisionController : ControllerBase
    {
        private readonly ILeagueSqlSession m_db;

        public SeasonDivisionController(ILeagueSqlSession db)
        {
            m_db = db;
        }

        #region Methods

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SeasonDivisionCreateRequest request)
        {
            var parameters = new SeasonDivision
            {
                SeasonId = request.SeasonId
            };

            var division = await m_db.SeasonDivisions.CreateAsync(parameters);

            m_db.Commit();

            var response = new SeasonDivisionCreateResponse
            {
                SeasonDivision = division
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var divisions = await m_db.SeasonDivisions.GetAllAsync();

            var response = new SeasonDivisionGetAllResponse
            {
                SeasonDivisions = divisions
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            var division = await m_db.SeasonDivisions.GetByIdAsync(id);

            var response = new SeasonDivisionGetByIdResponse
            {
                SeasonDivision = division
            };

            return Ok(response);
        }

        #endregion
    }
}
