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

            //var yellowBox = new BoxView
            //{
            //    Color = Color.Yellow,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    HorizontalOptions = LayoutOptions.FillAndExpand
            //};

            //var greenBox = new BoxView
            //{
            //    Color = Color.Green,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    HorizontalOptions = LayoutOptions.FillAndExpand
            //};

            //var blueBox = new BoxView
            //{
            //    Color = Color.Blue,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    HeightRequest = 75
            //};

            layout.Children.Add(scanBtn);
            layout.Children.Add(scanParejaBtn);
            

            //layout.Children.Add(yellowBox);
            //layout.Children.Add(greenBox);
            //layout.Children.Add(blueBox);
            //layout.Spacing = 10;
            layout.BackgroundColor = Color.Aqua;
            

            Content = layout;

            //        Content = new StackLayout
            //        {
            //            Children = {
            //                scanBtn
            //}
            //        };


            //var myImage = new Image()
            //{
            //    Source = FileImageSource.FromUri(
            //new Uri("http://xamarin.com/content/images/pages/index/hero-slide.jpg"))
            //};

            //var myImage = new Image { Aspect = Aspect.AspectFit };
            //myImage.Source = ImageSource.FromFile("fondo.jpg");

            //RelativeLayout layout = new RelativeLayout();

            //layout.Children.Add(myImage,
            //    Constraint.Constant(0),
            //    Constraint.Constant(0),
            //    Constraint.RelativeToParent((parent) => { return parent.Width; }),
            //    Constraint.RelativeToParent((parent) => { return parent.Height; }));

            //layout.Children.Add(scanBtn,
            //    Constraint.Constant(0),
            //    Constraint.Constant(0),
            //    Constraint.RelativeToParent((parent) => { return parent.Width; }),
            //    Constraint.RelativeToParent((parent) => { return parent.Height; }));


            //Content = layout;
        }
    }
}
