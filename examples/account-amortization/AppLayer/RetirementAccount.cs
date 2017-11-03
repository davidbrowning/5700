using System;
using System.Collections.Generic;

namespace AppLayer
{
    public class RetirementAccount : Account
    {

        protected override void SetupColumnHeaders(Amortization amortization)
        {
            Amortization.PaymentColumnHeader = "Deposit";
            Amortization.FeeColumnHeader = "Fee";
            Amortization.InterestColumnHeader = "Interest Earned";
            Amortization.PrincipleColumnHeader = "Paid-in Principle";
        }

        protected override List<string> Validate()
        {
            List<string> errors = new List<string>();
            if (Balance < 0) errors.Add("Invalid starting balance; must be $0 or more");
            if (NumberOfPeriods < 1) errors.Add("Invalid of number of periods; must be 1 or more");
            if (InterestRate < 0.0) errors.Add("Invalid interest rate; must be 0 or more");
            if (PaymentAmount < 100) errors.Add("Invalid deposit amount; must be $100 or more");
            return errors;
        }

        protected override void ComputeFee(PeriodAmounts amounts)
        {
            amounts.Fee = Fee;
        }

        protected override void ComputeInterest(PeriodAmounts amounts)
        {
            amounts.Interest = Balance * (Decimal) InterestRate;
        }

        protected override void ComputePrinciple(PeriodAmounts amounts)
        {
            amounts.Principle = PaymentAmount;
        }

        protected override void ComputeEndingBalance(PeriodAmounts amounts)
        {
            amounts.EndingBalance = Balance + amounts.Interest + amounts.Principle - amounts.Fee;
        }
    }
}
