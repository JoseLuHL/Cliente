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

        public static async Task<ObservableCollection<OrdenModelo>> GetOrdenModelosAsync()
        {
            var respuesta = new ObservableCollection<OrdenModelo>();
            Http = new HttpClient();
            var peticion = await Http.GetAsync(UrlModelo.odenes);
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

    }
}
