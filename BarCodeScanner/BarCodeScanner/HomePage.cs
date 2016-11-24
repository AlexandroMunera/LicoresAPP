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
            Button scanBtn = new Button
            {
                Text = "Verificar Producto",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            scanBtn.Clicked += async (sender, args) =>
            {
                var scanResult = await Acr.BarCodes.BarCodes.Instance.Read();
                if (!scanResult.Success)
                {
                    await this.DisplayAlert("Alerta ! ", "Perdon ! \n Error al leer el código !", "OK");
                }
                else
                {
                    if (scanResult.Code.ToString() == "Garrafa1")
                    {
                        await this.DisplayAlert("Verificado !", "Este producto esta certificado y proviene de una fuente confiable.", "OK");

                    }
                    else
                    {
                        await this.DisplayAlert("¡ CUIDADO !", "Este producto NO esta certificado, no proviene de una fuente confiable.", "OK");

                    }
                }
            };

            var layout = new StackLayout();

            var yellowBox = new BoxView {
                Color = Color.Yellow,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var greenBox = new BoxView {
                Color = Color.Green,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var blueBox = new BoxView
            {
                Color = Color.Blue,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 75
            };

            layout.Children.Add(scanBtn);
            layout.Children.Add(yellowBox);
            layout.Children.Add(greenBox);
            layout.Children.Add(blueBox);
            layout.Spacing = 10;

            Content = layout;

            //        Content = new StackLayout
            //        {
            //            Children = {
            //                scanBtn
            //}
            //        };
        }
    }
}
