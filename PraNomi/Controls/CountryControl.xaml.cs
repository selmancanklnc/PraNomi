using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using PraNomi.Models;
using Xamarin.Forms.Xaml;

namespace PraNomi.Controls
{
    public partial class CountryControl : StackLayout
    {
        public static readonly BindableProperty CountryProperty = BindableProperty.Create(
            nameof(Country),
            typeof(CountryModel),
            typeof(CountryControl),
            default,
            BindingMode.TwoWay,
            propertyChanged: (bindable, value, newValue) => (bindable as CountryControl)?.UpdateCountry(newValue as CountryModel));

        public CountryModel Country
        {
            get => (CountryModel)GetValue(CountryProperty);
            set => SetValue(CountryProperty, value);
        }

        public CountryControl()
        {
            InitializeComponent();
        }

        private void UpdateCountry(CountryModel model)
        {
            CountryCodeLabel.Text = $"(+{model?.CountryCode})";
            CountryNameLabel.Text = model?.CountryName;
            CountryCodeLabel1.Text = $"(+{model?.CountryCode})";
            CountryNameLabel1.Text = model?.CountryName;
            if (!string.IsNullOrEmpty(model?.FlagUrl))
            {
                FlagImage.Source = ImageSource.FromUri(new Uri(model?.FlagUrl));
            }
        }
    }
}