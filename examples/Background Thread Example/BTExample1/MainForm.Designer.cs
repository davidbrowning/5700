namespace BTExample1
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
            this.producerLabel = new System.Windows.Forms.Label();
            this.producerSuspendResumeButton = new System.Windows.Forms.Button();
            this.producerStartStopButton = new System.Windows.Forms.Button();
            this.packagerStartStopButton = new System.Windows.Forms.Button();
            this.packagerSuspendResumeButton = new System.Windows.Forms.Button();
            this.packagerLabel = new System.Windows.Forms.Label();
            this.productionTime = new System.Windows.Forms.NumericUpDown();
            this.packagingTime = new System.Windows.Forms.NumericUpDown();
            this.producerPanel = new System.Windows.Forms.Panel();
            this.producerTimeLabel = new System.Windows.Forms.Label();
            this.packagerPanel = new System.Windows.Forms.Panel();
            this.packagingTimeLabel = new System.Windows.Forms.Label();
            this.consumerPanel = new System.Windows.Forms.Panel();
            this.consumerTimeLabel = new System.Windows.Forms.Label();
            this.consumingSuspendResumeButton = new System.Windows.Forms.Button();
            this.consumingStartStopButton = new System.Windows.Forms.Button();
            this.consumingTime = new System.Windows.Forms.NumericUpDown();
            this.consumerLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productionTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packagingTime)).BeginInit();
            this.producerPanel.SuspendLayout();
            this.packagerPanel.SuspendLayout();
            this.consumerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.consumingTime)).BeginInit();
            this.SuspendLayout();
            // 
            // producerLabel
            // 
            this.producerLabel.AutoSize = true;
            this.producerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.producerLabel.Location = new System.Drawing.Point(16, 21);
            this.producerLabel.Name = "producerLabel";
            this.producerLabel.Size = new System.Drawing.Size(175, 13);
            this.producerLabel.TabIndex = 1;
            this.producerLabel.Text = "Process A - Widget Producer:";
            // 
            // producerSuspendResumeButton
            // 
            this.producerSuspendResumeButton.Location = new System.Drawing.Point(324, 14);
            this.producerSuspendResumeButton.Name = "producerSuspendResumeButton";
            this.producerSuspendResumeButton.Size = new System.Drawing.Size(75, 23);
            this.producerSuspendResumeButton.TabIndex = 2;
            this.producerSuspendResumeButton.Text = "Suspend";
            this.producerSuspendResumeButton.UseVisualStyleBackColor = true;
            this.producerSuspendResumeButton.Visible = false;
            this.producerSuspendResumeButton.Click += new System.EventHandler(this.producerSuspendResumeButton_Click);
            // 
            // producerStartStopButton
            // 
            this.producerStartStopButton.Location = new System.Drawing.Point(256, 14);
            this.producerStartStopButton.Name = "producerStartStopButton";
            this.producerStartStopButton.Size = new System.Drawing.Size(62, 23);
            this.producerStartStopButton.TabIndex = 0;
            this.producerStartStopButton.Text = "Start";
            this.producerStartStopButton.UseVisualStyleBackColor = true;
            this.producerStartStopButton.Click += new System.EventHandler(this.producerStartStopButton_Click);
            // 
            // packagerStartStopButton
            // 
            this.packagerStartStopButton.Location = new System.Drawing.Point(258, 12);
            this.packagerStartStopButton.Name = "packagerStartStopButton";
            this.packagerStartStopButton.Size = new System.Drawing.Size(62, 23);
            this.packagerStartStopButton.TabIndex = 3;
            this.packagerStartStopButton.Text = "Start";
            this.packagerStartStopButton.UseVisualStyleBackColor = true;
            this.packagerStartStopButton.Click += new System.EventHandler(this.packagerStartStopButton_Click);
            // 
            // packagerSuspendResumeButton
            // 
            this.packagerSuspendResumeButton.Location = new System.Drawing.Point(326, 12);
            this.packagerSuspendResumeButton.Name = "packagerSuspendResumeButton";
            this.packagerSuspendResumeButton.Size = new System.Drawing.Size(75, 23);
            this.packagerSuspendResumeButton.TabIndex = 5;
            this.packagerSuspendResumeButton.Text = "Suspend";
            this.packagerSuspendResumeButton.UseVisualStyleBackColor = true;
            this.packagerSuspendResumeButton.Visible = false;
            this.packagerSuspendResumeButton.Click += new System.EventHandler(this.packagerSuspendResumeButton_Click);
            // 
            // packagerLabel
            // 
            this.packagerLabel.AutoSize = true;
            this.packagerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packagerLabel.Location = new System.Drawing.Point(11, 104);
            this.packagerLabel.Name = "packagerLabel";
            this.packagerLabel.Size = new System.Drawing.Size(178, 13);
            this.packagerLabel.TabIndex = 4;
            this.packagerLabel.Text = "Process B - Widget Packager:";
            // 
            // productionTime
            // 
            this.productionTime.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.productionTime.Location = new System.Drawing.Point(163, 17);
            this.productionTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.productionTime.Name = "productionTime";
            this.productionTime.Size = new System.Drawing.Size(67, 20);
            this.productionTime.TabIndex = 6;
            this.productionTime.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.productionTime.ValueChanged += new System.EventHandler(this.productionTime_ValueChanged);
            // 
            // packagingTime
            // 
            this.packagingTime.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.packagingTime.Location = new System.Drawing.Point(165, 15);
            this.packagingTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.packagingTime.Name = "packagingTime";
            this.packagingTime.Size = new System.Drawing.Size(67, 20);
            this.packagingTime.TabIndex = 7;
            this.packagingTime.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.packagingTime.ValueChanged += new System.EventHandler(this.packagingTime_ValueChanged);
            // 
            // producerPanel
            // 
            this.producerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.producerPanel.Controls.Add(this.producerTimeLabel);
            this.producerPanel.Controls.Add(this.productionTime);
            this.producerPanel.Controls.Add(this.producerStartStopButton);
            this.producerPanel.Controls.Add(this.producerSuspendResumeButton);
            this.producerPanel.Location = new System.Drawing.Point(16, 37);
            this.producerPanel.Name = "producerPanel";
            this.producerPanel.Size = new System.Drawing.Size(413, 53);
            this.producerPanel.TabIndex = 8;
            // 
            // producerTimeLabel
            // 
            this.producerTimeLabel.AutoSize = true;
            this.producerTimeLabel.Location = new System.Drawing.Point(7, 19);
            this.producerTimeLabel.Name = "producerTimeLabel";
            this.producerTimeLabel.Size = new System.Drawing.Size(146, 13);
            this.producerTimeLabel.TabIndex = 7;
            this.producerTimeLabel.Text = "Widget Production Time (ms):";
            // 
            // packagerPanel
            // 
            this.packagerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.packagerPanel.Controls.Add(this.packagingTimeLabel);
            this.packagerPanel.Controls.Add(this.packagerSuspendResumeButton);
            this.packagerPanel.Controls.Add(this.packagerStartStopButton);
            this.packagerPanel.Controls.Add(this.packagingTime);
            this.packagerPanel.Location = new System.Drawing.Point(14, 122);
            this.packagerPanel.Name = "packagerPanel";
            this.packagerPanel.Size = new System.Drawing.Size(415, 53);
            this.packagerPanel.TabIndex = 9;
            // 
            // packagingTimeLabel
            // 
            this.packagingTimeLabel.AutoSize = true;
            this.packagingTimeLabel.Location = new System.Drawing.Point(9, 17);
            this.packagingTimeLabel.Name = "packagingTimeLabel";
            this.packagingTimeLabel.Size = new System.Drawing.Size(146, 13);
            this.packagingTimeLabel.TabIndex = 8;
            this.packagingTimeLabel.Text = "Widget Packaging Time (ms):";
            // 
            // consumerPanel
            // 
            this.consumerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.consumerPanel.Controls.Add(this.consumerTimeLabel);
            this.consumerPanel.Controls.Add(this.consumingSuspendResumeButton);
            this.consumerPanel.Controls.Add(this.consumingStartStopButton);
            this.consumerPanel.Controls.Add(this.consumingTime);
            this.consumerPanel.Location = new System.Drawing.Point(14, 209);
            this.consumerPanel.Name = "consumerPanel";
            this.consumerPanel.Size = new System.Drawing.Size(415, 53);
            this.consumerPanel.TabIndex = 11;
            // 
            // consumerTimeLabel
            // 
            this.consumerTimeLabel.AutoSize = true;
            this.consumerTimeLabel.Location = new System.Drawing.Point(9, 17);
            this.consumerTimeLabel.Name = "consumerTimeLabel";
            this.consumerTimeLabel.Size = new System.Drawing.Size(147, 13);
            this.consumerTimeLabel.TabIndex = 8;
            this.consumerTimeLabel.Text = "Widget Consuming Time (ms):";
            // 
            // consumingSuspendResumeButton
            // 
            this.consumingSuspendResumeButton.Location = new System.Drawing.Point(326, 12);
            this.consumingSuspendResumeButton.Name = "consumingSuspendResumeButton";
            this.consumingSuspendResumeButton.Size = new System.Drawing.Size(75, 23);
            this.consumingSuspendResumeButton.TabIndex = 5;
            this.consumingSuspendResumeButton.Text = "Suspend";
            this.consumingSuspendResumeButton.UseVisualStyleBackColor = true;
            this.consumingSuspendResumeButton.Visible = false;
            this.consumingSuspendResumeButton.Click += new System.EventHandler(this.consumingSuspendResumeButton_Click);
            // 
            // consumingStartStopButton
            // 
            this.consumingStartStopButton.Location = new System.Drawing.Point(258, 12);
            this.consumingStartStopButton.Name = "consumingStartStopButton";
            this.consumingStartStopButton.Size = new System.Drawing.Size(62, 23);
            this.consumingStartStopButton.TabIndex = 3;
            this.consumingStartStopButton.Text = "Start";
            this.consumingStartStopButton.UseVisualStyleBackColor = true;
            this.consumingStartStopButton.Click += new System.EventHandler(this.consumingStartStopButton_Click);
            // 
            // consumingTime
            // 
            this.consumingTime.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.consumingTime.Location = new System.Drawing.Point(165, 15);
            this.consumingTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.consumingTime.Name = "consumingTime";
            this.consumingTime.Size = new System.Drawing.Size(67, 20);
            this.consumingTime.TabIndex = 7;
            this.consumingTime.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.consumingTime.ValueChanged += new System.EventHandler(this.consumingTime_ValueChanged);
            // 
            // consumerLabel
            // 
            this.consumerLabel.AutoSize = true;
            this.consumerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consumerLabel.Location = new System.Drawing.Point(11, 188);
            this.consumerLabel.Name = "consumerLabel";
            this.consumerLabel.Size = new System.Drawing.Size(175, 13);
            this.consumerLabel.TabIndex = 10;
            this.consumerLabel.Text = "Process C - Widget Consumer";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(354, 285);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 12;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 320);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.consumerPanel);
            this.Controls.Add(this.consumerLabel);
            this.Controls.Add(this.packagerPanel);
            this.Controls.Add(this.producerPanel);
            this.Controls.Add(this.packagerLabel);
            this.Controls.Add(this.producerLabel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productionTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packagingTime)).EndInit();
            this.producerPanel.ResumeLayout(false);
            this.producerPanel.PerformLayout();
            this.packagerPanel.ResumeLayout(false);
            this.packagerPanel.PerformLayout();
            this.consumerPanel.ResumeLayout(false);
            this.consumerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.consumingTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label producerLabel;
        private System.Windows.Forms.Button producerSuspendResumeButton;
        private System.Windows.Forms.Button producerStartStopButton;
        private System.Windows.Forms.Button packagerStartStopButton;
        private System.Windows.Forms.Button packagerSuspendResumeButton;
        private System.Windows.Forms.Label packagerLabel;
        private System.Windows.Forms.NumericUpDown productionTime;
        private System.Windows.Forms.NumericUpDown packagingTime;
        private System.Windows.Forms.Panel producerPanel;
        private System.Windows.Forms.Label producerTimeLabel;
        private System.Windows.Forms.Panel packagerPanel;
        private System.Windows.Forms.Label packagingTimeLabel;
        private System.Windows.Forms.Panel consumerPanel;
        private System.Windows.Forms.Label consumerTimeLabel;
        private System.Windows.Forms.Button consumingSuspendResumeButton;
        private System.Windows.Forms.Button consumingStartStopButton;
        private System.Windows.Forms.NumericUpDown consumingTime;
        private System.Windows.Forms.Label consumerLabel;
        private System.Windows.Forms.Button exitButton;
    }
}