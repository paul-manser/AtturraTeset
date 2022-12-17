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
    public class MedicareLevyTests
    {
        // Because DataRow cannot be used for paramatised tests that take a decimal (who knew) :-)
        public static IEnumerable<object[]> CalculateTestData => new[] {
                new object[] { 20000m, 0m },
                new object[] { 25000m, 367m },
                new object[] { 40000m, 800m }
        };
        
        [TestMethod()]
        [DynamicData(nameof(CalculateTestData))]
        public void CalulateTest(decimal gross, decimal expected)
        {
            // arrange
            var levy = new MedicareLevy();

            // act
            var actual = levy.Calculate(gross);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}