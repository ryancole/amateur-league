using System;

namespace League.Entity.Database
{
    public class SeasonWeek
    {
        #region Properties

        public long Id { get; set; }

        public long SeasonId { get; set; }

        public DateTime DateCreated { get; set; }

        #endregion
    }
}
