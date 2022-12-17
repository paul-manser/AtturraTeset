using AtturraTest.Engine.PayDetails;
using AtturraTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtturraTeset.UserInterface
{
    internal class ConsoleOutputs
    {
        internal static void PrintDeductions(IReadOnlyCollection<PayDeduction> deductions)
        {
            Console.WriteLine("Deductions:");
            foreach (var deduction in deductions)
            {
                Console.WriteLine($"{deduction.Name}: {deduction.Amount:C2}");
            }
        }

        internal static void PrintGrossPackage(decimal grossPackage)
        {
            Console.WriteLine($"Gross package: {grossPackage:C2}");
        }

        internal static void PrintNetIncome(decimal netIncome)
        {
            Console.WriteLine($"Net income: {netIncome:C2}");
        }

        internal static void PrintPayPackage(decimal payPacket)
        {
            Console.WriteLine($"Pay packet: {payPacket:C2}");
        }

        internal static void PrintSuperannuation(decimal super)
        {
            Console.WriteLine($"Superannuation: {super:C2}");
        }

        internal static void PrintTaxableIncome(decimal taxableIncome)
        {
            Console.WriteLine($"Taxable income: {taxableIncome:C2}");
        }

        internal static void NewSectionDivider()
        {
            Console.WriteLine();
        }

        internal static void Report(IPayDetails pay)
        {
            PrintGrossPackage(pay.GrossPackage);
            PrintSuperannuation(pay.Super);
            
            NewSectionDivider();
            
            PrintTaxableIncome(pay.TaxableIncome);

            NewSectionDivider();
            
            PrintDeductions(pay.Deductions);

            NewSectionDivider();
            
            PrintNetIncome(pay.NetIncome);
            PrintPayPackage(pay.PayPacket);
        }

        internal static void ShowProgress()
        {
            Console.WriteLine("Calculating salary details....");
            NewSectionDivider();
        }
    }
}
