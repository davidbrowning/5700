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
            this.labelBoxButton = new System.Windows.Forms.ToolStripButton();
            this.lineButton = new System.Windows.Forms.ToolStripButton();
            this.relationship_aggregation = new System.Windows.Forms.ToolStripButton();
            this.relationship_composition = new System.Windows.Forms.ToolStripButton();
            this.relationship_dependency = new System.Windows.Forms.ToolStripButton();
            this.relationship_inheritance = new System.Windows.Forms.ToolStripButton();
            this.fileToolStrip.SuspendLayout();
            this.drawingToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.drawingPanel.Location = new System.Drawing.Point(128, 82);
            this.drawingPanel.Margin = new System.Windows.Forms.Padding(4);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(1091, 827);
            this.drawingPanel.TabIndex = 1;
            this.drawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseDown);
            this.drawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseMove);
            this.drawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseUp);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // fileToolStrip
            // 
            this.fileToolStrip.AutoSize = false;
            this.fileToolStrip.BackColor = System.Drawing.Color.DarkSlateGray;
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
            this.fileToolStrip.Size = new System.Drawing.Size(1219, 79);
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
            this.deleteButton.Size = new System.Drawing.Size(36, 76);
            this.deleteButton.Text = "Delete";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(36, 76);
            this.undoButton.Text = "Undo";
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Image = ((System.Drawing.Image)(resources.GetObject("redoButton.Image")));
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(36, 76);
            this.redoButton.Text = "Redo";
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // drawingToolStrip
            // 
            this.drawingToolStrip.BackColor = System.Drawing.Color.Black;
            this.drawingToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.drawingToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.drawingToolStrip.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.drawingToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointerButton,
            this.toolStripSeparator2,
            this.scaleLabel,
            this.scale,
            this.toolStripSeparator1,
            this.labelBoxButton,
            this.lineButton,
            this.relationship_aggregation,
            this.relationship_composition,
            this.relationship_dependency,
            this.relationship_inheritance});
            this.drawingToolStrip.Location = new System.Drawing.Point(0, 79);
            this.drawingToolStrip.Name = "drawingToolStrip";
            this.drawingToolStrip.Padding = new System.Windows.Forms.Padding(0, 10, 1, 0);
            this.drawingToolStrip.Size = new System.Drawing.Size(119, 833);
            this.drawingToolStrip.TabIndex = 3;
            this.drawingToolStrip.Text = "Tools";
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
            this.toolStripSeparator2.Size = new System.Drawing.Size(116, 6);
            // 
            // scaleLabel
            // 
            this.scaleLabel.BackColor = System.Drawing.Color.White;
            this.scaleLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(116, 20);
            this.scaleLabel.Text = "Scale (.01 to 99):";
            this.scaleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scale
            // 
            this.scale.AutoSize = false;
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(92, 27);
            this.scale.Text = "1";
            this.scale.Leave += new System.EventHandler(this.scale_Leave);
            this.scale.TextChanged += new System.EventHandler(this.scale_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(116, 6);
            // 
            // labelBoxButton
            // 
            this.labelBoxButton.AutoSize = false;
            this.labelBoxButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.labelBoxButton.Image = ((System.Drawing.Image)(resources.GetObject("labelBoxButton.Image")));
            this.labelBoxButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.labelBoxButton.Name = "labelBoxButton";
            this.labelBoxButton.Size = new System.Drawing.Size(90, 40);
            this.labelBoxButton.Text = "Label Box";
            this.labelBoxButton.Click += new System.EventHandler(this.labelBoxButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.AutoSize = false;
            this.lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineButton.Image = ((System.Drawing.Image)(resources.GetObject("lineButton.Image")));
            this.lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(90, 24);
            this.lineButton.Text = "Line";
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // relationship_aggregation
            // 
            this.relationship_aggregation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.relationship_aggregation.Image = global::Forests.Properties.Resources.aggregation;
            this.relationship_aggregation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.relationship_aggregation.Name = "relationship_aggregation";
            this.relationship_aggregation.Size = new System.Drawing.Size(116, 68);
            this.relationship_aggregation.Text = "aggregation";
            this.relationship_aggregation.Click += new System.EventHandler(this.relationshipButton_Click);
            // 
            // relationship_composition
            // 
            this.relationship_composition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.relationship_composition.Image = global::Forests.Properties.Resources.composition;
            this.relationship_composition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.relationship_composition.Name = "relationship_composition";
            this.relationship_composition.Size = new System.Drawing.Size(116, 68);
            this.relationship_composition.Text = "composition";
            this.relationship_composition.Click += new System.EventHandler(this.relationshipButton_Click);
            // 
            // relationship_dependency
            // 
            this.relationship_dependency.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.relationship_dependency.Image = global::Forests.Properties.Resources.dependency;
            this.relationship_dependency.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.relationship_dependency.Name = "relationship_dependency";
            this.relationship_dependency.Size = new System.Drawing.Size(116, 68);
            this.relationship_dependency.Text = "dependency";
            this.relationship_dependency.Click += new System.EventHandler(this.relationshipButton_Click);
            // 
            // relationship_inheritance
            // 
            this.relationship_inheritance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.relationship_inheritance.Image = global::Forests.Properties.Resources.inheritance;
            this.relationship_inheritance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.relationship_inheritance.Name = "relationship_inheritance";
            this.relationship_inheritance.Size = new System.Drawing.Size(116, 68);
            this.relationship_inheritance.Text = "inheritance";
            this.relationship_inheritance.Click += new System.EventHandler(this.relationshipButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1219, 912);
            this.Controls.Add(this.drawingToolStrip);
            this.Controls.Add(this.fileToolStrip);
            this.Controls.Add(this.drawingPanel);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "UML Drawing";
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel scaleLabel;
        private System.Windows.Forms.ToolStripTextBox scale;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton redoButton;
        private System.Windows.Forms.ToolStripButton lineButton;
        private System.Windows.Forms.ToolStripButton labelBoxButton;
        private System.Windows.Forms.ToolStripButton relationship_aggregation;
        private System.Windows.Forms.ToolStripButton relationship_composition;
        private System.Windows.Forms.ToolStripButton relationship_dependency;
        private System.Windows.Forms.ToolStripButton relationship_inheritance;
    }
}

