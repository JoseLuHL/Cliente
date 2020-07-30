
using AgendaApp;
using MvvmHelpers;
using SwipeMenu.Models;
using SwipeMenu.Service;
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
          modelo=null;
          await Application.Current.MainPage.Navigation.PushModalAsync(new OrdenDetalle { BindingContext = this });

          //await Application.Current.MainPage.DisplayAlert("", modelo.OrdId.ToString(), "OK");
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
        public ICommand MapaCommand => new Xamarin.Forms.Command(async () =>
        {
            await Application.Current.MainPage.Navigation.PushAsync(new PinPage { BindingContext = Ordenes });
        });

        public ICommand OrdenesCommand => new Xamarin.Forms.Command(async () =>
        {
            try
            {
                await GetOrdenesAsync();
                if (Ordenes.Count < 1)
                {
                    await Application.Current.MainPage.DisplayAlert("","No hay pedidos", "OK");
                    return;
                }

                await Application.Current.MainPage.Navigation.PushModalAsync(new OrdenesPage { BindingContext = this });
            }
            catch (System.Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("", ex.ToString(), "OK");
            }
        });

        public ObservableCollection<OrdenModelo> Ordenes { get; set; }

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
