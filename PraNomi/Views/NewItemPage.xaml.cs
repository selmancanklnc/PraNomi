﻿using PraNomi.Models;
using PraNomi.ViewModels;
using PraNomi.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PraNomi.Views
{
    public partial class NewItemPage : ContentPage
    {
        

        public Item Item { get; set; }
        public NewItemViewModel model { get; set; }
        public NewItemPage()
        {

            InitializeComponent();
          
            model = new NewItemViewModel()
            {
                Date = DateTime.Now,
                Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0),
                Customers = new CustomerViewModel()
            };

            BindingContext = model;

        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            string customerName = ((Customer)CustomerEntry.SelectedItem).CustomerName;
            model.CustomerName = customerName;

        }

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

    }
}