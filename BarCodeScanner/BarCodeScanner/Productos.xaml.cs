using BarCodeScanner.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BarCodeScanner
{
    public partial class Productos : ContentPage
    {
        private AzureClient _client;
        public ObservableCollection<Producto> Items { get; set; }
        public Command RefreshCommand { get; set; }

        public Productos()
        {
            Items = new ObservableCollection<Producto>();
            RefreshCommand = new Command(() => Load());
            _client = new AzureClient();

            InitializeComponent();
        }

        public async void Load()
        {
            IsBusy = true;
            Items.Clear();

            var result = await _client.GetProductos();           

            foreach (var item in result)
            {
                Items.Add(item);
            }
            IsBusy = false;
        }
    }
}
