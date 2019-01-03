using System.Collections.Generic;

using League.Entity.Database;

namespace League.Entity.WebApi
{
    public class SeasonGetAllResponse
    {
        public SeasonGetAllResponse()
        {
            Seasons = new List<Season>();
        }

        #region Properties

        public IReadOnlyCollection<Season> Seasons { get; set; }

        #endregion
    }
}
