using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        public async Task<Team> CreateAsync(Team team)
        {
            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO Team (Name)
                                    OUTPUT inserted.*
                                    VALUES (@name)";

                cmd.Parameters.Add("name", SqlDbType.Text).Value = team.Name;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<Team>();

                        return result;
                    }
                }
            }

            throw new Exception("failed to create team");
        }

        public async Task<Team> GetByIdAsync(long id)
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
                        var result = await reader.MapToTypeAsync<Team>();

                        return result;
                    }
                }
            }

            throw new Exception($"team not found: {id}");
        }

        public async Task<IReadOnlyCollection<Team>> GetAllAsync()
        {
            var results = new List<Team>();

            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"SELECT *
                                    FROM Team";

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<Team>();

                        results.Add(result);
                    }
                }
            }

            return results.AsReadOnly();
        }

        #endregion
    }
}
