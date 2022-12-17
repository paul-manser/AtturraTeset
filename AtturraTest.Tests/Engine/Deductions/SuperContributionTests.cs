using AtturraTeset.Engine.Deductions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtturraTest.Tests.Engine.Deductions
{
    [TestClass()]
    public class SuperContributionTests
    {
        // Because DataRow cannot be used for paramatised tests that take a decimal (who knew) :-)
        public static IEnumerable<object[]> CalculateTestData => new[] {
                new object[] { 50000m, 4337.90m }

        };

        [TestMethod()]
        [DynamicData(nameof(CalculateTestData))]
        public void CalulateTest(decimal gross, decimal expected)
        {
            // arrange
            var super = new SuperContribution();

            // act
            var actual = super.Calculate(gross);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}