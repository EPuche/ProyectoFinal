using Microsoft.AspNetCore.Mvc;
using SistemaGestion.DTOs;
using SistemaGestion.SistemaGestionData;
using SistemaGestion.SistemaGestionEntities;

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

        [HttpGet]
        public ActionResult <List<Producto>> ObtenerTodosLosProductos()
        {
            return productoData.ListarProducto();
        }

        [HttpPost]
        public IActionResult AgregarUnNuevoProducto([FromBody] ProductoDTO producto)
        {

            if (this.productoData.CrearProducto(producto))
            {

                return base.Ok(new { mensaje = "Producto agregado", producto });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se pudo agregar el producto" });
            }
        }

        [HttpPut("{id}")]

        public IActionResult ModificarProducto(ProductoDTO productoDTO, int id)
        {
            if (id > 0)
            {
                if (this.productoData.ModificarProductoPorId(productoDTO, id))
                {
                    return base.Ok(new { message = "Producto actualizado", status = 200 });
                }
                return base.Conflict(new { message = "No se pudo actualizar el usuario" });
            }

            return base.BadRequest(new { message = "El id no puede ser negativo", status = 400 });
        }

        [HttpDelete("{id}")]
        public IActionResult BorrarProducto(int id)
        {
            if (id > 0)
            {
                if (this.productoData.EliminarProducto(id))
                {
                    return base.Ok(new { mensaje = "Producto borrado", status = 200 });
                }

                return base.Conflict(new { mensaje = "No se pudo borrar el producto" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }
    }
}
