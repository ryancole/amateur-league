using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using League.Entity.WebApi;
using League.Entity.Database;
using League.Data.Sql.Interface;

namespace LeagueHttpApi.Controllers
{
    [ApiController, Route("season-division-membership")]
    public class SeasonDivisionMembershipController : ControllerBase
    {
        private readonly ILeagueSqlSession m_db;

        public SeasonDivisionMembershipController(ILeagueSqlSession db)
        {
            m_db = db;
        }

        #region Methods

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SeasonDivisionMembershipCreateRequest request)
        {
            var parameters = new SeasonDivisionMembership
            {
                TeamId = request.TeamId,
                SeasonDivisionId = request.SeasonDivisionId
            };

            var membership = await m_db.SeasonDivisionMemberships.CreateAsync(parameters);

            m_db.Commit();

            var response = new SeasonDivisionMembershipCreateResponse
            {
                SeasonDivisionMembership = membership
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var memberships = await m_db.SeasonDivisionMemberships.GetAllAsync();

            var response = new SeasonDivisionMembershipGetAllResponse
            {
                SeasonDivisionMemberships = memberships
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBySeasonDivisionAsync([FromBody] SeasonDivisionMembershipGetBySeasonDivisionRequest request)
        {
            var memberships = await m_db.SeasonDivisionMemberships.GetBySeasonDivisionIdAsync(request.SeasonDivisionId);

            var response = new SeasonDivisionMembershipGetBySeasonDivisionResponse
            {
                SeasonDivisionMemberships = memberships
            };

            return Ok(response);
        }

        #endregion
    }
}
