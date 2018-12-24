using System;
using System.Data;
using System.Threading.Tasks;

using League.Entity.Database;
using League.Data.Sql.Utility;

namespace League.Data.Sql.Repository
{
    public class RegularSeasonWeekRepository
    {
        private readonly LeagueSqlSession m_session;

        public RegularSeasonWeekRepository(LeagueSqlSession session)
        {
            m_session = session;
        }

        #region Methods

        public async Task<RegularSeasonWeek> CreateAsync()
        {
            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO RegularSeasonWeek
                                    OUTPUT inserted.*
                                    DEFAULT VALUES";

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<RegularSeasonWeek>();

                        return result;
                    }
                }
            }

            throw new Exception("failed to create week");
        }

        #endregion
    }
}
