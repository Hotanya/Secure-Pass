using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SecurePass.Pages
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Database : ContentPage
    {
        public Database()
        {
            Title = "Accounts";
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtApplicationId = -1;
            listView.ItemsSource = await App.Database.GetApplicationsAsync();
        }

        async void OnApplicationAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailsPage
            {
                BindingContext = new User()
            });
        }

        async void OnApplicationItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtApplicationId = (e.SelectedItem as User).Id;
            Debug.WriteLine("setting ResumeAtApplicationId = " + (e.SelectedItem as User).Id);

            await Navigation.PushAsync(new DetailsPage
            {
                BindingContext = e.SelectedItem as User
            });
        }
    }
}