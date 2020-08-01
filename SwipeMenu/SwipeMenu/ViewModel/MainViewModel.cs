
using AgendaApp;
using MvvmHelpers;
using SwipeMenu.Models;
using SwipeMenu.Service;
using SwipeMenu.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkingWithMaps;
using Xamarin.Forms;
using XFFurniture.Models;
using XFFurniture.Service;

namespace SwipeMenu.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {

        }

        public ObservableCollection<Menu> MyMenu => GetMenus();
        //public OrdenModelo OrdenSelect { get; set; }
        private OrdenModelo ordenSelect;

        public OrdenModelo OrdenSelect
        {
            get => ordenSelect;
            set => SetProperty(ref ordenSelect, value);
        }

        private ObservableCollection<Ordendetalle> ordenDetalle;

        public ObservableCollection<Ordendetalle> OrdenDetalle
        {
            get => ordenDetalle;
            set => SetProperty(ref ordenDetalle, value);
        }

        public ICommand SelectOrdenCommand => new Command<OrdenModelo>(async (OrdenModelo modelo) =>
          {
              OrdenSelect = modelo;
              OrdenDetalle = modelo.Ordendetalles;
              modelo = null;
              await Application.Current.MainPage.Navigation.PushModalAsync(new OrdenDetalle { BindingContext = this });
          });
        private ObservableCollection<Menu> GetMenus()
        {
            return new ObservableCollection<Menu>
            {
                new Menu{ Name = "Home", Icon = "home.png"},
                new Menu{ Name = "Profile", Icon = "user.png"},
                new Menu{ Name = "Notifications", Icon = "bell.png"},
                new Menu{ Name = "Messages", Icon = "envelope.png"},
                new Menu{ Name = "My Tasks", Icon = "tasks.png"},
            };
        }
        public ICommand ProductoCommand => new Command(execute: async () => { IsBusy = true; await Application.Current.MainPage.Navigation.PushAsync(new ProductoPage()); IsBusy = false; });
        public ICommand MisDatosCommand => new Command(execute: async () => { IsBusy = true; await Application.Current.MainPage.Navigation.PushAsync(new MisDatosPage()); IsBusy = false; });
        public ICommand MapaCommand => new Command(async () =>
        {
            await GetOrdenesAsync();
            await Application.Current.MainPage.Navigation.PushAsync(new PinPage { BindingContext = this });
        });
        public ICommand MapaOrdenesCommand => new Command(async () =>
       {
           IsBusy = true;
           //var s = OrdenSelect;
           await Application.Current.MainPage.Navigation.PushModalAsync(new PinPage
           {
               BindingContext = this
           });
           IsBusy = false;
       });

        public ICommand DespacharOrdenesCommand => new Command(execute: async () => { IsBusy = true; await Application.Current.MainPage.Navigation.PushAsync(new PinPage { BindingContext = this }); IsBusy = false; });
        public ICommand AvandonarOrdenesCommand => new Command(execute: async () => { IsBusy = true; await Application.Current.MainPage.Navigation.PushAsync(new PinPage { BindingContext = this }); IsBusy = false; });
        public ICommand OrdenesCommand => new Xamarin.Forms.Command(async () =>
        {
            try
            {
                await GetOrdenesAsync();
                if (Ordenes.Count < 1)
                {
                    await Application.Current.MainPage.DisplayAlert("", "No hay pedidos", "OK");
                    IsBusy = false;
                    return;
                }
                await Application.Current.MainPage.Navigation.PushModalAsync(new OrdenesPage { BindingContext = this });
            }
            catch (System.Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("", ex.ToString(), "OK");
            }
        });

        public ICommand RefrescarOrdenesComman => new Command(execute: async () => { IsBusy = true; await GetOrdenesAsync(); IsBusy = false; });

        //public ObservableCollection<OrdenModelo> Ordenes { get; set; }
        private ObservableCollection<OrdenModelo> ordenes;

        public ObservableCollection<OrdenModelo> Ordenes
        {
            get => ordenes;
            set => SetProperty(ref ordenes, value);
        }

        async Task GetOrdenesAsync()
        {
            IsBusy = true;
            Ordenes = await DataService.GetOrdenModelosAsync($"{UrlModelo.odenesTienda}{UsuarioServicio.Tienda.TienId}");
            IsBusy = false;
        }

        private ObservableCollection<ClienteModelo> clientes;

        public ObservableCollection<ClienteModelo> Clientes
        {
            get => clientes;
            set => SetProperty(ref clientes, value);
        }

        async Task GetClientesAsync()
        {
            IsBusy = true;
            clientes = await DataService.GetClientesAsync();
            IsBusy = false;
        }

        async Task GetTiendaAsync()
        {
            IsBusy = true;
            clientes = await DataService.GetClientesAsync();
            IsBusy = false;
        }

    }
}
