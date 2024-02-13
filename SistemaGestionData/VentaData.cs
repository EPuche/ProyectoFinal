using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WepApiProyectoFinal.database;
using WepApiProyectoFinal.models;

namespace Entregable2.service
{
    public static class VentaData
    {
        public static List<Venta> ListarVentas()
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {

                List<Venta> ventas = context.Venta.ToList();

                return ventas;

            }
        }

        public static Venta ObtenerVenta(int id)
        {
            List<Venta> ventas = VentaData.ListarVentas();

            foreach (Venta item in ventas)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static bool CrearVenta(Venta venta)
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {
                context.Venta.Add(venta);
                context.SaveChanges();
                return true;
            }


        }

        public static bool ModificarVenta(Venta venta, int id)
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {
                Venta? ventaBuscada = ObtenerVenta(id);


                ventaBuscada.UserId = venta.UserId;
                ventaBuscada.Comments = venta.Comments;

                context.Venta.Update(ventaBuscada);

                context.SaveChanges();

                return true;
            }
        }

        public static bool EliminarVenta(int id)
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {
                Venta ventaAEliminar = context.Venta.Include(v => v.ProductoVendidos)
                    .Where(v => v.Id == id)
                    .FirstOrDefault();

                if (ventaAEliminar is not null)
                {
                    context.Venta.Remove(ventaAEliminar);
                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }

    }
}
