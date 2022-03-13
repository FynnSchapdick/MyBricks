using System.Net.Http;
using MyBricksApp.Features.Parts;
using Prism.Ioc;
using RebrickableSharp.Client;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace MyBricksApp
{
    public partial class App
    {
        public App()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<PartsView, PartsViewModel>();
            containerRegistry.RegisterSingleton(typeof(IRebrickableClient), provider => RebrickableClientFactory.Build(new HttpClient()));
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            
            RebrickableClientConfiguration.Instance.ApiKey = "";
            
            var result = await NavigationService.NavigateAsync("PartsView");

            if(!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }
    }
}