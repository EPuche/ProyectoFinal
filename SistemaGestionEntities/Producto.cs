using System;
using System.Collections.Generic;

namespace SistemaGestion.SistemaGestionEntities
{
    public partial class Producto
    {
        public Producto()
        {
            ProductoVendidos = new HashSet<ProductoVendido>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal? Cost { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public int UserId { get; set; }

        public virtual Usuario User { get; set; } = null!;
        public virtual ICollection<ProductoVendido> ProductoVendidos { get; set; }
    }
}
