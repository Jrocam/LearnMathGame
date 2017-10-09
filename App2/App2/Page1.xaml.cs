using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        public String playerName;
        public String partidas, operacion;
        public int partidaActual;
        public int puntosConseguidos;
        public int num1;
        public int num2;
        public Label n1, label;
        public Entry respuestaPj;


        public Page1 (String nombre, String part,int partidaAct, int puntos)
		{
            playerName = nombre;
            partidas = part;
            partidaActual = partidaAct;
            puntosConseguidos = puntos;
			InitializeComponent ();


            Label header = new Label
            {
                Text = "Saludos "+ playerName + " Score= "+puntosConseguidos ,
                Font = Font.BoldSystemFontOfSize(14),
                HorizontalOptions = LayoutOptions.Center
            };

            Label intentos = new Label
            {
                Text =  partidaAct+ " de " + partidas,
                Font = Font.BoldSystemFontOfSize(14),
                HorizontalOptions = LayoutOptions.Center
            };
            Random rnd = new Random();
            num1 = rnd.Next(1, 16);
            num2 = rnd.Next(1, 16);
            int op = rnd.Next(1, 3);

            if (op == 1)
            {
                operacion = "+";
            }
            else
            {
                operacion = "-";
            }

            n1 = new Label
            {
                Text = num1.ToString()+" "+operacion+" "+num2.ToString(),
                Font = Font.BoldSystemFontOfSize(28),
                HorizontalOptions = LayoutOptions.Center
            };

            respuestaPj = new Entry
            {
                Placeholder = "        ",
                Keyboard = Keyboard.Numeric,
                WidthRequest = 250,
                HorizontalOptions = LayoutOptions.Center

            };

            Button next = new Button
            {
                Text = "NEXT →",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            next.Clicked += Score;
            label = new Label
            {
                Text = "",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Accomodate iPhone status bar.  
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    intentos,
                    n1,
                    respuestaPj,
                    next,
                    label,
                }
            };

        }
        void Score(object sender, EventArgs e)
        {
            int respuestaReal = 1000;
            int respuestaMan = 2000;
            if (operacion.Equals("+")){
                respuestaReal = num1 + num2;
            }else if (operacion.Equals("-"))
            {
                respuestaReal = num1 - num2;
            };
            if (respuestaPj.Equals(""))
            {
                //respuestaMan = 2000;
            }
            else
            {
               respuestaMan = Int32.Parse(respuestaPj.Text);
            }

            label.Text = respuestaMan +" | "+ respuestaReal;

            if (respuestaReal.Equals(respuestaMan))
            {
                puntosConseguidos = puntosConseguidos + 1;
            }
            //puntosConseguidos = puntosConseguidos + 1;
            if (partidaActual+1 <= Int32.Parse(partidas))
            {
                Navigation.PushAsync(new Page1(playerName, partidas, partidaActual + 1, puntosConseguidos));
            }
            else
            {
                Navigation.PushAsync(new MainPage(true,partidas,puntosConseguidos));
            }
            
            //label.Text = String.Format("{0} Rikolina{1}", partidas, clickTotal == 1 ? "" : "s");
            //DisplayAlert("Hola", "Que tal", "SI!");
        }
    }
}