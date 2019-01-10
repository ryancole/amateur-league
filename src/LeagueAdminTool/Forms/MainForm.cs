using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using League.Entity.WebApi;
using League.Entity.WebApi.Request;
using League.Entity.WebApi.Response;
using League.Entity.Database;

using LeagueAdminTool.Utility;

namespace LeagueAdminTool.Forms
{
    public partial class MainForm : Form
    {
        private IReadOnlyCollection<Team> m_teams;
        private IReadOnlyCollection<Season> m_seasons;

        public MainForm()
        {
            InitializeComponent();
        }

        #region Events

        private void MainForm_Shown(object sender, EventArgs e)
        {
            RefreshTeams();
            RefreshSeasons();
        }

        private void btnCreateRandomTeam_Click(object sender, EventArgs e)
        {
            CreateRandomTeam();
        }

        private void btnCreateRandomSeason_Click(object sender, EventArgs e)
        {
            CreateRandomSeason();
        }

        private void btnAddSelectedTeams_Click(object sender, EventArgs e)
        {
            var teams = new List<Team>();
            var seasons = new List<Season>();

            foreach (DataGridViewRow team in dataTeams.SelectedRows)
            {
                teams.Add(team.DataBoundItem as Team);
            }

            foreach (DataGridViewRow season in dataSeasons.SelectedRows)
            {
                seasons.Add(season.DataBoundItem as Season);
            }

            if (MessageBox.Show($"Add {teams.Count()} to {seasons.Count()} seasons?") == DialogResult.OK)
            {
                AddSelectedTeamsToSeason(teams, seasons);
            }
        }

        private void dataSeasons_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var season = dataSeasons.Rows[e.RowIndex].DataBoundItem as Season;

            RefreshSeasonMemberships(season);
        }

        #endregion

        #region Methods

        private async void RefreshSeasonMemberships(Season season)
        {
            var request = new SeasonMembershipGetBySeasonRequest
            {
                SeasonId = season.Id
            };

            var memberships = await WebApiClient.SubmitCommand<SeasonMembershipGetBySeasonParameter, SeasonMembershipGetBySeasonResponse>(LeagueApiRequestCommand.SeasonMembershipGetBySeason, request);

            dataSeasonMemberships.DataSource = memberships.SeasonMemberships;
        }

        private async void AddSelectedTeamsToSeason(IEnumerable<Team> teams, IEnumerable<Season> seasons)
        {
            foreach (var season in seasons)
            {
                var request = new SeasonMembershipCreateRequest
                {
                    TeamIds = teams.Select(m => m.Id),
                    SeasonId = season.Id
                };

                await WebApiClient.CreateSeasonMembershipsAsync(request);
            }
        }

        private async void RefreshTeams()
        {
            var teams = await WebApiClient.GetAllTeamsAsync();

            m_teams = teams.Teams;
            dataTeams.DataSource = m_teams;
        }

        private async void RefreshSeasons()
        {
            var seasons = await WebApiClient.GetAllSeasonsAsync();

            m_seasons = seasons.Seasons;
            dataSeasons.DataSource = m_seasons;
        }

        private async void CreateRandomSeason()
        {
            var response = await WebApiClient.CreateSeasonAsync();

            RefreshSeasons();
        }

        private async void CreateRandomTeam()
        {
            var request = new TeamCreateRequest
            {
                Name = RandomWord.Generate(8)
            };

            var response = await WebApiClient.CreateTeamAsync(request);

            RefreshTeams();
        }

        private void GenerateRegularSeasonWeeks(int amount)
        {
            var schedule = new Dictionary<int, IEnumerable<long[]>>(amount);

            for (var week = 0; week < amount; week++)
            {
                var currentWeek = new List<long[]>();
                var previousWeeks = FlattenSchedule(schedule.Values.ToArray());

                foreach (var team in m_teams)
                {
                    // this team may already be playing this week, so we may
                    // need to skip
                    if (currentWeek.Any(match => match.Contains(team.Id)))
                    {
                        continue;
                    }

                    // cant play self, cant play somebody already playing this
                    // week, cant play somebody i already played this season
                    var opponent = m_teams
                        .Where(t => t.Id != team.Id)
                        .Where(t => currentWeek.Any(match => match.Contains(t.Id)) == false)
                        .Where(t => previousWeeks[team.Id].Contains(t.Id) == false)
                        .First();

                    currentWeek.Add(new long[] { team.Id, opponent.Id });
                }

                schedule[week] = currentWeek;
            }
        }

        private IDictionary<long, ICollection<long>> FlattenSchedule(IEnumerable<long[]>[] weeks)
        {
            var result = new Dictionary<long, ICollection<long>>();

            foreach (var team in m_teams)
            {
                result[team.Id] = new List<long>();
            }

            foreach (var week in weeks)
            {
                foreach (var match in week)
                {
                    var a = match[0];
                    var b = match[1];

                    result[a].Add(b);
                    result[b].Add(a);
                }
            }

            return result;
        }

        #endregion
    }
}
