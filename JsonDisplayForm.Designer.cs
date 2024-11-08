namespace AltFinder
{
    partial class JsonDisplayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtJsonContent = new MetroFramework.Controls.MetroTextBox();
            this.btnClose = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // txtJsonContent
            // 
            this.txtJsonContent.Location = new System.Drawing.Point(23, 63);
            this.txtJsonContent.Multiline = true;
            this.txtJsonContent.Name = "txtJsonContent";
            this.txtJsonContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJsonContent.Size = new System.Drawing.Size(754, 533);
            this.txtJsonContent.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(23, 602);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // JsonDisplayForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 648);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtJsonContent);
            this.Name = "JsonDisplayForm";
            this.Text = "Json Data Display";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtJsonContent;
        private MetroFramework.Controls.MetroButton btnClose;
    }
}
