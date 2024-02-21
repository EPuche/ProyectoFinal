using SistemaGestion.DTOs;
using SistemaGestion.SistemaGestionData;
using SistemaGestion.SistemaGestionEntities;

namespace SistemaGestion.Mapper
{
    public class VentaMapper
    {
        public static Venta MapearAProducto(VentaDTO dto)
        {
            Venta venta = new Venta();
            venta.Id = dto.Id;
            venta.Comments = dto.Comments;
            venta.UserId = dto.UserId;

            return venta;
        }

        public static VentaDTO MapearADTO(Venta venta)
        {
            VentaDTO dto = new VentaDTO();

            dto.Id = venta.Id;
            dto.Comments = venta.Comments;
            dto.UserId = venta.UserId;

            return dto;

        }
    }
}
