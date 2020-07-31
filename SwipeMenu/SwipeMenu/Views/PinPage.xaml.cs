using SwipeMenu.Models;
using SwipeMenu.ViewModel;
using System;
using System.Collections.ObjectModel;
using WorkingWithMaps.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XFFurniture.Models;

namespace WorkingWithMaps
{
    public partial class PinPage : ContentPage
    {
        //List<Pin> boardwalkPin;
        MainViewModel Ordens => ((MainViewModel)BindingContext);
        //OrdenModelo OrdenSelect => ((OrdenModelo)BindingContext);
        Property property;
        public PinPage()
        {
            InitializeComponent();
            map.IsShowingUser = true;

        }

        public PinPage(Property property)
        {
            InitializeComponent();
            map.IsShowingUser = false;
            this.property = property;

        }

        protected override void OnAppearing()
        {
            Cargar();
            base.OnAppearing();
        }

        public void Cargar()
        {
            Pin boardwalkPin = new Pin();
            Pin listPin = new Pin();

            if (Ordens.OrdenSelect != null)
            {
                listPin = new Pin
                {
                    Position = new Position(Ordens.OrdenSelect.OrdLatitud, Ordens.OrdenSelect.OrdLongitud),
                    BindingContext = Ordens.OrdenSelect,
                    AutomationId = Ordens.OrdenSelect.OrdId.ToString(),
                    Label = Ordens.OrdenSelect.OrdIdclienteNavigation.NombreCompleto,
                    Address = Ordens.OrdenSelect.OrdDireccion,
                    Type = PinType.Place
                };
                //listPin.MarkerClicked += OnMarkerClickedAsync;
                listPin.InfoWindowClicked += OnInfoWindowClickedAsync;
                map.Pins.Add(listPin);
                return;
            }



            if (Ordens != null)
                foreach (var item in Ordens.Ordenes)
                {
                    listPin = new Pin
                    {
                        Position = new Position(item.OrdLatitud, item.OrdLongitud),
                        BindingContext = item,
                        AutomationId = item.OrdId.ToString(),
                        Label = item.OrdIdclienteNavigation.NombreCompleto,
                        Address = item.OrdDireccion,
                        Type = PinType.Place
                    };

                    //listPin.MarkerClicked += OnMarkerClickedAsync;
                    listPin.InfoWindowClicked += OnInfoWindowClickedAsync;
                    map.Pins.Add(listPin);
                }

            //boardwalkpin.markerclicked += onmarkerclickedasync;
            //pin wharfpin = new pin
            //{
            //    position = new position(5.6845709, -76.6540463),
            //    label = "chocó",
            //    address = "quibdo",
            //    type = pintype.place
            //};
            //map.pins.add(wharfpin);
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            Cargar();
        }

        async void OnMarkerClickedAsync(object sender, PinClickedEventArgs e)
        {
            e.HideInfoWindow = true;
            string pinName = ((Pin)sender).Label;
            await DisplayAlert("Pin Clicked", $"{pinName} was clicked.", "Ok");
        }

        async void OnInfoWindowClickedAsync(object sender, PinClickedEventArgs e)
        {
            var property = ((Pin)sender).BindingContext as Property;
            string pinName = ((Pin)sender).Label;
            //await DisplayAlert("", property.Price , "Ok");
            //await Navigation.PushModalAsync(new DetailsPage(property));
        }
    }
}
