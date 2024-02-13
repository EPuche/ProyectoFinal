using System;
using System.Collections.Generic;

namespace WepApiProyectoFinal.models
{
    public partial class ProductoVendido
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int ProductId { get; set; }
        public int SaleId { get; set; }

        public virtual Producto Product { get; set; } = null!;
        public virtual Venta Sale { get; set; } = null!;
    }
}
