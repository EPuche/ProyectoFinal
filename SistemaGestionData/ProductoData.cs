using Microsoft.EntityFrameworkCore;
using SistemaGestion.DTOs;
using SistemaGestion.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestion.database;
using SistemaGestion.SistemaGestionEntities;

namespace SistemaGestion.SistemaGestionData
{
    public  class ProductoData
    {
        private SistemaGestionContext context;
        public ProductoData(SistemaGestionContext coderContext)
        {
            this.context = coderContext;

        }
        public  List<Producto> ListarProducto()
        {


                List<Producto> productos = this.context.Productos.ToList();

                return productos;

        }

        public  ProductoDTO ObtenerProducto(int id)
        {
            
            Producto? productoBuscado = this.context.Productos.Where(p => p.Id == id).FirstOrDefault();
            ProductoDTO producto = ProductoMapper.MapearADTO(productoBuscado);
            return producto;
        }

        public bool CrearProducto(ProductoDTO producto)
        {
            Producto p = ProductoMapper.MapearAProducto(producto);    

            this.context.Productos.Add(p);
            this.context.SaveChanges();
            return true;
            
        }

        public  bool ModificarProductoPorId(ProductoDTO producto, int id)
        {

            Producto? productoBuscado = this.context.Productos.Where(p => p.Id == id).FirstOrDefault();

            if (productoBuscado is not null) 
            {
                productoBuscado.Description = producto.Description;
                productoBuscado.Cost = producto.Cost;
                productoBuscado.SalePrice = producto.SalePrice;
                productoBuscado.Stock = producto.Stock;

                this.context.Productos.Update(productoBuscado);

                this.context.SaveChanges();

                return true;
            }
            return false;
        }

        
        public bool ActualizarProducto(ProductoDTO productoAct)
        {
            Producto? productoBuscado = this.context.Productos.Where(p => p.Id == productoAct.Id).FirstOrDefault();
            if (productoAct is not null)
            {
                productoBuscado.Description = productoAct.Description;
                productoBuscado.Cost = productoAct.Cost;
                productoBuscado.SalePrice = productoAct.SalePrice;
                productoBuscado.Stock = productoAct.Stock;

                this.context.Productos.Update(productoBuscado);

                this.context.SaveChanges();

                return true;
            }
            return false;
        }

        public  bool EliminarProducto(int id)
        {
            
                Producto productoAEliminar = context.Productos.Include(p => p.ProductoVendidos).Where(p => p.Id == id).FirstOrDefault();

                if (productoAEliminar is not null)
                {
                    this.context.Productos.Remove(productoAEliminar);
                    this.context.SaveChanges();
                    return true;
                }
            

            return false;
        }
    }
}
