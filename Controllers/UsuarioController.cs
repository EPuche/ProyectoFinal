using Microsoft.AspNetCore.Mvc;
using SistemaGestion.DTOs;
using SistemaGestion.SistemaGestionData;
using SistemaGestion.SistemaGestionEntities;
using System.Net;

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

        [HttpGet("{userName}")]

        public ActionResult<UsuarioDTO> TraerUsuario(string userName)
        {
            if(string.IsNullOrEmpty(userName)) 
            { 
                return base.BadRequest(new {message="El nombre de usuario no puede ser una cada de caracteres vacios", 
                    status=HttpStatusCode.BadRequest});
            }
            try
            {
                UsuarioDTO usuarioDTO = this.usuarioData.ObtenerUsuario(userName);
                return usuarioDTO;
            }
            catch
            {
                return base.Conflict(new {message="No se pudo obtener el usuario.", status=HttpStatusCode.Conflict});
            }
        }

        [HttpGet("{userName}/{password}")]

        public ActionResult<UsuarioDTO> InicioSesion(string userName, string password) 
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                return base.BadRequest(new
                {
                    message = "El nombre de usuario o el password no puede ser una cada de caracteres vacios",
                    status = HttpStatusCode.BadRequest
                });
            }
            try
            {
                UsuarioDTO usuarioDTO = this.usuarioData.ObtenerUsuarioPorPassword(userName, password);
                return usuarioDTO;
            }
            catch
            {
                return base.Unauthorized(new {message="No se pudo obtener un usuario con los datos dados", 
                    StatusCode=HttpStatusCode.Unauthorized});
            }
            
        }

        [HttpPost]
        public IActionResult CrearUsuario([FromBody] UsuarioDTO usuario)
        {

            try
            {
                this.usuarioData.CrearUsuario(usuario);
                IActionResult result = base.Ok(new
                {
                    mensage = "Producto creado con exito",
                    productoNuevo = usuario,
                    status = HttpStatusCode.Created
                });
                return result;

            }
            catch (Exception ex)
            {
                return base.Conflict(new { mensage = ex.Message, StatusCode = HttpStatusCode.Conflict });
            }
        }

        [HttpPut("{id}")]
        
        public IActionResult ModificarUsuario([FromBody] UsuarioDTO usuariodto, int id) 
        {
            if (id>0) 
            {
                if(this.usuarioData.ModificarUsuario(usuariodto, id))
                {
                    return base.Ok(new {message = "Usuario actualizado",status=200});
                }
                else
                    return base.Conflict(new { message = "No se pudo actualizar el usuario"});
            }

            return base.BadRequest(new { message = "El id no puede ser negativo", status=400 });
        }

        [HttpDelete("{id}")]

        public IActionResult BorrarUsuario(int id)
        {
            try
            {
                this.usuarioData.EliminarUsuario(id);
                IActionResult result = base.Ok(new
                {
                    mensage = "Usuario eliminado con exito",
                    status = HttpStatusCode.NoContent
                });
                return result;
            }
            catch (Exception ex)
            {
                return base.Conflict(new { mensage = ex.Message, status = HttpStatusCode.Conflict });
            }
        }
    }
}
