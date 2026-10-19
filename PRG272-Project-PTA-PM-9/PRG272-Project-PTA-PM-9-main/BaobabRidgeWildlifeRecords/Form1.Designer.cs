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
            dataGridView1.Location = new Point(14, 16);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1080, 608);
            dataGridView1.TabIndex = 0;
            // 
            // lblAnimalID
            // 
            lblAnimalID.AutoSize = true;
            lblAnimalID.Location = new Point(1133, 18);
            lblAnimalID.Name = "lblAnimalID";
            lblAnimalID.Size = new Size(75, 20);
            lblAnimalID.TabIndex = 20;
            lblAnimalID.Text = "Animal ID";
            // 
            // txtAnimalID
            // 
            txtAnimalID.Location = new Point(1133, 42);
            txtAnimalID.Margin = new Padding(3, 4, 3, 4);
            txtAnimalID.Name = "txtAnimalID";
            txtAnimalID.Size = new Size(347, 27);
            txtAnimalID.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(1133, 82);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 19;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(1133, 106);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(347, 27);
            txtName.TabIndex = 2;
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new Point(1133, 146);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(59, 20);
            lblSpecies.TabIndex = 18;
            lblSpecies.Text = "Species";
            // 
            // txtSpecies
            // 
            txtSpecies.Location = new Point(1133, 170);
            txtSpecies.Margin = new Padding(3, 4, 3, 4);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new Size(347, 27);
            txtSpecies.TabIndex = 3;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(1133, 210);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(84, 20);
            lblAge.TabIndex = 17;
            lblAge.Text = "Age (years)";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(1133, 234);
            txtAge.Margin = new Padding(3, 4, 3, 4);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(347, 27);
            txtAge.TabIndex = 4;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(1133, 274);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(110, 20);
            lblScore.TabIndex = 16;
            lblScore.Text = "Recovery Score";
            // 
            // txtScore
            // 
            txtScore.Location = new Point(1133, 298);
            txtScore.Margin = new Padding(3, 4, 3, 4);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(347, 27);
            txtScore.TabIndex = 5;
            // 
            // AddAnimal
            // 
            AddAnimal.Location = new Point(1146, 342);
            AddAnimal.Margin = new Padding(3, 4, 3, 4);
            AddAnimal.Name = "AddAnimal";
            AddAnimal.Size = new Size(71, 37);
            AddAnimal.TabIndex = 6;
            AddAnimal.Text = "Add";
            AddAnimal.UseVisualStyleBackColor = true;
            AddAnimal.Click += AddAnimal_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Enabled = false;
            btnSaveChanges.Location = new Point(1223, 342);
            btnSaveChanges.Margin = new Padding(3, 4, 3, 4);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(89, 37);
            btnSaveChanges.TabIndex = 7;
            btnSaveChanges.Text = "Save";
            btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(1318, 342);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(73, 37);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // lblSearchID
            // 
            lblSearchID.AutoSize = true;
            lblSearchID.Location = new Point(1133, 395);
            lblSearchID.Name = "lblSearchID";
            lblSearchID.Size = new Size(143, 20);
            lblSearchID.TabIndex = 15;
            lblSearchID.Text = "Search by Animal ID";
            // 
            // txtSearchID
            // 
            txtSearchID.Location = new Point(1133, 419);
            txtSearchID.Margin = new Padding(3, 4, 3, 4);
            txtSearchID.Name = "txtSearchID";
            txtSearchID.Size = new Size(236, 27);
            txtSearchID.TabIndex = 10;
            // 
            // btnSearchID
            // 
            btnSearchID.Location = new Point(1375, 419);
            btnSearchID.Margin = new Padding(3, 4, 3, 4);
            btnSearchID.Name = "btnSearchID";
            btnSearchID.Size = new Size(91, 35);
            btnSearchID.TabIndex = 11;
            btnSearchID.Text = "Search";
            btnSearchID.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1397, 342);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(69, 37);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnGenerateSummary
            // 
            btnGenerateSummary.Location = new Point(1133, 490);
            btnGenerateSummary.Margin = new Padding(3, 4, 3, 4);
            btnGenerateSummary.Name = "btnGenerateSummary";
            btnGenerateSummary.Size = new Size(310, 37);
            btnGenerateSummary.TabIndex = 12;
            btnGenerateSummary.Text = "Generate Summary";
            btnGenerateSummary.UseVisualStyleBackColor = true;
            // 
            // txtSummaryDisplay
            // 
            txtSummaryDisplay.Location = new Point(1133, 535);
            txtSummaryDisplay.Margin = new Padding(3, 4, 3, 4);
            txtSummaryDisplay.Multiline = true;
            txtSummaryDisplay.Name = "txtSummaryDisplay";
            txtSummaryDisplay.ReadOnly = true;
            txtSummaryDisplay.ScrollBars = ScrollBars.Vertical;
            txtSummaryDisplay.Size = new Size(309, 89);
            txtSummaryDisplay.TabIndex = 13;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Location = new Point(1133, 466);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(120, 20);
            lblSummary.TabIndex = 14;
            lblSummary.Text = "Summary Report";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1492, 659);
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
            Margin = new Padding(3, 4, 3, 4);
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