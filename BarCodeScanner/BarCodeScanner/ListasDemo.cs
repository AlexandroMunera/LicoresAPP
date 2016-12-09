using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BarCodeScanner
{
    public class ListasDemo : ContentPage
    {
        public ListasDemo()
        {
            var nombres = new[]
            {
                "Alex",
                "Emanuel",
                "Noemy",
                "Giovanny"
            };

            var miListView = new ListView();
            miListView.ItemsSource = from n in nombres select n;
            miListView.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    Debug.WriteLine("Selected: " + e.SelectedItem);
                    miListView.SelectedItem = null;
                }
            };

            Content = miListView;
        }
    }
}
