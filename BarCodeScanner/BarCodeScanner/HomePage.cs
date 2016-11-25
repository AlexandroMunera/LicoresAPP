﻿using BarCodeScanner.Services;
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
        private AzureClient _client;
        private Producto _producto;

        public HomePage()
        {
            _client = new AzureClient();


            this.Title = "Titulo";
            //this.BackgroundColor = Color.Aqua; 
            this.BackgroundImage = "@drawable/fondo.png"; //No sirvió

            Button scanBtn = new Button
            {
                Text = "Verificar Producto",
                Font = Font.SystemFontOfSize(14, FontAttributes.Bold),
                BorderWidth = 1,
                HeightRequest = 42,
                BackgroundColor = Color.Green,
                BorderColor = Color.Black,
                BorderRadius = 5,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand

            };

            Button scanParejaBtn = new Button
            {
                Text = "Scanear la pareja",
                Font = Font.SystemFontOfSize(14, FontAttributes.Bold),
                BorderWidth = 1,
                HeightRequest = 42,
                BackgroundColor = Color.Green,
                BorderColor = Color.Black,
                BorderRadius = 5,
                TextColor = Color.White,
                IsVisible = false,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand

            };

            scanBtn.Clicked += async (sender, args) =>
            {
                scanParejaBtn.IsVisible = false;

                var scanResult = await Acr.BarCodes.BarCodes.Instance.Read();
                if (!scanResult.Success)
                {
                    await this.DisplayAlert("Alerta ! ", "Error al leer el código, intenta nuevamente", "OK");
                }
                else
                {
                    var codigoLeido = scanResult.Code.ToString();

                    _producto = await _client.ValidarProducto(codigoLeido);
                    
                    if (_producto != null && !string.IsNullOrEmpty(_producto.Id)) //Preguntar si existe
                    {
                        if (_producto.Status) //Preguntar si esta activo o no
                        {
                            await this.DisplayAlert("Verificado !", "Este producto esta certificado y proviene de una fuente confiable, puede consumirse", "OK");

                            //Habilitar el botón para scanear la pareja
                            scanParejaBtn.IsVisible = true;

                        }
                        else
                        {
                            await this.DisplayAlert("Alerta !", "Este producto esta certificado y proviene de una fuente confiable, pero ya se le ha realizado el doble scaneo ", "OK");
                        }
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
                    var codigoLeido = scanResult.Code.ToString();

                    if (codigoLeido == _producto.codigo2)
                    {
                        _producto.Status = false;

                        await _client.ActualizarProducto(_producto);

                        await this.DisplayAlert("Correcto !", "Este producto se ha inhabilitado para un posterior uso, puedes consumirlo tranquilamente, gracias por salvar vidas !", "OK");

                    }
                    else
                    {
                        await this.DisplayAlert("¡ CUIDADO !", "Este código no es la pareja de este producto, puede ser peligroso si decides consumirlo.", "OK");
                    }
                }
            };

            var layout = new StackLayout { Padding = 80 };

            layout.Children.Add(scanBtn);
            layout.Children.Add(scanParejaBtn);


            //No funcionó para poner el fondo
            //var backgroundImage = new Image()
            //{
            //    Source = FileImageSource.FromFile("fondo.png")
            //};

            //var relativeLayout = new RelativeLayout();

            //relativeLayout.Children.Add(backgroundImage,
            //    Constraint.Constant(0),
            //    Constraint.Constant(0),
            //    Constraint.RelativeToParent((parent) => { return parent.Width; }),
            //    Constraint.RelativeToParent((parent) => { return parent.Height; }));

            //relativeLayout.Children.Add(layout,
            //    Constraint.Constant(0),
            //    Constraint.Constant(0),
            //    Constraint.RelativeToParent((parent) => { return parent.Width; }),
            //    Constraint.RelativeToParent((parent) => { return parent.Height; }));


            //Content = relativeLayout;

            Content = layout;

        }
    }
}
