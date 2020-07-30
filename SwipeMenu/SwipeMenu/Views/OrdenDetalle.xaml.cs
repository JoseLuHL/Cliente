using SwipeMenu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdenDetalle : ContentPage
    {
        MainViewModel MainView => ((MainViewModel)BindingContext);
        public OrdenDetalle()
        {
            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
            lista.ItemsSource = MainView.OrdenSelect.Ordendetalles;
            base.OnAppearing();
        }

    }
}