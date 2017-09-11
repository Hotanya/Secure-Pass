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
            nameEntry.HorizontalOptions = LayoutOptions.CenterAndExpand;
            nameEntry.WidthRequest = 330;


            var passEntry = new Entry();
            passEntry.SetBinding(Entry.TextProperty, "Password");
            passEntry.HorizontalOptions = LayoutOptions.CenterAndExpand;
            passEntry.WidthRequest = 330;
            passEntry.IsPassword = true;

            var showButton = new Button { Text = "Show Password",
            HeightRequest = 50,
            WidthRequest= 330,
            HorizontalOptions = LayoutOptions.CenterAndExpand,

        };
            showButton.Clicked += async (sender, e) =>
            {
                passEntry.IsPassword = false;
            };

            var padding = new Label
            {

            };

            var padding2 = new Label
            {

            };

            var padding3 = new Label
            {

            };

            var padding4 = new Label
            {

            };

            var padding5 = new Label
            {

            };

            var acv = new AddControlView
            {
                HeightRequest = 50,
                WidthRequest = 360,
                VerticalOptions = LayoutOptions.End
            };

            var editSwitch = new Switch();
            editSwitch.SetBinding(Switch.IsToggledProperty, "Edit");
        

            var saveButton = new Button { Text = "Save",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 330
            };
            saveButton.Clicked += async (sender, e) =>
                {
                    if (nameEntry.Text == null || passEntry.Text == null)
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

            var deleteButton = new Button { Text = "Delete",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 330
            };
            deleteButton.Clicked += async (sender, e) =>
            {                
                {
                    var result =
                      await DisplayAlert("Confirmation", "Are you sure? This cannot be undone",
                      "Yes", "Cancel");
                    if (result == true)
                    {
                        var application = (User)BindingContext;
                        await App.Database.DeleteItemAsync(application);
                        await Navigation.PopAsync();
                    }
                }
            };

            var cancelButton = new Button { Text = "Cancel",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 330
            };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };


            Content = new StackLayout
            {
                //Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "AccountName" },
                    nameEntry,
                    new Label { Text = "Password" },
                    passEntry,
                    showButton,
                    //new Label { Text = "Edit" },
                   
                    //editSwitch,
                    saveButton,
                    deleteButton,
                    cancelButton,  
                    padding,
                    padding2,
                    padding3,
                    padding4,
                    padding5,
                    acv,
                }
                

            };
           
            //if (editSwitch.IsToggled == false)
            //{
            //    passEntry.IsEnabled = false;
            //    nameEntry.IsEnabled = false;
            //}
            if (editSwitch.IsToggled == true)
            {
                passEntry.IsEnabled = true;
                nameEntry.IsEnabled = true;
            }
        }
        string nameEntry { get; set; }
        string passEntry { get; set; }
        //async void enable(object sender, EventArgs e)
        //{
        //    //why this no work??
        //    if (doneSwitch.IsToggled)
        //    {
        //        var toggle = passEntry.IsEnabled == true;
        //        return;
        //    }
        //    else
        //    {
        //        var toggle = nameEntry.IsEnabled == false;
        //        return;
        //    }
        //}


        async void OnSaveClicked(object sender, EventArgs e)
        {
            //validate(nameEntry, passEntry);
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

    }
}