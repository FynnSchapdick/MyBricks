namespace MyBricksApp.Core.Mvvm
{
    public class MenuItemViewModel : ViewModelBase
    {
        private string _menuIcon = "empty.png";
        public string MenuIcon
        {
            get => _menuIcon;
            set => SetProperty(ref _menuIcon, value, nameof(MenuIcon));
        }

        public MenuItemViewModel(string title, string icon)
        {
            Title = title;
            MenuIcon = icon;
        }
    }
}