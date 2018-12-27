using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using League.Entity.WebApi;
using League.Entity.Database;
using League.Data.Sql.Interface;

namespace LeagueHttpApi.Controllers
{
    [ApiController, Route("season")]
    public class SeasonController : ControllerBase
    {
        private readonly ILeagueSqlSession m_db;

        public SeasonController(ILeagueSqlSession db)
        {
            m_db = db;
        }

        #region Methods

        [HttpPost]
        public async Task<IActionResult> CreateAsync()
        {
            var season = await m_db.Seasons.CreateAsync();

            m_db.Commit();

            var response = new SeasonCreateResponse
            {
                Season = season
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var seasons = await m_db.Seasons.GetAllAsync();

            var response = new SeasonGetAllResponse
            {
                Seasons = seasons
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            var season = await m_db.Seasons.GetByIdAsync(id);

            var response = new SeasonGetByIdResponse
            {
                Season = season
            };

            return Ok(response);
        }

        #endregion
    }
}
