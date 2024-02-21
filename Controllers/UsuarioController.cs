using Microsoft.AspNetCore.Mvc;
using SistemaGestion.DTOs;
using SistemaGestion.SistemaGestionData;
using SistemaGestion.SistemaGestionEntities;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private UsuarioData usuarioData;

        public UsuarioController(UsuarioData usuarioData)
        {
            this.usuarioData = usuarioData;
        }

        [HttpGet]
        public List<Usuario> ListarUsuario()
        {
            return this.usuarioData.ListarUsuarios();
        }

        
        [HttpPut("{id}")]
        
        public IActionResult ModificarUsuario(UsuarioDTO usuariodto, int id) 
        {
            if (id>0) 
            {
                if(this.usuarioData.ModificarUsuario(usuariodto, id))
                {
                    return base.Ok(new {message = "Usuario actualizado",status=200});
                }
                return base.Conflict(new { message = "No se pudo actualizar el usuario"});
            }

            return base.BadRequest(new { message = "El id no puede ser negativo", status=400 });
        }
    }
}
