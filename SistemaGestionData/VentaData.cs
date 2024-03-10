using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestion.SistemaGestionEntities;
using SistemaGestion.database;
using SistemaGestion.DTOs;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SistemaGestion.Mapper;

namespace SistemaGestion.SistemaGestionData
{
    
    public  class VentaData
    {
        private SistemaGestionContext context;
        public VentaData(SistemaGestionContext coderContext)
        {
            this.context = coderContext;

        }

        public  List<Venta> ListarVentas()
        {
            
                List<Venta> ventas = this.context.Venta.ToList();

                return ventas;
        }

        public  Venta ObtenerVenta(int id)
        {
            
            List<Venta> ventas = this.ListarVentas();

            foreach (Venta item in ventas)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public  bool CrearVenta(int idusuario, List<ProductoDTO> productos)
        {
            Venta venta = new Venta();

            List<string> nombreProduct = productos.Select(p => p.Description).ToList();
            string comentario = string.Join("-", nombreProduct);
            venta.UserId = idusuario;
            venta.Comments = comentario;

            EntityEntry<Venta>?  result = this.context.Venta.Add(venta);
            result.State = Microsoft.EntityFrameworkCore.EntityState.Added;
            this.context.SaveChanges();

            this.MarcarVendidos(productos, venta.Id);

            this.ActualizarStock(productos, 0);

            return true;

        }

        private void MarcarVendidos(List<ProductoDTO> productos, int ventaid)
        {
            productos.ForEach(p =>
            {
                ProductoVendidoDTO productoVendidoDTO = new ProductoVendidoDTO();
                productoVendidoDTO.ProductId = p.Id;
                productoVendidoDTO.SaleId = ventaid;
                productoVendidoDTO.Stock = p.Stock;

                ProductoVendido productoVendido = ProductoVendidoMapper.MapearAProducto(productoVendidoDTO);

                context.ProductoVendidos.Add(productoVendido);
                context.SaveChanges();
            });
        }
        private void ActualizarStock(List<ProductoDTO> productos, int op) //op es 0 si es agregar venta o 1 si es eliminar venta
        {
            if (op == 0)
            {
                productos.ForEach(p =>
                {
                    Producto? productoBuscado = this.context.Productos.Where(pr => pr.Id == p.Id).FirstOrDefault();
                    ProductoDTO productoAct = ProductoMapper.MapearADTO(productoBuscado);
                    productoAct.Stock -= p.Stock;

                    Producto? producto = this.context.Productos.Where(pre => pre.Id == productoAct.Id).FirstOrDefault();
                    if (productoAct is not null)
                    {
                        producto.Description = productoAct.Description;
                        producto.Cost = productoAct.Cost;
                        producto.SalePrice = productoAct.SalePrice;
                        producto.Stock = productoAct.Stock;

                        this.context.Productos.Update(productoBuscado);

                        this.context.SaveChanges();
                    }
                });
            }
            else
            {
                productos.ForEach(p =>
                {
                    Producto? productoBuscado = this.context.Productos.Where(pr => pr.Id == p.Id).FirstOrDefault();
                    ProductoDTO productoAct = ProductoMapper.MapearADTO(productoBuscado);
                    productoAct.Stock += p.Stock;

                    Producto? producto = this.context.Productos.Where(pre => pre.Id == productoAct.Id).FirstOrDefault();
                    if (productoAct is not null)
                    {
                        producto.Description = productoAct.Description;
                        producto.Cost = productoAct.Cost;
                        producto.SalePrice = productoAct.SalePrice;
                        producto.Stock = productoAct.Stock;

                        this.context.Productos.Update(productoBuscado);

                        this.context.SaveChanges();
                    }
                });
            }
        }

        private void DesmarcarVendido(int ventaId) 
        {
            ProductoVendido productoVendAEliminar = context.ProductoVendidos.Where(p => p.SaleId == ventaId).FirstOrDefault();

            if (productoVendAEliminar is not null)
            {
                context.ProductoVendidos.Remove(productoVendAEliminar);
                context.SaveChanges();
            }
        }

        public  bool ModificarVenta(Venta venta, int id)
        {
            
           Venta? ventaBuscada = ObtenerVenta(id);

            if (ventaBuscada is not null) 
            { 
                ventaBuscada.UserId = venta.UserId;
                ventaBuscada.Comments = venta.Comments;

                context.Venta.Update(ventaBuscada);

                context.SaveChanges();

                return true;
            }
            return false;

        }

        public  bool EliminarVenta(int id, List<ProductoDTO> productos)
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

            this.DesmarcarVendido(id);
            this.ActualizarStock(productos, 1);

            return false;
        }

    }
}
