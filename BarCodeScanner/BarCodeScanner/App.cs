using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BarCodeScanner
{
    public class App : Application
    {
        private HomePage _homePage;
        private Productos _productos;

        public App()
        {
            _homePage = new HomePage();
            _productos = new Productos();


            //MainPage = _homePage;        
            //MainPage = _productos;        
            MainPage = new NavigationPage(_homePage);

        }

        protected override void OnStart()
        {
            _productos.Load();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
