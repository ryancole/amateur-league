using System;
using System.Data;
using System.Threading.Tasks;

using League.Entity.Database;
using League.Data.Sql.Utility;

namespace League.Data.Sql.Repository
{
    public class TeamRepository
    {
        private readonly LeagueSqlSession m_session;

        public TeamRepository(LeagueSqlSession session)
        {
            m_session = session;
        }

        #region Methods

        public async Task<LeagueTeam> GetByIdAsync(long id)
        {
            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"SELECT *
                                    FROM Team
                                    WHERE Id = @id";

                cmd.Parameters.Add("id", SqlDbType.BigInt).Value = id;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<LeagueTeam>();

                        return result;
                    }
                }
            }

            throw new Exception($"team not found: {id}");
        }

        #endregion
    }
}
