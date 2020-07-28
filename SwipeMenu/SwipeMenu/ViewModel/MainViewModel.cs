
using MvvmHelpers;
using SwipeMenu.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkingWithMaps;
using Xamarin.Forms;
using XFFurniture.Service;

namespace SwipeMenu.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
            _ = GetOrdenesAsync();
        }

        public ObservableCollection<Menu> MyMenu => GetMenus();

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
            await Application.Current.MainPage.Navigation.PushAsync(new OrdenesPage());
        });

        public ObservableCollection<OrdenModelo> Ordenes { get; set; }
        async Task GetOrdenesAsync()
        {
            IsBusy = true;
            Ordenes = await DataService.GetOrdenModelosAsync();
            IsBusy = true;
        }

    }
}
