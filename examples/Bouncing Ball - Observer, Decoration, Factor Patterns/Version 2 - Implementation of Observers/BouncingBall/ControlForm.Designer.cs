namespace BouncingBall
{
    partial class ControlForm
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
            this.createStuffButon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createStuffButon
            // 
            this.createStuffButon.Location = new System.Drawing.Point(31, 31);
            this.createStuffButon.Name = "createStuffButon";
            this.createStuffButon.Size = new System.Drawing.Size(221, 23);
            this.createStuffButon.TabIndex = 0;
            this.createStuffButon.Text = "Create some Ball and Observers";
            this.createStuffButon.UseVisualStyleBackColor = true;
            this.createStuffButon.Click += new System.EventHandler(this.createStuffButon_Click);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 178);
            this.Controls.Add(this.createStuffButon);
            this.Name = "ControlForm";
            this.Text = "ControlForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ControlForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createStuffButon;
    }
}