using MvvmHelpers;
using SwipeMenu.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XFFurniture.Models;

namespace SwipeMenu.ViewModel
{
    public class MisDatosViewModel : BaseViewModel
    {

        private string latitud;

        public string Latitud
        {
            get => latitud;
            set => SetProperty(ref latitud, value);
        }

        private string longitud;
        private string mensajeUbicacion;

        public string MensajeUbicacion
        {
            get => mensajeUbicacion;
            set => SetProperty(ref mensajeUbicacion, value);
        }

        public string Longitud
        {
            get => longitud;
            set => SetProperty(ref longitud, value);
        }
        private string colorUbicacion = "Red";

        public string ColorUbicacion
        {
            get => colorUbicacion;
            set => SetProperty(ref colorUbicacion, value);
        }

        public ICommand UbicacionCommand => new Command(async () =>
        {
            IsBusy = true;
            var ubicacion = new UbicacionServicio();
            var ubi = await ubicacion.OnGetCurrentLocation();
            if (string.IsNullOrEmpty(ubi))
            {
                await Application.Current.MainPage.DisplayAlert("","No podemos optener su ubicación \n " +
                    "verifique si esta activado el GPS","OK");
                MensajeUbicacion = "Sin ubicacion";
                ColorUbicacion = "Red" ;
                IsBusy = false;

                return;
            }
            var array = ubi.Split(' ');
            Latitud = array[0];
            Longitud = array[1];
            var datos = Tienda;
            datos.TienLatitud = Latitud;
            datos.TienLongitud = Longitud;
            Tienda = null;
            Tienda = datos;
            ColorUbicacion = "Green";
            MensajeUbicacion = "Ubicación obtenida";
            IsBusy = false;

        });
        private TiendaModelo tienda;

        public TiendaModelo Tienda
        {
            get => tienda;
            set => SetProperty(ref tienda, value);
        }

        public MisDatosViewModel()
        {
            Tienda = UsuarioServicio.Tienda;
            ColorUbicacion = "Red";
            MensajeUbicacion = "Sin ubicacion";
        }



    }
}
