using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FooView
    {
        internal Label TestFooLabel => FooLabel;

        public FooView()
        {
            InitializeComponent();
        }
    }
}