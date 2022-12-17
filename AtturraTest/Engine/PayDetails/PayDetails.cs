using AtturraTeset.Enums;
using AtturraTest.Interfaces;

namespace AtturraTest.Engine.PayDetails
{
    readonly public struct PayDetails : IPayDetails
    {
        public decimal GrossPackage { get; }
        public decimal TaxableIncome { get; }
        public decimal Super { get; }
        public decimal NetIncome { get; }
        public decimal PayPacket { get; }
        public PayFrequency PayFrequency { get; }

        public IReadOnlyCollection<PayDeduction> Deductions { get; }


        public PayDetails(decimal grossPackage, decimal taxableIncome, decimal super, decimal netIncome, decimal payPacket,
                   PayFrequency payFrequency, IReadOnlyCollection<PayDeduction> deductions)
        {
            GrossPackage = grossPackage;
            TaxableIncome = taxableIncome;
            Super = super;
            NetIncome = netIncome;

            PayPacket = payPacket;
            PayFrequency = payFrequency;
            Deductions = deductions;
        }

    }
}