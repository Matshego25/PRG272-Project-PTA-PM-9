using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BaobabRidgeWildlifeRecords
{
    public partial class Form1 : Form
    {
        // BindingList allows the DataGridView to update automatically when data changes
        public BindingList<Animal> AnimalList { get; set; } = new BindingList<Animal>();

        // animals.txt path relative to the executable
        private string filePath = Path.Combine(AppContext.BaseDirectory, "animals.txt");

        // Tracks the animal currently being edited
        private Animal? selectedAnimal = null;

        public Form1()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadAnimalsFromFile();

            // Wire up event handlers
            dataGridView1.CellClick += dataGridView1_CellClick;
            btnSearchID.Click += btnSearchID_Click;
            btnSaveChanges.Click += btnSaveChanges_Click;
            btnClear.Click += btnClear_Click;
            btnDelete.Click += btnDelete_Click;
            btnGenerateSummary.Click += btnGenerateSummary_Click;

            // Start in Add mode
            SetEditMode(false, null);
        }

        
        /// Configures the DataGridView columns and read-only settings.
        
        private void ConfigureDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AnimalID", HeaderText = "Animal ID" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Species", HeaderText = "Species" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Age", HeaderText = "Age" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RecoveryScore", HeaderText = "Recovery Score" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HousingUnit", HeaderText = "Housing Unit" });

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.DataSource = AnimalList;
        }

        
        /// Reads animals.txt into the list and skips malformed lines gracefully.
       
        private void LoadAnimalsFromFile()
        {
            int skippedLinesCount = 0;
            AnimalList.Clear();

            try
            {
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

                    if (parts.Length != 7)
                    {
                        skippedLinesCount++;
                        continue;
                    }

                    string id = parts[0].Trim().ToUpper();
                    string name = parts[1].Trim();
                    string species = parts[2].Trim();

                    if (!int.TryParse(parts[3].Trim(), out int age) || age < 0 || age > 100 ||
                        !int.TryParse(parts[4].Trim(), out int score) || score < 0 || score > 100)
                    {
                        skippedLinesCount++;
                        continue;
                    }

                    if (!Regex.IsMatch(id, "^WR-[0-9]{4}$"))
                    {
                        skippedLinesCount++;
                        continue;
                    }

                    Animal animal = new Animal(id, name, species, age, score);
                    AnimalList.Add(animal);
                }

                if (skippedLinesCount > 0)
                {
                    MessageBox.Show($"Loaded records successfully, but skipped {skippedLinesCount} malformed line(s).",
                                    "Data Loading Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Permission denied when trying to access animals.txt.", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"A file error occurred: {ex.Message}", "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while loading files: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        /// Feature 1: Add a new animal after validating all fields.
        
        private void AddAnimal_Click(object? sender, EventArgs e)
        {
            string id = txtAnimalID.Text.Trim().ToUpper();
            string name = txtName.Text.Trim();
            string species = txtSpecies.Text.Trim();

            // Validate ID format
            if (!Regex.IsMatch(id, "^WR-[0-9]{4}$"))
            {
                MessageBox.Show("Animal ID must be WR- followed by exactly 4 digits (e.g., WR-0007).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnimalID.Focus();
                return;
            }

            // Validate ID uniqueness
            if (AnimalList.Any(a => a.AnimalID.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Animal ID {id} already exists. Each Animal ID must be unique.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnimalID.Focus();
                return;
            }

            // Validate Name
            if (string.IsNullOrEmpty(name) || name.Length > 30 || name.Contains('|'))
            {
                MessageBox.Show("Name must be 1–30 characters long and cannot contain pipe '|' characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            // Validate Species
            if (string.IsNullOrEmpty(species) || species.Length > 30 || species.Contains('|'))
            {
                MessageBox.Show("Species must be 1–30 characters long and cannot contain pipe '|' characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSpecies.Focus();
                return;
            }

            // Validate Age
            if (!int.TryParse(txtAge.Text.Trim(), out int age) || age < 0 || age > 100)
            {
                MessageBox.Show("Age must be a whole number between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAge.Focus();
                return;
            }

            // Validate Recovery Score
            if (!int.TryParse(txtScore.Text.Trim(), out int score) || score < 0 || score > 100)
            {
                MessageBox.Show("Recovery Score must be a whole number between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtScore.Focus();
                return;
            }

            Animal newAnimal = new Animal(id, name, species, age, score);

            try
            {
                string existing = File.Exists(filePath) ? File.ReadAllText(filePath) : "";
                string prefix = (existing.Length > 0 && !existing.EndsWith("\n")) ? Environment.NewLine : "";
                File.AppendAllText(filePath, prefix + newAnimal.ToFileString() + Environment.NewLine);

                // Add to list so DataGridView updates instantly
                AnimalList.Add(newAnimal);

                SetEditMode(false, null);

                MessageBox.Show($"Animal added successfully!\n\nStatus: {newAnimal.Status}\nHousing Unit: {newAnimal.HousingUnit}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Permission denied when saving to animals.txt.", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"File error occurred (file may be in use): {ex.Message}", "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        /// Toggles between Add Mode and Edit Mode.
     
        private void SetEditMode(bool editing, Animal? animal)
        {
            selectedAnimal = animal;

            if (editing && animal != null)
            {
                txtAnimalID.Text = animal.AnimalID;
                txtAnimalID.ReadOnly = true;
                txtName.Text = animal.Name;
                txtSpecies.Text = animal.Species;
                txtAge.Text = animal.Age.ToString();
                txtScore.Text = animal.RecoveryScore.ToString();

                AddAnimal.Enabled = false;
                btnSaveChanges.Enabled = true;
            }
            else
            {
                txtAnimalID.Clear();
                txtAnimalID.ReadOnly = false;
                txtName.Clear();
                txtSpecies.Clear();
                txtAge.Clear();
                txtScore.Clear();

                AddAnimal.Enabled = true;
                btnSaveChanges.Enabled = false;
                selectedAnimal = null;
            }
        }

       
        /// Feature 3.1: Load record into form on grid click.
       
        private void dataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].DataBoundItem is Animal animal)
            {
                SetEditMode(true, animal);
            }
        }

        
        /// Feature 3.1: Search by Animal ID (case-insensitive).
        
        private void btnSearchID_Click(object? sender, EventArgs e)
        {
            string searchId = txtSearchID.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(searchId))
            {
                MessageBox.Show("Please enter an Animal ID to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var match = AnimalList.FirstOrDefault(a => a.AnimalID.Equals(searchId, StringComparison.OrdinalIgnoreCase));

            if (match != null)
            {
                SetEditMode(true, match);

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.DataBoundItem is Animal a && a.AnimalID == match.AnimalID)
                    {
                       dataGridView1.ClearSelection();
                        row.Selected = true;
                        try
    {
        // Move to the found row and scroll to it
        dataGridView1.CurrentCell = row.Cells[0];
        dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
    }
    catch
    {
        // If scrolling fails, the row is still selected
    }

    dataGridView1.Focus();
                           
                        
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Animal ID not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        /// Feature 3.2: Clear button resets form to Add mode.
        
        private void btnClear_Click(object? sender, EventArgs e)
        {
            SetEditMode(false, null);
            dataGridView1.ClearSelection();
        }

        
        /// Feature 3.3 & 3.4: Save changes and rewrite animals.txt.
        
        private void btnSaveChanges_Click(object? sender, EventArgs e)
        {
            if (selectedAnimal == null) return;

            string name = txtName.Text.Trim();
            string species = txtSpecies.Text.Trim();

            if (string.IsNullOrEmpty(name) || name.Length > 30 || name.Contains('|'))
            {
                MessageBox.Show("Name must be 1–30 characters long and cannot contain pipe '|' characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(species) || species.Length > 30 || species.Contains('|'))
            {
                MessageBox.Show("Species must be 1–30 characters long and cannot contain pipe '|' characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSpecies.Focus();
                return;
            }

            if (!int.TryParse(txtAge.Text.Trim(), out int age) || age < 0 || age > 100)
            {
                MessageBox.Show("Age must be a whole number between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAge.Focus();
                return;
            }

            if (!int.TryParse(txtScore.Text.Trim(), out int score) || score < 0 || score > 100)
            {
                MessageBox.Show("Recovery Score must be a whole number between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtScore.Focus();
                return;
            }

            string oldName = selectedAnimal.Name;
            string oldSpecies = selectedAnimal.Species;
            int oldAge = selectedAnimal.Age;
            int oldScore = selectedAnimal.RecoveryScore;

            selectedAnimal.Name = name;
            selectedAnimal.Species = species;
            selectedAnimal.Age = age;
            selectedAnimal.RecoveryScore = score; // Auto-recalculates Status and HousingUnit

            bool saved = false;

            try
            {
                var lines = AnimalList.Select(a => a.ToFileString());
                File.WriteAllText(filePath, string.Join(Environment.NewLine, lines) + (AnimalList.Count > 0 ? Environment.NewLine : ""));
                saved = true;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Permission denied when saving to animals.txt.", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"File error occurred (file may be in use): {ex.Message}", "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving changes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!saved)
            {
                selectedAnimal.Name = oldName;
                selectedAnimal.Species = oldSpecies;
                selectedAnimal.Age = oldAge;
                selectedAnimal.RecoveryScore = oldScore;
                return;
            }

            string resultMsg = $"Animal updated successfully!\n\nStatus: {selectedAnimal.Status}\nHousing Unit: {selectedAnimal.HousingUnit}";

            AnimalList.ResetBindings();
            SetEditMode(false, null);

            MessageBox.Show(resultMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        /// Feature 4: Delete selected animal with confirmation dialog.
       
        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.DataBoundItem is not Animal selectedForDelete)
            {
                MessageBox.Show("Please select an animal row from the grid to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Delete {selectedForDelete.AnimalID} ({selectedForDelete.Name})? This cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    AnimalList.Remove(selectedForDelete);

                    var lines = AnimalList.Select(a => a.ToFileString());
                    File.WriteAllText(filePath, string.Join(Environment.NewLine, lines) + (AnimalList.Count > 0 ? Environment.NewLine : ""));

                    if (selectedAnimal == selectedForDelete)
                    {
                        SetEditMode(false, null);
                    }

                    MessageBox.Show($"Record {selectedForDelete.AnimalID} deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Permission denied when updating animals.txt.", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"File error occurred (file may be in use): {ex.Message}", "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
        // Feature 5: Generate Summary Report, display on form, and save to summary.txt.
        
        private void btnGenerateSummary_Click(object? sender, EventArgs e)
        {
            try
            {
                int total = AnimalList.Count;
                string avgAgeStr = "N/A";
                string avgScoreStr = "N/A";

                int criticalCount = AnimalList.Count(a => a.Status == "Critical");
                int seriousCount = AnimalList.Count(a => a.Status == "Serious");
                int stableCount = AnimalList.Count(a => a.Status == "Stable");
                int recoveringCount = AnimalList.Count(a => a.Status == "Recovering");
                int releaseReadyCount = AnimalList.Count(a => a.Status == "Release-Ready");

                if (total > 0)
                {
                    double avgAge = AnimalList.Average(a => a.Age);
                    double avgScore = AnimalList.Average(a => a.RecoveryScore);

                    avgAgeStr = avgAge.ToString("F2", CultureInfo.InvariantCulture);
                    avgScoreStr = avgScore.ToString("F2", CultureInfo.InvariantCulture);
                }

                // Display on Form
                txtSummaryDisplay.Text = $"Total Animals: {total}" + Environment.NewLine +
                                         $"Average Age: {avgAgeStr}" + Environment.NewLine +
                                         $"Average Score: {avgScoreStr}" + Environment.NewLine +
                                         $"Critical: {criticalCount} | Serious: {seriousCount} | Stable: {stableCount} | Recovering: {recoveringCount} | Release-Ready: {releaseReadyCount}";

                // Save to summary.txt in exact required format
                string summaryFilePath = Path.Combine(AppContext.BaseDirectory, "summary.txt");
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

               string summaryContent =
    "BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE" + Environment.NewLine +
    "ANIMAL SUMMARY REPORT" + Environment.NewLine +
    $"Generated: {timestamp}" + Environment.NewLine +
    "----------------------------------------" + Environment.NewLine +
    "Total animals:".PadRight(26) + total + Environment.NewLine +
    "Average age (years):".PadRight(26) + avgAgeStr + Environment.NewLine +
    "Average recovery score:".PadRight(26) + avgScoreStr + Environment.NewLine +
    "----------------------------------------" + Environment.NewLine +
    "Animals per status:" + Environment.NewLine +
    "  " + "Critical:".PadRight(24) + criticalCount + Environment.NewLine +
    "  " + "Serious:".PadRight(24) + seriousCount + Environment.NewLine +
    "  " + "Stable:".PadRight(24) + stableCount + Environment.NewLine +
    "  " + "Recovering:".PadRight(24) + recoveringCount + Environment.NewLine +
    "  " + "Release-Ready:".PadRight(24) + releaseReadyCount + Environment.NewLine;
    

                File.WriteAllText(summaryFilePath, summaryContent);

                MessageBox.Show("Summary report generated successfully and saved to summary.txt!", "Summary Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Permission denied when writing to summary.txt.", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"File error occurred while writing summary.txt: {ex.Message}", "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating summary report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
