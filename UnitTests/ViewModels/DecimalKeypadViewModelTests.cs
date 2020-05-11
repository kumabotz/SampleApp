using System.Threading.Tasks;
using NUnit.Framework;
using SampleApp.ViewModels;

namespace UnitTests.ViewModels
{
    [TestFixture]
    public class DecimalKeypadViewModelTests
    {
        private DecimalKeypadViewModel _vm;

        [SetUp]
        public void Setup()
        {
            _vm = new DecimalKeypadViewModel();
        }

        [Test]
        public void TestClear()
        {
            _vm.DigitCommand.Execute("1");
            Assert.AreEqual("1", _vm.Entry);
            _vm.ClearCommand.Execute(null);
            Assert.AreEqual("0", _vm.Entry);
        }

        [Test]
        public async Task TestAsync()
        {
            Assert.Null(_vm.SimulatedDownloadResult);
            await _vm.SimulateDownloadAsync();
            Assert.AreEqual("Done", _vm.SimulatedDownloadResult);
        }
    }
}