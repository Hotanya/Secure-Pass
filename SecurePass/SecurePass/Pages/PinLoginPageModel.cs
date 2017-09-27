using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreshMvvm;
using System.Windows.Input;
using PropertyChanged;

namespace SecurePass.Pages
{
    public class PinLoginPageModel : FreshBasePageModel
    {
        [AlsoNotifyFor("PincodeMasked")]
        public string Pincode { get; set; }

        public string PincodeMasked { get { return string.Empty.PadLeft(Pincode != null ? Pincode.Length : 0, '*');} }

        public ICommand NumberCommand { get; protected set; }

        public PinLoginPageModel()
        {
            NumberCommand = new Command<string>(async (key) => await EnterNumber(key));
        }

        async Task EnterNumber(string key)
        {
            // Add the key to the input string until we have the max length of 6.
            if (Pincode == null || Pincode.Length < 6)
                Pincode += key;

            // If there's a pin and it's 6 in length we try a login.
            if (Pincode != null && Pincode.Length == 6)
            {
                Pincode = string.Empty;
                await Application.Current.MainPage.DisplayAlert("Login", "Login Success", "Ok");
                
            }
        }
    }
}
