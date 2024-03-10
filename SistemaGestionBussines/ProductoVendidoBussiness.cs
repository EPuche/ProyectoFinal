using SistemaGestion.SistemaGestionEntities;
using SistemaGestion.SistemaGestionData;
using SistemaGestion.DTOs;

namespace SistemaGestion.SistemaGestionBussines
{
    public class ProductoVendidoBussiness
    {
        private ProductoVendidoData productoVendidoData;

        public ProductoVendidoBussiness(ProductoVendidoData productoVendidoData)
        {
            this.productoVendidoData = productoVendidoData;
        }
        public  List<ProductoVendido> ListarProductoVendidoBussines(int userID)
        {
            return productoVendidoData.ObtenerProductosVendidosPorIdUsuario(userID);
        }

        public  ProductoVendido ObtenerProductoBussines(int id)
        {
            return productoVendidoData.ObtenerProductoVendido(id);
        }

        public  void CrearProductoBussines(ProductoVendidoDTO producto)
        {
            productoVendidoData.CrearProductoVendido(producto);

        }

        public bool ModificarProductoBussines(ProductoVendido producto, int id)
        {
            return productoVendidoData.ModificarProducto(producto, id);
        }

        public bool EliminarProductoBussines(int id)
        {
            return productoVendidoData.EliminarProductoVendido(id);
        }
    }
}
