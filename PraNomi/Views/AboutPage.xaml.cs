using PraNomi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PraNomi.Views
{
    public partial class AboutPage : ContentPage
    {

        public List<Fatura> Faturas = new List<Fatura>();
        public AboutPage()
        {
            InitializeComponent();
            this.Faturas = new List<Fatura>();
            Fatura fatura = new Fatura()
            {
                Text = "Gelir 1"
            };

            this.Faturas.Add(fatura);
            this.faturas.ItemsSource = this.Faturas;
        }
    }
}
