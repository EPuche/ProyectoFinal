using SistemaGestion.DTOs;
using SistemaGestion.SistemaGestionEntities;
using SistemaGestion.SistemaGestionData;

namespace SistemaGestion.Mapper
{
    public class ProductoVendidoMapper
    {
        public static ProductoVendido MapearAProducto(ProductoVendidoDTO dto)
        {
            ProductoVendido producto = new ProductoVendido();
            producto.Id = dto.Id;
            producto.ProductId = dto.ProductId;
            producto.Stock = dto.Stock;
            producto.SaleId = dto.SaleId;

            return producto;
        }

        public static ProductoVendidoDTO MapearADTO(ProductoVendido producto)
        {
            ProductoVendidoDTO dto = new ProductoVendidoDTO();

            dto.Id = producto.Id;
            dto.ProductId = producto.ProductId;
            dto.Stock = producto.Stock;
            dto.SaleId = producto.SaleId;

            return dto;

        }

    }
}
