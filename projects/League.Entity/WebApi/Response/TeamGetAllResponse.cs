using System.Collections.Generic;
using League.Entity.Database;

namespace League.Entity.WebApi.Response
{
    public class TeamGetAllResponse
    {
        #region Properties

        public IReadOnlyCollection<Team> Teams { get; set; }

        #endregion
    }
}
