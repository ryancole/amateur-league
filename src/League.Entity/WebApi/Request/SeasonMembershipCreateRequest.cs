using System.Collections.Generic;

namespace League.Entity.WebApi.Request
{
    public class SeasonMembershipCreateRequest
    {
        #region Properties

        public long SeasonId { get; set; }

        public IEnumerable<long> TeamIds { get; set; }

        #endregion
    }
}
