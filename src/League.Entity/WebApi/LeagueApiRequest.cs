namespace League.Entity.WebApi
{
    public class LeagueApiRequest
    {
        public LeagueApiRequest()
        {
            Command = LeagueApiRequestCommand.Unknown;
        }

        #region Properties

        public LeagueApiRequestCommand Command { get; set; }

        public string SerializedParameters { get; set; }

        #endregion
    }

    public enum LeagueApiRequestCommand
    {
        #region Values

        Unknown,

        TeamGetAll,
        TeamCreate,

        SeasonGetAll,
        SeasonCreate,

        SeasonMembershipCreate,
        SeasonMembershipGetByTeam,
        SeasonMembershipGetBySeason

        #endregion
    }
}
