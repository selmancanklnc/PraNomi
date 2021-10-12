using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace PraNomi.ViewModels
{
    class ShowPasswordTriggerAction : TriggerAction<ImageButton>, INotifyPropertyChanged
    {
       
            public string ShowIcon { get; set; }
            public string HideIcon { get; set; }

            bool _hidepassword = true;

            public bool HidePassword
            {
                get => _hidepassword;
                set
                {
                    if (_hidepassword != value)
                    {
                        _hidepassword = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HidePassword)));
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;

            protected override void Invoke(ImageButton sender)
            {
                sender.Source = HidePassword ? ShowIcon : HideIcon;
                HidePassword = !HidePassword;
            }
        }
    }

