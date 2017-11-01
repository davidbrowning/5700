using System;
using System.Linq;
using System.Windows.Forms;
using AppLayer;

namespace Amortization
{
    public partial class MainForm : Form
    {
        private AppLayer.Amortization _amortization;

        public MainForm()
        {
            InitializeComponent();
            SetupLoanDefaults();
        }

        private void AdjustPrompts()
        {
            if (loanTypeOption.Checked)
            {
                fee.Text = @"$5.00";
                fee.Enabled = true;
                paymentLabel.Text = @"Payment (per period):";
                SetupLoanDefaults();
            }
            else
            {
                fee.Text = "";
                fee.Enabled = false;
                paymentLabel.Text = @"Deposit (per period):";
                SetupRetirementDefaults();
            }
        }

        private void SetupLoanDefaults()
        {
            if (startingBalance.Text == string.Empty) startingBalance.Text = @"$10000.00";
            if (interestRate.Text == string.Empty) interestRate.Text = @"0.5";
            if (numberOfPeriods.Text == string.Empty) numberOfPeriods.Text = @"60";
            if (fee.Text == string.Empty) fee.Text = @"$5.00";
            payment.Text = "";
        }

        private void SetupRetirementDefaults()
        {
            if (startingBalance.Text == string.Empty) startingBalance.Text = @"$0.00";
            if (interestRate.Text == string.Empty) interestRate.Text = @"0.4";
            if (numberOfPeriods.Text == string.Empty) numberOfPeriods.Text = @"60";
            if (fee.Text == string.Empty) fee.Text = @"$0.00";
            if (payment.Text == string.Empty) payment.Text = @"$200.00";
        }

        private void DisplayRefresh()
        {
            paymentColumnHeader.Text = _amortization.PaymentColumnHeader;
            feeColumnHeader.Text = _amortization.FeeColumnHeader;
            interestColumnHeader.Text = _amortization.InterestColumnHeader;
            principleColumnHeader.Text = _amortization.PrincipleColumnHeader;

            amorizationList.Items.Clear();
            foreach (PeriodAmounts p in _amortization)
            {
                ListViewItem item = new ListViewItem(new []
                {
                    p.PeriodNumber.ToString(),
                    p.StartingBalance.ToString("C"),
                    p.Payment.ToString("C"),
                    p.Fee.ToString("C"),
                    p.Interest.ToString("C"),
                    p.Principle.ToString("C"),
                    p.EndingBalance.ToString("C")
                });
                amorizationList.Items.Add(item);
            }

            totalPayments.Text = _amortization.TotalPayments.ToString("C");
            totalFees.Text = _amortization.TotalFees.ToString("C");
            totalInterest.Text = _amortization.TotalInterest.ToString("C");
            totalPrinciple.Text = _amortization.TotalPrinciple.ToString("C");
        }

        private void loanTypeOption_CheckedChanged(object sender, EventArgs e)
        {
            AdjustPrompts();
        }

        private void retirementTypeOption_CheckedChanged(object sender, EventArgs e)
        {
            AdjustPrompts();
        }

        private void computeButton_Click(object sender, EventArgs e)
        {
            var account = (loanTypeOption.Checked) ? (Account) new LoanAccount() : new RetirementAccount();

            account.Balance = HelperFunctions.ConvertToDecimal(startingBalance.Text);
            account.NumberOfPeriods = HelperFunctions.ConvertToInt(numberOfPeriods.Text);
            account.InterestRate = HelperFunctions.ConvertToPercent(interestRate.Text);
            account.Fee = HelperFunctions.ConvertToDecimal(fee.Text);
            account.PaymentAmount = HelperFunctions.ConvertToDecimal(payment.Text);

            if (loanTypeOption.Checked && account.PaymentAmount <= 0)
            {
                account.PaymentAmount = ((LoanAccount) account).ComputePaymentAmount();
                payment.Text = account.PaymentAmount.ToString("C");
            }

            var errors = account.ComputeAmortization();
            _amortization = account.Amortization;

            if (errors.Count > 0)
            {
                string errorMessage = errors.Aggregate("", (current, err) => current + (err + "\n"));
                MessageBox.Show(errorMessage);
            }
            else
            {
                DisplayRefresh();
            }
        }
    }
}
