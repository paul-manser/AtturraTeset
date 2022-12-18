using AtturraTest.Enums;
using AtturraTest.Interfaces;

namespace AtturraTest.Engine.Deductions
{
    public class BudgetRepairLevy : IDeduction
    {
        public Guid Id => Guid.NewGuid(); // just hard wired for demo

        public string Name => "Budget Repair Levy";
        public DeductionType DeductionType => DeductionType.Other;

        public bool IsDecimalPlacesSignificant => false;

        public decimal Calculate(decimal grossPackage)
        {
            decimal levy;

            if (grossPackage < 0)
                throw new ArgumentOutOfRangeException("grossPackage", "Gross package cannot be negative");

            if (grossPackage <= 180000)
            {
                return 0m;
            }
            else // > 1800000
            {
                levy = (grossPackage - 180000) * 0.02m;
            }

            return Math.Ceiling(levy); // always round up to nearest dollar
        }
    }
}
