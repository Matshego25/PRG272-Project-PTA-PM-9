namespace BaobabRidgeWildlifeRecords
{
    partial class Form1
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
            dataGridView1 = new DataGridView();
            txtName = new TextBox();
            txtSpecies = new TextBox();
            txtAge = new TextBox();
            txtScore = new TextBox();
            AddAnimal = new Button();
            txtSearch = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, -1);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(713, 403);
            dataGridView1.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.AccessibleName = "Name";
            txtName.Location = new Point(805, -1);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 1;
            txtName.Text = "Name";
            // 
            // txtSpecies
            // 
            txtSpecies.AccessibleName = "Species";
            txtSpecies.Location = new Point(805, 57);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new Size(100, 23);
            txtSpecies.TabIndex = 2;
            txtSpecies.Text = "Species";
            // 
            // txtAge
            // 
            txtAge.AccessibleName = "Age";
            txtAge.Location = new Point(805, 131);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(100, 23);
            txtAge.TabIndex = 3;
            txtAge.Text = "Age";
            // 
            // txtScore
            // 
            txtScore.AccessibleName = "Score";
            txtScore.Location = new Point(805, 199);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(100, 23);
            txtScore.TabIndex = 4;
            txtScore.Text = "Score";
            // 
            // AddAnimal
            // 
            AddAnimal.Location = new Point(805, 259);
            AddAnimal.Name = "AddAnimal";
            AddAnimal.Size = new Size(75, 23);
            AddAnimal.TabIndex = 5;
            AddAnimal.Text = "Add Animal";
            AddAnimal.UseVisualStyleBackColor = true;
            AddAnimal.Click += AddAnimal_Click;
            // 
            // txtSearch
            // 
            txtSearch.AccessibleName = "txtSearch";
            txtSearch.Location = new Point(805, 315);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 6;
            txtSearch.Text = "Search";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(805, 379);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Save Changes";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1247, 470);
            Controls.Add(button1);
            Controls.Add(txtSearch);
            Controls.Add(AddAnimal);
            Controls.Add(txtScore);
            Controls.Add(txtAge);
            Controls.Add(txtSpecies);
            Controls.Add(txtName);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtName;
        private TextBox txtSpecies;
        private TextBox txtAge;
        private TextBox txtScore;
        private Button AddAnimal;
        private TextBox txtSearch;
        private Button button1;
    }
}
