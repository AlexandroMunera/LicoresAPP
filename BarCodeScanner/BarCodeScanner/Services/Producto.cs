using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarCodeScanner
{
    [DataTable("Productos")]
    public class Producto
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string Nombre { get; set; }

        [JsonProperty]
        public bool Status { get; set; }

        public string codigo2 { get; set; }

        [Version]
        public string Version { get; set; }
    }
}
