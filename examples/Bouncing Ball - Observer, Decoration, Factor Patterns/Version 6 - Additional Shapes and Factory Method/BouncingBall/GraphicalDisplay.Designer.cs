namespace BouncingBall
{
    partial class GraphicalDisplay
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
            this.boxPanel = new System.Windows.Forms.Panel();
            this.boxPanelLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // boxPanel
            // 
            this.boxPanel.BackColor = System.Drawing.Color.White;
            this.boxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxPanel.Location = new System.Drawing.Point(12, 29);
            this.boxPanel.Name = "boxPanel";
            this.boxPanel.Size = new System.Drawing.Size(600, 400);
            this.boxPanel.TabIndex = 0;
            // 
            // boxPanelLabel
            // 
            this.boxPanelLabel.AutoSize = true;
            this.boxPanelLabel.Location = new System.Drawing.Point(13, 12);
            this.boxPanelLabel.Name = "boxPanelLabel";
            this.boxPanelLabel.Size = new System.Drawing.Size(29, 13);
            this.boxPanelLabel.TabIndex = 1;
            this.boxPanelLabel.Tag = "";
            this.boxPanelLabel.Text = "Balls";
            // 
            // GraphicalDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 440);
            this.Controls.Add(this.boxPanelLabel);
            this.Controls.Add(this.boxPanel);
            this.Name = "GraphicalDisplay";
            this.Text = "Box Display";
            this.Load += new System.EventHandler(this.GraphicalDisplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel boxPanel;
        private System.Windows.Forms.Label boxPanelLabel;
    }
}

