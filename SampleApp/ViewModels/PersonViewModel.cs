namespace SampleApp.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        private string _name;
        private double _age;
        private string _skills;

        public string Name
        {
            set => SetProperty(ref _name, value);
            get => _name;
        }

        public double Age
        {
            set => SetProperty(ref _age, value);
            get => _age;
        }

        public string Skills
        {
            set => SetProperty(ref _skills, value);
            get => _skills;
        }

        public override string ToString()
        {
            return $"{Name}, age {Age}, skill {Skills}";
        }
    }
}