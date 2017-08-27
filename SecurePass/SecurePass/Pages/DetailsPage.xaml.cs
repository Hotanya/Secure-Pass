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
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            
            InitializeComponent();

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "AccountName");

            var passEntry = new Entry();
            passEntry.SetBinding(Entry.TextProperty, "Password");

           

            var doneSwitch = new Switch();
            doneSwitch.SetBinding(Switch.IsToggledProperty, "Done");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                if (nameEntry.Text.Length == 0)
                {
                    await DisplayAlert("Oops", "Please enter an account name", "OK");
                }
                else
                {
                    var application = (User)BindingContext;
                    await App.Database.SaveApplicationAsync(application);
                    await Navigation.PopAsync();
                }
                
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {                
                {
                    var result =
                      await DisplayAlert("Confirmation", "Are you sure? This cannot be undone",
                      "OK", "Cancel");
                    if (result == true)
                    {
                        var application = (User)BindingContext;
                        await App.Database.DeleteItemAsync(application);
                        await Navigation.PopAsync();
                    }
                }
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };




            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "AccountName" },
                    nameEntry,
                    new Label { Text = "Password" },
                    passEntry,
                    //new Label { Text = "Done" },

                    //doneSwitch,
                    saveButton,
                    deleteButton,
                    cancelButton,
                }

            };
            //why this no work??
            if (doneSwitch.IsToggled) {
                var toggle = passEntry.IsEnabled == true;
                return;
            }
            else {
                var toggle = nameEntry.IsEnabled == false;
                return;
            }
        }
        string nameEntry { get; set; }
        string passEntry { get; set; }




        async void OnSaveClicked(object sender, EventArgs e)
        {
            validate(nameEntry, passEntry);
            var application = (User)BindingContext;
            await App.Database.SaveApplicationAsync(application);
            await Navigation.PopAsync();
           
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            
                    var application = (User)BindingContext;
                    await App.Database.DeleteItemAsync(application);
                    await Navigation.PopAsync();               
            
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void validate(string accountName, string password)
        {
            if (!string.IsNullOrWhiteSpace(accountName) && !string.IsNullOrWhiteSpace(password))
            {
                User user = new User
                {
                    AccountName = accountName

                };
                await DisplayAlert("Oops", "Please enter an account name", "OK");

            }
        }
    }
}