using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

using League.Entity.Database;
using League.Data.Sql.Utility;

namespace League.Data.Sql.Repository
{
    public class SeasonDivisionRepository
    {
        private readonly LeagueSqlSession m_session;

        public SeasonDivisionRepository(LeagueSqlSession session)
        {
            m_session = session;
        }

        #region Methods

        public async Task<SeasonDivision> CreateAsync(SeasonDivision division)
        {
            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO SeasonDivision (SeasonId)
                                    OUTPUT inserted.*
                                    VALUES (@season)";

                cmd.Parameters.Add("season", SqlDbType.BigInt).Value = division.SeasonId;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<SeasonDivision>();

                        return result;
                    }
                }
            }

            throw new Exception("failed to create season division");
        }

        public async Task<SeasonDivision> GetByIdAsync(long id)
        {
            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"SELECT *
                                    FROM SeasonDivision
                                    WHERE Id = @id";

                cmd.Parameters.Add("id", SqlDbType.BigInt).Value = id;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<SeasonDivision>();

                        return result;
                    }
                }
            }

            throw new Exception($"season division not found: {id}");
        }

        public async Task<IReadOnlyCollection<SeasonDivision>> GetAllAsync()
        {
            var results = new List<SeasonDivision>();

            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"SELECT *
                                    FROM SeasonDivision";

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<SeasonDivision>();

                        results.Add(result);
                    }
                }
            }

            return results.AsReadOnly();
        }

        #endregion
    }
}
