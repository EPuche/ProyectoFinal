using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestion.database;
using SistemaGestion.SistemaGestionEntities;
using SistemaGestion.DTOs;
using SistemaGestion.Mapper;

namespace SistemaGestion.SistemaGestionData
{
    public  class ProductoVendidoData
    {
        private SistemaGestionContext context;
        public ProductoVendidoData(SistemaGestionContext coderContext)
        {
            this.context = coderContext;

        }

        public List<ProductoVendido> ObtenerProductosVendidosPorIdUsuario(int userId)
        {
            List<Producto> productos = this.ListarProducto();


            List<Producto> productosFiltrados = productos.Where(q=> q.UserId == userId).ToList();


            List<ProductoVendido> resultadoFinal = new List<ProductoVendido>();
            List<ProductoVendido> productosVendidos = this.context.ProductoVendidos.ToList();
            foreach (Producto p in productosFiltrados)
            {
                int id = p.Id;
                ProductoVendido? pVendido = productosVendidos.Find(p => p.ProductId == id);

                if (pVendido is not null)
                {
                    resultadoFinal.Add(pVendido);
                }
            }
            
            return resultadoFinal;
        }

        public List<Producto> ListarProducto()
        {


            return this.context.Productos.ToList<Producto>();

        }

        public  ProductoVendido ObtenerProductoVendido(int id)
        {
         
                ProductoVendido? productoVendidoBuscado = context.ProductoVendidos.Where(p => p.Id == id).FirstOrDefault();
                return productoVendidoBuscado;

        }

        public  void CrearProductoVendido(ProductoVendidoDTO productoVendidoDTO)
        {
            ProductoVendido productoVendido = ProductoVendidoMapper.MapearAProducto(productoVendidoDTO);    

            context.ProductoVendidos.Add(productoVendido);
            context.SaveChanges();

        }

        public  bool ModificarProducto(ProductoVendido productoVendido, int id)
        {
            
                ProductoVendido? usuarioProductoVend = ObtenerProductoVendido(id);

                usuarioProductoVend.Stock = productoVendido.Stock;

                context.ProductoVendidos.Update(usuarioProductoVend);

                context.SaveChanges();

                return true;

        }

        public  bool EliminarProductoVendido(int id)
        {

                ProductoVendido productoVendAEliminar = context.ProductoVendidos.Where(p => p.Id == id).FirstOrDefault();

                if (productoVendAEliminar is not null)
                {
                    context.ProductoVendidos.Remove(productoVendAEliminar);
                    context.SaveChanges();
                    return true;
                }


            return false;
        }
    }
}
