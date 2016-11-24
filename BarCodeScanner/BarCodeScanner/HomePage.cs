using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace BarCodeScanner
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {

            //Poner fondo               
            this.Title = "Titulo";
            this.BackgroundColor = Color.Aqua;
           // this.BackgroundImage = "fondo.png";

            Button scanBtn = new Button
            {
                Text = "Verificar Producto",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand

            };

            Button scanParejaBtn = new Button
            {
                Text = "Scanear la pareja",
                IsVisible = false,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand

            };

            scanBtn.Clicked += async (sender, args) =>
            {
                var scanResult = await Acr.BarCodes.BarCodes.Instance.Read();
                if (!scanResult.Success)
                {
                    await this.DisplayAlert("Alerta ! ", "Error al leer el código, intenta nuevamente", "OK");
                }
                else
                {
                    if (scanResult.Code.ToString() == "Garrafa1")
                    {
                        await this.DisplayAlert("Verificado !", "Este producto esta certificado y proviene de una fuente confiable.", "OK");


                        //Habilitar el botón para scanear la pareja
                        scanParejaBtn.IsVisible = true;

                    }
                    else
                    {
                        await this.DisplayAlert("¡ CUIDADO !", "Este producto NO esta certificado, no proviene de una fuente confiable.", "OK");

                    }
                }
            };

            scanParejaBtn.Clicked += async (sender, args) =>
            {
                var scanResult = await Acr.BarCodes.BarCodes.Instance.Read();
                if (!scanResult.Success)
                {
                    await this.DisplayAlert("Alerta ! ", "Error al leer el código, intenta nuevamente", "OK");
                }
                else
                {
                    if (scanResult.Code.ToString() == "ParejaGarrafa1")
                    {
                        await this.DisplayAlert("Correcto !", "Este producto se ha inhabilitado para un posterior uso, puedes consumirlo tranquilamente, gracias por salvar vidas !", "OK");

                    }
                    else
                    {
                        await this.DisplayAlert("¡ CUIDADO !", "Este código no es la pareja de este producto, ten cuidado si decides consumirlo.", "OK");

                    }
                }
            };

            var layout = new StackLayout { Padding = 80 };           

            layout.Children.Add(scanBtn);
            layout.Children.Add(scanParejaBtn);            

            Content = layout;

        }
    }
}
