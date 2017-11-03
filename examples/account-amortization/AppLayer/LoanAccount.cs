using System;
using System.Collections.Generic;

namespace AppLayer
{
    public class LoanAccount : Account
    {
        public decimal ComputePaymentAmount()
        {
            double rateToNth = Math.Pow((1 + InterestRate), (double) NumberOfPeriods);
            decimal principleAndInterest = Balance * Convert.ToDecimal((InterestRate * rateToNth) / (rateToNth - 1));
            return principleAndInterest + Fee;
        }

        protected override void SetupColumnHeaders(Amortization amortization)
        {
            Amortization.PaymentColumnHeader = "Payment";
            Amortization.FeeColumnHeader = "Fee";
            Amortization.InterestColumnHeader = "Interest Paid";
            Amortization.PrincipleColumnHeader = "Principle Paid";
        }

        protected override List<string> Validate()
        {
            List<string> errors = new List<string>();
            if (Balance<1000) errors.Add("Invalid starting balance; must be $1000 or more");
            if (NumberOfPeriods<2) errors.Add("Invalid of number of periods; must be 2 or more");
            if (InterestRate<0.0008) errors.Add("Invalid interest rate; must be .0008 or more");
            if (Fee<0) errors.Add("Invalid fee; must be $0 or more");
            return errors;
        }

        protected override void ComputeFee(PeriodAmounts amounts)
        {
            amounts.Fee = (Balance>0) ? Fee : 0;
        }

        protected override void ComputeInterest(PeriodAmounts amounts)
        {
            amounts.Interest = Balance * (decimal) InterestRate;
        }

        protected override void ComputePrinciple(PeriodAmounts amounts)
        {
            decimal principle = PaymentAmount - amounts.Fee - amounts.Interest;
            if (principle > Balance)
                principle = Balance;
            amounts.Principle = principle;
            amounts.Payment = amounts.Fee + amounts.Interest + amounts.Principle;
        }

        protected override void ComputeEndingBalance(PeriodAmounts amounts)
        {
            amounts.EndingBalance = Balance - amounts.Principle;
        }
    }
}
