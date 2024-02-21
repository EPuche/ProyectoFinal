using SistemaGestion.DTOs;
using SistemaGestion.SistemaGestionData;
using SistemaGestion.SistemaGestionEntities;

namespace SistemaGestion.Mapper
{
    public class ProductoMapper
    {
        public static Producto MapearAProducto(ProductoDTO dto)
        {
            Producto producto = new Producto();
            producto.Description = dto.Description;
            producto.Id = dto.Id;
            producto.SalePrice = dto.SalePrice;
            producto.Stock = dto.Stock;
            producto.Cost = dto.Cost;
            producto.UserId = dto.UserId;

            return producto;
        }

        public static ProductoDTO MapearADTO(Producto producto)
        {
            ProductoDTO dto = new ProductoDTO();

            dto.Description = producto.Description;
            dto.Id = producto.Id;
            dto.SalePrice = producto.SalePrice;
            dto.Stock = producto.Stock;
            dto.Cost = producto.Cost;
            dto.UserId = producto.UserId;

            return dto;

        }
    }
}
