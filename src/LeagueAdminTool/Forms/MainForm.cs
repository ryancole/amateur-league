using System.Windows.Forms;

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

        #endregion

        #region Methods

        private async void RefreshTeamListView()
        {
            var teams = await WebApiClient.GetAllTeams();

            dataTeams.DataSource = teams.Teams;
        }

        #endregion
    }
}
