using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtturraTest.Engine.Deductions;

namespace AtturraTest.Tests.Engine.Deductions
{
    [TestClass()]
    public class TaxScaleTests
    {

        // Because DataRow cannot be used for paramatised tests that take a decimal (who knew) :-)
        public static IEnumerable<object[]> CalculateTestData => new[] {
                new object[] { 18200m, 0m },
                new object[] { 18201m, 0m }, // this is rounding to nearest dollar, not rounding UP to nearest dollar
                new object[] { 18203m, 1m },
                new object[] { 25000m, 1292m },
                new object[] { 45000m, 6172m },
                new object[] { 59360.73m, 10839m },
                new object[] { 95000m, 22782m },
                new object[] { 200000m, 63632m }
        };

        [TestMethod()]
        [DynamicData(nameof(CalculateTestData))]
        public void CalulateTest(decimal gross, decimal expected)
        {
            // arrange
            var tax = new IncomeTax();

            // act
            var actual = tax.Calculate(gross);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}