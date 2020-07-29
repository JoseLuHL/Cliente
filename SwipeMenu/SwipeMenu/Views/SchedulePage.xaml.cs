using SwipeMenu.Models;
using SwipeMenu.ViewModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CalendarUI.Views
{
    public partial class SchedulePage : ContentPage
    {
        MainViewModel Orden => ((MainViewModel)BindingContext);
        public SchedulePage()
        {
            InitializeComponent();
            //BindingContext = new ScheduleViewModel();
        }
        protected async override void OnAppearing()
        {
            //await  DisplayAlert("", Orden.Ordenes.Count.ToString(), "OK");
            //lista.ItemsSource = Orden;
            //base.OnAppearing();
        }

        private void lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var s = e.CurrentSelection as OrdenModelo;
            //Orden.SelectOrdenCommand.Execute(s);
        }
    }
}
