using System.Windows.Forms;

using League.Entity.WebApi;

using LeagueAdminTool.Utility;

namespace LeagueAdminTool.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Events

        private void MainForm_Shown(object sender, System.EventArgs e)
        {
            RefreshTeamListView();
        }

        private void btnCreateRandomTeam_Click(object sender, System.EventArgs e)
        {
            CreateRandomTeam();
        }

        #endregion

        #region Methods

        private async void RefreshTeamListView()
        {
            var teams = await WebApiClient.GetAllTeamsAsync();

            dataTeams.DataSource = teams.Teams;
        }

        private async void CreateRandomTeam()
        {
            var request = new TeamCreateRequest
            {
                Name = RandomWord.Generate(8)
            };

            var response = await WebApiClient.CreateAsync(request);

            RefreshTeamListView();
        }

        #endregion
    }
}
