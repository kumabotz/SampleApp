using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.ViewModels
{
    public class DecimalKeypadViewModel : BaseViewModel
    {
        private string _entry = "0";
        public string Entry
        {
            private set => SetProperty(ref _entry, value);
            get => _entry;
        }
        public ICommand ClearCommand { get; }

        public ICommand BackspaceCommand { get; }

        public ICommand DigitCommand { get; }

        public ICommand SimulateDownloadCommand { get; }

        private bool _canDownload = true;
        private string _simulatedDownloadResult;

        internal string SimulatedDownloadResult
        {
            get => _simulatedDownloadResult;
            private set => SetProperty(ref _simulatedDownloadResult, value);
        }

        public DecimalKeypadViewModel()
        {
            ClearCommand = new Command(execute: Clear);
            BackspaceCommand = new Command(Backspace, canExecute: () => Entry.Length > 1 || Entry != "0");
            DigitCommand = new Command<string>(Digit, canExecute: digit => !(digit == "." && Entry.Contains(".")));
            SimulateDownloadCommand = new Command(async() => await SimulateDownloadAsync());
        }

        public async Task SimulateDownloadAsync()
        {
            CanInitiateNewDownload(false);
            SimulatedDownloadResult = "Start";
            await Task.Run(SimulateDownload);
            SimulatedDownloadResult = "Done";
            CanInitiateNewDownload(true);
        }

        private void CanInitiateNewDownload(bool value)
        {
            _canDownload = value;
            ((Command)SimulateDownloadCommand).ChangeCanExecute();
        }

        private void SimulateDownload()
        {
            var delay = DateTime.Now.AddSeconds(3);
            while (true)
            {
                if (DateTime.Now > delay)
                {
                    break;
                }
            }
        }

        private void Backspace()
        {
            Entry = Entry.Substring(0, Entry.Length - 1);
            if (Entry == "")
            {
                Entry = "0";
            }
            RefreshCanExecutes();
        }

        private void Clear()
        {
            Entry = "0";
            RefreshCanExecutes();
        }

        private void RefreshCanExecutes()
        {
            ((Command)BackspaceCommand).ChangeCanExecute();
            ((Command)DigitCommand).ChangeCanExecute();
        }

        private void Digit(string digit)
        {
            Entry += digit;
            if (Entry.StartsWith("0") && !Entry.StartsWith("0."))
            {
                Entry = Entry.Substring(1);
            }
            RefreshCanExecutes();
        }
    }
}