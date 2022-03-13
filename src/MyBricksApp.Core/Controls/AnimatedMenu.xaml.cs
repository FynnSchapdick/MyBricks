using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MyBricksApp.Core.Mvvm;
using Prism.Commands;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyBricksApp.Core.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimatedMenu
    {
        public string MenuTitle
        {
            get => (string) GetValue(MenuTitleProperty);
            set => SetValue(MenuTitleProperty, value);
        }

        public static readonly BindableProperty MenuTitleProperty = BindableProperty.Create(
            propertyName: nameof(MenuTitle),
            returnType: typeof(string),
            declaringType: typeof(AnimatedMenu),
            defaultValue: "defaultMenuTitle",
            defaultBindingMode: BindingMode.OneWay);

        public string MenuIcon
        {
            get => (string) GetValue(MenuIconProperty);
            set => SetValue(MenuIconProperty, value);
        }

        public static readonly BindableProperty MenuIconProperty = BindableProperty.Create(
            propertyName: nameof(MenuIcon),
            returnType: typeof(string),
            declaringType: typeof(AnimatedMenu),
            defaultValue: "empty.png",
            defaultBindingMode: BindingMode.OneWay);

        public ObservableCollection<MenuItemViewModel> MenuItems
        {
            get => (ObservableCollection<MenuItemViewModel>) GetValue(MenuItemsProperty);
            set => SetValue(MenuItemsProperty, value);
        }

        public static readonly BindableProperty MenuItemsProperty = BindableProperty.Create(
            propertyName: nameof(MenuItems),
            returnType: typeof(ObservableCollection<MenuItemViewModel>),
            declaringType: typeof(AnimatedMenu),
            defaultValue: default,
            defaultBindingMode: BindingMode.OneWay);

        public DelegateCommand<MenuItemViewModel> NavigateCommand
        {
            get => (DelegateCommand<MenuItemViewModel>) GetValue(NavigateCommandProperty);
            set => SetValue(NavigateCommandProperty, value);
        }
        
        public static readonly BindableProperty NavigateCommandProperty = BindableProperty.Create(
            propertyName: nameof(NavigateCommand),
            returnType: typeof(DelegateCommand<MenuItemViewModel>),
            declaringType: typeof(AnimatedMenu),
            defaultValue: default,
            defaultBindingMode: BindingMode.OneWay);

        public AnimatedMenu()
        {
            InitializeComponent();
        }

        private async void ShowMenu(object sender, EventArgs e)
        {
            await Show();
        }

        private async void MenuTapped(object sender, EventArgs e)
        {
            await Hide();

            NavigateCommand?.Execute((sender as StackLayout)?.BindingContext as MenuItemViewModel);
        }

        private async Task Show()
        {
            if (!(GetTemplateChild("TitleText") is Label label)
                || !(GetTemplateChild("MenuItemsView") is Grid menuItemsView) 
                || !(GetTemplateChild("MenuView") is Grid menuView))
            {
                return;
            }

            await label.FadeTo(0);
            await menuItemsView.FadeTo(1);
            await menuView.RotateTo(0, 300, Easing.BounceOut);
        }

        private async Task Hide()
        {
            if (!(GetTemplateChild("TitleText") is Label label)
                || !(GetTemplateChild("MenuItemsView") is Grid menuItemsView) 
                || !(GetTemplateChild("MenuView") is Grid menuView))
            {
                return;
            }

            await label.FadeTo(1);
            await menuItemsView.FadeTo(0);
            await menuView.RotateTo(-90, 300, Easing.BounceOut);
        }
    }
}