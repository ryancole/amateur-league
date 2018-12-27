using System;

namespace League.Entity.Database
{
    public class Team
    {
        #region Properties

        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        #endregion

        #region Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}
