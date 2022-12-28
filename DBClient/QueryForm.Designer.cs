namespace DBClient
{
    partial class QueryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryForm));
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dataGridMain = new System.Windows.Forms.DataGridView();
            this.btnGenerationDrivRace = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMain)).BeginInit();
            this.btnGenerationDrivRace.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.ResumeLayout(false);

        }

        #endregion
        private TextBox txtQuery;
        private Button btnQuery;
        private DataGridView dataGridMain;
        private TabControl btnGenerationDrivRace;
        private TabPage tabPage1;
    }
}