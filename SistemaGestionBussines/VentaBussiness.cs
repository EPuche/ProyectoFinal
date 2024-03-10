using SistemaGestion.SistemaGestionEntities;
using SistemaGestion.SistemaGestionData;
using SistemaGestion.DTOs;

namespace SistemaGestion.SistemaGestionBussines
{
    public class VentaBussiness
    {
        private VentaData ventaData;

        public VentaBussiness(VentaData ventaData)
        {
            this.ventaData = ventaData;
        }
        public  List<Venta> ListarVentaBussines()
        {
            return ventaData.ListarVentas();
        }

        public  Venta ObtenerVentaBussines(int id)
        {
            return ventaData.ObtenerVenta(id);
        }

        public  bool CrearVentaBussines(int idusuario, List<ProductoDTO> productos)
        {
            return ventaData.CrearVenta(idusuario,productos);

        }

        public bool ModificarVentaBussines(Venta venta, int id)
        {
            return ventaData.ModificarVenta(venta, id);
        }

        public  bool EliminarVentaBussines(int id, List<ProductoDTO> productos)
        {
            return ventaData.EliminarVenta(id, productos);
        }
    }
}
