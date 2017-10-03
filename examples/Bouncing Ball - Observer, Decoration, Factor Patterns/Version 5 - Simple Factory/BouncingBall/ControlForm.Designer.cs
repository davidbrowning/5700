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
            this.otherShapesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.otherBallLabel = new System.Windows.Forms.Label();
            this.observersLabel = new System.Windows.Forms.Label();
            this.observedBallsLabel = new System.Windows.Forms.Label();
            this.observedShapesListView = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.observersListView = new System.Windows.Forms.ListView();
            this.unscribeButton = new System.Windows.Forms.Button();
            this.subscribeButton = new System.Windows.Forms.Button();
            this.createObserverButton = new System.Windows.Forms.Button();
            this.createShapeButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.triangleOption = new System.Windows.Forms.RadioButton();
            this.squareOption = new System.Windows.Forms.RadioButton();
            this.ballOption = new System.Windows.Forms.RadioButton();
            this.changeColor = new System.Windows.Forms.CheckBox();
            this.changeDirection = new System.Windows.Forms.CheckBox();
            this.changeSpeed = new System.Windows.Forms.CheckBox();
            this.changeSize = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // otherShapesListView
            // 
            this.otherShapesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.otherShapesListView.FullRowSelect = true;
            this.otherShapesListView.Location = new System.Drawing.Point(289, 213);
            this.otherShapesListView.Name = "otherShapesListView";
            this.otherShapesListView.Size = new System.Drawing.Size(210, 269);
            this.otherShapesListView.TabIndex = 1;
            this.otherShapesListView.UseCompatibleStateImageBehavior = false;
            this.otherShapesListView.View = System.Windows.Forms.View.Details;
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
            this.otherBallLabel.Location = new System.Drawing.Point(286, 194);
            this.otherBallLabel.Name = "otherBallLabel";
            this.otherBallLabel.Size = new System.Drawing.Size(114, 13);
            this.otherBallLabel.TabIndex = 2;
            this.otherBallLabel.Text = "Unsubscribed Shapes:";
            // 
            // observersLabel
            // 
            this.observersLabel.AutoSize = true;
            this.observersLabel.Location = new System.Drawing.Point(12, 18);
            this.observersLabel.Name = "observersLabel";
            this.observersLabel.Size = new System.Drawing.Size(58, 13);
            this.observersLabel.TabIndex = 3;
            this.observersLabel.Text = "Observers:";
            // 
            // observedBallsLabel
            // 
            this.observedBallsLabel.AutoSize = true;
            this.observedBallsLabel.Location = new System.Drawing.Point(12, 194);
            this.observedBallsLabel.Name = "observedBallsLabel";
            this.observedBallsLabel.Size = new System.Drawing.Size(102, 13);
            this.observedBallsLabel.TabIndex = 5;
            this.observedBallsLabel.Text = "Subscribed Shapes:";
            // 
            // observedShapesListView
            // 
            this.observedShapesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.observedShapesListView.FullRowSelect = true;
            this.observedShapesListView.Location = new System.Drawing.Point(15, 213);
            this.observedShapesListView.Name = "observedShapesListView";
            this.observedShapesListView.Size = new System.Drawing.Size(210, 269);
            this.observedShapesListView.TabIndex = 6;
            this.observedShapesListView.UseCompatibleStateImageBehavior = false;
            this.observedShapesListView.View = System.Windows.Forms.View.Details;
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
            this.observersListView.Location = new System.Drawing.Point(12, 35);
            this.observersListView.MultiSelect = false;
            this.observersListView.Name = "observersListView";
            this.observersListView.Size = new System.Drawing.Size(197, 103);
            this.observersListView.TabIndex = 7;
            this.observersListView.UseCompatibleStateImageBehavior = false;
            this.observersListView.View = System.Windows.Forms.View.List;
            this.observersListView.SelectedIndexChanged += new System.EventHandler(this.observersListView_SelectedIndexChanged);
            // 
            // unscribeButton
            // 
            this.unscribeButton.Location = new System.Drawing.Point(234, 333);
            this.unscribeButton.Name = "unscribeButton";
            this.unscribeButton.Size = new System.Drawing.Size(41, 23);
            this.unscribeButton.TabIndex = 8;
            this.unscribeButton.Text = ">";
            this.unscribeButton.UseVisualStyleBackColor = true;
            this.unscribeButton.Click += new System.EventHandler(this.unscribeButton_Click);
            // 
            // subscribeButton
            // 
            this.subscribeButton.Location = new System.Drawing.Point(234, 298);
            this.subscribeButton.Name = "subscribeButton";
            this.subscribeButton.Size = new System.Drawing.Size(41, 23);
            this.subscribeButton.TabIndex = 9;
            this.subscribeButton.Text = "<";
            this.subscribeButton.UseVisualStyleBackColor = true;
            this.subscribeButton.Click += new System.EventHandler(this.subscribeButton_Click);
            // 
            // createObserverButton
            // 
            this.createObserverButton.Location = new System.Drawing.Point(12, 144);
            this.createObserverButton.Name = "createObserverButton";
            this.createObserverButton.Size = new System.Drawing.Size(75, 23);
            this.createObserverButton.TabIndex = 11;
            this.createObserverButton.Text = "Create";
            this.createObserverButton.UseVisualStyleBackColor = true;
            this.createObserverButton.Click += new System.EventHandler(this.createObserverButton_Click);
            // 
            // createShapeButton
            // 
            this.createShapeButton.Location = new System.Drawing.Point(289, 144);
            this.createShapeButton.Name = "createShapeButton";
            this.createShapeButton.Size = new System.Drawing.Size(95, 23);
            this.createShapeButton.TabIndex = 13;
            this.createShapeButton.Text = "Create a Shape";
            this.createShapeButton.UseVisualStyleBackColor = true;
            this.createShapeButton.Click += new System.EventHandler(this.createShapeButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.triangleOption);
            this.groupBox1.Controls.Add(this.squareOption);
            this.groupBox1.Controls.Add(this.ballOption);
            this.groupBox1.Controls.Add(this.changeColor);
            this.groupBox1.Controls.Add(this.changeDirection);
            this.groupBox1.Controls.Add(this.changeSpeed);
            this.groupBox1.Controls.Add(this.changeSize);
            this.groupBox1.Location = new System.Drawing.Point(289, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 120);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shape Type and Features";
            // 
            // triangleOption
            // 
            this.triangleOption.AutoSize = true;
            this.triangleOption.Location = new System.Drawing.Point(16, 70);
            this.triangleOption.Name = "triangleOption";
            this.triangleOption.Size = new System.Drawing.Size(63, 17);
            this.triangleOption.TabIndex = 9;
            this.triangleOption.Text = "Triangle";
            this.triangleOption.UseVisualStyleBackColor = true;
            // 
            // squareOption
            // 
            this.squareOption.AutoSize = true;
            this.squareOption.Location = new System.Drawing.Point(16, 47);
            this.squareOption.Name = "squareOption";
            this.squareOption.Size = new System.Drawing.Size(59, 17);
            this.squareOption.TabIndex = 8;
            this.squareOption.Text = "Square";
            this.squareOption.UseVisualStyleBackColor = true;
            // 
            // ballOption
            // 
            this.ballOption.AutoSize = true;
            this.ballOption.Checked = true;
            this.ballOption.Location = new System.Drawing.Point(16, 24);
            this.ballOption.Name = "ballOption";
            this.ballOption.Size = new System.Drawing.Size(42, 17);
            this.ballOption.TabIndex = 7;
            this.ballOption.TabStop = true;
            this.ballOption.Text = "Ball";
            this.ballOption.UseVisualStyleBackColor = true;
            // 
            // changeColor
            // 
            this.changeColor.AutoSize = true;
            this.changeColor.Location = new System.Drawing.Point(95, 93);
            this.changeColor.Name = "changeColor";
            this.changeColor.Size = new System.Drawing.Size(89, 17);
            this.changeColor.TabIndex = 3;
            this.changeColor.Text = "Change color";
            this.changeColor.UseVisualStyleBackColor = true;
            // 
            // changeDirection
            // 
            this.changeDirection.AutoSize = true;
            this.changeDirection.Location = new System.Drawing.Point(95, 70);
            this.changeDirection.Name = "changeDirection";
            this.changeDirection.Size = new System.Drawing.Size(106, 17);
            this.changeDirection.TabIndex = 2;
            this.changeDirection.Text = "Change direction";
            this.changeDirection.UseVisualStyleBackColor = true;
            // 
            // changeSpeed
            // 
            this.changeSpeed.AutoSize = true;
            this.changeSpeed.Location = new System.Drawing.Point(95, 47);
            this.changeSpeed.Name = "changeSpeed";
            this.changeSpeed.Size = new System.Drawing.Size(95, 17);
            this.changeSpeed.TabIndex = 1;
            this.changeSpeed.Text = "Change speed";
            this.changeSpeed.UseVisualStyleBackColor = true;
            // 
            // changeSize
            // 
            this.changeSize.AutoSize = true;
            this.changeSize.Location = new System.Drawing.Point(95, 24);
            this.changeSize.Name = "changeSize";
            this.changeSize.Size = new System.Drawing.Size(84, 17);
            this.changeSize.TabIndex = 0;
            this.changeSize.Text = "Change size";
            this.changeSize.UseVisualStyleBackColor = true;
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 498);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.createShapeButton);
            this.Controls.Add(this.createObserverButton);
            this.Controls.Add(this.subscribeButton);
            this.Controls.Add(this.unscribeButton);
            this.Controls.Add(this.observersListView);
            this.Controls.Add(this.observedShapesListView);
            this.Controls.Add(this.observedBallsLabel);
            this.Controls.Add(this.observersLabel);
            this.Controls.Add(this.otherBallLabel);
            this.Controls.Add(this.otherShapesListView);
            this.Name = "ControlForm";
            this.Text = "ControlForm";
            this.Load += new System.EventHandler(this.ControlForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView otherShapesListView;
        private System.Windows.Forms.Label otherBallLabel;
        private System.Windows.Forms.Label observersLabel;
        private System.Windows.Forms.Label observedBallsLabel;
        private System.Windows.Forms.ListView observedShapesListView;
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
        private System.Windows.Forms.Button createShapeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox changeColor;
        private System.Windows.Forms.CheckBox changeDirection;
        private System.Windows.Forms.CheckBox changeSpeed;
        private System.Windows.Forms.CheckBox changeSize;
        private System.Windows.Forms.RadioButton triangleOption;
        private System.Windows.Forms.RadioButton squareOption;
        private System.Windows.Forms.RadioButton ballOption;
    }
}