using System.Collections.Generic;

namespace League.Entity.WebApi.Parameters
{
    public class SeasonMembershipCreateParameter
    {
        #region Properties

        public long SeasonId { get; set; }

        public IEnumerable<long> TeamIds { get; set; }

        #endregion
    }
}
