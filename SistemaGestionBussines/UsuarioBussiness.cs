using Entregable2.service;
using WepApiProyectoFinal.models;
using WepApiProyectoFinal.service;

namespace SistemaGestion.SistemaGestionBussines
{
    public class UsuarioBussiness
    {
        public static List<Usuario> ListarUsuarioBussines()
        {
            return UsuarioData.ListarUsuarios();
        }

        public static Usuario ObtenerUsuarioBussines(int id)
        {
            return UsuarioData.ObtenerUsuario(id);
        }

        public static bool CrearUsuarioBussines(Usuario usuario)
        {
            return UsuarioData.CrearUsuario(usuario);

        }

        public static bool ModificarUsuarioBussines(Usuario usuario, int id)
        {
            return UsuarioData.ModificarUsuario(usuario, id);
        }

        public static bool EliminarUsuarioBussines(int id)
        {
            return UsuarioData.EliminarUsuario(id);
        }
    }
}
