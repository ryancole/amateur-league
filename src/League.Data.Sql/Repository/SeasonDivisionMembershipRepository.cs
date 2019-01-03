using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

using League.Entity.Database;
using League.Data.Sql.Utility;

namespace League.Data.Sql.Repository
{
    public class SeasonDivisionMembershipRepository
    {
        private readonly LeagueSqlSession m_session;

        public SeasonDivisionMembershipRepository(LeagueSqlSession session)
        {
            m_session = session;
        }

        #region Methods

        public async Task<SeasonDivisionMembership> CreateAsync(SeasonDivisionMembership membership)
        {
            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO SeasonDivisionMembership (TeamId, SeasonDivisionId)
                                    OUTPUT inserted.*
                                    VALUES (@team, @season)";

                cmd.Parameters.Add("team", SqlDbType.BigInt).Value = membership.TeamId;
                cmd.Parameters.Add("season", SqlDbType.BigInt).Value = membership.SeasonDivisionId;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<SeasonDivisionMembership>();

                        return result;
                    }
                }
            }

            throw new Exception("failed to create season division membership");
        }

        public async Task<IReadOnlyCollection<SeasonDivisionMembership>> GetBySeasonDivisionIdAsync(long id)
        {
            var results = new List<SeasonDivisionMembership>();

            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"SELECT *
                                    FROM SeasonDivisionMembership
                                    WHERE SeasonDivisionId = @id";

                cmd.Parameters.Add("id", SqlDbType.BigInt).Value = id;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<SeasonDivisionMembership>();

                        results.Add(result);
                    }
                }
            }

            return results.AsReadOnly();
        }

        public async Task<IReadOnlyCollection<SeasonDivisionMembership>> GetAllAsync()
        {
            var results = new List<SeasonDivisionMembership>();

            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"SELECT *
                                    FROM SeasonDivisionMembership";

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<SeasonDivisionMembership>();

                        results.Add(result);
                    }
                }
            }

            return results.AsReadOnly();
        }

        #endregion
    }
}
