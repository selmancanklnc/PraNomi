using PraNomi.Models;
using PraNomi.Services;
using PraNomi.ViewModels;
using PraNomi.Views;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PraNomi.Views
{
    public partial class NewItemPage : ContentPage
    {

        ObservableCollection<string> data = new ObservableCollection<string>();
        //public List<Product> Temp = new List<Product>();
        public Item Item { get; set; }
        public NewItemViewModel model { get; set; }
        public NewItemPage()
        {

            InitializeComponent();
            ListOfStore();
            model = new NewItemViewModel()
            {
                Date = DateTime.Now,
                Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0),
                Customers = new Customer()


            };

            BindingContext = model;

        }
        public void ListOfStore() //List of Countries  
        {
            CustomerSearchModel searchModel = new CustomerSearchModel()
            {

                Page = 0,
                Size = 10,
            };
            var customerResponse = CustomerServices.CustomerList(searchModel);
            countryListView.ItemsSource = customerResponse.customers;

        }
        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            countryListView.IsVisible = true;
            countryListView.BeginRefresh();

            try
            {
                CustomerSearchModel searchModel = new CustomerSearchModel()
                {
                    customerSearchQuery = e.NewTextValue,
                    Page = 0,
                    Size = 10,
                };
                var customerResponse = CustomerServices.CustomerList(searchModel);
                var customerList = customerResponse.customers;

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    countryListView.IsVisible = false;
                else if (customerList.Count == 0)
                    countryListView.IsVisible = false;
                else
                    countryListView.ItemsSource = customerList;
            }
            catch (Exception ex)
            {
                countryListView.IsVisible = false;

            }
            countryListView.EndRefresh();

        }


        private void ListView_OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            //EmployeeListView.IsVisible = false;  

            var listsd = e.Item as Customer;
            searchBar_2.Text = listsd.customerName;

            model.Customer = listsd.customerName;

            countryListView.IsVisible = false;

            ((ListView)sender).SelectedItem = null;
        }


        //private void Button_Clicked(object sender, EventArgs e)
        //    {
        //        string customerName = ((Customer)CustomerEntry.SelectedItem).CustomerName;
        //        model.CustomerName = customerName;

        //    }

        private void DatePicker_OnDateSelected(object sender, DateChangedEventArgs e)
        {
            MainLabel.Text = e.NewDate.ToString();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private async void Button_Customer(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CustomersPage));

        }


        private async void Button_Product(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ProductPage));
        }


        private async void Entry_Focused(object sender, FocusEventArgs e)
        {
            MessagingCenter.Send<object, List<string>>(this, "Selected", model.SelectedProducts);

            await Shell.Current.GoToAsync(nameof(Page2) + "?Selected=" + string.Join(",", model.SelectedProducts ?? new List<string>()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<object, List<Product>>(this, "Hi", (obj, s) =>
            {
                entry_2.Text = string.Join(",", s.Select(x => x.productName));
                model.SelectedProducts = s.Select(x => x.UniqueIdentifier).ToList();
                //Temp = s;
            });
        }
    }



}












