using System.Collections.Generic;

namespace AppLayer
{
    public abstract class Account
    {
        public decimal Balance { get; set; }
        public int NumberOfPeriods { get; set; }
        public decimal PaymentAmount { get; set; }
        public double InterestRate { get; set; }
        public decimal Fee { get; set; }

        public Amortization Amortization { get; private set; }

        /// <summary>
        /// Compute the amortization for the account.
        /// 
        /// Note that this is a template method with five customizable steps that will be implemented for each
        /// specialization of this class.
        /// </summary>
        /// <returns></returns>
        public List<string> ComputeAmortization()
        {
            var errors = Validate();
            if (errors.Count != 0) return errors;

            Amortization = new Amortization();
            SetupColumnHeaders(Amortization);
            for (var i = 0; i < NumberOfPeriods; i++)
            {
                var p = new PeriodAmounts() { PeriodNumber = i+1, StartingBalance = Balance};
                ComputeFee(p);
                ComputeInterest(p);
                ComputePrinciple(p);
                ComputeEndingBalance(p);
                Amortization.Add(p);
                Balance = p.EndingBalance;
            }
            return errors;
        }

        protected abstract List<string> Validate();
        protected abstract void SetupColumnHeaders(Amortization amortization);
        protected abstract void ComputeFee(PeriodAmounts amounts);
        protected abstract void ComputeInterest(PeriodAmounts amounts);
        protected abstract void ComputePrinciple(PeriodAmounts amounts);
        protected abstract void ComputeEndingBalance(PeriodAmounts amounts);


    }
}
