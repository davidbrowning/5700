namespace GuiLayer
{
    partial class ListDisplay
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
            this.athleteListView = new System.Windows.Forms.ListView();
            this.BibNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RaceStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Location = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OfficialStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OfficialEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // athleteListView
            // 
            this.athleteListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BibNumber,
            this.RaceStatus,
            this.FirstName,
            this.LastName,
            this.Location,
            this.OfficialStartTime,
            this.OfficialEndTime});
            this.athleteListView.Location = new System.Drawing.Point(12, 12);
            this.athleteListView.Name = "athleteListView";
            this.athleteListView.Size = new System.Drawing.Size(1158, 538);
            this.athleteListView.TabIndex = 0;
            this.athleteListView.UseCompatibleStateImageBehavior = false;
            this.athleteListView.View = System.Windows.Forms.View.Details;
            // 
            // BibNumber
            // 
            this.BibNumber.Text = "Bib Number";
            this.BibNumber.Width = 93;
            // 
            // RaceStatus
            // 
            this.RaceStatus.Text = "Race Status";
            // 
            // FirstName
            // 
            this.FirstName.Text = "First Name";
            this.FirstName.Width = 92;
            // 
            // LastName
            // 
            this.LastName.Text = "Last Name";
            this.LastName.Width = 101;
            // 
            // Location
            // 
            this.Location.Text = "Location";
            this.Location.Width = 171;
            // 
            // OfficialStartTime
            // 
            this.OfficialStartTime.Text = "StartTime";
            this.OfficialStartTime.Width = 185;
            // 
            // OfficialEndTime
            // 
            this.OfficialEndTime.Text = "EndTime";
            this.OfficialEndTime.Width = 173;
            // 
            // ListDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 562);
            this.Controls.Add(this.athleteListView);
            this.Name = "ListDisplay";
            this.Text = "ListView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView athleteListView;
        private System.Windows.Forms.ColumnHeader FirstName;
        private System.Windows.Forms.ColumnHeader LastName;
        private System.Windows.Forms.ColumnHeader BibNumber;
        private System.Windows.Forms.ColumnHeader Location;
        private System.Windows.Forms.ColumnHeader OfficialStartTime;
        private System.Windows.Forms.ColumnHeader OfficialEndTime;
        private System.Windows.Forms.ColumnHeader RaceStatus;
    }
}