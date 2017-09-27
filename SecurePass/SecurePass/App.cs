using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using FreshMvvm;
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
        static CustomersDataAccess database;

        public App()
        {
            var menuPage = new Pages.MenuPage();
            //line below shows numpad without menu icon on top
            //var navContainer = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<Pages.PinLoginPageModel>());
            NavigationPage = new NavigationPage(new Pages.PinLoginPage());
            root = new Pages.root();
            root.Master = menuPage;
            root.Detail = NavigationPage;
            MainPage = root;//if using navContainer, MainPage=navContainer
        }      
        
        public static CustomersDataAccess Database
        {
            get
            {
                if (database == null)
                {
                    database = new CustomersDataAccess(DependencyService.Get<IFileHelper>().GetLocalFilePath("SecurePass.db3"));
                }
                return database;
            }
        }

        public int ResumeAtApplicationId { get; set; }

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
}
