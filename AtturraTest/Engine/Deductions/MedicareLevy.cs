using AtturraTest.Enums;
using AtturraTest.Interfaces;

namespace AtturraTest.Engine.Deductions
{
    public class MedicareLevy : IDeduction
    {
        public Guid Id => Guid.NewGuid(); // just hard wired for demo

        public string Name => "Medicare Levy";
        public DeductionType DeductionType => DeductionType.Other;

        public decimal Calculate(decimal grossPackage)
        {
            decimal levy;

            if (grossPackage < 0)
                throw new ArgumentOutOfRangeException("grossPackage", "Gross package cannot be negative");

            if (grossPackage < 21335)
            {
                return 0;
            }
            else if (grossPackage <= 26668)
            {
                levy = (grossPackage - 21335) * 0.1m;
            }
            else // > 26669 and over
            {
                levy = grossPackage * 0.02m;
            }
            
            return Math.Ceiling(levy); // always round up to nearest dollar
        }
    }
}