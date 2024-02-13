using Entregable2.service;
using WepApiProyectoFinal.models;
using WepApiProyectoFinal.service;

namespace SistemaGestion.SistemaGestionBussines
{
    public class VentaBussiness
    {
        public static List<Venta> ListarVentaBussines()
        {
            return VentaData.ListarVentas();
        }

        public static Venta ObtenerVentaBussines(int id)
        {
            return VentaData.ObtenerVenta(id);
        }

        public static bool CrearVentaBussines(Venta venta)
        {
            return VentaData.CrearVenta(venta);

        }

        public static bool ModificarVentaBussines(Venta venta, int id)
        {
            return VentaData.ModificarVenta(venta, id);
        }

        public static bool EliminarVentaBussines(int id)
        {
            return VentaData.EliminarVenta(id);
        }
    }
}
