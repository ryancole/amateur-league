namespace LeagueAdminTool.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataTeams = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCreateRandomTeam = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataRegularSeasonWeeks = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnGenerateRegSeasonWeeks = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnCreateRandomSeason = new System.Windows.Forms.Button();
            this.dataSeasons = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTeams)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataRegularSeasonWeeks)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSeasons)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataTeams);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 283);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Teams";
            // 
            // dataTeams
            // 
            this.dataTeams.AllowUserToAddRows = false;
            this.dataTeams.AllowUserToDeleteRows = false;
            this.dataTeams.AllowUserToOrderColumns = true;
            this.dataTeams.AllowUserToResizeColumns = false;
            this.dataTeams.AllowUserToResizeRows = false;
            this.dataTeams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTeams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTeams.Location = new System.Drawing.Point(3, 16);
            this.dataTeams.Name = "dataTeams";
            this.dataTeams.ReadOnly = true;
            this.dataTeams.RowHeadersVisible = false;
            this.dataTeams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataTeams.Size = new System.Drawing.Size(293, 264);
            this.dataTeams.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCreateRandomTeam);
            this.groupBox2.Location = new System.Drawing.Point(317, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(122, 283);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Team Commands";
            // 
            // btnCreateRandomTeam
            // 
            this.btnCreateRandomTeam.Location = new System.Drawing.Point(6, 19);
            this.btnCreateRandomTeam.Name = "btnCreateRandomTeam";
            this.btnCreateRandomTeam.Size = new System.Drawing.Size(110, 23);
            this.btnCreateRandomTeam.TabIndex = 0;
            this.btnCreateRandomTeam.Text = "Create Random";
            this.btnCreateRandomTeam.UseVisualStyleBackColor = true;
            this.btnCreateRandomTeam.Click += new System.EventHandler(this.btnCreateRandomTeam_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataRegularSeasonWeeks);
            this.groupBox3.Location = new System.Drawing.Point(12, 301);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(299, 328);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Regular Season Weeks";
            // 
            // dataRegularSeasonWeeks
            // 
            this.dataRegularSeasonWeeks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataRegularSeasonWeeks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataRegularSeasonWeeks.Location = new System.Drawing.Point(3, 16);
            this.dataRegularSeasonWeeks.Name = "dataRegularSeasonWeeks";
            this.dataRegularSeasonWeeks.Size = new System.Drawing.Size(293, 309);
            this.dataRegularSeasonWeeks.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnGenerateRegSeasonWeeks);
            this.groupBox4.Location = new System.Drawing.Point(317, 301);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(122, 328);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RSW Commands";
            // 
            // btnGenerateRegSeasonWeeks
            // 
            this.btnGenerateRegSeasonWeeks.Location = new System.Drawing.Point(6, 19);
            this.btnGenerateRegSeasonWeeks.Name = "btnGenerateRegSeasonWeeks";
            this.btnGenerateRegSeasonWeeks.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateRegSeasonWeeks.TabIndex = 0;
            this.btnGenerateRegSeasonWeeks.Text = "Generate";
            this.btnGenerateRegSeasonWeeks.UseVisualStyleBackColor = true;
            this.btnGenerateRegSeasonWeeks.Click += new System.EventHandler(this.btnGenerateRegSeasonWeeks_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataSeasons);
            this.groupBox5.Location = new System.Drawing.Point(445, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(299, 283);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Seasons";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnCreateRandomSeason);
            this.groupBox6.Location = new System.Drawing.Point(750, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(122, 283);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Season Commands";
            // 
            // btnCreateRandomSeason
            // 
            this.btnCreateRandomSeason.Location = new System.Drawing.Point(6, 19);
            this.btnCreateRandomSeason.Name = "btnCreateRandomSeason";
            this.btnCreateRandomSeason.Size = new System.Drawing.Size(110, 23);
            this.btnCreateRandomSeason.TabIndex = 0;
            this.btnCreateRandomSeason.Text = "Create Random";
            this.btnCreateRandomSeason.UseVisualStyleBackColor = true;
            this.btnCreateRandomSeason.Click += new System.EventHandler(this.btnCreateRandomSeason_Click);
            // 
            // dataSeasons
            // 
            this.dataSeasons.AllowUserToAddRows = false;
            this.dataSeasons.AllowUserToDeleteRows = false;
            this.dataSeasons.AllowUserToOrderColumns = true;
            this.dataSeasons.AllowUserToResizeColumns = false;
            this.dataSeasons.AllowUserToResizeRows = false;
            this.dataSeasons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataSeasons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSeasons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSeasons.Location = new System.Drawing.Point(3, 16);
            this.dataSeasons.Name = "dataSeasons";
            this.dataSeasons.ReadOnly = true;
            this.dataSeasons.RowHeadersVisible = false;
            this.dataSeasons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataSeasons.Size = new System.Drawing.Size(293, 264);
            this.dataSeasons.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 946);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "League Admin Tool";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTeams)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataRegularSeasonWeeks)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSeasons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataTeams;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCreateRandomTeam;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataRegularSeasonWeeks;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnGenerateRegSeasonWeeks;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnCreateRandomSeason;
        private System.Windows.Forms.DataGridView dataSeasons;
    }
}

