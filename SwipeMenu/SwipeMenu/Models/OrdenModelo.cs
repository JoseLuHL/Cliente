﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SwipeMenu.Models
{
   public class OrdenModelo
    {
        public int OrdId { get; set; }
        public string OrdNumero { get; set; }
        public string OrdIdcliente { get; set; }
        public string OrdIdtienda { get; set; }
        public string OrdDireccion { get; set; }
        public double? OrdTotalcompra { get; set; }

        public virtual ObservableCollection<Ordendetalle> Ordendetalles { get; set; }

        public DateTime OrdFecha { get; set; }
        public double OrdLatitud { get; set; }
        public double OrdLongitud { get; set; }
        public string OrdAltura { get; set; }
        public DateTime OrdFechaenvio { get; set; }

    }
}
