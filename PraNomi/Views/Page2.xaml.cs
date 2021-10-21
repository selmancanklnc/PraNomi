using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PraNomi.Models;
using PraNomi.Services;
using PraNomi.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PraNomi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(Selected), nameof(Selected))]

    public partial class Page2 : PopupPage
    {

        public static string Selected { get; set; }
        public ProductSelectViewModel model = new ProductSelectViewModel(Selected);
        public Page2()
        {
            InitializeComponent();

            //denemes

            this.BackgroundColor = Color.White;



            BindingContext = model;
            listView.ItemsSource = model.ProductList;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();


            //var result = BindingContext.Where(w => w.IsChecked).Select(x => x.Text).ToList();

            //string s = string.Join(",", result);



            MessagingCenter.Send<object, List<Product>>(this, "Hi", model.ProductList.Where(x => x.IsChecked).ToList());
        }

        private async void Button_Add_Product(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Page3));
        }
        void ColorSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {

        }
        private void ColorSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = ColorSearchBar.Text;
           if (keyword.Length >= 1)
            {
                ProductSearchModel searchModel = new ProductSearchModel()
                {
                    productSearchQuery = keyword,
                    Page = 0,
                    Size =10,
                };
                var productResult =  ProductServices.ProductList(searchModel);
                // var suggestions = model.ProductList.Where(c => c.UniqueIdentifier.ToLower().Contains(keyword.ToLower()));
              
                listView.ItemsSource = productResult.products;

               listView.IsVisible = true;
            }
            else
            {
                listView.ItemsSource = model.ProductList;
            }
            ColorSearchBar.Focus();
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Shell.Current.Navigation.PopAsync();
            });

            return true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


        }
    }
}