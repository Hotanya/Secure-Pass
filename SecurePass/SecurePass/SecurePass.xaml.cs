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
            string[] upper = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int[] number = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] special = new string[13] { "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "+" };

            //Starting the Random
            Random r = new Random();
            
            //for lower
            int countLower = r.Next(lower.Count); 
            foreach (string i in lower)
            {
                valueLabel.Text = lower[countLower];
                
            }

            //for upper
            int countUpper = r.Next(lower.Count);
            foreach (string i in upper)
                valueLabel.Text = upper[countUpper];
        }
    }
}
