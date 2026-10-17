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
            txtId = new TextBox();
            txtName = new TextBox();
            txtSpecies = new TextBox();
            txtAge = new TextBox();
            txtScore = new TextBox();
            AddAnimal = new Button();
            txtSearch = new TextBox();
            button1 = new Button();
            lblId = new Label();
            lblName = new Label();
            lblSpecies = new Label();
            lblAge = new Label();
            lblScore = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, -2);
            dataGridView1.Margin = new Padding(6, 6, 6, 6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1324, 860);
            dataGridView1.TabIndex = 0;
            // 
            // txtId
            // 
            txtId.Location = new Point(1579, 36);
            txtId.Margin = new Padding(6, 6, 6, 6);
            txtId.Name = "txtId";
            txtId.PlaceholderText = "WR-0001";
            txtId.Size = new Size(314, 39);
            txtId.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.AccessibleName = "Name";
            txtName.Location = new Point(1579, 132);
            txtName.Margin = new Padding(6, 6, 6, 6);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "e.g. Thabo";
            txtName.Size = new Size(314, 39);
            txtName.TabIndex = 2;
            // 
            // txtSpecies
            // 
            txtSpecies.AccessibleName = "Species";
            txtSpecies.Location = new Point(1579, 228);
            txtSpecies.Margin = new Padding(6, 6, 6, 6);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.PlaceholderText = "e.g. Serval";
            txtSpecies.Size = new Size(314, 39);
            txtSpecies.TabIndex = 3;
            // 
            // txtAge
            // 
            txtAge.AccessibleName = "Age";
            txtAge.Location = new Point(1579, 324);
            txtAge.Margin = new Padding(6, 6, 6, 6);
            txtAge.Name = "txtAge";
            txtAge.PlaceholderText = "0-100";
            txtAge.Size = new Size(314, 39);
            txtAge.TabIndex = 4;
            // 
            // txtScore
            // 
            txtScore.AccessibleName = "Score";
            txtScore.Location = new Point(1579, 420);
            txtScore.Margin = new Padding(6, 6, 6, 6);
            txtScore.Name = "txtScore";
            txtScore.PlaceholderText = "0-100";
            txtScore.Size = new Size(314, 39);
            txtScore.TabIndex = 5;
            // 
            // AddAnimal
            // 
            AddAnimal.Location = new Point(1444, 542);
            AddAnimal.Margin = new Padding(6, 6, 6, 6);
            AddAnimal.Name = "AddAnimal";
            AddAnimal.Size = new Size(318, 60);
            AddAnimal.TabIndex = 6;
            AddAnimal.Text = "Add Animal";
            AddAnimal.UseVisualStyleBackColor = true;
            AddAnimal.Click += AddAnimal_Click;
            // 
            // txtSearch
            // 
            txtSearch.AccessibleName = "txtSearch";
            txtSearch.Location = new Point(1371, 673);
            txtSearch.Margin = new Padding(6, 6, 6, 6);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(182, 39);
            txtSearch.TabIndex = 7;
            txtSearch.Text = "(Search box)";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(1358, 786);
            button1.Margin = new Padding(6, 6, 6, 6);
            button1.Name = "button1";
            button1.Size = new Size(216, 49);
            button1.TabIndex = 8;
            button1.Text = "Save Changes";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(1356, 43);
            lblId.Margin = new Padding(6, 0, 6, 0);
            lblId.Name = "lblId";
            lblId.Size = new Size(118, 32);
            lblId.TabIndex = 9;
            lblId.Text = "Animal ID";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(1356, 139);
            lblName.Margin = new Padding(6, 0, 6, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(78, 32);
            lblName.TabIndex = 10;
            lblName.Text = "Name";
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new Point(1356, 235);
            lblSpecies.Margin = new Padding(6, 0, 6, 0);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(94, 32);
            lblSpecies.TabIndex = 11;
            lblSpecies.Text = "Species";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(1356, 331);
            lblAge.Margin = new Padding(6, 0, 6, 0);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(56, 32);
            lblAge.TabIndex = 12;
            lblAge.Text = "Age";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(1356, 427);
            lblScore.Margin = new Padding(6, 0, 6, 0);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(176, 32);
            lblScore.TabIndex = 13;
            lblScore.Text = "Recovery Score";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2316, 1003);
            Controls.Add(lblScore);
            Controls.Add(lblAge);
            Controls.Add(lblSpecies);
            Controls.Add(lblName);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(button1);
            Controls.Add(txtSearch);
            Controls.Add(AddAnimal);
            Controls.Add(txtScore);
            Controls.Add(txtAge);
            Controls.Add(txtSpecies);
            Controls.Add(txtName);
            Controls.Add(dataGridView1);
            Margin = new Padding(6, 6, 6, 6);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtSpecies;
        private TextBox txtAge;
        private TextBox txtScore;
        private Button AddAnimal;
        private TextBox txtSearch;
        private Button button1;
        private Label lblId;
        private Label lblName;
        private Label lblSpecies;
        private Label lblAge;
        private Label lblScore;
    }
}