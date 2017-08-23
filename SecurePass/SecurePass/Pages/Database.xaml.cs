using System;
using System.Collections.Generic;
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
        private CustomersDataAccess dataAccess;
        public Database()
        {
            InitializeComponent();
            // An instance of the CustomersDataAccessClass
            // that is used for data-binding and data access
            this.dataAccess = new CustomersDataAccess();
        }
        // An event that is raised when the page is shown
        protected override void OnAppearing()
        {
            base.OnAppearing();
            // The instance of CustomersDataAccess
            // is the data binding source
            this.BindingContext = this.dataAccess;
        }
        // Save any pending changes
        private void OnSaveClick(object sender, EventArgs e)
        {
            this.dataAccess.SaveAllApplications();
        }
        // Add a new customer to the Customers collection
        private void OnAddClick(object sender, EventArgs e)
        {
            this.dataAccess.AddNewApplication();
        }
        // Remove the current customer
        // If it exist in the database, it will be removed
        // from there too
        private void OnRemoveClick(object sender, EventArgs e)
        {
            var currentApplication =
              this.CustomersView.SelectedItem as User;
            if (currentApplication != null)
            {
                this.dataAccess.DeleteApplication(currentApplication);
            }
        }
        // Remove all customers
        // Use a DisplayAlert object to ask the user's confirmation
        private async void OnRemoveAllClick(object sender, EventArgs e)
        {
            if (this.dataAccess.Applications.Any())
            {
                var result =
                  await DisplayAlert("Confirmation",
                  "Are you sure? This cannot be undone",
                  "OK", "Cancel");
                if (result == true)
                {
                    this.dataAccess.DeleteAllApplications();
                    this.BindingContext = this.dataAccess;
                }
            }
        }
    }
}