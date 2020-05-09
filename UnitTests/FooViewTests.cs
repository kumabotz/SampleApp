using NUnit.Framework;
using SampleApp.Views;

namespace UnitTests
{
    [TestFixture]
    public class FooViewTests : ViewUnitTestBase
    {
        [Test]
        public void TestLabelText()
        {
            var view = new FooView();
            Assert.AreEqual("Hello This is Foo View!!", view.TestFooLabel.Text);
        }
    }
}