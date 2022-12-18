using AtturraTest.Enums;
using AtturraTest.Interfaces;

namespace AtturraTest.Engine.Deductions
{
    public class IncomeTax : IIncomeTax
    {
        public Guid Id => throw new NotImplementedException();

        public string Name => "Income Tax";
        
        public DeductionType DeductionType => DeductionType.IncomeTax;

        public bool IsDecimalPlacesSignificant => true;

        public decimal Calculate(decimal taxableIncome)
        {
            if (taxableIncome < 0)
                throw new ArgumentOutOfRangeException("grossPackage", "Gross package cannot be negative");

            decimal tax;

            if (taxableIncome <= 18200)
            {
                return 0;
            }
            else if (taxableIncome <= 37000)
            {
                tax = (taxableIncome - 18200) * 0.19m;
            }
            else if (taxableIncome <= 87000)
            {
                tax = (taxableIncome - 37000) * 0.325m + 3572m;
            }
            else if (taxableIncome <= 180000)
            {
                tax = (taxableIncome - 87000) * 0.37m + 19822m;
            }
            else // > 180000
            {
                tax = (taxableIncome - 180000) * 0.47m + 54232m;
            }

            return Math.Floor(tax + 0.5M); // this is rounding to nearest dollar, not rounding UP to nearest dollar
            //return Math.Ceiling(tax); // always round up to nearest dollar
        }
    }
}