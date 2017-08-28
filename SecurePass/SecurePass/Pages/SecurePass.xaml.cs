using SecurePass.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SecurePass;

namespace SecurePass
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecurePass : ContentPage
    {
        Label label;
        Label valueLabel;

        public SecurePass()
        {
            InitializeComponent();
            Label header = new Label
            {
                Text = "SecurePass",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            var generateButton = new Button { Text = "Generate Password" };
            generateButton.Clicked += OnButtonClicked;

            var copyButton = new Button { Text = "Copy Password" };
            copyButton.Clicked += CopyPassword;

            Slider slider = new Slider
            {
                Minimum = 0,
                Maximum = 50,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            slider.ValueChanged += Slider_ValueChanged;

            valueLabel = new Label
            {                
                Font = Font.SystemFontOfSize(NamedSize.Large),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            label = new Label
            {
                Text = "Slider value is 0",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,                    
                    slider,
                    generateButton,
                    valueLabel,
                    copyButton,
                    //label
                }
            };
        }

        private void GenerateButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        string output { get; set; }
        
        public void OnButtonClicked(object sender, EventArgs args)
        {
            var lower = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            var upper = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            var number = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            var special = new List<string> { "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "+", ",", ".", "'", "{", "}", "<", ">", "=", "_", "`","|" , "/" };
            var all = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "+", ",", ".", "'", "{", "}", "<", ">", "=", "_", "`", "|", "/" };

            //Starting the Random
            Random r = new Random();
            
            //for lower
            int countLower = r.Next(lower.Count);
            int countLower1 = r.Next(lower.Count);
            foreach (string i in lower)
            {
                //valueLabel.Text = lower[countLower];
                var l = lower[countLower];
            }

            //for upper
            int countUpper = r.Next(upper.Count);
            int countUpper1 = r.Next(upper.Count);
            foreach (string i in upper)
            {
                //valueLabel.Text = upper[countUpper];
                var u = upper[countUpper];
            }

            //for number
            int countNumber = r.Next(number.Count);
            int countNumber1 = r.Next(number.Count);
            foreach (string i in number)
            {
                //valueLabel.Text = number[countNumber];
                var n = number[countNumber];
            }

            //for special
            int countSpecial = r.Next(special.Count);
            int countSpecial1 = r.Next(special.Count);
            foreach (string i in special)
            {
                //valueLabel.Text = special[countSpecial];
                var s = special[countSpecial];
            }

            //all
            int countAll = r.Next(all.Count);
            foreach (string i in all)
            {
                 var a = all[countAll];
            }

            var p1 = lower[countLower];
            var p11 = lower[countLower1];

            var p2 = upper[countUpper];
            var p22 = upper[countUpper1];

            var p3 = number[countNumber];
            var p33 = number[countNumber1];

            var p4 = special[countSpecial];
            var p44 = special[countSpecial1];

            var mix = new List<string> { lower[countLower], upper[countUpper], number[countNumber], special[countSpecial], all[countAll] };
            var bleh = new List<string> { };
            int numbr = 5;
            for(int e = 0; e < numbr; e += 1)
            {
                foreach (string i in mix)
                {
                    bleh.Add(i);
                }
                
            }


            output =  p1 + p11 + p2 + p22 + p3 + p33 + p4 + p44;

            
            valueLabel.Text = "Your password is: " + p1 + p11 + p2 + p22 + p3 + p33 + p4 +p44; /*+ all[countAll] + all[countAll] + all[countAll] + all[countAll]*/ 
        }

        async void CopyPassword(object sender, EventArgs e)
        {           
            await Navigation.PushAsync(new DetailsPage
            {
                BindingContext = new User { Password = output }                
            });
            
        }

        void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            label.Text = String.Format("Password length is {0:F1}", e.NewValue);
        }
    }
}
