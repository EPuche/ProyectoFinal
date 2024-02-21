using Microsoft.AspNetCore.Mvc;
using SistemaGestion.SistemaGestionData;

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
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
