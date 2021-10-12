using PraNomi.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
        private CustomerViewModel customers;


        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)

                && !String.IsNullOrWhiteSpace(price);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
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
                CustomerName = CustomerName
            
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
