using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace BaobabRidgeWildlifeRecords
{
    public partial class Form1 : Form
    {
        // BindingList allows the DataGridView to update automatically when data changes
        public BindingList<Animal> AnimalList { get; set; } = new BindingList<Animal>();
        private string filePath = "animals.txt";

        public Form1()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadAnimalsFromFile();
        }


        private void ConfigureDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // Add the 7 required columns in the exact order specified by the project brief
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AnimalID", HeaderText = "Animal ID" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Species", HeaderText = "Species" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Age", HeaderText = "Age" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RecoveryScore", HeaderText = "Recovery Score" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HousingUnit", HeaderText = "Housing Unit" });

            // Make grid read-only and select whole rows on click[cite: 8]
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            // Bind the list to the grid
            dataGridView1.DataSource = AnimalList;
        }


        private void LoadAnimalsFromFile()
        {
            int skippedLinesCount = 0;
            AnimalList.Clear();

            try
            {
                // If the file doesn't exist, create an empty one and show an empty grid without crashing[cite: 8]
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, string.Empty);
                    return;
                }

                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split('|');

                    // Must have exactly 7 fields[cite: 7]
                    if (parts.Length != 7)
                    {
                        skippedLinesCount++;
                        continue;
                    }

                    string id = parts[0].Trim();
                    string name = parts[1].Trim();
                    string species = parts[2].Trim();

                    // Validate numeric fields for Age and Recovery Score[cite: 7]
                    if (!int.TryParse(parts[3].Trim(), out int age) || age < 0 || age > 100 ||
                        !int.TryParse(parts[4].Trim(), out int score) || score < 0 || score > 100)
                    {
                        skippedLinesCount++;
                        continue;
                    }

                    // Optional ID validation check
                    if (!id.StartsWith("WR-", StringComparison.OrdinalIgnoreCase))
                    {
                        skippedLinesCount++;
                        continue;
                    }

                    // Compute simple status and housing if not provided in file
                    string status = score >= 70 ? "Healthy" : score >= 40 ? "Recovering" : "Critical";
                    string housingUnit = age < 1 ? "Nursery" : "General";

                    // Create valid Animal record using the full constructor
                    Animal animal = new Animal(id, name, species, age, score, status, housingUnit);
                    AnimalList.Add(animal);
                }

                // Tell the user once how many lines were skipped (if any)[cite: 7]
                if (skippedLinesCount > 0)
                {
                    MessageBox.Show($"Loaded records successfully, but skipped {skippedLinesCount} malformed line(s).",
                                    "Data Loading Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Permission denied when trying to access animals.txt. Please check file permissions.", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"A file error occurred (File may be in use): {ex.Message}", "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while loading files: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AddAnimal_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;   // an error was already shown

            string id = txtId.Text.Trim().ToUpper();
            string name = txtName.Text.Trim();
            string species = txtSpecies.Text.Trim();
            int age = int.Parse(txtAge.Text.Trim());
            int score = int.Parse(txtScore.Text.Trim());

            var result = AnimalClassifier.GetClassification(score);
            Animal newAnimal = new Animal(id, name, species, age, score, result.Status, result.HousingUnit);

            try
            {
                File.AppendAllText(filePath, Environment.NewLine + newAnimal.ToFileString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save to animals.txt: " + ex.Message);
                return;
            }

            AnimalList.Add(newAnimal);
            dataGridView1.DataSource = AnimalList;

            txtId.Clear();
            txtName.Clear();
            txtSpecies.Clear();
            txtAge.Clear();
            txtScore.Clear();
            txtId.Focus();
        }

        private bool ValidateInputs()
        {
            string id = txtId.Text.Trim().ToUpper();
            string name = txtName.Text.Trim();
            string species = txtSpecies.Text.Trim();

            // Animal ID must look like WR-0001
            bool idIsValid = true;
            if (id.Length != 7 || !id.StartsWith("WR-"))
            {
                idIsValid = false;
            }
            else
            {
                foreach (char c in id.Substring(3))
                {
                    if (c < '0' || c > '9')
                    {
                        idIsValid = false;
                    }
                }
            }

            if (idIsValid == false)
            {
                ShowError("Animal ID must look like WR-0001 (WR- then 4 digits).", txtId);
                return false;
            }

            // Animal ID must not already exist
            foreach (Animal a in AnimalList)
            {
                if (a.AnimalID.ToUpper() == id)
                {
                    ShowError("Animal ID " + id + " already exists.", txtId);
                    return false;
                }
            }

            // Name: 1 to 30 characters, no | symbol
            if (name.Length < 1 || name.Length > 30 || name.Contains("|"))
            {
                ShowError("Name must be 1 to 30 characters and cannot contain |.", txtName);
                return false;
            }

            // Species: 1 to 30 characters, no | symbol
            if (species.Length < 1 || species.Length > 30 || species.Contains("|"))
            {
                ShowError("Species must be 1 to 30 characters and cannot contain |.", txtSpecies);
                return false;
            }

            // Age: whole number 0 to 100
            int age;
            if (!int.TryParse(txtAge.Text.Trim(), out age) || age < 0 || age > 100)
            {
                ShowError("Age must be a whole number from 0 to 100.", txtAge);
                return false;
            }

            // Recovery Score: whole number 0 to 100
            int score;
            if (!int.TryParse(txtScore.Text.Trim(), out score) || score < 0 || score > 100)
            {
                ShowError("Recovery Score must be a whole number from 0 to 100.", txtScore);
                return false;
            }

            return true;   // everything is valid
        }

        private void ShowError(string message, TextBox box)
        {
            MessageBox.Show(message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            box.Focus();
            box.SelectAll();
        }






        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(query))
            {
                // If the search box is empty, show all the animals again!
                dataGridView1.DataSource = AnimalList;
            }
            else
            {
                // Otherwise, filter the list by matching Name or Species
                var filteredList = AnimalList.Where(a =>
                    a.Species.ToLower().Contains(query) ||
                    a.Name.ToLower().Contains(query)
                ).ToList();

                dataGridView1.DataSource = new BindingList<Animal>(filteredList);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Convert each animal back into the pipe-separated line format for our text file
                var lines = AnimalList.Select(a => $"{a.AnimalID} | {a.Name} | {a.Species} | {a.Age} | {a.RecoveryScore} | {a.Status} | {a.HousingUnit}");

                // 2. Save all lines back to animals.txt
                File.WriteAllLines(filePath, lines);

                // 3. Let us know it worked!
                MessageBox.Show("Boom! All animal records saved successfully to animals.txt!", "Save Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uh-oh, could not save the file: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}