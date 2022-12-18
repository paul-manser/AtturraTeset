using AtturraTeset.Enums;
using AtturraTest.Engine.PayDetails;
using AtturraTest.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtturraTeset.Engine
{
    internal class TaxEngine
    {
        public decimal GrossPackage { get; }
        public PayFrequency Frequency { get; set; }

        public IEnumerable<IDeduction> GeneralDedictions { get;  }
        public IIncomeTax Tax { get; }
        public ISuperContribution SuperContribution { get; }


        public TaxEngine(decimal grossPackage, PayFrequency frequency, IEnumerable<IDeduction> deductions)
        {
            GrossPackage = grossPackage;
            Frequency = frequency;  
            GeneralDedictions = deductions.Where(d => d.DeductionType == AtturraTest.Enums.DeductionType.Other) ?? throw new ArgumentNullException(nameof(deductions));
            Tax = (IIncomeTax) deductions.Single(d => d.DeductionType == AtturraTest.Enums.DeductionType.IncomeTax);
            SuperContribution = (ISuperContribution) deductions.Single(d => d.DeductionType == AtturraTest.Enums.DeductionType.Super); ;
        }

        public IPayDetails CaculatePay()
        {
            decimal totalDeduction = 0;
            // keep copy of deductions actually applied so it can be logged in database for historic lookup
            var reportDeductions = new List<PayDeduction>();

            var super = SuperContribution.Calculate(GrossPackage);
            var taxableIncome = GrossPackage - super;

            // General Deductions
            foreach (var deduction in GeneralDedictions)
            {
                var payDeduction = CalculateDeduction(deduction, taxableIncome);
                reportDeductions.Add(payDeduction);
                totalDeduction += payDeduction.Amount;
            }
            // Payroll Tax
            var taxDeduction = CalculateDeduction(Tax, taxableIncome);
            reportDeductions.Add(taxDeduction);
            totalDeduction += taxDeduction.Amount;


            decimal net = taxableIncome - totalDeduction;
            decimal payPacket = CalculatePayPacket(net);
            
            PayDetails pay = new PayDetails(GrossPackage, taxableIncome, super, net, payPacket, Frequency, reportDeductions);

            return pay;
        }

        private PayDeduction CalculateDeduction(IDeduction deduction, decimal taxableIncome)
        {
            var deductionAmount = deduction.Calculate(taxableIncome);
            var payDeduction = new PayDeduction(deduction.Name, deductionAmount, deduction.IsDecimalPlacesSignificant);
            return payDeduction;
        }

        private decimal CalculatePayPacket(decimal net)
        {
            decimal payPacket;
            switch (Frequency)
            {
                case PayFrequency.Weekly:
                    payPacket = net / 52;
                    break;
                case PayFrequency.Fortnightly:
                    payPacket = net / 26;
                    break;
                case PayFrequency.Monthly:
                    payPacket = net / 12;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return payPacket;
        }
    }
}
