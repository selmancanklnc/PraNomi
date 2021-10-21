using PraNomi.Services;
using PraNomi.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
namespace PraNomi
{
    public partial class App : Xamarin.Forms.Application
    {

        public App()
        {
            InitializeComponent();
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
