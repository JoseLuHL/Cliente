using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeMenu.Models
{
    public class ProductoModelo
    {
        public int ProdId { get; set; }
        public string ProdCodigo { get; set; }
        public string ProdNombre { get; set; }
        public string ProdDescripcion { get; set; }
        public double? ProdPreciounitario { get; set; }
        public string ProdCategoria { get; set; }
        public string ProdFoto { get; set; }
        public string ProdColor { get; set; }
        public string ProdRanking { get; set; }
        public int? ProdStockmin { get; set; }
        public int? ProdStok { get; set; }
        public int? ProdStokmax { get; set; }
        public string ProdFecha { get; set; }
        private ICollection<Ordendetalle> ordendetalles { get; set; }
        public virtual ICollection<Ordendetalle> Ordendetalles
        {
            get { return null; }
            set { ordendetalles = value; }
        }
    }
}
