using AtturraTeset.Enums;
using AtturraTest.Engine.PayDetails;

namespace AtturraTest.Interfaces
{
    public interface IPayDetails
    {
        public decimal GrossPackage { get; }
        public decimal TaxableIncome { get; }
        public decimal Super { get; }
        public decimal NetIncome { get; }
        public decimal PayPacket { get; }
        public PayFrequency PayFrequency { get; }
        public IReadOnlyCollection<PayDeduction> Deductions { get; }
    }
}