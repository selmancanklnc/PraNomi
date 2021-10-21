using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PraNomi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();



            MainPicker.Items.Add("%0,00");
            MainPicker.Items.Add("%1,00");
            MainPicker.Items.Add("%8,00");
            MainPicker.Items.Add("%18,00");


          
            CurrencyPicker.Items.Add("TRY");

        }
       

        private async void Create_Product(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();

        }

        private void Button_Clicked(object sender, EventArgs e)
        {



        }

        private void MainPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

            var name = MainPicker.Items[MainPicker.SelectedIndex];

        }

        private void CurrencyPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = CurrencyPicker.Items[CurrencyPicker.SelectedIndex];
        }
    }
  
}