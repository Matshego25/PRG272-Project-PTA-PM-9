namespace BaobabRidgeWildlifeRecords
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            lblAnimalID = new Label();
            txtAnimalID = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblSpecies = new Label();
            txtSpecies = new TextBox();
            lblAge = new Label();
            txtAge = new TextBox();
            lblScore = new Label();
            txtScore = new TextBox();
            AddAnimal = new Button();
            btnSaveChanges = new Button();
            btnClear = new Button();
            lblSearchID = new Label();
            txtSearchID = new TextBox();
            btnSearchID = new Button();
            btnDelete = new Button();
            btnGenerateSummary = new Button();
            txtSummaryDisplay = new TextBox();
            lblSummary = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(710, 456);
            dataGridView1.TabIndex = 0;
            // 
            // lblAnimalID
            // 
            lblAnimalID.AutoSize = true;
            lblAnimalID.Location = new Point(735, 12);
            lblAnimalID.Name = "lblAnimalID";
            lblAnimalID.Size = new Size(58, 15);
            lblAnimalID.Text = "Animal ID";
            // 
            // txtAnimalID
            // 
            txtAnimalID.Location = new Point(735, 30);
            txtAnimalID.Name = "txtAnimalID";
            txtAnimalID.Size = new Size(270, 23);
            txtAnimalID.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(735, 60);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(735, 78);
            txtName.Name = "txtName";
            txtName.Size = new Size(270, 23);
            txtName.TabIndex = 2;
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new Point(735, 108);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(45, 15);
            lblSpecies.Text = "Species";
            // 
            // txtSpecies
            // 
            txtSpecies.Location = new Point(735, 126);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new Size(270, 23);
            txtSpecies.TabIndex = 3;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(735, 156);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(68, 15);
            lblAge.Text = "Age (years)";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(735, 174);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(270, 23);
            txtAge.TabIndex = 4;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(735, 204);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(90, 15);
            lblScore.Text = "Recovery Score";
            // 
            // txtScore
            // 
            txtScore.Location = new Point(735, 222);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(270, 23);
            txtScore.TabIndex = 5;
            // 
            // AddAnimal
            // 
            AddAnimal.Location = new Point(735, 255);
            AddAnimal.Name = "AddAnimal";
            AddAnimal.Size = new Size(62, 28);
            AddAnimal.TabIndex = 6;
            AddAnimal.Text = "Add";
            AddAnimal.UseVisualStyleBackColor = true;
            AddAnimal.Click += AddAnimal_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Enabled = false;
            btnSaveChanges.Location = new Point(803, 255);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(92, 28);
            btnSaveChanges.TabIndex = 7;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(901, 255);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(50, 28);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(957, 255);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(50, 28);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblSearchID
            // 
            lblSearchID.AutoSize = true;
            lblSearchID.Location = new Point(735, 295);
            lblSearchID.Name = "lblSearchID";
            lblSearchID.Size = new Size(110, 15);
            lblSearchID.Text = "Search by Animal ID";
            // 
            // txtSearchID
            // 
            txtSearchID.Location = new Point(735, 313);
            txtSearchID.Name = "txtSearchID";
            txtSearchID.Size = new Size(185, 23);
            txtSearchID.TabIndex = 10;
            // 
            // btnSearchID
            // 
            btnSearchID.Location = new Point(926, 311);
            btnSearchID.Name = "btnSearchID";
            btnSearchID.Size = new Size(80, 26);
            btnSearchID.TabIndex = 11;
            btnSearchID.Text = "Search";
            btnSearchID.UseVisualStyleBackColor = true;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Location = new Point(735, 348);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(93, 15);
            lblSummary.Text = "Summary Report";
            // 
            // btnGenerateSummary
            // 
            btnGenerateSummary.Location = new Point(735, 366);
            btnGenerateSummary.Name = "btnGenerateSummary";
            btnGenerateSummary.Size = new Size(271, 28);
            btnGenerateSummary.TabIndex = 12;
            btnGenerateSummary.Text = "Generate Summary";
            btnGenerateSummary.UseVisualStyleBackColor = true;
            // 
            // txtSummaryDisplay
            // 
            txtSummaryDisplay.Location = new Point(735, 400);
            txtSummaryDisplay.Multiline = true;
            txtSummaryDisplay.Name = "txtSummaryDisplay";
            txtSummaryDisplay.ReadOnly = true;
            txtSummaryDisplay.ScrollBars = ScrollBars.Vertical;
            txtSummaryDisplay.Size = new Size(271, 68);
            txtSummaryDisplay.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 480);
            Controls.Add(txtSummaryDisplay);
            Controls.Add(btnGenerateSummary);
            Controls.Add(lblSummary);
            Controls.Add(btnDelete);
            Controls.Add(btnSearchID);
            Controls.Add(txtSearchID);
            Controls.Add(lblSearchID);
            Controls.Add(btnClear);
            Controls.Add(btnSaveChanges);
            Controls.Add(AddAnimal);
            Controls.Add(txtScore);
            Controls.Add(lblScore);
            Controls.Add(txtAge);
            Controls.Add(lblAge);
            Controls.Add(txtSpecies);
            Controls.Add(lblSpecies);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(txtAnimalID);
            Controls.Add(lblAnimalID);
            Controls.Add(dataGridView1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Baobab Ridge Wildlife Rehabilitation Records";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label lblAnimalID;
        private TextBox txtAnimalID;
        private Label lblName;
        private TextBox txtName;
        private Label lblSpecies;
        private TextBox txtSpecies;
        private Label lblAge;
        private TextBox txtAge;
        private Label lblScore;
        private TextBox txtScore;
        private Button AddAnimal;
        private Button btnSaveChanges;
        private Button btnClear;
        private Label lblSearchID;
        private TextBox txtSearchID;
        private Button btnSearchID;
        private Button btnDelete;
        private Button btnGenerateSummary;
        private TextBox txtSummaryDisplay;
        private Label lblSummary;
    }
}