using AtturraTeset.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtturraTeset.UserInterface
{
    internal class ConsoleInputs
    {
        internal static PayFrequency GetPayFrequency()
        {
            var mapping = new Dictionary<string, PayFrequency> {
                { "w", PayFrequency.Weekly },
                { "m", PayFrequency.Monthly },
                { "f", PayFrequency.Fortnightly },
                { "W", PayFrequency.Weekly },
                { "M", PayFrequency.Monthly },
                { "F", PayFrequency.Fortnightly }
            };

            do
            {
                Console.Write("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly: ");
                var input = Console.ReadLine();
                if ((input != null) && mapping.ContainsKey(input.Trim()))
                    return mapping[input];
                else
                    ConsoleOutputs.InvalidInput();
            } while (true);

        }

        internal static decimal GetAnnualSalary()
        {
            decimal salary;

            do
            {
                Console.Write("Enter your salary package amount: ");
                var input = Console.ReadLine();
                if (decimal.TryParse(input, out salary) && (salary > 0))
                {
                    return salary;
                }
                else
                    ConsoleOutputs.InvalidInput();
            } while (true);
        }

    }
}
