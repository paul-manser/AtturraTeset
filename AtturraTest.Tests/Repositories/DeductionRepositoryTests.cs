using AtturraTeset.Engine;
using AtturraTest.Repositories;

namespace AtturraTest.Tests.Repositories
{
    [TestClass]
    public class DeductionRepositoryTests
    {
        [TestMethod]
        public void GetAll_ShouldReturn2Items()
        {
            // arrange
            var store = new DeductionRepository();
            var expectedCount = 4;

            // act
            var actual = store.GetAll();

            // assert
            Assert.AreEqual(actual.Count(), expectedCount);
        }
    }
}