using Microsoft.AspNetCore.Mvc;
using SistemaGestion.DTOs;
using SistemaGestion.SistemaGestionData;
using System.Net;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private VentaData ventaData;

        public VentaController(VentaData ventaData)
        {
            this.ventaData = ventaData;
        }

        [HttpPost ("{idusuario}")]
        public IActionResult CrearVenta(int idusuario, [FromBody] List<ProductoDTO> productos)
        {
            if (productos.Count == 0) 
            {
                return base.BadRequest(new { mensaje = "No se recibieron los productos", status = HttpStatusCode.BadRequest });
            }
            try
            {
                this.ventaData.CrearVenta (idusuario, productos);
                IActionResult result = base.Created(nameof(CrearVenta), new
                {
                    mensage = "Venta realizada con exito",
                    status = HttpStatusCode.Created,
                    nuevaVenta = productos.Count
                });
                return result;
            }
            catch (Exception ex) 
            {
                return base.Conflict(new { mensaje = ex.Message, status = HttpStatusCode.Conflict });
            }
        }

    }
}
