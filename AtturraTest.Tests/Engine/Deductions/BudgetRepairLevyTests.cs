using Microsoft.VisualStudio.TestTools.UnitTesting;
using AtturraTest.Engine.Deductions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtturraTest.Engine.Deductions.Tests
{
    [TestClass()]
    public class BudgetRepairLevyTests
    {
        // Because DataRow cannot be used for paramatised tests that take a decimal (who knew) :-)
        public static IEnumerable<object[]> CalculateTestData => new[] {
                new object[] { 179000m, 0m },
                new object[] { 180000m, 0m },
                new object[] { 180001m, 1m },
                new object[] { 200000m, 400m },
                new object[] { 200001m, 401m }
        };

        [TestMethod()]
        [DynamicData(nameof(CalculateTestData))]
        public void CalulateTest(decimal gross, decimal expected)
        {
            // arrange
            var levy = new BudgetRepairLevy();

            // act
            var actual = levy.Calculate(gross);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}