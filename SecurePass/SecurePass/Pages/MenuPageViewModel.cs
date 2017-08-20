using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SecurePass.Pages
{

    public class MenuPageViewModel
    {
        public ICommand GoHomeCommand { get; set; }

        public MenuPageViewModel()
        {
            GoHomeCommand = new Command(GoHome);
        }

        void GoHome(object obj)
        {
            App.root.Detail = new NavigationPage(new SecurePass());
        }
    }
}
