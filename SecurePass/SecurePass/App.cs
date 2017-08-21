using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Xamarin.Forms;

namespace SecurePass
{
    public class App : Application
    {

        public static NavigationPage NavigationPage { get; private set; }
        public static Pages.root root;

        public static bool MenuIsPresented
        {
            get
            {
                return root.IsPresented;
            }
            set
            {
                root.IsPresented = value;
            }
        }

        public App()
        {
            var menuPage = new Pages.MenuPage();
            NavigationPage = new NavigationPage(new SecurePass());
            root = new Pages.root();
            root.Master = menuPage;
            root.Detail = NavigationPage;
            MainPage = root;
        }       

            protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

    
    public class Main
    {

        // need to add a button or something which will do this when clicked
        public static void GeneratePass()
        {
            string[] lower = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string[] upper = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int[] number = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] special = new string[13] { "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "+" };

            foreach (string i in lower)
                Debug.WriteLine(i);
        }
    }
}
