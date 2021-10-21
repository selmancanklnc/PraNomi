using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Threading.Tasks;
using PraNomi.Models;
using PraNomi.Popups;
using PraNomi.Utils;



namespace PraNomi.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        #region Fields

        private CountryModel _selectedCountry;

        #endregion Fields


        #region Constructors

        public AboutViewModel()
        {
            
            
                Title = "About";
                SelectedCountry = CountryUtils.GetCountryModelByName("United States");
                ShowPopupCommand = new Command(async _ => await ExecuteShowPopupCommand());
                CountrySelectedCommand = new Command(country => ExecuteCountrySelectedCommand(country as CountryModel));
 
            
        }

        #endregion Constructors

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
    }
}