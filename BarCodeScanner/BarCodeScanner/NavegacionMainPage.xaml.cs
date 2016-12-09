using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BarCodeScanner
{
    public partial class NavegacionMainPage : ContentPage
    {
        public NavegacionMainPage()
        {
            InitializeComponent();
            btnToSecondPage.Clicked += BtnToSecondPage_Clicked;
        }

        private void BtnToSecondPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavegacionSecondPage());
        }
    }
}
