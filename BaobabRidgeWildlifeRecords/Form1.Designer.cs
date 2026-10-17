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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            //
            // dataGridView1
            //
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(720, 456);
            dataGridView1.TabIndex = 0;
            //
            // lblAnimalID
            //
            lblAnimalID.AutoSize = true;
            lblAnimalID.Location = new Point(750, 12);
            lblAnimalID.Name = "lblAnimalID";
            lblAnimalID.Size = new Size(58, 15);
            lblAnimalID.Text = "Animal ID";
            //
            // txtAnimalID
            //
            txtAnimalID.Location = new Point(750, 32);
            txtAnimalID.Name = "txtAnimalID";
            txtAnimalID.Size = new Size(220, 23);
            txtAnimalID.TabIndex = 1;
            //
            // lblName
            //
            lblName.AutoSize = true;
            lblName.Location = new Point(750, 64);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.Text = "Name";
            //
            // txtName
            //
            txtName.Location = new Point(750, 84);
            txtName.Name = "txtName";
            txtName.Size = new Size(220, 23);
            txtName.TabIndex = 2;
            //
            // lblSpecies
            //
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new Point(750, 116);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(45, 15);
            lblSpecies.Text = "Species";
            //
            // txtSpecies
            //
            txtSpecies.Location = new Point(750, 136);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new Size(220, 23);
            txtSpecies.TabIndex = 3;
            //
            // lblAge
            //
            lblAge.AutoSize = true;
            lblAge.Location = new Point(750, 168);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(68, 15);
            lblAge.Text = "Age (years)";
            //
            // txtAge
            //
            txtAge.Location = new Point(750, 188);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(220, 23);
            txtAge.TabIndex = 4;
            //
            // lblScore
            //
            lblScore.AutoSize = true;
            lblScore.Location = new Point(750, 220);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(90, 15);
            lblScore.Text = "Recovery Score";
            //
            // txtScore
            //
            txtScore.Location = new Point(750, 240);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(220, 23);
            txtScore.TabIndex = 5;
            //
            // AddAnimal
            //
            AddAnimal.Location = new Point(750, 280);
            AddAnimal.Name = "AddAnimal";
            AddAnimal.Size = new Size(70, 28);
            AddAnimal.TabIndex = 6;
            AddAnimal.Text = "Add";
            AddAnimal.UseVisualStyleBackColor = true;
            AddAnimal.Click += AddAnimal_Click;
            //
            // btnSaveChanges
            //
            btnSaveChanges.Enabled = false;
            btnSaveChanges.Location = new Point(826, 280);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(100, 28);
            btnSaveChanges.TabIndex = 7;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            //
            // btnClear
            //
            btnClear.Location = new Point(932, 280);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(70, 28);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            //
            // lblSearchID
            //
            lblSearchID.AutoSize = true;
            lblSearchID.Location = new Point(750, 330);
            lblSearchID.Name = "lblSearchID";
            lblSearchID.Size = new Size(110, 15);
            lblSearchID.Text = "Search by Animal ID";
            //
            // txtSearchID
            //
            txtSearchID.Location = new Point(750, 350);
            txtSearchID.Name = "txtSearchID";
            txtSearchID.Size = new Size(160, 23);
            txtSearchID.TabIndex = 9;
            //
            // btnSearchID
            //
            btnSearchID.Location = new Point(920, 348);
            btnSearchID.Name = "btnSearchID";
            btnSearchID.Size = new Size(82, 28);
            btnSearchID.TabIndex = 10;
            btnSearchID.Text = "Search";
            btnSearchID.UseVisualStyleBackColor = true;
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 480);
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
            Margin = new Padding(6, 6, 6, 6);
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
    }
}