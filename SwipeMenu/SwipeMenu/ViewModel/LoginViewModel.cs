using GalaSoft.MvvmLight.Views;
using MvvmHelpers;
using SwipeMenu.Service;
using SwipeMenu.Views;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFFurniture.Models;
using XFFurniture.Service;

namespace SwipeMenu.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private bool _areCredentialsInvalid;

        public LoginViewModel()
        {
            //IsBusy = true;
            AreCredentialsInvalid = false;
        }

        public ICommand PaginaRegistrarCommand => new Command(execute: async () => { await Application.Current.MainPage.Navigation.PushModalAsync(new MisDatosPage()); });

        private async Task<bool> UserAuthenticated(string username, string password)
        {
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                return false;
            }
            var res = await DataService.GetTiendasOneAsync($"{UrlModelo.tiendas}/{username}/{password}");
            if (res != null)
            {
                res.TienClave = string.Empty;
                UsuarioServicio.Tienda = res;

            }
            return res != null;
        }

        private bool isBusin;

        //public new bool IsBusy
        //{
        //    get => isBusin;
        //    set 
        //    {
        //        if (value == isBusin) return;
        //        isBusin = value;
        //        SetProperty(ref _username, Username);
        //    }
        //}
        public string Username
        {
            get => _username;
            set
            {
                if (value == _username) return;
                _username = value;
                AreCredentialsInvalid = false;
                SetProperty(ref _username, value);
            }
        }
        public string Password
        {
            get => _password;
            set
            {

                if (value == _password) return;
                _password = value;
                AreCredentialsInvalid = false;
                SetProperty(ref _password, value);
            }
        }

        public ICommand AuthenticateCommand => new Command(execute: async () =>
            {
                IsBusy = true;
                AreCredentialsInvalid = !await UserAuthenticated(Username, Password);
                if (AreCredentialsInvalid) return;
                _username = string.Empty;
                _password = string.Empty;
                Username = string.Empty;
                Password = string.Empty;
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                IsBusy = false;
            });

        public bool AreCredentialsInvalid
        {
            get => _areCredentialsInvalid;
            set
            {
                if (value == _areCredentialsInvalid) return;
                _areCredentialsInvalid = value;
                SetProperty(ref _areCredentialsInvalid, value);
            }
        }
    }
}
