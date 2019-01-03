using System.Collections.Generic;
using League.Entity.Database;

namespace League.Entity.WebApi
{
    public class SeasonDivisionMembershipGetAllResponse
    {
        #region Properties

        public IReadOnlyCollection<SeasonDivisionMembership> SeasonDivisionMemberships { get; set; }

        #endregion
    }
}
