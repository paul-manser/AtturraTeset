using AtturraTeset.Engine;
using AtturraTeset.Enums;
using AtturraTeset.UserInterface;
using AtturraTest.Repositories;
using System;
using System.Diagnostics;

namespace AtturraTest
{ 
    internal class Program
    {
        static int Main(string[] args)
        {
            //Add handler to handle the exception raised by additional threads
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // Seperation of UI and calculation engine
            var grossPackage = ConsoleInputs.GetAnnualSalary();
            var frequency = ConsoleInputs.GetPayFrequency();

            ConsoleOutputs.ShowProgress();

            // seperate stores what would be in the DB
            var deductionsStore = new DeductionRepository();
            var deductions = deductionsStore.GetAll();

            // can be dependency injection on larger app
            var taxEngine = new TaxEngine(grossPackage, frequency, deductions);
            var pay = taxEngine.CaculatePay();

            ConsoleOutputs.Report(pay);

            return (int)ExitCodes.Success;
        }

        /// <summary>
        /// Do something useful with unhandled exception. At least log them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("An unhandled exception occured. The application will now exit.");
            Console.WriteLine(e.ExceptionObject.ToString());
            Environment.Exit((int)ExitCodes.UnhandledException);
        }

    }
}