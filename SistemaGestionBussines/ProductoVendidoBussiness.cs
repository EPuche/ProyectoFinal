using Entregable2.service;
using WepApiProyectoFinal.models;
using WepApiProyectoFinal.service;

namespace SistemaGestion.SistemaGestionBussines
{
    public class ProductoVendidoBussiness
    {
        public static List<ProductoVendido> ListarProductoVendidoBussines()
        {
            return ProductoVendidoData.ListarProductoVendido();
        }

        public static ProductoVendido ObtenerProductoBussines(int id)
        {
            return ProductoVendidoData.ObtenerProductoVendido(id);
        }

        public static bool CrearProductoBussines(ProductoVendido producto)
        {
            return ProductoVendidoData.CrearProductoVendido(producto);

        }

        public static bool ModificarProductoBussines(ProductoVendido producto, int id)
        {
            return ProductoVendidoData.ModificarProducto(producto, id);
        }

        public static bool EliminarProductoBussines(int id)
        {
            return ProductoVendidoData.EliminarProductoVendido(id);
        }
    }
}
