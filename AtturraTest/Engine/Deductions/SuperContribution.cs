using AtturraTest.Enums;
using AtturraTest.Interfaces;
using System.Numerics;

namespace AtturraTeset.Engine.Deductions
{
    public class SuperContribution : ISuperContribution
    {
        public Guid Id => throw new NotImplementedException();

        public string Name => "Super";
        public DeductionType DeductionType => DeductionType.Super;

        public decimal Rate => 0.095M;

        public decimal Calculate(decimal grossPackage)
        {
            if (grossPackage < 0)
                throw new ArgumentOutOfRangeException("grossPackage", "Gross package cannot be negative");

            decimal rateReverseFactor = 1M + Rate;
            decimal taxableIncome = grossPackage / rateReverseFactor;
                

            decimal super = (decimal) (grossPackage - taxableIncome);

            return Math.Round(super, 2, MidpointRounding.AwayFromZero); // round to nearest cent
        }
    }
}