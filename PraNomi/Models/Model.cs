using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PraNomi.Models
{
   public class ProductListModelPopup : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ProductListModelPopup()
        {
            IsChecked = false;
        }

        public string Text { get; set; }

        private bool isChecked;
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                NotifyPropertyChanged();
            }
        }
    }

}
