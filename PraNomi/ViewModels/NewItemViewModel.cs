using PraNomi.Models;
using PraNomi.Popups;
using PraNomi.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PraNomi.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private DateTime date;
        private TimeSpan time;
        private string price;
        private string customerName;
        private string customer;
      
        private CustomerViewModel customers;
        private List<string> selectedProducts;
        #region Fields

        private CountryModel _selectedCountry;

        #endregion Fields

        #region Properties

        public CountryModel SelectedCountry
        {
            get => _selectedCountry;
            set => SetProperty(ref _selectedCountry, value);
        }

        #endregion Properties

        #region Commands

        public ICommand ShowPopupCommand { get; }
        public ICommand CountrySelectedCommand { get; }

        #endregion Commands


        #region Private Methods

        private Task ExecuteShowPopupCommand()
        {
            var popup = new ChooseCountryPopup(SelectedCountry)
            {
                CountrySelectedCommand = CountrySelectedCommand
            };
            return Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
        }

        private void ExecuteCountrySelectedCommand(CountryModel country)
        {
            SelectedCountry = country;
        }

        #endregion Private Methods

        public NewItemViewModel()
        {

            Title = "About";
            SelectedCountry = CountryUtils.GetCountryModelByName("United States");
            ShowPopupCommand = new Command(async _ => await ExecuteShowPopupCommand());
            CountrySelectedCommand = new Command(country => ExecuteCountrySelectedCommand(country as CountryModel));
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text);

            //&& !String.IsNullOrWhiteSpace(price);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public List<string> SelectedProducts
        {
            get => selectedProducts;
            set => SetProperty(ref selectedProducts, value);
        }

        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }
        public TimeSpan Time
        {
            get => time;
            set => SetProperty(ref time, value);
        }

        public string Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }
        public string Customer
        {
            get => customer;
            set => SetProperty(ref customer, value);
        }

        public string CustomerName
        {
            get => customerName;
            set => SetProperty(ref customerName, value);
        }

        
        public CustomerViewModel Customers
        {
            get => customers;
            set => SetProperty(ref customers, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Date = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hours, Time.Minutes, 0),
                Price = Price,
                Customer = Customer,
                CustomerName = CustomerName,
                SelectedProducts = SelectedProducts

            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
