namespace Amortization
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
            this.accountTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.retirementTypeOption = new System.Windows.Forms.RadioButton();
            this.loanTypeOption = new System.Windows.Forms.RadioButton();
            this.startingBalanceLabel = new System.Windows.Forms.Label();
            this.startingBalance = new System.Windows.Forms.TextBox();
            this.payment = new System.Windows.Forms.TextBox();
            this.paymentLabel = new System.Windows.Forms.Label();
            this.interestRate = new System.Windows.Forms.TextBox();
            this.interestRateLabel = new System.Windows.Forms.Label();
            this.numberOfPeriods = new System.Windows.Forms.TextBox();
            this.numberOfPeriodLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fee = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.amorizationList = new System.Windows.Forms.ListView();
            this.periodNumberHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.startingBalanceHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paymentColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.feeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.interestColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.principleColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.endingBalanceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.totalPayments = new System.Windows.Forms.Label();
            this.totalFees = new System.Windows.Forms.Label();
            this.totalInterest = new System.Windows.Forms.Label();
            this.totalPrinciple = new System.Windows.Forms.Label();
            this.computeButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.accountTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // accountTypeGroupBox
            // 
            this.accountTypeGroupBox.Controls.Add(this.retirementTypeOption);
            this.accountTypeGroupBox.Controls.Add(this.loanTypeOption);
            this.accountTypeGroupBox.Location = new System.Drawing.Point(27, 19);
            this.accountTypeGroupBox.Name = "accountTypeGroupBox";
            this.accountTypeGroupBox.Size = new System.Drawing.Size(281, 65);
            this.accountTypeGroupBox.TabIndex = 0;
            this.accountTypeGroupBox.TabStop = false;
            this.accountTypeGroupBox.Text = "Type of Account";
            // 
            // retirementTypeOption
            // 
            this.retirementTypeOption.AutoSize = true;
            this.retirementTypeOption.Location = new System.Drawing.Point(144, 28);
            this.retirementTypeOption.Name = "retirementTypeOption";
            this.retirementTypeOption.Size = new System.Drawing.Size(119, 17);
            this.retirementTypeOption.TabIndex = 1;
            this.retirementTypeOption.Text = "Retirement Account";
            this.retirementTypeOption.UseVisualStyleBackColor = true;
            this.retirementTypeOption.CheckedChanged += new System.EventHandler(this.retirementTypeOption_CheckedChanged);
            // 
            // loanTypeOption
            // 
            this.loanTypeOption.AutoSize = true;
            this.loanTypeOption.Checked = true;
            this.loanTypeOption.Location = new System.Drawing.Point(22, 28);
            this.loanTypeOption.Name = "loanTypeOption";
            this.loanTypeOption.Size = new System.Drawing.Size(92, 17);
            this.loanTypeOption.TabIndex = 0;
            this.loanTypeOption.TabStop = true;
            this.loanTypeOption.Text = "Loan Account";
            this.loanTypeOption.UseVisualStyleBackColor = true;
            this.loanTypeOption.CheckedChanged += new System.EventHandler(this.loanTypeOption_CheckedChanged);
            // 
            // startingBalanceLabel
            // 
            this.startingBalanceLabel.AutoSize = true;
            this.startingBalanceLabel.Location = new System.Drawing.Point(30, 103);
            this.startingBalanceLabel.Name = "startingBalanceLabel";
            this.startingBalanceLabel.Size = new System.Drawing.Size(131, 13);
            this.startingBalanceLabel.TabIndex = 1;
            this.startingBalanceLabel.Text = "Starting Principle Balance:";
            // 
            // startingBalance
            // 
            this.startingBalance.Location = new System.Drawing.Point(171, 100);
            this.startingBalance.Name = "startingBalance";
            this.startingBalance.Size = new System.Drawing.Size(100, 20);
            this.startingBalance.TabIndex = 1;
            // 
            // payment
            // 
            this.payment.Location = new System.Drawing.Point(460, 126);
            this.payment.Name = "payment";
            this.payment.Size = new System.Drawing.Size(100, 20);
            this.payment.TabIndex = 5;
            // 
            // paymentLabel
            // 
            this.paymentLabel.AutoSize = true;
            this.paymentLabel.Location = new System.Drawing.Point(350, 129);
            this.paymentLabel.Name = "paymentLabel";
            this.paymentLabel.Size = new System.Drawing.Size(107, 13);
            this.paymentLabel.TabIndex = 3;
            this.paymentLabel.Text = "Payment (per period):";
            // 
            // interestRate
            // 
            this.interestRate.Location = new System.Drawing.Point(171, 157);
            this.interestRate.Name = "interestRate";
            this.interestRate.Size = new System.Drawing.Size(100, 20);
            this.interestRate.TabIndex = 3;
            // 
            // interestRateLabel
            // 
            this.interestRateLabel.AutoSize = true;
            this.interestRateLabel.Location = new System.Drawing.Point(30, 160);
            this.interestRateLabel.Name = "interestRateLabel";
            this.interestRateLabel.Size = new System.Drawing.Size(127, 13);
            this.interestRateLabel.TabIndex = 5;
            this.interestRateLabel.Text = "Interest Rate (per period):";
            // 
            // numberOfPeriods
            // 
            this.numberOfPeriods.Location = new System.Drawing.Point(171, 128);
            this.numberOfPeriods.Name = "numberOfPeriods";
            this.numberOfPeriods.Size = new System.Drawing.Size(100, 20);
            this.numberOfPeriods.TabIndex = 2;
            // 
            // numberOfPeriodLabel
            // 
            this.numberOfPeriodLabel.AutoSize = true;
            this.numberOfPeriodLabel.Location = new System.Drawing.Point(30, 131);
            this.numberOfPeriodLabel.Name = "numberOfPeriodLabel";
            this.numberOfPeriodLabel.Size = new System.Drawing.Size(97, 13);
            this.numberOfPeriodLabel.TabIndex = 7;
            this.numberOfPeriodLabel.Text = "Number of Periods:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Amortization";
            // 
            // fee
            // 
            this.fee.Location = new System.Drawing.Point(460, 100);
            this.fee.Name = "fee";
            this.fee.Size = new System.Drawing.Size(100, 20);
            this.fee.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fee (per period):";
            // 
            // amorizationList
            // 
            this.amorizationList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.periodNumberHeader,
            this.startingBalanceHeader,
            this.paymentColumnHeader,
            this.feeColumnHeader,
            this.interestColumnHeader,
            this.principleColumnHeader,
            this.endingBalanceColumnHeader});
            this.amorizationList.Location = new System.Drawing.Point(33, 211);
            this.amorizationList.Name = "amorizationList";
            this.amorizationList.Size = new System.Drawing.Size(706, 191);
            this.amorizationList.TabIndex = 5;
            this.amorizationList.UseCompatibleStateImageBehavior = false;
            this.amorizationList.View = System.Windows.Forms.View.Details;
            // 
            // periodNumberHeader
            // 
            this.periodNumberHeader.Text = "#";
            this.periodNumberHeader.Width = 51;
            // 
            // startingBalanceHeader
            // 
            this.startingBalanceHeader.Text = "Starting Balance";
            this.startingBalanceHeader.Width = 98;
            // 
            // paymentColumnHeader
            // 
            this.paymentColumnHeader.Text = "Payment";
            this.paymentColumnHeader.Width = 103;
            // 
            // feeColumnHeader
            // 
            this.feeColumnHeader.Text = "Fee";
            this.feeColumnHeader.Width = 89;
            // 
            // interestColumnHeader
            // 
            this.interestColumnHeader.Text = "Interest";
            this.interestColumnHeader.Width = 97;
            // 
            // principleColumnHeader
            // 
            this.principleColumnHeader.Text = "Principle";
            this.principleColumnHeader.Width = 105;
            // 
            // endingBalanceColumnHeader
            // 
            this.endingBalanceColumnHeader.Text = "Ending Balance";
            this.endingBalanceColumnHeader.Width = 119;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Totals:";
            // 
            // totalPayments
            // 
            this.totalPayments.AutoSize = true;
            this.totalPayments.Location = new System.Drawing.Point(191, 414);
            this.totalPayments.Name = "totalPayments";
            this.totalPayments.Size = new System.Drawing.Size(13, 13);
            this.totalPayments.TabIndex = 14;
            this.totalPayments.Text = "$";
            // 
            // totalFees
            // 
            this.totalFees.AutoSize = true;
            this.totalFees.Location = new System.Drawing.Point(295, 414);
            this.totalFees.Name = "totalFees";
            this.totalFees.Size = new System.Drawing.Size(13, 13);
            this.totalFees.TabIndex = 15;
            this.totalFees.Text = "$";
            // 
            // totalInterest
            // 
            this.totalInterest.AutoSize = true;
            this.totalInterest.Location = new System.Drawing.Point(388, 414);
            this.totalInterest.Name = "totalInterest";
            this.totalInterest.Size = new System.Drawing.Size(13, 13);
            this.totalInterest.TabIndex = 16;
            this.totalInterest.Text = "$";
            // 
            // totalPrinciple
            // 
            this.totalPrinciple.AutoSize = true;
            this.totalPrinciple.Location = new System.Drawing.Point(481, 414);
            this.totalPrinciple.Name = "totalPrinciple";
            this.totalPrinciple.Size = new System.Drawing.Size(13, 13);
            this.totalPrinciple.TabIndex = 17;
            this.totalPrinciple.Text = "$";
            // 
            // computeButton
            // 
            this.computeButton.Location = new System.Drawing.Point(353, 155);
            this.computeButton.Name = "computeButton";
            this.computeButton.Size = new System.Drawing.Size(187, 23);
            this.computeButton.TabIndex = 18;
            this.computeButton.Text = "Compute Amortization";
            this.computeButton.UseVisualStyleBackColor = true;
            this.computeButton.Click += new System.EventHandler(this.computeButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "%";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 449);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.computeButton);
            this.Controls.Add(this.totalPrinciple);
            this.Controls.Add(this.totalInterest);
            this.Controls.Add(this.totalFees);
            this.Controls.Add(this.totalPayments);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.amorizationList);
            this.Controls.Add(this.fee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberOfPeriods);
            this.Controls.Add(this.numberOfPeriodLabel);
            this.Controls.Add(this.interestRate);
            this.Controls.Add(this.interestRateLabel);
            this.Controls.Add(this.payment);
            this.Controls.Add(this.paymentLabel);
            this.Controls.Add(this.startingBalance);
            this.Controls.Add(this.startingBalanceLabel);
            this.Controls.Add(this.accountTypeGroupBox);
            this.Name = "MainForm";
            this.Text = "Account Amortization";
            this.accountTypeGroupBox.ResumeLayout(false);
            this.accountTypeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox accountTypeGroupBox;
        private System.Windows.Forms.RadioButton retirementTypeOption;
        private System.Windows.Forms.RadioButton loanTypeOption;
        private System.Windows.Forms.Label startingBalanceLabel;
        private System.Windows.Forms.TextBox startingBalance;
        private System.Windows.Forms.TextBox payment;
        private System.Windows.Forms.Label paymentLabel;
        private System.Windows.Forms.TextBox interestRate;
        private System.Windows.Forms.Label interestRateLabel;
        private System.Windows.Forms.TextBox numberOfPeriods;
        private System.Windows.Forms.Label numberOfPeriodLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView amorizationList;
        private System.Windows.Forms.ColumnHeader periodNumberHeader;
        private System.Windows.Forms.ColumnHeader startingBalanceHeader;
        private System.Windows.Forms.ColumnHeader paymentColumnHeader;
        private System.Windows.Forms.ColumnHeader feeColumnHeader;
        private System.Windows.Forms.ColumnHeader interestColumnHeader;
        private System.Windows.Forms.ColumnHeader principleColumnHeader;
        private System.Windows.Forms.ColumnHeader endingBalanceColumnHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalPayments;
        private System.Windows.Forms.Label totalFees;
        private System.Windows.Forms.Label totalInterest;
        private System.Windows.Forms.Label totalPrinciple;
        private System.Windows.Forms.Button computeButton;
        private System.Windows.Forms.Label label4;
    }
}

