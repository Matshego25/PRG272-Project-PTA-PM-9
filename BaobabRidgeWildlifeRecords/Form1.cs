using System;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BaobabRidgeWildlifeRecords
{
    public partial class Form1 : Form
    {
        // BindingList allows the DataGridView to update automatically when data changes
        public BindingList<Animal> AnimalList { get; set; } = new BindingList<Animal>();

        // animals.txt has to be next to the .exe, so we build the path from the program folder
        private string filePath = Path.Combine(AppContext.BaseDirectory, "animals.txt");

        // Tracks the animal currently being edited
        private Animal? selectedAnimal = null;

        public Form1()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadAnimalsFromFile();

            // Hook up the update controls
            dataGridView1.CellClick += dataGridView1_CellClick;
            btnSearchID.Click += btnSearchID_Click;
            btnSaveChanges.Click += btnSaveChanges_Click;
            btnClear.Click += btnClear_Click;

            // Start in Add mode
            SetEditMode(false, null);
        }


        // Sets up the 7 columns and makes the grid read-only
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

            // Make grid read-only and select whole rows on click
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Bind the list to the grid
            dataGridView1.DataSource = AnimalList;
        }


        // Reads animals.txt into the list and skips any bad lines
        private void LoadAnimalsFromFile()
        {
            int skippedLinesCount = 0;
            AnimalList.Clear();

            try
            {
                // If the file doesn't exist, create an empty one and show an empty grid without crashing
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

                    // Must have exactly 7 fields
                    if (parts.Length != 7)
                    {
                        skippedLinesCount++;
                        continue;
                    }

                    // ID goes to upper case so wr-0007 is read as WR-0007
                    string id = parts[0].Trim().ToUpper();
                    string name = parts[1].Trim();
                    string species = parts[2].Trim();

                    // Validate numeric fields for Age and Recovery Score
                    if (!int.TryParse(parts[3].Trim(), out int age) || age < 0 || age > 100 ||
                        !int.TryParse(parts[4].Trim(), out int score) || score < 0 || score > 100)
                    {
                        skippedLinesCount++;
                        continue;
                    }

                    // ID must be WR- followed by exactly 4 digits
                    if (!Regex.IsMatch(id, "^WR-[0-9]{4}$"))
                    {
                        skippedLinesCount++;
                        continue;
                    }

                    // Create valid Animal record (the Animal class works out the status and housing unit itself)
                    Animal animal = new Animal(id, name, species, age, score);
                    AnimalList.Add(animal);
                }

                // Tell the user once how many lines were skipped (if any)
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

        // Feature 1: checks every box, then saves the new animal to the list and the file
        private void AddAnimal_Click(object? sender, EventArgs e)
        {
            try
            {
                //Fetch what you typed in the box
                string id = txtAnimalID.Text.Trim().ToUpper();
                string name = txtName.Text.Trim();
                string species = txtSpecies.Text.Trim();

                // Animal ID must be WR- followed by 4 digits
                if (!Regex.IsMatch(id, "^WR-[0-9]{4}$"))
                {
                    MessageBox.Show("Animal ID must be WR- followed by exactly 4 digits, for example WR-0007.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAnimalID.Focus();
                    return;
                }

                // The ID has to be unique
                if (AnimalList.Any(a => a.AnimalID == id))
                {
                    MessageBox.Show($"Animal ID {id} already exists. Each Animal ID must be unique.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAnimalID.Focus();
                    return;
                }

                // Name and Species: 1-30 characters and no pipe
                if (name.Length < 1 || name.Length > 30 || name.Contains('|'))
                {
                    MessageBox.Show("Name must be 1-30 characters and cannot contain pipe characters.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                if (species.Length < 1 || species.Length > 30 || species.Contains('|'))
                {
                    MessageBox.Show("Species must be 1-30 characters and cannot contain pipe characters.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSpecies.Focus();
                    return;
                }

                // Check if age and score are actual whole numbers from 0 to 100
                if (!int.TryParse(txtAge.Text.Trim(), out int age) || age < 0 || age > 100)
                {
                    MessageBox.Show("Age must be a whole number between 0 and 100.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAge.Focus();
                    return;
                }

                if (!int.TryParse(txtScore.Text.Trim(), out int score) || score < 0 || score > 100)
                {
                    MessageBox.Show("Recovery Score must be a whole number between 0 and 100.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtScore.Focus();
                    return;
                }

                // Create the new animal (our classifier handles the status and housing unit!)
                Animal newAnimal = new Animal(id, name, species, age, score);

                // If the last line in the file has no new line, add one first so two animals don't end up on one line
                string existing = File.Exists(filePath) ? File.ReadAllText(filePath) : "";
                string prefix = (existing.Length > 0 && !existing.EndsWith("\n")) ? Environment.NewLine : "";

                // Add the new line at the end of the file (if this fails we jump to the catch and the list stays the same)
                File.AppendAllText(filePath, prefix + newAnimal.ToFileString() + Environment.NewLine);

                // Add it to our list so it pops up on the screen instantly!
                AnimalList.Add(newAnimal);

                // Clear out the typing boxes for the next animal
                txtAnimalID.Clear();
                txtName.Clear();
                txtSpecies.Clear();
                txtAge.Clear();
                txtScore.Clear();

                MessageBox.Show($"Animal added successfully!\n\nStatus: {newAnimal.Status}\nHousing Unit: {newAnimal.HousingUnit}", "Awesome!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Permission denied when trying to save to animals.txt. Please check the file isn't read-only.", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"A file error occurred (File may be in use): {ex.Message}", "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }
        }

        /// <summary>
        /// Handles switching between Add mode and Edit mode.
        /// </summary>
        private void SetEditMode(bool editing, Animal? animal)
        {
            selectedAnimal = animal;

            if (editing && animal != null)
            {
                // Load data into text boxes
                txtAnimalID.Text = animal.AnimalID;
                txtAnimalID.ReadOnly = true; // ID cannot change per requirements
                txtName.Text = animal.Name;
                txtSpecies.Text = animal.Species;
                txtAge.Text = animal.Age.ToString();
                txtScore.Text = animal.RecoveryScore.ToString();

                // Disable Add button and enable Save Changes during edit mode
                AddAnimal.Enabled = false;
                btnSaveChanges.Enabled = true;
            }
            else
            {
                // Reset form back to Add mode
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

        // Feature 3.1: Load record when clicking a row in the DataGridView
        private void dataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].DataBoundItem is Animal animal)
            {
                SetEditMode(true, animal);
            }
        }

        // Feature 3.1: Search by exact Animal ID (not case-sensitive)
        private void btnSearchID_Click(object? sender, EventArgs e)
        {
            string searchId = txtSearchID.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(searchId))
            {
                MessageBox.Show("Please enter an Animal ID to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Find match in our list
            var match = AnimalList.FirstOrDefault(a => a.AnimalID.Equals(searchId, StringComparison.OrdinalIgnoreCase));

            if (match != null)
            {
                SetEditMode(true, match);

                // Highlight the row in the grid
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.DataBoundItem is Animal a && a.AnimalID == match.AnimalID)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Animal ID not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Feature 3.2: Clear button to exit edit mode
        private void btnClear_Click(object? sender, EventArgs e)
        {
            SetEditMode(false, null);
            dataGridView1.ClearSelection();
        }

        // Feature 3.3 & 3.4: Save Changes with validation and clean file rewriting
        private void btnSaveChanges_Click(object? sender, EventArgs e)
        {
            if (selectedAnimal == null) return;

            string name = txtName.Text.Trim();
            string species = txtSpecies.Text.Trim();

            // Validate Name
            if (string.IsNullOrEmpty(name) || name.Length > 30 || name.Contains('|'))
            {
                MessageBox.Show("Name must be 1-30 characters and cannot contain pipe characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            // Validate Species
            if (string.IsNullOrEmpty(species) || species.Length > 30 || species.Contains('|'))
            {
                MessageBox.Show("Species must be 1-30 characters and cannot contain pipe characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Keep the old values so we can put them back if the file can't be saved
            string oldName = selectedAnimal.Name;
            string oldSpecies = selectedAnimal.Species;
            int oldAge = selectedAnimal.Age;
            int oldScore = selectedAnimal.RecoveryScore;

            // Update animal properties (recovery score setter automatically updates status and housing)
            selectedAnimal.Name = name;
            selectedAnimal.Species = species;
            selectedAnimal.Age = age;
            selectedAnimal.RecoveryScore = score;

            bool saved = false;

            try
            {
                // Rewrite the file with proper newlines and no trailing blank lines
                var lines = AnimalList.Select(a => a.ToFileString());
                File.WriteAllText(filePath, string.Join(Environment.NewLine, lines) + Environment.NewLine);
                saved = true;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Permission denied when trying to save to animals.txt. Please check the file isn't read-only.", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("File error (File may be in use): " + ex.Message, "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!saved)
            {
                // Put the old values back so the grid still matches the file
                selectedAnimal.Name = oldName;
                selectedAnimal.Species = oldSpecies;
                selectedAnimal.Age = oldAge;
                selectedAnimal.RecoveryScore = oldScore;
                return;
            }

            // Grab the result before the form goes back to Add mode
            string result = $"Animal updated successfully!\n\nStatus: {selectedAnimal.Status}\nHousing Unit: {selectedAnimal.HousingUnit}";

            // Refresh grid and return to Add mode
            AnimalList.ResetBindings();
            SetEditMode(false, null);

            MessageBox.Show(result, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}