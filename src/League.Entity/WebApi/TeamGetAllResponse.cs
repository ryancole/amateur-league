using System.Collections.Generic;

using League.Entity.Database;

namespace League.Entity.WebApi
{
    public class TeamGetAllResponse
    {
        public TeamGetAllResponse()
        {
            Teams = new List<Team>();
        }

        #region Properties

        public IReadOnlyCollection<Team> Teams { get; set; }

        #endregion
    }
}
