using Microsoft.AspNetCore.Mvc;
using SistemaGestion.SistemaGestionData;
using SistemaGestion.SistemaGestionEntities;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoVendidoController : Controller
    {
        private ProductoVendidoData productoVendidoData;

        public ProductoVendidoController(ProductoVendidoData productoVendidoData)
        {
            this.productoVendidoData = productoVendidoData;
        }

        [HttpGet("{userID}")]
        public ActionResult<List<ProductoVendido>> TraerProductosVendidos(int userId)
        {
            return productoVendidoData.ObtenerProductosVendidosPorIdUsuario(userId);
        }

        
    }
}
