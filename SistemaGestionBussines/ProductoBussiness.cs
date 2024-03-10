using SistemaGestion.DTOs;
using SistemaGestion.SistemaGestionEntities;
using SistemaGestion.database;
using SistemaGestion.SistemaGestionData;

namespace SistemaGestion.SistemaGestionBussines
{
    public class ProductoBussiness
    {
        private ProductoData productoData;

        public ProductoBussiness(ProductoData productoData)
        {
            this.productoData = productoData;
        }
        public  List<Producto> ListarProductoBussines()
        {
            return productoData.ListarProducto();
        }

        public  ProductoDTO ObtenerProductoBussines(int id)
        {
            return productoData.ObtenerProducto(id);
        }

        public  bool CrearProductoBussines(ProductoDTO producto)
        {
            return productoData.CrearProducto(producto);

        }

        public  bool ModificarProductoBussines(ProductoDTO producto)
        {
            return productoData.ModificarProductoPorId(producto);
        }

        public  bool EliminarProductoBussines(int id)
        {
            return productoData.EliminarProducto(id);
        }
    }
}
