using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AppLayer;

namespace AppLayerTesting
{
    [TestClass]
    public class AmortizationTester
    {
        [TestMethod]
        public void Amortization_TotalPayment()
        {
            Amortization amortization = new Amortization();
            Setup(amortization);
            Assert.AreEqual(4*205, amortization.TotalPayments);
        }

        private void Setup(Amortization amortization)
        {
            PeriodAmounts p1 = new PeriodAmounts()
            {
                StartingBalance = 10000,
                Payment = 205,
                Fee = 5,
                Interest = 10,
                Principle = 190,
                EndingBalance = 9810
            };
            amortization.Add(p1);

            PeriodAmounts p2 = new PeriodAmounts()
            {
                StartingBalance = 9810,
                Payment = 205,
                Fee = 5,
                Interest = 9,
                Principle = 191,
                EndingBalance = 9619
            };
            amortization.Add(p2);

            PeriodAmounts p3 = new PeriodAmounts()
            {
                StartingBalance = 9619,
                Payment = 205,
                Fee = 5,
                Interest = 8,
                Principle = 192,
                EndingBalance = 9427
            };
            amortization.Add(p3);

            PeriodAmounts p4 = new PeriodAmounts()
            {
                StartingBalance = 9427,
                Payment = 205,
                Fee = 5,
                Interest = 7,
                Principle = 193,
                EndingBalance = 9234
            };
            amortization.Add(p4);

        }
    }
}
