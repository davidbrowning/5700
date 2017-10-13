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
            this.otherBallsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.otherBallLabel = new System.Windows.Forms.Label();
            this.observersLabel = new System.Windows.Forms.Label();
            this.observedBallsLabel = new System.Windows.Forms.Label();
            this.observedBallsListView = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.observersListView = new System.Windows.Forms.ListView();
            this.unscribeButton = new System.Windows.Forms.Button();
            this.subscribeButton = new System.Windows.Forms.Button();
            this.createObserverButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.changeColor = new System.Windows.Forms.CheckBox();
            this.changeDirection = new System.Windows.Forms.CheckBox();
            this.changeSpeed = new System.Windows.Forms.CheckBox();
            this.changeSize = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // otherBallsListView
            // 
            this.otherBallsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.otherBallsListView.FullRowSelect = true;
            this.otherBallsListView.Location = new System.Drawing.Point(385, 262);
            this.otherBallsListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.otherBallsListView.Name = "otherBallsListView";
            this.otherBallsListView.Size = new System.Drawing.Size(279, 330);
            this.otherBallsListView.TabIndex = 1;
            this.otherBallsListView.UseCompatibleStateImageBehavior = false;
            this.otherBallsListView.View = System.Windows.Forms.View.Details;
            this.otherBallsListView.SelectedIndexChanged += new System.EventHandler(this.otherBallsListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ball Id";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Radius";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Speed";
            // 
            // otherBallLabel
            // 
            this.otherBallLabel.AutoSize = true;
            this.otherBallLabel.Location = new System.Drawing.Point(381, 239);
            this.otherBallLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.otherBallLabel.Name = "otherBallLabel";
            this.otherBallLabel.Size = new System.Drawing.Size(82, 17);
            this.otherBallLabel.TabIndex = 2;
            this.otherBallLabel.Text = "Other Balls:";
            // 
            // observersLabel
            // 
            this.observersLabel.AutoSize = true;
            this.observersLabel.Location = new System.Drawing.Point(16, 22);
            this.observersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.observersLabel.Name = "observersLabel";
            this.observersLabel.Size = new System.Drawing.Size(78, 17);
            this.observersLabel.TabIndex = 3;
            this.observersLabel.Text = "Observers:";
            // 
            // observedBallsLabel
            // 
            this.observedBallsLabel.AutoSize = true;
            this.observedBallsLabel.Location = new System.Drawing.Point(16, 239);
            this.observedBallsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.observedBallsLabel.Name = "observedBallsLabel";
            this.observedBallsLabel.Size = new System.Drawing.Size(104, 17);
            this.observedBallsLabel.TabIndex = 5;
            this.observedBallsLabel.Text = "Subscribed To:";
            // 
            // observedBallsListView
            // 
            this.observedBallsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.observedBallsListView.FullRowSelect = true;
            this.observedBallsListView.Location = new System.Drawing.Point(20, 262);
            this.observedBallsListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.observedBallsListView.Name = "observedBallsListView";
            this.observedBallsListView.Size = new System.Drawing.Size(279, 330);
            this.observedBallsListView.TabIndex = 6;
            this.observedBallsListView.UseCompatibleStateImageBehavior = false;
            this.observedBallsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ball Id";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Radius";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Speed";
            // 
            // observersListView
            // 
            this.observersListView.Location = new System.Drawing.Point(16, 43);
            this.observersListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.observersListView.MultiSelect = false;
            this.observersListView.Name = "observersListView";
            this.observersListView.Size = new System.Drawing.Size(261, 126);
            this.observersListView.TabIndex = 7;
            this.observersListView.UseCompatibleStateImageBehavior = false;
            this.observersListView.View = System.Windows.Forms.View.List;
            this.observersListView.SelectedIndexChanged += new System.EventHandler(this.observersListView_SelectedIndexChanged);
            // 
            // unscribeButton
            // 
            this.unscribeButton.Location = new System.Drawing.Point(312, 410);
            this.unscribeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.unscribeButton.Name = "unscribeButton";
            this.unscribeButton.Size = new System.Drawing.Size(55, 28);
            this.unscribeButton.TabIndex = 8;
            this.unscribeButton.Text = ">";
            this.unscribeButton.UseVisualStyleBackColor = true;
            this.unscribeButton.Click += new System.EventHandler(this.unscribeButton_Click);
            // 
            // subscribeButton
            // 
            this.subscribeButton.Location = new System.Drawing.Point(312, 367);
            this.subscribeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.subscribeButton.Name = "subscribeButton";
            this.subscribeButton.Size = new System.Drawing.Size(55, 28);
            this.subscribeButton.TabIndex = 9;
            this.subscribeButton.Text = "<";
            this.subscribeButton.UseVisualStyleBackColor = true;
            this.subscribeButton.Click += new System.EventHandler(this.subscribeButton_Click);
            // 
            // createObserverButton
            // 
            this.createObserverButton.Location = new System.Drawing.Point(16, 177);
            this.createObserverButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.createObserverButton.Name = "createObserverButton";
            this.createObserverButton.Size = new System.Drawing.Size(100, 28);
            this.createObserverButton.TabIndex = 11;
            this.createObserverButton.Text = "Create";
            this.createObserverButton.UseVisualStyleBackColor = true;
            this.createObserverButton.Click += new System.EventHandler(this.createObserverButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(385, 177);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 13;
            this.button1.Text = "Create a Ball";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.createBallButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.changeColor);
            this.groupBox1.Controls.Add(this.changeDirection);
            this.groupBox1.Controls.Add(this.changeSpeed);
            this.groupBox1.Controls.Add(this.changeSize);
            this.groupBox1.Location = new System.Drawing.Point(385, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(280, 148);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ball Features";
            // 
            // changeColor
            // 
            this.changeColor.AutoSize = true;
            this.changeColor.Location = new System.Drawing.Point(20, 114);
            this.changeColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.changeColor.Name = "changeColor";
            this.changeColor.Size = new System.Drawing.Size(114, 21);
            this.changeColor.TabIndex = 3;
            this.changeColor.Text = "Change color";
            this.changeColor.UseVisualStyleBackColor = true;
            // 
            // changeDirection
            // 
            this.changeDirection.AutoSize = true;
            this.changeDirection.Location = new System.Drawing.Point(20, 86);
            this.changeDirection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.changeDirection.Name = "changeDirection";
            this.changeDirection.Size = new System.Drawing.Size(137, 21);
            this.changeDirection.TabIndex = 2;
            this.changeDirection.Text = "Change direction";
            this.changeDirection.UseVisualStyleBackColor = true;
            // 
            // changeSpeed
            // 
            this.changeSpeed.AutoSize = true;
            this.changeSpeed.Location = new System.Drawing.Point(20, 58);
            this.changeSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.changeSpeed.Name = "changeSpeed";
            this.changeSpeed.Size = new System.Drawing.Size(122, 21);
            this.changeSpeed.TabIndex = 1;
            this.changeSpeed.Text = "Change speed";
            this.changeSpeed.UseVisualStyleBackColor = true;
            // 
            // changeSize
            // 
            this.changeSize.AutoSize = true;
            this.changeSize.Location = new System.Drawing.Point(20, 30);
            this.changeSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.changeSize.Name = "changeSize";
            this.changeSize.Size = new System.Drawing.Size(108, 21);
            this.changeSize.TabIndex = 0;
            this.changeSize.Text = "Change size";
            this.changeSize.UseVisualStyleBackColor = true;
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 613);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.createObserverButton);
            this.Controls.Add(this.subscribeButton);
            this.Controls.Add(this.unscribeButton);
            this.Controls.Add(this.observersListView);
            this.Controls.Add(this.observedBallsListView);
            this.Controls.Add(this.observedBallsLabel);
            this.Controls.Add(this.observersLabel);
            this.Controls.Add(this.otherBallLabel);
            this.Controls.Add(this.otherBallsListView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ControlForm";
            this.Text = "ControlForm";
            this.Load += new System.EventHandler(this.ControlForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView otherBallsListView;
        private System.Windows.Forms.Label otherBallLabel;
        private System.Windows.Forms.Label observersLabel;
        private System.Windows.Forms.Label observedBallsLabel;
        private System.Windows.Forms.ListView observedBallsListView;
        private System.Windows.Forms.ListView observersListView;
        private System.Windows.Forms.Button unscribeButton;
        private System.Windows.Forms.Button subscribeButton;
        private System.Windows.Forms.Button createObserverButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox changeColor;
        private System.Windows.Forms.CheckBox changeDirection;
        private System.Windows.Forms.CheckBox changeSpeed;
        private System.Windows.Forms.CheckBox changeSize;
    }
}