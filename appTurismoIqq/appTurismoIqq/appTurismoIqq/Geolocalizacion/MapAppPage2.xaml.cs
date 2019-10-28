using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Map = Xamarin.Forms.Maps.Map;
using Map2 = Xamarin.Essentials.Map;
using Plugin.Geolocator;
using System.Threading;

/*
  En esta clase se instancia el mapa de google para su utilización, además de manejar la geolocalización para mostrar ubicaciones
  y direcciones

  Al principio se utilizaba un botón para señalar la posición y poner los pines, luego se desecho esa idea por poner la posición
  del usuario inmediatamente y con un pin la posición del lugar buscado

  Se están usando valores estaticos de momento, hasta que se puedan usar los almacenados en la base de datos

    */
namespace appTurismoIqq.Geolocalizacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapAppPage2 : ContentPage

    {
        public string boton;

        public MapAppPage2(double lat, double lon, string calle)
        {
            InitializeComponent();

            
          string  lenguaje = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;


            if (lenguaje == "en")
            {
                boton = "Trace the route";
            }
            if (lenguaje == "es")
            {
                boton = "Trazar la ruta";
            }

            /* Botón que se utilizará para trazar la dirección desde el punto de origen hasta 
             la localización deseada, es posible que este botón sea desechado también en pos de instanciar el mapa con la ruta trazada           
            */
            Button button2 = new Button()
            {
                
                Text = boton,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Accent
            };
            

            // Se crea la unidad logica del mapa que utilizaremos
            Map map = new Map // Se declara la variable map
            {
                IsShowingUser = true, // Variable para señalar la ubicación actual del usuario
                MapType = MapType.Street, // Variable para definir el tipo de mapa mostrado, en este caso de tipo street para ver las calles
                VerticalOptions = LayoutOptions.FillAndExpand, // Variable para definir el alto del mapa, en este caso que llene y se expanda verticalmente
                                                               // por toda la pantalla
                HorizontalOptions = LayoutOptions.FillAndExpand, // Lo mismo que la de arriba pero horizontalment

                
            

        };
            
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(-20.247508, -70.133661), Distance.FromMiles(1)).WithZoom(100));

            

            //Declaración de una variable tipo pin
            var pin3 = new Pin()
            {
                Label = "Ubicación",
                Position = new Position(lat, lon), //Asignando valor a la posición del pin (latitud, longuitud)
                Address = calle,
            };
            map.Pins.Add(pin3); // Agregar la variable instanciada pin a la variable map

            /* El metodo que use utilizará cuando se clicke el boton
            button.Clicked += async (object sender, EventArgs e) =>
            {
                ILocation loc = DependencyService.Get<ILocation>();
                loc.locationObtained += (object ss, ILocationEventArgs ee) =>
                {
                    lat = ee.lat;
                    lng = ee.lng;
                };
                loc.ObtainMyLocation();
                loc = null;
                await Task.Delay(4000);
                Position position = new Position(lat, lng);
                Position position2 = new Position(-20.233169, -70.14294);
                Pin pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = "Posición",
                };
                
                Pin pin2 = new Pin
                {
                    Type = PinType.Place,
                    Position = position2,
                    Label = "Mall Plaza",
                };
                map.Pins.Add(pin);
                map.Pins.Add(pin2);
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lat, lng), Distance.FromMiles(7)));
            };

    */
             
                          
            button2.Clicked += async (object sender, EventArgs e) =>
            {

                var location = new Location(lat, lon);
                var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };
                await Map2.OpenAsync(location, options);



            };


            // El layout donde estarán tanto el mapa como el botón
            StackLayout stack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand, // Definiendo que el layout ocupe horizontalmente toda la pantalla que sea posible
                VerticalOptions = LayoutOptions.FillAndExpand, // Lo mismo que arriba pero verticalmente
                Children = { map, button2 }, // Asignando al layout como variables hijas tanto la variable map como el botón
                BackgroundColor = Color.Aqua // Asignando color al fondo del stacklayout
            };

            Content = stack; // Asigna el stacklayout definido como el contenido de la contentpage 
            Padding = new Thickness(0, top: Device.OnPlatform(20, 0, 0), right: 0, bottom: 0); // Definiendo los bordes de la contentpage
            // Este es un comando viejo, aun funciona pero habrá que pensar en cambiarlo
        }

    }
}