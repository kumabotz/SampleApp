using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.ViewModels
{
    public class PersonCollectionViewModel : BaseViewModel
    {
        private PersonViewModel _personEdit;
        private bool _isEditing;

        public bool IsEditing
        {
            private set => SetProperty(ref _isEditing, value);
            get => _isEditing;
        }

        public PersonViewModel PersonEdit
        {
            set => SetProperty(ref _personEdit, value);
            get => _personEdit;
        }
        public ICommand NewCommand { get; }

        public ICommand SubmitCommand { get; }

        public ICommand CancelCommand { get; }

        public IList<PersonViewModel> Persons { get; } = new ObservableCollection<PersonViewModel>();

        public PersonCollectionViewModel()
        {
            NewCommand = new Command(NewPerson, canExecute: () => !IsEditing);
            SubmitCommand = new Command(Submit, 
                canExecute: () => PersonEdit?.Name != null && PersonEdit.Name.Length > 1 && PersonEdit.Age > 0);
            CancelCommand = new Command(Cancel, canExecute: () => IsEditing);
        }

        private void NewPerson()
        {
            PersonEdit = new PersonViewModel();
            PersonEdit.PropertyChanged += OnPersonEditPropertyChanged;
            IsEditing = true;
            RefreshCanExecutes();
        }

        private void Submit()
        {
            Persons.Add(PersonEdit);
            Cancel();
        }

        private void Cancel()
        {
            PersonEdit.PropertyChanged -= OnPersonEditPropertyChanged;
            PersonEdit = null;
            IsEditing = false;
            RefreshCanExecutes();
        }

        private void OnPersonEditPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (SubmitCommand as Command)?.ChangeCanExecute();
        }

        private void RefreshCanExecutes()
        {
            (NewCommand as Command)?.ChangeCanExecute();
            (SubmitCommand as Command)?.ChangeCanExecute();
            (CancelCommand as Command)?.ChangeCanExecute();
        }
    }
}