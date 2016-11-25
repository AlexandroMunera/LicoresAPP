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

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _table.ToEnumerableAsync();
        }

        public async Task<Producto> ValidarProducto(string valor)
        {
            try
            {
                //var datos = _table.Where(p => p.Id == valor).ToListAsync();
                Producto producto = await _table.LookupAsync(valor);

                if (producto == null)
                {
                    return null;
                }

                return producto;
            }
            catch (Exception)
            {
                return new Producto();
            }
                        
        }

        public async Task ActualizarProducto(Producto _producto)
        {
            await _table.UpdateAsync(_producto);
        }
    }
}   
