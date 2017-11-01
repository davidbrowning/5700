namespace AppLayer
{
    public class PeriodAmounts
    {
        public int PeriodNumber { get; set; }
        public decimal StartingBalance { get; set; }
        public decimal Payment { get; set; }
        public decimal Fee { get; set; }
        public decimal Principle { get; set; }
        public decimal Interest { get; set; }
        public decimal EndingBalance { get; set; }
    }
}
