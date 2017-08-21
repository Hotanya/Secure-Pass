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
        public ICommand GoDbCommand { get; set; }

        public MenuPageViewModel()
        {
            GoHomeCommand = new Command(GoHome);
            GoDbCommand = new Command(GoDb);
        }

        void GoHome(object obj)
        {
            App.root.Detail = new NavigationPage(new SecurePass());
            App.MenuIsPresented = false;

        }

        void GoDb(object obj)
        {
            App.root.Detail = new NavigationPage(new Database());
            App.MenuIsPresented = false;
        }
    }
}
