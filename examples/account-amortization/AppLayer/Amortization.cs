using System.Collections.Generic;
using System.Linq;

namespace AppLayer
{
    public class Amortization : IEnumerable<PeriodAmounts>
    {
        private readonly List<PeriodAmounts> _periods = new List<PeriodAmounts>();

        public string PaymentColumnHeader { get; set; }
        public string FeeColumnHeader { get; set; }
        public string InterestColumnHeader { get; set; }
        public string PrincipleColumnHeader { get; set; }

        public decimal TotalPayments => _periods.Sum(p => p.Payment);
        public decimal TotalFees => _periods.Sum(p => p.Fee);
        public decimal TotalInterest => _periods.Sum(p => p.Interest);
        public decimal TotalPrinciple => _periods.Sum(p => p.Principle);
        public int Count => _periods.Count;

        public void Add(PeriodAmounts period)
        {
            if (period != null)
                _periods.Add(period);
        }

        public IEnumerator<PeriodAmounts> GetEnumerator()
        {
            return _periods.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _periods.GetEnumerator();
        }
    }
}
