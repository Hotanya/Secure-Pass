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
            foreach (int i in number)
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
            var p1 = lower[countLower];
            var p11 = lower[countLower1];

            var p2 = upper[countUpper];
            var p22 = upper[countUpper1];

            var p3 = number[countNumber];
            var p33 = number[countNumber1];

            var p4 = special[countSpecial];
            var p44 = special[countSpecial1];

            valueLabel.Text = "Your password is: " + p1 + p11 + p2 + p22 + p3 + p33 + p4 +p44;
        }
    }
}
