namespace AltFinder
{
    partial class Form1
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
            this.txtLogContent = new MetroFramework.Controls.MetroTextBox();
            this.txtReferenceList = new MetroFramework.Controls.MetroTextBox();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.txtResult = new MetroFramework.Controls.MetroTextBox();
            this.btnDisplayJson = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // txtLogContent
            // 
            this.txtLogContent.Location = new System.Drawing.Point(13, 27);
            this.txtLogContent.Multiline = true;
            this.txtLogContent.Name = "txtLogContent";
            this.txtLogContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogContent.Size = new System.Drawing.Size(349, 382);
            this.txtLogContent.TabIndex = 0;
            // 
            // txtReferenceList
            // 
            this.txtReferenceList.Location = new System.Drawing.Point(368, 27);
            this.txtReferenceList.Multiline = true;
            this.txtReferenceList.Name = "txtReferenceList";
            this.txtReferenceList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReferenceList.Size = new System.Drawing.Size(349, 383);
            this.txtReferenceList.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(13, 415);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(723, 27);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(410, 383);
            this.txtResult.TabIndex = 3;
            // 
            // btnDisplayJson
            // 
            this.btnDisplayJson.Location = new System.Drawing.Point(1037, 415);
            this.btnDisplayJson.Name = "btnDisplayJson";
            this.btnDisplayJson.Size = new System.Drawing.Size(96, 23);
            this.btnDisplayJson.TabIndex = 5;
            this.btnDisplayJson.Text = "Display Json";
            this.btnDisplayJson.Click += new System.EventHandler(this.btnDisplayJson_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 450);
            this.Controls.Add(this.btnDisplayJson);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtReferenceList);
            this.Controls.Add(this.txtLogContent);
            this.Name = "Form1";
            this.Text = "wwwwww";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtLogContent;
        private MetroFramework.Controls.MetroTextBox txtReferenceList;
        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroTextBox txtResult;
        private MetroFramework.Controls.MetroButton btnDisplayJson;
    }
}
