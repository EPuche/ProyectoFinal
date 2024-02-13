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
    public static class ProductoVendidoData
    {
        public static List<ProductoVendido> ListarProductoVendido()
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {

                List<ProductoVendido> productosVendidos = context.ProductoVendidos.ToList();

                return productosVendidos;

            }
        }

        public static ProductoVendido ObtenerProductoVendido(int id)
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {

                ProductoVendido? productoVendidoBuscado = context.ProductoVendidos.Where(p => p.Id == id).FirstOrDefault();
                return productoVendidoBuscado;
            }
        }

        public static bool CrearProductoVendido(ProductoVendido productoVendido)
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {
                context.ProductoVendidos.Add(productoVendido);
                context.SaveChanges();
                return true;
            }


        }

        public static bool ModificarProducto(ProductoVendido productoVendido, int id)
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {
                ProductoVendido? usuarioProductoVend = ObtenerProductoVendido(id);

                usuarioProductoVend.Stock = productoVendido.Stock;

                context.ProductoVendidos.Update(usuarioProductoVend);

                context.SaveChanges();

                return true;
            }
        }

        public static bool EliminarProductoVendido(int id)
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {
                ProductoVendido productoVendAEliminar = context.ProductoVendidos.Where(p => p.Id == id).FirstOrDefault();

                if (productoVendAEliminar is not null)
                {
                    context.ProductoVendidos.Remove(productoVendAEliminar);
                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }
    }
}
