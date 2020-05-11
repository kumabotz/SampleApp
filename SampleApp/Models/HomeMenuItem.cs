namespace SampleApp.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        PersonEntry,
        DecimalKeypad
    }

    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }
        public string Title { get; set; }
    }
}