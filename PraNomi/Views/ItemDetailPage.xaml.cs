using PraNomi.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PraNomi.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}