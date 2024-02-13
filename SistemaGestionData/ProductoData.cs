using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WepApiProyectoFinal.database;
using WepApiProyectoFinal.models;

namespace WepApiProyectoFinal.service
{
    public static class ProductoData
    {
        public static List<Producto> ListarProducto()
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {

                List<Producto> productos = context.Productos.ToList();

                return productos;

            }
        }

        public static Producto ObtenerProducto(int id)
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {

                Producto? productoBuscado = context.Productos.Where(p => p.Id == id).FirstOrDefault();
                return productoBuscado;
            }
        }

        public static bool CrearProducto(Producto producto)
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {
                context.Productos.Add(producto);
                context.SaveChanges();
                return true;
            }


        }

        public static bool ModificarProducto(Producto producto, int id)
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {
                Producto? usuarioProducto = ObtenerProducto(id);

                usuarioProducto.Description = producto.Description;
                usuarioProducto.Cost = producto.Cost;
                usuarioProducto.SalePrice = producto.SalePrice;
                usuarioProducto.Stock = producto.Stock;

                context.Productos.Update(usuarioProducto);

                context.SaveChanges();

                return true;
            }
        }

        public static bool EliminarProducto(int id)
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {
                Producto productoAEliminar = context.Productos.Include(p => p.ProductoVendidos).Where(p => p.Id == id).FirstOrDefault();

                if (productoAEliminar is not null)
                {
                    context.Productos.Remove(productoAEliminar);
                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }
    }
}
