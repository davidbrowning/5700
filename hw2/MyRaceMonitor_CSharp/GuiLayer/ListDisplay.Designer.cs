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
            this.FirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BibNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // athleteListView
            // 
            this.athleteListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FirstName,
            this.LastName,
            this.BibNumber});
            this.athleteListView.Location = new System.Drawing.Point(12, 12);
            this.athleteListView.Name = "athleteListView";
            this.athleteListView.Size = new System.Drawing.Size(628, 409);
            this.athleteListView.TabIndex = 0;
            this.athleteListView.UseCompatibleStateImageBehavior = false;
            // 
            // FirstName
            // 
            this.FirstName.Text = "First Name";
            // 
            // LastName
            // 
            this.LastName.Text = "Last Name";
            // 
            // BibNumber
            // 
            this.BibNumber.Text = "Bib Number";
            // 
            // ListDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 433);
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
    }
}