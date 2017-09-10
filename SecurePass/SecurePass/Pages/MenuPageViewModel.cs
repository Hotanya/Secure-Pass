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
        public ICommand GoHelpCommand { get; set; }

        public MenuPageViewModel()
        {
            GoHomeCommand = new Command(GoHome);
            GoDbCommand = new Command(GoDb);
            GoHelpCommand = new Command(GoHelp);
        }

        void GoHome(object obj)
        {
            App.root.Detail = new NavigationPage(new SecurePass());
            App.MenuIsPresented = false;

        }

        void GoDb(object obj)
        {
            //var database = new CustomersDataAccess();
            App.root.Detail = new NavigationPage(new Database());
            App.MenuIsPresented = false;
        }

        void GoHelp(object obj)
        {
            App.root.Detail = new NavigationPage(new HelpPage());
            App.MenuIsPresented = false;
        }
    }
}
