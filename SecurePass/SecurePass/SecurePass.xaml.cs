using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SecurePass
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecurePass : ContentPage
    {
        public SecurePass()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            var lower = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            var upper = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            var number = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var special = new List<string> { "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "+" };

            //Starting the Random
            Random r = new Random();
            
            //for lower
            int countLower = r.Next(lower.Count); 
            foreach (string i in lower)
            {
                //valueLabel.Text = lower[countLower];
                var l = lower[countLower];
            }

            //for upper
            int countUpper = r.Next(upper.Count);
            foreach (string i in upper)
            {
                //valueLabel.Text = upper[countUpper];
                var u = upper[countUpper];
            }

            //for number
            int countNumber = r.Next(number.Count);
            foreach (int i in number)
            {
                //valueLabel.Text = number[countNumber];
                var n = number[countNumber];
            }

            //for special
            int countSpecial = r.Next(special.Count);
            foreach (string i in special)
            {
                //valueLabel.Text = special[countSpecial];
                var s = special[countSpecial];
            }

            valueLabel.Text = "Your password is: " + lower[countLower] + lower[countLower] + upper[countUpper] + upper[countUpper] + number[countNumber] + number[countNumber] + special[countSpecial] + special[countSpecial];
        }
    }
}
