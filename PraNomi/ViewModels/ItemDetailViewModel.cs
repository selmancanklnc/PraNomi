﻿using PraNomi.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PraNomi.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private DateTime date;
        private string price;
        private string customerName;
        private string selectedProdcuts;
        private string customer;
        private string tax;

        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public string Tax
        {
            get => tax;
            set => SetProperty(ref tax, value);
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

        public string SelectedProducts
        {
            get => selectedProdcuts;
            set => SetProperty(ref selectedProdcuts, value);
        }

        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public string Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }

        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Date = item.Date;
                Price = item.Price;
                SelectedProducts = string.Join(", ", item.SelectedProducts);
                CustomerName = item.CustomerName;
                Customer = item.Customer;
                Tax = item.Tax;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}