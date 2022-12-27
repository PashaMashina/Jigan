namespace DBClient
{
    partial class GenerateForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateForm));
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dataGridMain = new System.Windows.Forms.DataGridView();
            this.btnGenerationDrivRace = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pbDriverGeneration = new System.Windows.Forms.ProgressBar();
            this.btnGenerationDrivers = new System.Windows.Forms.Button();
            this.upCount = new System.Windows.Forms.NumericUpDown();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblBronze = new System.Windows.Forms.Label();
            this.lblSilver = new System.Windows.Forms.Label();
            this.tbSilver = new System.Windows.Forms.TrackBar();
            this.tbBronze = new System.Windows.Forms.TrackBar();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblPlatinum = new System.Windows.Forms.Label();
            this.lbСlassification = new System.Windows.Forms.Label();
            this.tbPlatinum = new System.Windows.Forms.TrackBar();
            this.tbGold = new System.Windows.Forms.TrackBar();
            this.lblFemale = new System.Windows.Forms.Label();
            this.lblMale = new System.Windows.Forms.Label();
            this.tbMaleFemale = new System.Windows.Forms.TrackBar();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lblTypeRaces = new System.Windows.Forms.Label();
            this.lblCircle = new System.Windows.Forms.Label();
            this.tbCircle = new System.Windows.Forms.TrackBar();
            this.lblEndurance = new System.Windows.Forms.Label();
            this.tbEndurance = new System.Windows.Forms.TrackBar();
            this.lblRally = new System.Windows.Forms.Label();
            this.tbRally = new System.Windows.Forms.TrackBar();
            this.lblDrug = new System.Windows.Forms.Label();
            this.tbDrug = new System.Windows.Forms.TrackBar();
            this.lblTrofi = new System.Windows.Forms.Label();
            this.tbTrofy = new System.Windows.Forms.TrackBar();
            this.pbRaces = new System.Windows.Forms.ProgressBar();
            this.btnGenerationRaces = new System.Windows.Forms.Button();
            this.upCountRaces = new System.Windows.Forms.NumericUpDown();
            this.lblCounRaces = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.upCountDrivRac = new System.Windows.Forms.NumericUpDown();
            this.pbDrivRaceGeneration = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMain)).BeginInit();
            this.btnGenerationDrivRace.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSilver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBronze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPlatinum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaleFemale)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCircle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEndurance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRally)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDrug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTrofy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upCountRaces)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upCountDrivRac)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuery
            // 
            resources.ApplyResources(this.txtQuery, "txtQuery");
            this.txtQuery.Name = "txtQuery";
            // 
            // btnQuery
            // 
            resources.ApplyResources(this.btnQuery, "btnQuery");
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dataGridMain
            // 
            resources.ApplyResources(this.dataGridMain, "dataGridMain");
            this.dataGridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMain.Name = "dataGridMain";
            this.dataGridMain.RowTemplate.Height = 25;
            // 
            // btnGenerationDrivRace
            // 
            resources.ApplyResources(this.btnGenerationDrivRace, "btnGenerationDrivRace");
            this.btnGenerationDrivRace.Controls.Add(this.tabPage1);
            this.btnGenerationDrivRace.Controls.Add(this.tabPage2);
            this.btnGenerationDrivRace.Controls.Add(this.tabPage4);
            this.btnGenerationDrivRace.Controls.Add(this.tabPage5);
            this.btnGenerationDrivRace.Name = "btnGenerationDrivRace";
            this.btnGenerationDrivRace.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.txtQuery);
            this.tabPage1.Controls.Add(this.dataGridMain);
            this.tabPage1.Controls.Add(this.btnQuery);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.pbDriverGeneration);
            this.tabPage2.Controls.Add(this.btnGenerationDrivers);
            this.tabPage2.Controls.Add(this.upCount);
            this.tabPage2.Controls.Add(this.lblCount);
            this.tabPage2.Controls.Add(this.lblBronze);
            this.tabPage2.Controls.Add(this.lblSilver);
            this.tabPage2.Controls.Add(this.tbSilver);
            this.tabPage2.Controls.Add(this.tbBronze);
            this.tabPage2.Controls.Add(this.lblGold);
            this.tabPage2.Controls.Add(this.lblPlatinum);
            this.tabPage2.Controls.Add(this.lbСlassification);
            this.tabPage2.Controls.Add(this.tbPlatinum);
            this.tabPage2.Controls.Add(this.tbGold);
            this.tabPage2.Controls.Add(this.lblFemale);
            this.tabPage2.Controls.Add(this.lblMale);
            this.tabPage2.Controls.Add(this.tbMaleFemale);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pbDriverGeneration
            // 
            resources.ApplyResources(this.pbDriverGeneration, "pbDriverGeneration");
            this.pbDriverGeneration.Name = "pbDriverGeneration";
            this.pbDriverGeneration.Step = 5;
            this.pbDriverGeneration.Tag = "";
            // 
            // btnGenerationDrivers
            // 
            resources.ApplyResources(this.btnGenerationDrivers, "btnGenerationDrivers");
            this.btnGenerationDrivers.Name = "btnGenerationDrivers";
            this.btnGenerationDrivers.UseVisualStyleBackColor = true;
            this.btnGenerationDrivers.Click += new System.EventHandler(this.btnGenerationDrivers_Click);
            // 
            // upCount
            // 
            resources.ApplyResources(this.upCount, "upCount");
            this.upCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.upCount.Name = "upCount";
            this.upCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCount
            // 
            resources.ApplyResources(this.lblCount, "lblCount");
            this.lblCount.Name = "lblCount";
            // 
            // lblBronze
            // 
            resources.ApplyResources(this.lblBronze, "lblBronze");
            this.lblBronze.Name = "lblBronze";
            // 
            // lblSilver
            // 
            resources.ApplyResources(this.lblSilver, "lblSilver");
            this.lblSilver.Name = "lblSilver";
            // 
            // tbSilver
            // 
            resources.ApplyResources(this.tbSilver, "tbSilver");
            this.tbSilver.BackColor = System.Drawing.SystemColors.Control;
            this.tbSilver.Name = "tbSilver";
            // 
            // tbBronze
            // 
            resources.ApplyResources(this.tbBronze, "tbBronze");
            this.tbBronze.BackColor = System.Drawing.SystemColors.Control;
            this.tbBronze.Name = "tbBronze";
            // 
            // lblGold
            // 
            resources.ApplyResources(this.lblGold, "lblGold");
            this.lblGold.Name = "lblGold";
            // 
            // lblPlatinum
            // 
            resources.ApplyResources(this.lblPlatinum, "lblPlatinum");
            this.lblPlatinum.Name = "lblPlatinum";
            // 
            // lbСlassification
            // 
            resources.ApplyResources(this.lbСlassification, "lbСlassification");
            this.lbСlassification.Name = "lbСlassification";
            // 
            // tbPlatinum
            // 
            resources.ApplyResources(this.tbPlatinum, "tbPlatinum");
            this.tbPlatinum.BackColor = System.Drawing.SystemColors.Control;
            this.tbPlatinum.Name = "tbPlatinum";
            // 
            // tbGold
            // 
            resources.ApplyResources(this.tbGold, "tbGold");
            this.tbGold.BackColor = System.Drawing.SystemColors.Control;
            this.tbGold.Name = "tbGold";
            // 
            // lblFemale
            // 
            resources.ApplyResources(this.lblFemale, "lblFemale");
            this.lblFemale.Name = "lblFemale";
            // 
            // lblMale
            // 
            resources.ApplyResources(this.lblMale, "lblMale");
            this.lblMale.Name = "lblMale";
            // 
            // tbMaleFemale
            // 
            resources.ApplyResources(this.tbMaleFemale, "tbMaleFemale");
            this.tbMaleFemale.BackColor = System.Drawing.SystemColors.Control;
            this.tbMaleFemale.Maximum = 100;
            this.tbMaleFemale.Name = "tbMaleFemale";
            // 
            // tabPage4
            // 
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Controls.Add(this.lblTypeRaces);
            this.tabPage4.Controls.Add(this.lblCircle);
            this.tabPage4.Controls.Add(this.tbCircle);
            this.tabPage4.Controls.Add(this.lblEndurance);
            this.tabPage4.Controls.Add(this.tbEndurance);
            this.tabPage4.Controls.Add(this.lblRally);
            this.tabPage4.Controls.Add(this.tbRally);
            this.tabPage4.Controls.Add(this.lblDrug);
            this.tabPage4.Controls.Add(this.tbDrug);
            this.tabPage4.Controls.Add(this.lblTrofi);
            this.tabPage4.Controls.Add(this.tbTrofy);
            this.tabPage4.Controls.Add(this.pbRaces);
            this.tabPage4.Controls.Add(this.btnGenerationRaces);
            this.tabPage4.Controls.Add(this.upCountRaces);
            this.tabPage4.Controls.Add(this.lblCounRaces);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lblTypeRaces
            // 
            resources.ApplyResources(this.lblTypeRaces, "lblTypeRaces");
            this.lblTypeRaces.Name = "lblTypeRaces";
            // 
            // lblCircle
            // 
            resources.ApplyResources(this.lblCircle, "lblCircle");
            this.lblCircle.Name = "lblCircle";
            // 
            // tbCircle
            // 
            resources.ApplyResources(this.tbCircle, "tbCircle");
            this.tbCircle.BackColor = System.Drawing.SystemColors.Control;
            this.tbCircle.Name = "tbCircle";
            // 
            // lblEndurance
            // 
            resources.ApplyResources(this.lblEndurance, "lblEndurance");
            this.lblEndurance.Name = "lblEndurance";
            // 
            // tbEndurance
            // 
            resources.ApplyResources(this.tbEndurance, "tbEndurance");
            this.tbEndurance.BackColor = System.Drawing.SystemColors.Control;
            this.tbEndurance.Name = "tbEndurance";
            // 
            // lblRally
            // 
            resources.ApplyResources(this.lblRally, "lblRally");
            this.lblRally.Name = "lblRally";
            // 
            // tbRally
            // 
            resources.ApplyResources(this.tbRally, "tbRally");
            this.tbRally.BackColor = System.Drawing.SystemColors.Control;
            this.tbRally.Name = "tbRally";
            // 
            // lblDrug
            // 
            resources.ApplyResources(this.lblDrug, "lblDrug");
            this.lblDrug.Name = "lblDrug";
            // 
            // tbDrug
            // 
            resources.ApplyResources(this.tbDrug, "tbDrug");
            this.tbDrug.BackColor = System.Drawing.SystemColors.Control;
            this.tbDrug.Name = "tbDrug";
            // 
            // lblTrofi
            // 
            resources.ApplyResources(this.lblTrofi, "lblTrofi");
            this.lblTrofi.Name = "lblTrofi";
            // 
            // tbTrofy
            // 
            resources.ApplyResources(this.tbTrofy, "tbTrofy");
            this.tbTrofy.BackColor = System.Drawing.SystemColors.Control;
            this.tbTrofy.Name = "tbTrofy";
            // 
            // pbRaces
            // 
            resources.ApplyResources(this.pbRaces, "pbRaces");
            this.pbRaces.Name = "pbRaces";
            this.pbRaces.Step = 5;
            this.pbRaces.Tag = "";
            // 
            // btnGenerationRaces
            // 
            resources.ApplyResources(this.btnGenerationRaces, "btnGenerationRaces");
            this.btnGenerationRaces.Name = "btnGenerationRaces";
            this.btnGenerationRaces.UseVisualStyleBackColor = true;
            this.btnGenerationRaces.Click += new System.EventHandler(this.btnGenerationRaces_Click_1);
            // 
            // upCountRaces
            // 
            resources.ApplyResources(this.upCountRaces, "upCountRaces");
            this.upCountRaces.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.upCountRaces.Name = "upCountRaces";
            this.upCountRaces.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCounRaces
            // 
            resources.ApplyResources(this.lblCounRaces, "lblCounRaces");
            this.lblCounRaces.Name = "lblCounRaces";
            // 
            // tabPage5
            // 
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Controls.Add(this.upCountDrivRac);
            this.tabPage5.Controls.Add(this.pbDrivRaceGeneration);
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Controls.Add(this.label1);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // upCountDrivRac
            // 
            resources.ApplyResources(this.upCountDrivRac, "upCountDrivRac");
            this.upCountDrivRac.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.upCountDrivRac.Name = "upCountDrivRac";
            this.upCountDrivRac.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upCountDrivRac.ValueChanged += new System.EventHandler(this.upCountDrivRac_ValueChanged);
            // 
            // pbDrivRaceGeneration
            // 
            resources.ApplyResources(this.pbDrivRaceGeneration, "pbDrivRaceGeneration");
            this.pbDrivRaceGeneration.Name = "pbDrivRaceGeneration";
            this.pbDrivRaceGeneration.Step = 5;
            this.pbDrivRaceGeneration.Tag = "";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // GenerateForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGenerationDrivRace);
            this.Name = "GenerateForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMain)).EndInit();
            this.btnGenerationDrivRace.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSilver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBronze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPlatinum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaleFemale)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCircle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEndurance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRally)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDrug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTrofy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upCountRaces)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upCountDrivRac)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TextBox txtQuery;
        private Button btnQuery;
        private DataGridView dataGridMain;
        private TabControl btnGenerationDrivRace;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label lblFemale;
        private Label lblMale;
        private TrackBar tbMaleFemale;
        private Label lbСlassification;
        private TrackBar tbPlatinum;
        private Label lblBronze;
        private Label lblSilver;
        private TrackBar tbSilver;
        private TrackBar tbBronze;
        private Label lblGold;
        private Label lblPlatinum;
        private TrackBar tbGold;
        private ProgressBar pbDriverGeneration;
        private Button btnGenerationDrivers;
        private NumericUpDown upCount;
        private Label lblCount;
        private TabPage tabPage4;
        private Label lblTypeRaces;
        private Label lblCircle;
        private TrackBar tbCircle;
        private Label lblEndurance;
        private TrackBar tbEndurance;
        private Label lblRally;
        private TrackBar tbRally;
        private Label lblDrug;
        private TrackBar tbDrug;
        private Label lblTrofi;
        private TrackBar tbTrofy;
        private ProgressBar pbRaces;
        private Button btnGenerationRaces;
        private NumericUpDown upCountRaces;
        private Label lblCounRaces;
        private TabPage tabPage5;
        private NumericUpDown upCountDrivRac;
        private ProgressBar pbDrivRaceGeneration;
        private Button button1;
        private Label label1;
    }
}