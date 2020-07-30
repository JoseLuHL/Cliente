using Newtonsoft.Json;
using SwipeMenu.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using XFFurniture.Models;

namespace XFFurniture.Service
{
    public class DataService
    {
        static HttpClient Http;

        public static async Task<ObservableCollection<OrdenModelo>> GetOrdenModelosAsync(string url)
        {
            var respuesta = new ObservableCollection<OrdenModelo>();
            Http = new HttpClient();
            var peticion = await Http.GetAsync(url);
            if (peticion.IsSuccessStatusCode)
            {
                var contenido = await peticion.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<ObservableCollection<OrdenModelo>>(contenido);
                respuesta = datos;
            }
            else
                respuesta = null;
            return respuesta;
        }

        public static async Task<ObservableCollection<ClienteModelo>> GetClientesAsync()
        {
            var respuesta = new ObservableCollection<ClienteModelo>();
            Http = new HttpClient();
            var peticion = await Http.GetAsync(UrlModelo.cliente);
            if (peticion.IsSuccessStatusCode)
            {
                var contenido = await peticion.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<ObservableCollection<ClienteModelo>>(contenido);
                respuesta = datos;
            }
            else
                respuesta = null;
            return respuesta;
        }

        public static async Task<ObservableCollection<TiendaModelo>> GetTiendasAsync(string urlTienda)
        {
            var respuesta = new ObservableCollection<TiendaModelo>();
            Http = new HttpClient();
            var peticion = await Http.GetAsync(urlTienda);
            if (peticion.IsSuccessStatusCode)
            {
                var contenido = await peticion.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<ObservableCollection<TiendaModelo>>(contenido);
                respuesta = datos;
            }
            else
                respuesta = null;
            return respuesta;
        }
        
        public static async Task<TiendaModelo> GetTiendasOneAsync(string urlTienda)
        {
            var respuesta = new TiendaModelo();
            Http = new HttpClient();
            var peticion = await Http.GetAsync(urlTienda);
            if (peticion.IsSuccessStatusCode)
            {
                var contenido = await peticion.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<TiendaModelo>(contenido);
                respuesta = datos;
            }
            else
                respuesta = null;
            return respuesta;
        }


    }
}
