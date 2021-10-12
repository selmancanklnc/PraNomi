using PraNomi.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PraNomi.Views
{
   
    public partial class LoginPage : ContentPage
    {
        
        public LoginPage()
        {
            InitializeComponent();
            // this.BindingContext = new LoginViewModel();
            
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            var content = await ApiServices.ServiceClientInstance.AuthenticateUserAsync(UserName.Text, UserPassword.Text);

            if (content.Success)
            {
                await Shell.Current.GoToAsync("//AboutPage");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", "Kullanıcı Adı veya Parola Hatalı", "Tamam");
            }


        }

    }
}