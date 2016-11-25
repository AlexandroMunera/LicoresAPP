using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace BarCodeScanner.Services
{
    public class AzureClient
    {
        private IMobileServiceClient _client;
        private IMobileServiceTable<Producto> _table;

        public AzureClient()
        {
            _client = new MobileServiceClient("http://famg.azurewebsites.net/");

            _table = _client.GetTable<Producto>();
        }

        public Task<IEnumerable<Producto>> GetProductos()
        {
            return _table.ToEnumerableAsync();
        }

    }
}
