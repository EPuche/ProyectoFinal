using System;
using System.Collections.Generic;

namespace SistemaGestion.SistemaGestionEntities
{
    public partial class Venta
    {
        public Venta()
        {
            ProductoVendidos = new HashSet<ProductoVendido>();
        }

        public int Id { get; set; }
        public string? Comments { get; set; }
        public int UserId { get; set; }

        public virtual Usuario User { get; set; } = null!;
        public virtual ICollection<ProductoVendido> ProductoVendidos { get; set; }
    }
}
