using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{

    public partial class MainPage : ContentPage
    {
        public float clickTotal = 0;
        public string partidas = "";
        public Label label;
        public Picker partidasPicker;
        public Entry nombreEntry;

        public MainPage(Boolean gano, string partidas, int puntos )
        {
            InitializeComponent();
            if (gano)
            {
                DisplayAlert("FIN", "Hiciste "+ puntos +" de "+partidas, "otra vez!");
            }
            int clickTotal = 0;

            Label header = new Label
            {
                Text = "¡RESTA-SUMA!",
                Font = Font.BoldSystemFontOfSize(48),
                HorizontalOptions = LayoutOptions.Center
            };


            Label nombreText = new Label
            {
                Text = "Nombre:",
                Font = Font.BoldSystemFontOfSize(18),
                HorizontalOptions = LayoutOptions.Center
            };

            nombreEntry = new Entry
            {
                Placeholder = "Juan Roca...",
                WidthRequest = 250,
                HorizontalOptions = LayoutOptions.Center

            };

            partidasPicker = new Picker
            {
                Title="# de partidas",
                WidthRequest = 120,
                HorizontalOptions = LayoutOptions.Center
                
            };
            partidasPicker.Items.Add("3");
            partidasPicker.Items.Add("5");
            partidasPicker.Items.Add("10");


            Button button = new Button
            {
                Text = "PLAY",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            button.Clicked += Holaquetalamigo;

            label = new Label
            {
                Text = "0 RIKOLINAS",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            var escogio = "0";
            //label.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: partidasPicker));

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    nombreText,
                    nombreEntry,
                    partidasPicker,
                    button,
                    label
                }
            };
        }

        void Holaquetalamigo(object sender, EventArgs e)
        {
            clickTotal += 1;
            partidas = partidasPicker.Items[partidasPicker.SelectedIndex];
            label.Text = partidas + " partidas";
            Navigation.PushAsync(new Page1(nombreEntry.Text, partidas, 1, 0));
            
            //label.Text = String.Format("{0} Rikolina{1}", partidas, clickTotal == 1 ? "" : "s");
            //DisplayAlert("Hola", "Que tal", "SI!");
        }

    }

}
