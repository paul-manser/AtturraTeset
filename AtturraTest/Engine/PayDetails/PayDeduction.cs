using AtturraTest.Interfaces;

namespace AtturraTest.Engine.PayDetails
{
    public class PayDeduction
    {
        public string Name { get; }
        public decimal Amount { get; }
        
        public bool DecimalPlacesSignificant { get; }

        public PayDeduction(string name, decimal amount, bool decimalPlacesSignificant)
        {
            Name = name;
            Amount = amount;
            DecimalPlacesSignificant = decimalPlacesSignificant;
        }


        override public string ToString()
        {
            switch (DecimalPlacesSignificant)
            {
                case false:
                    return $"{Name}: {Amount:C0}";
                case true:
                    return $"{Name}: {Amount:C2}";
            }
          
        }

    }

}