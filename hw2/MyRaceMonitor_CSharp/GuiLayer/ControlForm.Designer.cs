namespace GuiLayer
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
            this.athletelv = new System.Windows.Forms.ListView();
            this.BibNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RaceStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subscriberlv = new System.Windows.Forms.ListView();
            this.observerlv = new System.Windows.Forms.ListView();
            this.subscribe_button = new System.Windows.Forms.Button();
            this.unsubscribe_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.create_observer_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // athletelv
            // 
            this.athletelv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BibNumber,
            this.FirstName,
            this.LastName,
            this.RaceStatus});
            this.athletelv.Location = new System.Drawing.Point(484, 310);
            this.athletelv.Name = "athletelv";
            this.athletelv.Size = new System.Drawing.Size(717, 210);
            this.athletelv.TabIndex = 0;
            this.athletelv.UseCompatibleStateImageBehavior = false;
            this.athletelv.View = System.Windows.Forms.View.Details;
            //this.athletelv.SelectedIndexChanged += new System.EventHandler(this.athletelv_SelectedIndexChanged);
            // 
            // BibNumber
            // 
            this.BibNumber.Text = "Bib Number";
            this.BibNumber.Width = 97;
            // 
            // FirstName
            // 
            this.FirstName.Text = "FirstName";
            this.FirstName.Width = 93;
            // 
            // LastName
            // 
            this.LastName.Text = "Last Name";
            this.LastName.Width = 99;
            // 
            // RaceStatus
            // 
            this.RaceStatus.Text = "Race Status";
            this.RaceStatus.Width = 144;
            // 
            // subscriberlv
            // 
            this.subscriberlv.Location = new System.Drawing.Point(486, 30);
            this.subscriberlv.Name = "subscriberlv";
            this.subscriberlv.Size = new System.Drawing.Size(715, 209);
            this.subscriberlv.TabIndex = 1;
            this.subscriberlv.UseCompatibleStateImageBehavior = false;
            // 
            // observerlv
            // 
            this.observerlv.Location = new System.Drawing.Point(12, 30);
            this.observerlv.Name = "observerlv";
            this.observerlv.Size = new System.Drawing.Size(444, 389);
            this.observerlv.TabIndex = 2;
            this.observerlv.UseCompatibleStateImageBehavior = false;
            this.observerlv.SelectedIndexChanged += new System.EventHandler(this.observerlv_SelectedIndexChanged);
            // 
            // subscribe_button
            // 
            this.subscribe_button.Location = new System.Drawing.Point(614, 263);
            this.subscribe_button.Name = "subscribe_button";
            this.subscribe_button.Size = new System.Drawing.Size(302, 23);
            this.subscribe_button.TabIndex = 3;
            this.subscribe_button.Text = "Subscribe";
            this.subscribe_button.UseVisualStyleBackColor = true;
            this.subscribe_button.Click += new System.EventHandler(this.subscribe_button_click);
            // 
            // unsubscribe_button
            // 
            this.unsubscribe_button.Location = new System.Drawing.Point(922, 263);
            this.unsubscribe_button.Name = "unsubscribe_button";
            this.unsubscribe_button.Size = new System.Drawing.Size(279, 23);
            this.unsubscribe_button.TabIndex = 4;
            this.unsubscribe_button.Text = "Unsubscribe";
            this.unsubscribe_button.UseVisualStyleBackColor = true;
            this.unsubscribe_button.Click += new System.EventHandler(this.unsubscribe_button_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Subscribed To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(486, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Existing Racers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Observers";
            // 
            // create_observer_button
            // 
            this.create_observer_button.Location = new System.Drawing.Point(12, 437);
            this.create_observer_button.Name = "create_observer_button";
            this.create_observer_button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.create_observer_button.Size = new System.Drawing.Size(444, 83);
            this.create_observer_button.TabIndex = 8;
            this.create_observer_button.Text = "Create";
            this.create_observer_button.UseVisualStyleBackColor = true;
            this.create_observer_button.Click += new System.EventHandler(this.create_observer_button_Click);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 532);
            this.Controls.Add(this.create_observer_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unsubscribe_button);
            this.Controls.Add(this.subscribe_button);
            this.Controls.Add(this.observerlv);
            this.Controls.Add(this.subscriberlv);
            this.Controls.Add(this.athletelv);
            this.Name = "ControlForm";
            this.Text = "ControlForm";
            this.Load += new System.EventHandler(this.ControlForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView athletelv;
        private System.Windows.Forms.ListView subscriberlv;
        private System.Windows.Forms.ListView observerlv;
        private System.Windows.Forms.Button subscribe_button;
        private System.Windows.Forms.Button unsubscribe_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button create_observer_button;
        private System.Windows.Forms.ColumnHeader BibNumber;
        private System.Windows.Forms.ColumnHeader FirstName;
        private System.Windows.Forms.ColumnHeader LastName;
        private System.Windows.Forms.ColumnHeader RaceStatus;
    }
}