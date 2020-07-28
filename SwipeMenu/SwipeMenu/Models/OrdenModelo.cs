using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeMenu.Models
{
   public class OrdenModelo
    {
        public int OrdId { get; set; }
        public string OrdNumero { get; set; }
        public string OrdIdcliente { get; set; }
        public string OrdDireccion { get; set; }
        public string OrdFecha { get; set; }
        public double OrdLatitud { get; set; }
        public double OrdLongitud { get; set; }
        public string OrdAltura { get; set; }
        public string OrdFechaenvio { get; set; }
    }
}
