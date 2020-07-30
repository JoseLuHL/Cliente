using GalaSoft.MvvmLight.Views;
using SwipeMenu.Service;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFFurniture.Models;
using XFFurniture.Service;

namespace SwipeMenu.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private bool _areCredentialsInvalid;

        public LoginViewModel()
        {
            AuthenticateCommand = new Command(async () =>
            {
                IsBusy = true;
                AreCredentialsInvalid = !await UserAuthenticated(Username, Password);
                if (AreCredentialsInvalid) return;
                Username = string.Empty;
                Password = string.Empty;
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                IsBusy = false;
            });
            //IsBusy = true;
            AreCredentialsInvalid = false;
        }

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
            return res!=null;
            //return username.ToLowerInvariant() == "joe"
            //    && password.ToLowerInvariant() == "secret";
        }

        private bool isBusin;

        public bool IsBusy
        {
            get => isBusin;
            set
            {
                if (value == isBusin) return;
                isBusin = value;
                OnPropertyChanged(nameof(Username));
            }
        }


        public string Username
        {
            get => _username;
            set
            {
                if (value == _username) return;
                _username = value;
                AreCredentialsInvalid = false;
                OnPropertyChanged(nameof(Username));
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
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand AuthenticateCommand { get; set; }

        public bool AreCredentialsInvalid
        {
            get => _areCredentialsInvalid;
            set
            {
                if (value == _areCredentialsInvalid) return;
                _areCredentialsInvalid = value;
                OnPropertyChanged(nameof(AreCredentialsInvalid));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
