using NUnit.Framework;
using SampleApp.Views;

namespace UnitTests
{
    [TestFixture]
    public class FooViewTests : ViewUnitTestBase
    {
        [Test]
        public void FooViewTest()
        {
            var view = new FooView();
            Assert.NotNull(view);
        }
    }
}