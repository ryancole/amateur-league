using System;

namespace League.Entity.Database
{
    public class RegularSeasonMatch
    {
        #region Properties

        public long Id { get; set; }

        public long Week { get; set; }

        public long TeamA { get; set; }

        public long TeamB { get; set; }

        public DateTime DateCreated { get; set; }

        #endregion
    }
}
