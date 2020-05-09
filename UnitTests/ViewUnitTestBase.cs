using NUnit.Framework;
using SampleApp;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace UnitTests
{
    public class ViewUnitTestBase
    {
        [SetUp]
        public void Setup()
        {
            MockForms.Init();
            Application.Current = new App();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }
    }
}