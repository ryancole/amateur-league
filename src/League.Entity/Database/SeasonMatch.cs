using System;

namespace League.Entity.Database
{
    public class SeasonMatch
    {
        #region Properties

        public long Id { get; set; }

        public long TeamOneId { get; set; }

        public long TeamTwoId { get; set; }

        public long SeasonWeekId { get; set; }

        public DateTime DateCreated { get; set; }

        #endregion
    }
}
