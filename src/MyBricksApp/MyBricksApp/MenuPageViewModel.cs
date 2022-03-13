using System.Collections.ObjectModel;
using MyBricksApp.Core.Mvvm;
using Prism.Commands;

namespace MyBricksApp
{
    public class MenuPageViewModel : ViewModelBase
    {
        private string _titleIcon;
        public string TitleIcon
        {
            get => _titleIcon;
            set => SetProperty(ref _titleIcon, value, nameof(TitleIcon));
        }

        private ObservableCollection<MenuItemViewModel> _menuItems = new ObservableCollection<MenuItemViewModel>();
        public ObservableCollection<MenuItemViewModel> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value, nameof(MenuItems));
        }
        
        public DelegateCommand<MenuItemViewModel> MenuNavigationCommand { get; }

        public MenuPageViewModel()
        {
            Title = "Menu";
            TitleIcon = "menu.png";
            MenuNavigationCommand = new DelegateCommand<MenuItemViewModel>(NavigateToPage);
            MenuItems = new ObservableCollection<MenuItemViewModel>
                {new MenuItemViewModel("Einstellungen", "settings.png"), new MenuItemViewModel("Profil", "profile.png")};
        }

        private void NavigateToPage(MenuItemViewModel menuItemViewModel)
        {
            
        }
    }
}