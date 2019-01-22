using System.Collections.Generic;
using League.Entity.Database;

namespace League.Entity.WebApi.Response
{
    public class SeasonGetAllResponse
    {
        #region Properties

        public IReadOnlyCollection<Season> Seasons { get; set; }

        #endregion
    }
}
