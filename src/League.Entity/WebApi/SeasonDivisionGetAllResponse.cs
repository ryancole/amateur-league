using System.Collections.Generic;

using League.Entity.Database;

namespace League.Entity.WebApi
{
    public class SeasonDivisionGetAllResponse
    {
        #region Properties

        public IReadOnlyCollection<SeasonDivision> SeasonDivisions { get; set; }

        #endregion
    }
}
