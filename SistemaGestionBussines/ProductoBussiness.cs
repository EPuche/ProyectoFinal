using WepApiProyectoFinal.database;
using WepApiProyectoFinal.models;
using WepApiProyectoFinal.service;

namespace SistemaGestion.SistemaGestionBussines
{
    public static class ProductoBussiness
    {
        public static List<Producto> ListarProductoBussines()
        {
            return ProductoData.ListarProducto();
        }

        public static Producto ObtenerProductoBussines(int id)
        {
            return ProductoData.ObtenerProducto(id);
        }

        public static bool CrearProductoBussines(Producto producto)
        {
            return ProductoData.CrearProducto(producto);

        }

        public static bool ModificarProductoBussines(Producto producto, int id)
        {
            return ProductoData.ModificarProducto(producto, id);
        }

        public static bool EliminarProductoBussines(int id)
        {
            return ProductoData.EliminarProducto(id);
        }
    }
}
