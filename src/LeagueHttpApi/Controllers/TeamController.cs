using Microsoft.AspNetCore.Mvc;

namespace LeagueHttpApi.Controllers
{
    [ApiController, Route("team")]
    public class TeamController : ControllerBase
    {
        #region Methods

        [HttpGet]
        public IActionResult Get()
        {
            var result = new[] { 1, 2, 3 };

            return Ok(result);
        }

        #endregion
    }
}
