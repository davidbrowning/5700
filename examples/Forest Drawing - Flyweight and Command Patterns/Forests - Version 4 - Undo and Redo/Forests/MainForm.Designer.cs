namespace Forests
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.fileToolStrip = new System.Windows.Forms.ToolStrip();
            this.newButton = new System.Windows.Forms.ToolStripButton();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.drawingToolStrip = new System.Windows.Forms.ToolStrip();
            this.pointerButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.scaleLabel = new System.Windows.Forms.ToolStripLabel();
            this.scale = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tree01Button = new System.Windows.Forms.ToolStripButton();
            this.tree02Button = new System.Windows.Forms.ToolStripButton();
            this.tree03Button = new System.Windows.Forms.ToolStripButton();
            this.tree04Button = new System.Windows.Forms.ToolStripButton();
            this.tree05Button = new System.Windows.Forms.ToolStripButton();
            this.tree06Button = new System.Windows.Forms.ToolStripButton();
            this.tree07Button = new System.Windows.Forms.ToolStripButton();
            this.fileToolStrip.SuspendLayout();
            this.drawingToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.Color.White;
            this.drawingPanel.Location = new System.Drawing.Point(102, 67);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(812, 672);
            this.drawingPanel.TabIndex = 1;
            this.drawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseUp);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // fileToolStrip
            // 
            this.fileToolStrip.AutoSize = false;
            this.fileToolStrip.BackColor = System.Drawing.Color.CadetBlue;
            this.fileToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.fileToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.fileToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.openButton,
            this.saveButton,
            this.deleteButton,
            this.undoButton,
            this.redoButton});
            this.fileToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fileToolStrip.Name = "fileToolStrip";
            this.fileToolStrip.Size = new System.Drawing.Size(914, 64);
            this.fileToolStrip.TabIndex = 2;
            this.fileToolStrip.Text = "toolStrip1";
            // 
            // newButton
            // 
            this.newButton.AutoSize = false;
            this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newButton.Image = ((System.Drawing.Image)(resources.GetObject("newButton.Image")));
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(61, 61);
            this.newButton.Text = "New";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // openButton
            // 
            this.openButton.AutoSize = false;
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(61, 61);
            this.openButton.Text = "Open Drawing";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.AutoSize = false;
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(61, 61);
            this.saveButton.Text = "Save Drawing";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(36, 61);
            this.deleteButton.Text = "Delete";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(36, 61);
            this.undoButton.Text = "Undo";
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Image = ((System.Drawing.Image)(resources.GetObject("redoButton.Image")));
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(36, 61);
            this.redoButton.Text = "Redo";
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // drawingToolStrip
            // 
            this.drawingToolStrip.BackColor = System.Drawing.Color.PowderBlue;
            this.drawingToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.drawingToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.drawingToolStrip.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.drawingToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointerButton,
            this.toolStripSeparator2,
            this.scaleLabel,
            this.scale,
            this.toolStripSeparator1,
            this.tree01Button,
            this.tree02Button,
            this.tree03Button,
            this.tree04Button,
            this.tree05Button,
            this.tree06Button,
            this.tree07Button});
            this.drawingToolStrip.Location = new System.Drawing.Point(0, 64);
            this.drawingToolStrip.Name = "drawingToolStrip";
            this.drawingToolStrip.Padding = new System.Windows.Forms.Padding(0, 8, 1, 0);
            this.drawingToolStrip.Size = new System.Drawing.Size(93, 675);
            this.drawingToolStrip.TabIndex = 3;
            this.drawingToolStrip.Text = "toolStrip2";
            // 
            // pointerButton
            // 
            this.pointerButton.AutoSize = false;
            this.pointerButton.CheckOnClick = true;
            this.pointerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pointerButton.Image = ((System.Drawing.Image)(resources.GetObject("pointerButton.Image")));
            this.pointerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pointerButton.Name = "pointerButton";
            this.pointerButton.Size = new System.Drawing.Size(61, 50);
            this.pointerButton.Text = "pointerButton";
            this.pointerButton.Click += new System.EventHandler(this.pointerButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(90, 6);
            // 
            // scaleLabel
            // 
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(90, 15);
            this.scaleLabel.Text = "Scale (.01 to 99):";
            this.scaleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scale
            // 
            this.scale.AutoSize = false;
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(70, 23);
            this.scale.Text = "1";
            this.scale.Leave += new System.EventHandler(this.scale_Leave);
            this.scale.TextChanged += new System.EventHandler(this.scale_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(90, 6);
            // 
            // tree01Button
            // 
            this.tree01Button.AutoSize = false;
            this.tree01Button.CheckOnClick = true;
            this.tree01Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tree01Button.Image = ((System.Drawing.Image)(resources.GetObject("tree01Button.Image")));
            this.tree01Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tree01Button.Name = "tree01Button";
            this.tree01Button.Size = new System.Drawing.Size(61, 61);
            this.tree01Button.Text = "Tree-01";
            this.tree01Button.Click += new System.EventHandler(this.treeButton_Click);
            // 
            // tree02Button
            // 
            this.tree02Button.AutoSize = false;
            this.tree02Button.CheckOnClick = true;
            this.tree02Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tree02Button.Image = ((System.Drawing.Image)(resources.GetObject("tree02Button.Image")));
            this.tree02Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tree02Button.Name = "tree02Button";
            this.tree02Button.Size = new System.Drawing.Size(61, 61);
            this.tree02Button.Text = "Tree-02";
            this.tree02Button.Click += new System.EventHandler(this.treeButton_Click);
            // 
            // tree03Button
            // 
            this.tree03Button.AutoSize = false;
            this.tree03Button.CheckOnClick = true;
            this.tree03Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tree03Button.Image = ((System.Drawing.Image)(resources.GetObject("tree03Button.Image")));
            this.tree03Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tree03Button.Name = "tree03Button";
            this.tree03Button.Size = new System.Drawing.Size(61, 61);
            this.tree03Button.Text = "Tree-03";
            this.tree03Button.Click += new System.EventHandler(this.treeButton_Click);
            // 
            // tree04Button
            // 
            this.tree04Button.CheckOnClick = true;
            this.tree04Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tree04Button.Image = ((System.Drawing.Image)(resources.GetObject("tree04Button.Image")));
            this.tree04Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tree04Button.Name = "tree04Button";
            this.tree04Button.Size = new System.Drawing.Size(90, 68);
            this.tree04Button.Text = "Tree-04";
            this.tree04Button.Click += new System.EventHandler(this.treeButton_Click);
            // 
            // tree05Button
            // 
            this.tree05Button.CheckOnClick = true;
            this.tree05Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tree05Button.Image = ((System.Drawing.Image)(resources.GetObject("tree05Button.Image")));
            this.tree05Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tree05Button.Name = "tree05Button";
            this.tree05Button.Size = new System.Drawing.Size(90, 68);
            this.tree05Button.Text = "Tree-05";
            this.tree05Button.ToolTipText = "Tree-05";
            this.tree05Button.Click += new System.EventHandler(this.treeButton_Click);
            // 
            // tree06Button
            // 
            this.tree06Button.CheckOnClick = true;
            this.tree06Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tree06Button.Image = ((System.Drawing.Image)(resources.GetObject("tree06Button.Image")));
            this.tree06Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tree06Button.Name = "tree06Button";
            this.tree06Button.Size = new System.Drawing.Size(90, 68);
            this.tree06Button.Text = "Tree-06";
            this.tree06Button.Click += new System.EventHandler(this.treeButton_Click);
            // 
            // tree07Button
            // 
            this.tree07Button.CheckOnClick = true;
            this.tree07Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tree07Button.Image = ((System.Drawing.Image)(resources.GetObject("tree07Button.Image")));
            this.tree07Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tree07Button.Name = "tree07Button";
            this.tree07Button.Size = new System.Drawing.Size(90, 68);
            this.tree07Button.Text = "Tree-07";
            this.tree07Button.Click += new System.EventHandler(this.treeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(914, 739);
            this.Controls.Add(this.drawingToolStrip);
            this.Controls.Add(this.fileToolStrip);
            this.Controls.Add(this.drawingPanel);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Forest Drawing";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.fileToolStrip.ResumeLayout(false);
            this.fileToolStrip.PerformLayout();
            this.drawingToolStrip.ResumeLayout(false);
            this.drawingToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.ToolStrip fileToolStrip;
        private System.Windows.Forms.ToolStripButton newButton;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStrip drawingToolStrip;
        private System.Windows.Forms.ToolStripButton pointerButton;
        private System.Windows.Forms.ToolStripButton tree01Button;
        private System.Windows.Forms.ToolStripButton tree02Button;
        private System.Windows.Forms.ToolStripButton tree03Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tree04Button;
        private System.Windows.Forms.ToolStripButton tree05Button;
        private System.Windows.Forms.ToolStripButton tree06Button;
        private System.Windows.Forms.ToolStripButton tree07Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel scaleLabel;
        private System.Windows.Forms.ToolStripTextBox scale;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton redoButton;
    }
}

