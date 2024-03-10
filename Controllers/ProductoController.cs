using Microsoft.AspNetCore.Mvc;
using SistemaGestion.DTOs;
using SistemaGestion.SistemaGestionData;
using SistemaGestion.SistemaGestionEntities;
using System.Net;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private ProductoData productoData;

        public ProductoController(ProductoData productoData)
        {
            this.productoData = productoData;
        }

        
        [HttpPost]
        public IActionResult AgregarUnNuevoProducto([FromBody] ProductoDTO producto)
        {

            try
            {
                this.productoData.CrearProducto(producto);
                IActionResult result = base.Ok(new
                {
                    mensage = "Producto creado con exito",
                    productoNuevo = producto,
                    status = HttpStatusCode.Created
                }); 
                return result;

            }
            catch (Exception ex) 
            {
                return base.Conflict(new { mensage = ex.Message, StatusCode = HttpStatusCode.Conflict });
            }
        }

        [HttpPut]

        public IActionResult ModificarProducto([FromBody] ProductoDTO productoDTO)
        {
            try
            {
                this.productoData.ActualizarProducto(productoDTO);
                IActionResult result = base.Accepted(new
                {
                    mensage="Producto actualizado con exito",
                    nuevoProducto=productoDTO,
                    status = HttpStatusCode.Accepted
                });
                return result;
            }
            catch (Exception ex) 
            {
                return base.Conflict(new { mensage = ex.Message, StatusCode = HttpStatusCode.Conflict });
            }
        }

        [HttpDelete("{idProducto}")]
        public IActionResult BorrarProducto(int idProducto)
        {
            if (idProducto < 0)
            {
                return base.BadRequest(new { status = HttpStatusCode.BadRequest, mensaje = "El id no puede ser negativo" });
                 
            }

            try
            {
                this.productoData.EliminarProducto(idProducto);
                IActionResult result = base.Ok(new
                {
                    mensage = "Producto borrado con exito",
                    status = HttpStatusCode.Accepted
                });
                return result;
            }
            catch (Exception ex)
            {
                return base.Conflict(new { status = HttpStatusCode.Conflict, mensaje = ex.Message });
            }
        }

        [HttpGet("{idusuario}")]
        public List<Producto> TraerProductos(int idusuario)
        {
            return this.productoData.ListarProductoPorIdUsuario(idusuario);
        }

    }
}
