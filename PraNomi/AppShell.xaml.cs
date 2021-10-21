using PraNomi.ViewModels;
using PraNomi.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PraNomi
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(CustomersPage), typeof(CustomersPage));
            Routing.RegisterRoute(nameof(ProductPage), typeof(ProductPage));
            Routing.RegisterRoute(nameof(Page2), typeof(Page2));
            Routing.RegisterRoute(nameof(Page3), typeof(Page3));
            Task.Run(() => Shell.Current.GoToAsync("//LoginPage"));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
