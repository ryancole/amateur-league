using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

using League.Entity.Database;
using League.Data.Sql.Utility;

namespace League.Data.Sql.Repository
{
    public class SeasonMembershipRepository
    {
        private readonly LeagueSqlSession m_session;

        public SeasonMembershipRepository(LeagueSqlSession session)
        {
            m_session = session;
        }

        #region Methods

        public async Task<SeasonMembership> CreateAsync(long team, long season)
        {
            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO SeasonMembership (TeamId, SeasonId)
                                    OUTPUT inserted.*
                                    VALUES (@team, @season)";

                cmd.Parameters.Add("team", SqlDbType.BigInt).Value = team;
                cmd.Parameters.Add("season", SqlDbType.BigInt).Value = season;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<SeasonMembership>();

                        return result;
                    }
                }
            }

            throw new Exception("failed to create season membership");
        }

        public async Task<IReadOnlyCollection<SeasonMembership>> GetByTeam(long team)
        {
            var results = new List<SeasonMembership>();

            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"SELECT *
                                    FROM SeasonMembership
                                    WHERE TeamId = @team";

                cmd.Parameters.Add("team", SqlDbType.BigInt).Value = team;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<SeasonMembership>();

                        results.Add(result);
                    }
                }
            }

            return results.AsReadOnly();
        }

        public async Task<IReadOnlyCollection<SeasonMembership>> GetBySeason(long season)
        {
            var results = new List<SeasonMembership>();

            using (var cmd = m_session.CreateCommand())
            {
                cmd.CommandText = @"SELECT *
                                    FROM SeasonMembership
                                    WHERE SeasonId = @season";

                cmd.Parameters.Add("season", SqlDbType.BigInt).Value = season;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var result = await reader.MapToTypeAsync<SeasonMembership>();

                        results.Add(result);
                    }
                }
            }

            return results.AsReadOnly();
        }

        #endregion
    }
}
