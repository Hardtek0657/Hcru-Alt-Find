using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;

namespace AltFinder
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private Dictionary<string, int> unmatchedUsers = new Dictionary<string, int>();
        private const string JsonFilePath = "unmatchedUsers.json";

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Form1()
        {
            InitializeComponent();
            AllocConsole();
            LoadExistingData();
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Text = "AltFinder";

            ApplyDarkModeToControls();
        }

        private void ApplyDarkModeToControls()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MetroTextBox metroTextBox)
                {
                    metroTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
                    metroTextBox.Style = MetroFramework.MetroColorStyle.Black;
                }
                else if (ctrl is MetroButton metroButton)
                {
                    metroButton.Theme = MetroFramework.MetroThemeStyle.Dark;
                    metroButton.Style = MetroFramework.MetroColorStyle.Black;
                }
                else if (ctrl is MetroLabel metroLabel)
                {
                    metroLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
                }
            }
        }

        private void LoadExistingData()
        {
            try
            {
                if (File.Exists(JsonFilePath))
                {
                    string jsonContent = File.ReadAllText(JsonFilePath);
                    unmatchedUsers = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonContent) ?? new Dictionary<string, int>();
                    Console.WriteLine("Existing data loaded from JSON file.");
                }
                else
                {
                    unmatchedUsers = new Dictionary<string, int>();
                    Console.WriteLine("No existing data found; starting fresh.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON data: {ex.Message}");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Starting search...");
                txtResult.Clear();

                // Load existing unmatched users from the JSON file before processing new data
                LoadExistingData();

                // Clean up the content of txtLogContent directly
                CleanLogContentDirectly();

                List<string> referenceNames = txtReferenceList.Text
                    .Split(new[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(name => name.Trim())
                    .ToList();

                // Process the new log data
                ProcessLog(txtLogContent.Text, referenceNames); // Use cleaned txtLogContent.Text

                // Save the updated unmatched users to JSON (adding or updating counts)
                SaveToJson();

                // Display updated results while keeping the previous content
                DisplayRaidStatus(referenceNames);

                Console.WriteLine("Search completed and JSON file updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in btnSearch_Click: {ex.Message}");
            }
        }



        // New method to directly clean txtLogContent.Text
        private void CleanLogContentDirectly()
        {
            // Remove timestamps and emojis from txtLogContent.Text
            string pattern = @"\[\d{1,2}:\d{1,2}:\d{1,2}\] (🔑|✅) ";
            txtLogContent.Text = Regex.Replace(txtLogContent.Text, pattern, "").Trim();

            // Prepare list to store cleaned lines
            string[] lines = txtLogContent.Text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var cleanedLines = new List<string>();

            foreach (string line in lines)
            {
                // Skip lines containing phrases like "has ended the AFK check"
                if (line.Contains("has ended the AFK check"))
                {
                    continue;
                }

                // Pattern to capture only the player name and ID
                string cleanPattern = @"^([^()]+)\s\((\d+)\)";
                Match match = Regex.Match(line, cleanPattern);

                if (match.Success)
                {
                    // Capture the player's name and ID
                    string name = match.Groups[1].Value.Trim();
                    string userId = match.Groups[2].Value.Trim();
                    cleanedLines.Add($"{name} ({userId})");
                }
            }

            // Update txtLogContent.Text with only the name and ID of each player
            txtLogContent.Text = string.Join(Environment.NewLine, cleanedLines);
        }




        private void ProcessLog(string logContent, List<string> referenceNames)
        {
            try
            {
                Console.WriteLine("Processing cleaned log content...");

                // Split the cleaned log content into lines
                var lines = logContent.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length >= 2)
                    {
                        string name = parts[0].Trim();  // First part is the player's name
                        string userId = parts[1].Trim(); // Second part is the user ID
                        Console.WriteLine($"Captured Name: {name}, User ID: {userId}");

                        // Compare the cleaned and trimmed name in lowercase with reference names
                        if (!referenceNames.Contains(name, StringComparer.OrdinalIgnoreCase))
                        {
                            AddOrUpdateUnmatchedUser(name, userId);
                        }
                    }
                }
                Console.WriteLine("Log processing completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ProcessLog: {ex.Message}");
            }
        }



        private void AddOrUpdateUnmatchedUser(string name, string userId)
        {
            try
            {
                string key = $"{name} ({userId})";

                if (unmatchedUsers.ContainsKey(key))
                {
                    unmatchedUsers[key]++;  // Increment the count for this player
                    Console.WriteLine($"Incremented count for {key}: {unmatchedUsers[key]}");
                }
                else
                {
                    unmatchedUsers[key] = 1;  // Add new entry with count 1
                    Console.WriteLine($"Added new entry for {key}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddOrUpdateUnmatchedUser: {ex.Message}");
            }
        }

        private void DisplayRaidStatus(List<string> referenceNames)
        {
            var resultBuilder = new StringBuilder();

            // Only process new unmatched users (those not in the raid)
            foreach (var entry in unmatchedUsers.Keys)
            {
                var parts = entry.Split(' ');
                var playerName = parts[0]; // The player's name
                var userId = parts[1].Trim('(', ')'); // Remove parentheses around userId

                // Only add those who are not in the raid
                if (!referenceNames.Contains(playerName))
                {
                    resultBuilder.AppendLine($"{playerName} {userId} - Not in the raid");
                }
            }

            // Append the result to the current text in txtResult, preserving the previous content
            txtResult.Text += resultBuilder.ToString();
        }




        private void SaveToJson()
        {
            try
            {
                string json = JsonConvert.SerializeObject(unmatchedUsers, Formatting.Indented);
                File.WriteAllText(JsonFilePath, json);  // This saves the updated unmatched users
                Console.WriteLine("Data saved to JSON file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to JSON file: {ex.Message}");
            }
        }

        private void btnDisplayJson_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(JsonFilePath))
                {
                    string jsonContent = File.ReadAllText(JsonFilePath);
                    string formattedJson = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(jsonContent), Formatting.Indented);

                    JsonDisplayForm jsonForm = new JsonDisplayForm();
                    jsonForm.DisplayJson(formattedJson);
                    jsonForm.ShowDialog();

                    Console.WriteLine("JSON displayed in popup window.");
                }
                else
                {
                    MessageBox.Show("JSON file not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying JSON: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
