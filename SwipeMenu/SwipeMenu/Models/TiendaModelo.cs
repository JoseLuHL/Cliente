using SwipeMenu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFFurniture.Models
{
  public  class TiendaModelo
    {

        public int TienId { get; set; }
        public string TienNit { get; set; }
        public string TienClave { get; set; }
        public string TienTipoidentificacion { get; set; }
        public string TienRazonsocial { get; set; }
        public string TienDireccion { get; set; }
        public string TienBarrio { get; set; }
        public string TienTelefono { get; set; }
        public string TienCorreo { get; set; }
        public string TienLatitud { get; set; }
        public string TienLongitud { get; set; }
        public string TienAltura { get; set; }

        public virtual ICollection<Ordendetalle> Ordenes { get; set; }
    }
}
