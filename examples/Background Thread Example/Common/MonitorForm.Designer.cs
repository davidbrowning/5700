namespace Common
{
    partial class MonitorForm
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
            this.statsMultiGraph = new Common.MultiGraph();
            this.SuspendLayout();
            // 
            // statsMultiGraph
            // 
            this.statsMultiGraph.AutoScroll = true;
            this.statsMultiGraph.GraphDataSet = null;
            this.statsMultiGraph.Location = new System.Drawing.Point(12, 12);
            this.statsMultiGraph.Name = "statsMultiGraph";
            this.statsMultiGraph.RowIncrement = 50;
            this.statsMultiGraph.Size = new System.Drawing.Size(730, 469);
            this.statsMultiGraph.StandardMargin = 16;
            this.statsMultiGraph.TabIndex = 3;
            this.statsMultiGraph.TickMargin = 1F;
            // 
            // MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 482);
            this.Controls.Add(this.statsMultiGraph);
            this.DoubleBuffered = true;
            this.Name = "MonitorForm";
            this.Text = "Stats Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MonitorForm_FormClosing);
            this.Load += new System.EventHandler(this.MonitorForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MultiGraph statsMultiGraph;

    }
}