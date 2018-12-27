using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using Newtonsoft.Json;

using League.Entity.WebApi;
using League.Entity.Database;

using LeagueAdminTool.Utility;

namespace LeagueAdminTool.Forms
{
    public partial class MainForm : Form
    {
        private IReadOnlyCollection<Team> m_teams;

        public MainForm()
        {
            InitializeComponent();
        }

        #region Events

        private void MainForm_Shown(object sender, EventArgs e)
        {
            RefreshTeams();
        }

        private void btnCreateRandomTeam_Click(object sender, EventArgs e)
        {
            CreateRandomTeam();
        }

        private void btnGenerateRegSeasonWeeks_Click(object sender, EventArgs e)
        {
            GenerateRegularSeasonWeeks(6);
        }

        #endregion

        #region Methods

        private async void RefreshTeams()
        {
            var teams = await WebApiClient.GetAllTeamsAsync();

            m_teams = teams.Teams;
            dataTeams.DataSource = m_teams;
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
            var schedule = new Dictionary<int, IEnumerable<Tuple<long, long>>>(amount);

            for (var week = 0; week < amount; week++)
            {
                var currentWeek = new List<Tuple<long, long>>();
                var previousWeeks = FlattenSchedule(schedule.Values.ToArray());

                foreach (var team in m_teams)
                {
                    // this team may already be playing this week, so we may
                    // need to skip
                    if (currentWeek.Any(match => match.Contains(team.Id)))
                    {
                        continue;
                    }

                    var opponent = m_teams
                        .Where(t => t.Id != team.Id) // cant play self
                        .Where(t => currentWeek.Any(match => match.Contains(t.Id)) == false) // cant play somebody already playing this week
                        .Where(t => previousWeeks[team.Id].Contains(t.Id) == false) // cant play somebody i already played this season
                        .First();

                    currentWeek.Add(new Tuple<long, long>(team.Id, opponent.Id));
                }

                schedule[week] = currentWeek;
            }

            propertyGrid1.SelectedObject = new { Schedule = JsonConvert.SerializeObject(schedule) };
        }

        private IDictionary<long, ICollection<long>> FlattenSchedule(IEnumerable<Tuple<long, long>>[] weeks)
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
                    result[match.Item1].Add(match.Item2);
                    result[match.Item2].Add(match.Item1);
                }
            }

            return result;
        }

        #endregion
    }
}
