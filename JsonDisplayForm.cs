using MetroFramework.Forms;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace AltFinder
{
    public partial class JsonDisplayForm : MetroForm
    {
        public JsonDisplayForm()
        {
            InitializeComponent();

            // Apply dark mode theme to the form
            this.Style = MetroFramework.MetroColorStyle.Black;  // Dark background color
            this.Theme = MetroFramework.MetroThemeStyle.Dark;    // Dark mode theme

            // Optionally, adjust the color of the buttons to match the dark mode
            btnClose.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);  // Dark button background
            btnClose.ForeColor = System.Drawing.Color.White;                  // Light button text
        }

        // Method to load and display the JSON data
        public void DisplayJson(string jsonContent)
        {
            try
            {
                // Format the JSON with indentation
                var formattedJson = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(jsonContent), Formatting.Indented);
                txtJsonContent.Text = formattedJson;

                // Apply dark mode settings for the text box
                txtJsonContent.BackColor = System.Drawing.Color.FromArgb(32, 32, 32); // Dark background
                txtJsonContent.ForeColor = System.Drawing.Color.White;              // Light text color
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying JSON: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Close button click handler
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
