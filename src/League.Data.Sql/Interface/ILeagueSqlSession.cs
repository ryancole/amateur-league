using League.Data.Sql.Repository;

namespace League.Data.Sql.Interface
{
    public interface ILeagueSqlSession
    {
        #region Methods

        void Commit();

        #endregion

        #region Properties

        TeamRepository Teams { get; }

        SeasonRepository Seasons { get; }

        SeasonDivisionRepository SeasonDivisions { get; }

        SeasonDivisionMembershipRepository SeasonDivisionMemberships { get; }

        #endregion
    }
}
