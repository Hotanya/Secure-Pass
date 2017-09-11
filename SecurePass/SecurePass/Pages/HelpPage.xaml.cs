using Android.Gms.Ads;
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
    public partial class HelpPage : ContentPage
    {
        public HelpPage()
        {
            InitializeComponent();

            Label header = new Label
            {
                Text = "How to use eSecurePass",
                Font = Font.SystemFontOfSize(40),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            Label passButton = new Label
            {
                Text = "Generate Password Button" ,
                FontSize = 20,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center


            };

            Label passButtonText = new Label
            {
                Text = "Click the Generate Password button to generate a new random password",
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center


            };

            Label copyButton = new Label
            {
                Text = "Copy Password Button",
                FontSize = 20,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center

            };

            Label copyButtonText = new Label
            {
                Text = "Click the Copy Password button to navigate to the Account creation page where the generated password will be autofilled.",
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center


            };

            Label accountCreation = new Label
            {
                Text = "Account Creation Page",
                FontSize = 20,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center

            };

            Label accountCreationText = new Label
            {
                Text = "On this page you can store your generated passwords (or any password you come up with) and assign them with an associated Account.",
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center

            };

            Label view = new Label
            {
                Text = "View Stored Accounts/Passwords",
                FontSize = 20,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center

            };

            Label viewText = new Label
            {
                Text = "Tap the menu icon on the top left of the app. Select the View Stored Passwords button to see all stored Accounts. Click on any existing Account to view the password for that account. You can add new Accounts by tapping the Add button on the top right of the app. ",
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center


            };

            var acv = new AddControlView
            {
                HeightRequest = 50,
                WidthRequest = 320,
                VerticalOptions = LayoutOptions.EndAndExpand
            };

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    passButton,
                    passButtonText,
                    copyButton,
                    copyButtonText,
                    accountCreation,
                    accountCreationText,

                    acv

                }
            };
        }
    }
}