using System;
using System.Data;
using System.Threading.Tasks;

using League.Entity.Database;
using League.Data.Sql.Utility;

namespace League.Data.Sql.Repository
{
    public class SeasonWeekRepository
    {
        private readonly LeagueSqlSession m_session;

        public SeasonWeekRepository(LeagueSqlSession session)
        {
            m_session = session;
        }

        #region Methods

        public async Task<SeasonWeek> CreateAsync(SeasonWeek week)
        {
            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO SeasonWeek (SeasonId)
                                    OUTPUT inserted.*
                                    VALUES (@id)";

                cmd.Parameters.Add("id", SqlDbType.BigInt).Value = week.SeasonId;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<SeasonWeek>();

                        return result;
                    }
                }
            }

            throw new Exception("failed to create season week");
        }

        #endregion
    }
}
