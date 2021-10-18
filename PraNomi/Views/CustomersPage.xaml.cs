using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace PraNomi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomersPage : ContentPage
    {

        List<string> colors = new List<string>
        {
            "Red", "Blue", "Green", "Yellow","ee","eeee","eewwewewe","eeeqwreqwer","eewqewqfaxdfx","eedfsdf"
        };

        ObservableCollection<string> myColors = new ObservableCollection<string>();

        public CustomersPage()
        {
            InitializeComponent();
        }
      
        private void ColorsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var color = e.Item as string;

            myColors.Add(color);
            ColorsListView.ItemsSource = myColors;

            SuggestionsListView.IsVisible = false;
        }

        private void ColorSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = ColorSearchBar.Text;
            Ekle_Button.IsVisible = true;
            if (keyword.Length >= 1)
            {
                var suggestions = colors.Where(c => c.ToLower().Contains(keyword.ToLower()));

                SuggestionsListView.ItemsSource = suggestions;

                SuggestionsListView.IsVisible = true;
            }
            else
            {
                Ekle_Button.IsVisible = false;
                SuggestionsListView.IsVisible = false;
            }
        }
        void ColorSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {

        }

        private void Button_add(object sender, EventArgs e)
        {
            var keyword = ColorSearchBar.Text;

            if (keyword != null)
            {
                colors.Add(ColorSearchBar.Text.ToString());
              
            }
            
          

        }
    }
}