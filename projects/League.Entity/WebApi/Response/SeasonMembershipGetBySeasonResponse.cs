﻿using System.Collections.Generic;
using League.Entity.Database;

namespace League.Entity.WebApi.Response
{
    public class SeasonMembershipGetBySeasonResponse
    {
        #region Properties

        public IReadOnlyCollection<SeasonMembership> SeasonMemberships { get; set; }

        #endregion
    }
}
