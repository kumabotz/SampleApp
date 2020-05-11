using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.ViewModels
{
    public class FooViewModel : BaseViewModel
    {
        public ICommand MyCommand { get; }
        private string _result;

        public string Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        public FooViewModel()
        {
            MyCommand = new Command(DoMyCommand);
        }

        private void DoMyCommand()
        {
            Console.WriteLine("hi");
        }
    }
}