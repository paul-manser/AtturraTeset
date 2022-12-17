using AtturraTest.Interfaces;

namespace AtturraTest.Engine.PayDetails
{
    public class PayDeduction
    {
        public string Name { get; }
        public decimal Amount { get; }

        public PayDeduction(string name, decimal amount)
        {
            Name = name;
            Amount = amount;
        }

    }

}