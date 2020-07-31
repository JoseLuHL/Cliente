using MvvmHelpers;
using SwipeMenu.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SwipeMenu.ViewModel
{
    class ProductoViewModel: BaseViewModel
    {
        public ProductoViewModel()
        {

        }

        private ObservableCollection<ProductoModelo> producto;

        public ObservableCollection<ProductoModelo> Productos
        {
            get { return producto; }
            set { producto = value; }
        }


        private async Task GuardarProductoAsync()
        {

        }
    }
}
