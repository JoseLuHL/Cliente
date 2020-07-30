using SwipeMenu.Service;
using SwipeMenu.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SwipeMenu
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainViewModel MainViewModel { get; set; }
        public  MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
            //DisplayAlert("", UsuarioServicio.usuario, "OK");
        }


        protected override void OnAppearing()
        {
            nombre.Text = UsuarioServicio.Tienda.TienRazonsocial;
            base.OnAppearing();
        }

        private async void OpenAnimation()
        {
           
        }

        private async void CloseAnimation()
        {
            
        }

        private void OpenSwipe(object sender, EventArgs e)
        {
            
        }

        private void CloseSwipe(object sender, EventArgs e)
        {
          
        }

        private void SwipeStarted(object sender, SwipeStartedEventArgs e)
        {
        }

        private void SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
           
        }

        //private void CloseRequested(object sender, EventArgs e)
        //{
        //    CloseAnimation();
        //}
    }

    public class Menu
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
