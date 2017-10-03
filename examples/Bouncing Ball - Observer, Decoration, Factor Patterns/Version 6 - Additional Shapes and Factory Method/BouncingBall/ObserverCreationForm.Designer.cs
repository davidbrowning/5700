namespace BouncingBall
{
    partial class ObserverCreationForm
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
            this.creaetionButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.typeGroupBox = new System.Windows.Forms.GroupBox();
            this.listTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.graphicalTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.typeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // creaetionButton
            // 
            this.creaetionButton.Location = new System.Drawing.Point(333, 91);
            this.creaetionButton.Name = "creaetionButton";
            this.creaetionButton.Size = new System.Drawing.Size(75, 23);
            this.creaetionButton.TabIndex = 0;
            this.creaetionButton.Text = "Create Observer";
            this.creaetionButton.UseVisualStyleBackColor = true;
            this.creaetionButton.Click += new System.EventHandler(this.creaetionButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(20, 91);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(17, 68);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(30, 13);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Title:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(53, 65);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(355, 20);
            this.titleTextBox.TabIndex = 3;
            // 
            // typeGroupBox
            // 
            this.typeGroupBox.Controls.Add(this.graphicalTypeRadioButton);
            this.typeGroupBox.Controls.Add(this.listTypeRadioButton);
            this.typeGroupBox.Location = new System.Drawing.Point(20, 13);
            this.typeGroupBox.Name = "typeGroupBox";
            this.typeGroupBox.Size = new System.Drawing.Size(251, 46);
            this.typeGroupBox.TabIndex = 4;
            this.typeGroupBox.TabStop = false;
            this.typeGroupBox.Text = "Observer Type";
            // 
            // listTypeRadioButton
            // 
            this.listTypeRadioButton.AutoSize = true;
            this.listTypeRadioButton.Checked = true;
            this.listTypeRadioButton.Location = new System.Drawing.Point(6, 19);
            this.listTypeRadioButton.Name = "listTypeRadioButton";
            this.listTypeRadioButton.Size = new System.Drawing.Size(78, 17);
            this.listTypeRadioButton.TabIndex = 0;
            this.listTypeRadioButton.TabStop = true;
            this.listTypeRadioButton.Text = "List Display";
            this.listTypeRadioButton.UseVisualStyleBackColor = true;
            // 
            // graphicalTypeRadioButton
            // 
            this.graphicalTypeRadioButton.AutoSize = true;
            this.graphicalTypeRadioButton.Location = new System.Drawing.Point(128, 19);
            this.graphicalTypeRadioButton.Name = "graphicalTypeRadioButton";
            this.graphicalTypeRadioButton.Size = new System.Drawing.Size(107, 17);
            this.graphicalTypeRadioButton.TabIndex = 1;
            this.graphicalTypeRadioButton.TabStop = true;
            this.graphicalTypeRadioButton.Text = "Graphical Display";
            this.graphicalTypeRadioButton.UseVisualStyleBackColor = true;
            // 
            // ObserverCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 124);
            this.Controls.Add(this.typeGroupBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.creaetionButton);
            this.Name = "ObserverCreationForm";
            this.Text = "ObserverCreationForm";
            this.typeGroupBox.ResumeLayout(false);
            this.typeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button creaetionButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.GroupBox typeGroupBox;
        private System.Windows.Forms.RadioButton graphicalTypeRadioButton;
        private System.Windows.Forms.RadioButton listTypeRadioButton;
    }
}