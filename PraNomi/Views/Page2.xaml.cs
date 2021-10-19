using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PraNomi.Models;
using PraNomi.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PraNomi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Page2 : PopupPage
    {


        public ProductSelectViewModel model = new ProductSelectViewModel();
        public Page2()
        {
            InitializeComponent();



            this.BackgroundColor = Color.White;



            BindingContext = model;
            listView.ItemsSource = model.ProductList;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();


            //var result = BindingContext.Where(w => w.IsChecked).Select(x => x.Text).ToList();

            //string s = string.Join(",", result);



            MessagingCenter.Send<object, string>(this, "Hi", string.Join(",", model.ProductList.Where(x => x.IsChecked).Select(x => x.Text)));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();


        }
    }
}