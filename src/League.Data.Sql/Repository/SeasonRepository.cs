using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

using League.Entity.Database;
using League.Data.Sql.Utility;

namespace League.Data.Sql.Repository
{
    public class SeasonRepository
    {
        private readonly LeagueSqlSession m_session;

        public SeasonRepository(LeagueSqlSession session)
        {
            m_session = session;
        }

        #region Methods

        public async Task<Season> CreateAsync()
        {
            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO Season
                                    OUTPUT inserted.*
                                    DEFAULT VALUES";

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<Season>();

                        return result;
                    }
                }
            }

            throw new Exception("failed to create season");
        }

        public async Task<Season> GetByIdAsync(long id)
        {
            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"SELECT *
                                    FROM Season
                                    WHERE Id = @id";

                cmd.Parameters.Add("id", SqlDbType.BigInt).Value = id;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<Season>();

                        return result;
                    }
                }
            }

            throw new Exception($"season not found: {id}");
        }

        public async Task<IReadOnlyCollection<Season>> GetAllAsync()
        {
            var results = new List<Season>();

            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"SELECT *
                                    FROM Season";

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<Season>();

                        results.Add(result);
                    }
                }
            }

            return results.AsReadOnly();
        }

        #endregion
    }
}
